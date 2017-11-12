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
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-discover.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-discover.png";
                    else
                        return string.Empty;
                case MenuItemType.Movies:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-movie.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-movie.png";
                    else
                        return string.Empty;
                case MenuItemType.TVShows:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-shows.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-shows.png";
                    else
                        return string.Empty;
                case MenuItemType.Upcoming:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-upcoming.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-upcoming.png";
                    else
                        return string.Empty;
                case MenuItemType.Favourites:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-favourites.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-favourites.png";
                    else
                        return string.Empty;
                case MenuItemType.Settings:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/movies-settings.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/movies-settings.png";
                    else
                        return string.Empty;
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