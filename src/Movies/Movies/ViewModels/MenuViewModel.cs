using Movies.Models;
using Movies.Services.Navigation;
using Movies.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movies.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _menuItems;

        private INavigationService _navigationService;

        public MenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand ItemSelectedCommand => new Xamarin.Forms.Command<MenuItem>(SelectMenuItem);

        public override Task InitializeAsync(object navigationData)
        {
            InitMenuItems();

            return base.InitializeAsync(navigationData);
        }

        private void InitMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Title = "Discover",
                    MenuItemType = MenuItemType.Discover,
                    ViewModelType = typeof(HomeViewModel),
                    IsEnabled = true
                },
                new MenuItem
                {
                    Title = "Movies",
                    MenuItemType = MenuItemType.Movies,
                    ViewModelType = typeof(MoviesViewModel),
                    IsEnabled = true
                },
                new MenuItem
                {
                    Title = "TV Shows",
                    MenuItemType = MenuItemType.TVShows,
                    ViewModelType = typeof(ShowsViewModel),
                    IsEnabled = true
                },
                new MenuItem
                {
                    Title = "Upcoming",
                    MenuItemType = MenuItemType.Upcoming,
                    ViewModelType = typeof(UpcomingViewModel),
                    IsEnabled = true
                },
                new MenuItem
                {
                    Title = "Favourites",
                    MenuItemType = MenuItemType.Favourites,
                    IsEnabled = false
                },
                new MenuItem
                {
                    Title = "Settings",
                    MenuItemType = MenuItemType.Settings,
                    IsEnabled = false
                }
            };
        }

        private async void SelectMenuItem(MenuItem item)
        {
            if (item.IsEnabled)
            {
                await _navigationService.NavigateToAsync(item.ViewModelType, null);
            }
        }
    }
}