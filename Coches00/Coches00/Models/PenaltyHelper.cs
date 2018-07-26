using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Coches00.Models
{
    class PenaltyHelper
    {
        static readonly SQLiteAsyncConnection _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        static PenaltyHelper()
        {
            _connection.CreateTableAsync<Penalty>();
        }

        public static Task<List<Penalty>> GetItemsAsync()
        {
            return _connection.Table<Penalty>().ToListAsync();
        }

        public static Task<int> SaveItemAsync(Penalty item)
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

        public static Task<int> DeleteItemAsync(Penalty item)
        {
            return _connection.DeleteAsync(item);
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }

        public static Task<List<Penalty>> GetPenalties(Car car)
        {
            var query = _connection.Table<Penalty>().Where(v => v.CarId.Equals(car.Id));

            return query.ToListAsync();
        }
    }
}
