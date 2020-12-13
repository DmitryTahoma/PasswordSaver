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
        public MainPage()
        {
            InitializeComponent();

            using (SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.CreateTable<PasswordStringModel>(CreateFlags.AutoIncPK);

                TableQuery<PasswordStringModel> passwords = connection.Table<PasswordStringModel>();

                foreach (PasswordStringModel password in passwords)
                {
                    PasswordString ps = new PasswordString();
                    PasswordStringViewModel psContext = new PasswordStringViewModel(password);
                    ps.BindingContext = psContext;

                    PasswordStack.Children.Add(ps);
                }
            }
        }

        private void AddPasswordString(object sender, EventArgs e)
        {
            PasswordString ps = new PasswordString();
            PasswordStringViewModel psContext = new PasswordStringViewModel();
            ps.BindingContext = psContext;

            using (SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.Insert(psContext.Model);
            }

            PasswordStack.Children.Add(ps);
        }
    }
}
