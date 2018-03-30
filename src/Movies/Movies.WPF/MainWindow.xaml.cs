using Xamarin;
using Xamarin.Forms.Platform.WPF;

namespace Movies.WPF
{
	public partial class MainWindow : FormsApplicationPage
	{
		public MainWindow()
		{
			InitializeComponent();
			Xamarin.Forms.Forms.Init();
			FormsMaps.Init(string.Empty);
			LoadApplication(new Movies.App());
		}
	}
}
