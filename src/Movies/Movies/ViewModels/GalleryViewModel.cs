using System.Threading.Tasks;
using Movies.ViewModels.Base;
using Movies.Models;
using System.Collections.ObjectModel;
using Movies.Models.People;

namespace Movies.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        private Profile _current;
        private ObservableCollection<Profile> _images;

        public Profile Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Profile> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is ProfileParameter)
            {
                var parameter = (ProfileParameter)navigationData;
                Current = parameter.Current;
                Images = new ObservableCollection<Profile>(parameter.Images);
            }

            return base.InitializeAsync(navigationData);
        }
    }
}