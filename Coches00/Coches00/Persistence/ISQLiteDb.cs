using SQLite;

namespace Coches00
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
