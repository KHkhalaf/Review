using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Review.Controls;
using Review.iOS;
using SQLite;
using Xamarin.Forms;
using UIKit;
using System.IO;

[assembly: Dependency(typeof(SqlLiteIOS))]
namespace Review.iOS
{
    class SqlLiteIOS : Isqlite
    {
        public SqlLiteIOS()
        {
        }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var dbpath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dbpath, "PostsDatabase.db3");
            var connection = new SQLiteConnection(path);
            return connection;

        }

        #endregion
    }
}