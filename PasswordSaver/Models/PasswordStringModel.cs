using PasswordSaver.Database;
using SQLite;

namespace PasswordSaver.Models
{
    public class PasswordStringModel
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string PasswordValue { set; get; }

        public PasswordStringModel()
        {
            Name = "";
            PasswordValue = "";
        }
    }
}
