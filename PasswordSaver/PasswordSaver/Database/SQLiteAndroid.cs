using System;
using System.IO;

namespace PasswordSaver.Database
{
    public class SQLiteAndroid : ISQLite
    {
        public string GetDatabasePath(string filename)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(docPath, filename);
            return path;
        }
    }
}