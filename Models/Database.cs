using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Maths_Quiz_New.Models
{
    public class Database
    {
        string path;

        SQLiteConnection conn;

        public Database()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyDatabase.sqlite");

            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            // Create a table
            conn.CreateTable<User>();
        }

        public int Register(User user)
        {
            return conn.Insert(new User()
            {
                UserName = user.UserName,
                Password = user.Password
            });
        }

        public bool Login(string user, string password)
        {
            var query = conn.Table<User>().
                Where(t => t.UserName == user && t.Password == password);

            if (query.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
