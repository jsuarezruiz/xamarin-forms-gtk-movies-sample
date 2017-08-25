using Microsoft.Practices.Unity;
using Movies.Services.Movies;
using Movies.Services.Navigation;
using Movies.Services.People;
using Movies.Services.Request;
using Movies.Services.TVShow;
using System;

namespace Movies.ViewModels.Base
{
    public class Locator
    {
        private readonly IUnityContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            _container = new UnityContainer();

            _container.RegisterType<IRequestService, RequestService>();
            _container.RegisterType<IMoviesService, MoviesService>();
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IPeopleService, PeopleService>();
            _container.RegisterType<ITVShowService, TVShowService>();

            _container.RegisterType<DetailViewModel>();
            _container.RegisterType<GalleryViewModel>();
            _container.RegisterType<MoviesViewModel>();
            _container.RegisterType<MenuViewModel>();
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<HomeViewModel>();
            _container.RegisterType<HomepageViewModel>();
            _container.RegisterType<PeopleViewModel>();
            _container.RegisterType<ShowsViewModel>();
            _container.RegisterType<SplashViewModel>();
            _container.RegisterType<UpcomingViewModel>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}