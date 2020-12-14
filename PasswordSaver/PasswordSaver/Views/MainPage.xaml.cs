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
                    PasswordString ps = new PasswordString();
                    PasswordStringViewModel psContext = new PasswordStringViewModel(password);
                    psContext.OnDeletePressed += RemovePasswordString;
                    ps.BindingContext = psContext;

                    PasswordStringVMs.Add(psContext);
                    PasswordStack.Children.Add(ps);
                }
            }
        }

        private void AddPasswordString(object sender, EventArgs e)
        {
            PasswordString ps = new PasswordString();
            PasswordStringViewModel psContext = new PasswordStringViewModel();
            psContext.OnDeletePressed += RemovePasswordString;
            ps.BindingContext = psContext;

            using (SQLiteConnection connection = DBContext.GetConnection())
            {
                connection.Insert(psContext.Model);
            }

            PasswordStringVMs.Add(psContext);
            PasswordStack.Children.Add(ps);
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
    }
}
