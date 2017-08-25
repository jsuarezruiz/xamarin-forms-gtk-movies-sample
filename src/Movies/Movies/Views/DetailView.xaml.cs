using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<DetailViewModel, string>(this, AppSettings.DialogMessage, (sender, arg) =>
            { 
                DisplayAlert("Ooops!", arg, "Ok");
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<DetailViewModel, string>(this, AppSettings.DialogMessage);

            base.OnDisappearing();
        }
    }
}