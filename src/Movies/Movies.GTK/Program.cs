using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps.GTK;
using Xamarin.Forms.Platform.GTK;
using Xamarin.Forms.Platform.GTK.Helpers;

namespace Movies.GTK
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GtkThemes.Init();

            if (PlatformHelper.GetGTKPlatform() == GTKPlatform.Windows)
                GtkThemes.LoadCustomTheme("Themes/gtkrc-dark");

            Gtk.Application.Init();
            Forms.Init();
            FormsMaps.Init(string.Empty);
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Movies");
            window.SetApplicationIcon("Images/movies-icon.png");
            window.Show();
            Gtk.Application.Run();
        }
    }
}