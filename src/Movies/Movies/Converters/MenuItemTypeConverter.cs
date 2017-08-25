using Movies.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Movies.Converters
{
    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;

            switch (menuItemType)
            {
                case MenuItemType.Discover:
                    return "Images/movies-discover.png";
                case MenuItemType.Movies:
                    return "Images/movies-movie.png";
                case MenuItemType.TVShows:
                    return "Images/movies-shows.png";
                case MenuItemType.Upcoming:
                    return "Images/movies-upcoming.png";
                case MenuItemType.Favourites:
                    return "Images/movies-favourites.png";
                case MenuItemType.Settings:
                    return "Images/movies-settings.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}