using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Coches00.Models
{
    class FileHelper
    {
        static readonly SQLiteAsyncConnection _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        static FileHelper()
        {
            _connection.CreateTableAsync<File>();
        }

        public static Task<List<File>> GetItemsAsync()
        {
            return _connection.Table<File>().ToListAsync();
        }

        public static Task<int> SaveItemAsync(File item)
        {
            if (item.Id != 0)
            {
                return _connection.UpdateAsync(item);
            }
            else
            {
                return _connection.InsertAsync(item);
            }
        }

        public static Task<int> DeleteItemAsync(File item)
        {
            return _connection.DeleteAsync(item);
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }

        public static Task<List<File>> GetFiles(Car car)
        {
            var query = _connection.Table<File>().Where(v => v.CarId.Equals(car.Id));

            return query.ToListAsync();
        }
    }
}
