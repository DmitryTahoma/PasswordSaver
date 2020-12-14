using PasswordSaver.Database;
using PasswordSaver.Models;
using PasswordSaver.ViewModels;
using PasswordSaver.Views;
using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PasswordSaver
{
    public partial class MainPage : ContentPage
    {
        private List<PasswordStringViewModel> PasswordStringVMs;

        public MainPage()
        {
            InitializeComponent();
            PasswordStringVMs = new List<PasswordStringViewModel>();

            using (SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.CreateTable<PasswordStringModel>(CreateFlags.AutoIncPK);

                TableQuery<PasswordStringModel> passwords = connection.Table<PasswordStringModel>();

                foreach (PasswordStringModel password in passwords)
                {
                    AddPasswordString(password);
                }
            }
        }

        private void AddPasswordStringClick(object sender, EventArgs e)
        {
            PasswordStringModel model = AddPasswordString(new PasswordStringModel());

            using (SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.Insert(model);
            }
        }

        private void RemovePasswordString(PasswordStringModel model)
        {
            foreach(View it in PasswordStack.Children)
            {
                if(it is PasswordString ps)
                {
                    if(ps.BindingContext is PasswordStringViewModel vm)
                    {
                        if(vm.Model.Id == model.Id)
                        {
                            PasswordStack.Children.Remove(ps);
                            break;
                        }
                    }
                }
            }

            using(SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.Delete<PasswordStringModel>(model.Id);
            }
        }

        private PasswordStringModel AddPasswordString(PasswordStringModel model)
        {
            PasswordString ps = new PasswordString();
            PasswordStringViewModel psContext = new PasswordStringViewModel(model);
            model.FieldChanged += (s) => 
            {
                using(SQLiteConnection connection = DBContext.GetConnection())
                {
                    connection.InsertOrReplace(s);
                }
            };
            psContext.OnDeletePressed += RemovePasswordString;
            ps.BindingContext = psContext;

            PasswordStringVMs.Add(psContext);
            PasswordStack.Children.Add(ps);

            return model;
        }
    }
}
