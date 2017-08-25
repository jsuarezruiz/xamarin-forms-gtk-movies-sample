using System.Threading.Tasks;
using Movies.ViewModels.Base;

namespace Movies.ViewModels
{
    public class HomepageViewModel : ViewModelBase
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Url = navigationData.ToString();
            }

            return base.InitializeAsync(navigationData);
        }
    }
}