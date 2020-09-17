using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Review.Controls;
using Review.Droid;
using Review.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Dependency(typeof(SqlLiteAndroid))]
namespace Review.Droid
{
    public class SqlLiteAndroid : Isqlite
    {
        public SqlLiteAndroid()
        {
        }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "PostsDatabase.db3");

            var connection = new SQLiteConnection(path);

            return connection;
        }

        #endregion
    }
}