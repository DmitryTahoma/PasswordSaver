using SQLite;

namespace PasswordSaver.Models
{
    public delegate void FieldChangedHandler(PasswordStringModel sender);
    public class PasswordStringModel
    {
        public FieldChangedHandler FieldChanged;
        private string name;
        private string passwordValue;

        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                if(Id != 0)
                    FieldChanged?.Invoke(this);
            }
        }

        public string PasswordValue 
        {
            get => passwordValue;
            set 
            {
                passwordValue = value;
                if (Id != 0)
                    FieldChanged?.Invoke(this);
            }
        }

        public PasswordStringModel()
        {
            Name = "";
            PasswordValue = "";
        }
    }
}
