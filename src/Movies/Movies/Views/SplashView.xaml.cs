using Xamarin.Forms;

namespace Movies.Views
{
    public partial class SplashView : ContentPage
    {
        public SplashView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}