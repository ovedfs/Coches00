using System;
using System.IO;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Coches00.SQLiteDb))]

namespace Coches00
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = ApplicationData.Current.LocalFolder.Path;
        	var path = Path.Combine(documentsPath, "Coches00.db3");
        	return new SQLiteAsyncConnection(path);
        }
    }
}
