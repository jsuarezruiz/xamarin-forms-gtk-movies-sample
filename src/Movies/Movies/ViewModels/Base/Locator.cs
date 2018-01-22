using Autofac;
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
        private static IContainer _container;

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
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<RequestService>().As<IRequestService>();
            builder.RegisterType<MoviesService>().As<IMoviesService>();
            builder.RegisterType<PeopleService>().As<IPeopleService>();
            builder.RegisterType<TVShowService>().As<ITVShowService>();

            builder.RegisterType<DetailViewModel>();
            builder.RegisterType<GalleryViewModel>();
            builder.RegisterType<MoviesViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<HomepageViewModel>();
            builder.RegisterType<PeopleViewModel>();
            builder.RegisterType<ShowsViewModel>();
            builder.RegisterType<SplashViewModel>();
            builder.RegisterType<UpcomingViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
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