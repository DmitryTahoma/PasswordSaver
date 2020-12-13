using PasswordSaver.ViewModels;
using PasswordSaver.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PasswordSaver
{
    public partial class MainPage : ContentPage
    {
        private List<PasswordStringViewModel> passwords;

        public MainPage()
        {
            InitializeComponent();
            passwords = new List<PasswordStringViewModel>();
        }

        private void AddPasswordString(object sender, EventArgs e)
        {
            PasswordString ps = new PasswordString();
            PasswordStringViewModel psContext = new PasswordStringViewModel();
            ps.BindingContext = psContext;

            passwords.Add(psContext);
            PasswordStack.Children.Add(ps);
        }
    }
}
