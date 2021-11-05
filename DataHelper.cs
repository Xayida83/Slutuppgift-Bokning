using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ElephantBooking
{
    /// <summary>
    /// Hanterar lagring, uppdatering och hämtning av data samt sparar data i filformat.
    /// </summary>
    public static class DataHelper
    {
        public static List<Booking> Bookings;
        public static List<Elephant> Elephants;
        public static List<User> Users;
        private static string FilePath = AppDomain.CurrentDomain.BaseDirectory + "BookingData.json";

        #region File management

        public static void LoadInDataOrSeed()
        {
            if (!File.Exists(FilePath))
            {
                CreateFile();
                ReadFile();
            }
            else
            {
                ReadFile();
            }
        }

        public static void SaveCurrentFile()
        {
            LogOutAllUsers();
            UpdateFile();
        }

        //https://www.csharp-console-examples.com/csharp-console/create-a-text-file-in-c/
        private static void CreateFile()
        {
            using (FileStream fileStream = File.Create(FilePath))
            {
                var json = JsonConvert.SerializeObject(new Document { Bookings = BookingSeed(), Elephants = ElephantSeed(), Users = UserSeed() });
                Byte[] value = new UTF8Encoding(true).GetBytes(json);
                fileStream.Write(value, 0, value.Length);
            }
        }

        private static void ReadFile()
        {
            Document result = null;
            using (StreamReader streamReader = File.OpenText(FilePath))
            {
                string json = string.Empty;
                string value = string.Empty;
                while ((value = streamReader.ReadLine()) != null)
                {
                    json += value;
                }
                result = JsonConvert.DeserializeObject<Document>(json);
            }
            Elephants = new List<Elephant>(result.Elephants);
            Bookings = new List<Booking>(result.Bookings);
            Users = new List<User>(result.Users);
        }

        private static void DeleteFile()
        {
            File.Delete(FilePath);
        }

        private static void UpdateFile()
        {
            DeleteFile();
            using (FileStream fileStream = File.Create(FilePath))
            {
                var json = JsonConvert.SerializeObject(new Document { Bookings = Bookings, Elephants = Elephants, Users = Users });
                Byte[] value = new UTF8Encoding(true).GetBytes(json);
                fileStream.Write(value, 0, value.Length);
            }
        }

        #endregion File management

        #region Seeds

        private static List<Booking> BookingSeed()
        {
            return new List<Booking>
            {
            new Booking{BookedElephant = new Elephant("Sofia",37,false), UsernameForBooking = "Britt"}
            };
        }

        private static List<Elephant> ElephantSeed()
        {
            var list = new List<Elephant>
            {
            new Elephant(name: "Sandra", id: 31, vacant: true),
            new Elephant(name: "Anders", id: 32, vacant: true),
            new Elephant(name: "Sören", id: 33, vacant: true),
            new Elephant(name: "Ida", id: 34, vacant: true),
            new Elephant(name: "Krokus", id: 35, vacant: true),
            new Elephant(name: "Snoken", id: 36, vacant: true),
            new Elephant(name: "Sofia", id: 37, vacant: false),
            new Elephant(name: "Erik", id: 38, vacant: true)
            };
            list.Sort();
            return list;
        }

        private static List<User> UserSeed()
        {
            var list = new List<User>
            {
                new User(fullName: "Charlotta Lindberg", phonenumber: "0729921705", userName: "L8", password: "kodaÄrKul", isAdmin: true, isLoggedIn: false ),
                new User(fullName: "Jens Palmqvist", phonenumber: "0725547545", userName: "Högsta Hönset", password: "vabbaÄrJobbigt", isAdmin: true, isLoggedIn: false ),
                new User(fullName: "Britt Svensson", phonenumber: "0736695447", userName: "Britt", password: "Hund", isAdmin: false, isLoggedIn: false ),
                new User(fullName: "James Pitkanän", phonenumber: "0735546869", userName: "Wify", password: "Lottaärbäst", isAdmin: false, isLoggedIn: false),
            };
            list.Sort();
            return list;
        }

        #endregion Seeds

        #region User methods

        public static void AddUser(User model)
        {
            Users.Add(model);
            Users.Sort();
        }

        public static void UpdateUser(User model)
        {
            var result = Users.SingleOrDefault(x => x.UserName == model.UserName);
            Users.Remove(result);
            Users.Add(model);
            Users.Sort();
        }

        public static void LogOutAllUsers()
        {
            var loggedInUsers = Users.Where(x => x.IsLoggedIn).ToList();
            foreach (var user in loggedInUsers)
            {
                user.IsLoggedIn = false;
                UpdateUser(user);
            }
        }

        #endregion User methods

        #region Elephant methods

        public static void AddElephant(Elephant model)
        {
            Elephants.Add(model);
            Elephants.Sort();
        }

        public static void UpdateElephant(Elephant model)
        {
            var current = Elephants.SingleOrDefault(x => x.ID == model.ID);
            Elephants.Remove(current);
            Elephants.Add(model);
            Elephants.Sort();
        }

        public static void DeleteElephant(int id)
        {
            var current = Elephants.SingleOrDefault(x => x.ID == id);
            Elephants.Remove(current);
            Elephants.Sort();
        }

        #endregion Elephant methods

        #region Booking Methods

        public static void AddBooking(Booking model)
        {
            Bookings.Add(model);
            Bookings.Sort();
        }

        public static void DeleteBooking(Booking model)
        {
            Bookings.Remove(model);
            Bookings.Sort();
        }

        #endregion Booking Methods
    }

    internal class Document
    {
        public List<Booking> Bookings { get; set; }
        public List<Elephant> Elephants { get; set; }
        public List<User> Users { get; set; }
    }
}