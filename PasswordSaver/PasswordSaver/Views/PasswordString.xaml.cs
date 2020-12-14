using PasswordSaver.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordSaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordString : ContentView
    {
        public PasswordString()
        {
            InitializeComponent();
        }

        private void DeletePasswordString(object sender, System.EventArgs e)
        {
            if(BindingContext is PasswordStringViewModel context)
            {
                context.DeleteMe();
            }
        }
    }
}