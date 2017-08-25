using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies.ViewModels.Base
{
    public class ViewModelBase : BindableObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}