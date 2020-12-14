using SQLite;

namespace PasswordSaver.Database
{
    static class DBContext
    {
        public static SQLiteConnection GetConnection()
        {
            SQLiteAndroid sqlAndroid = new SQLiteAndroid();
            return new SQLiteConnection(sqlAndroid.GetDatabasePath("PasswordSaver"));
        }
    }
}
