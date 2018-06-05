using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Coches00.Models
{
    class CarHelper
    {
        static readonly SQLiteAsyncConnection _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        static CarHelper()
        {
            _connection.CreateTableAsync<Car>();
        }

        public static Task<List<Car>> GetItemsAsync()
        {
            return _connection.Table<Car>().ToListAsync();
        }

        public static Task<int> SaveItemAsync(Car item)
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

        public static Task<int> DeleteItemAsync(Car item)
        {
            return _connection.DeleteAsync(item);
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }

        public static Task<List<Car>> GetCars(User user)
        {
            var query = _connection.Table<Car>().Where(v => v.UserId.Equals(user.Id));

            return query.ToListAsync();
        }
    }
}
