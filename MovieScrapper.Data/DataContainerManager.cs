﻿using Microsoft.Practices.Unity;
using MovieScrapper.Data.Interfaces;

namespace MovieScrapper.Data
{
    public class DataContainerManager
    {
        public void RegisterTypes(IUnityContainer container)
        {
            // Register repositories 
            container.RegisterType<IBetRepository, BetRepository>();
            container.RegisterType<IGamePropertyRepository, GamePropertyRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IMovieRepository, MovieRepository>();
            container.RegisterType<ITMDBRepository, TMDBRepository>();
            container.RegisterType<IViewModelsRepository, ViewModelsRepository>();
            container.RegisterType<IWatchedMovieRepository, WatchedMovieRepository>();
            container.RegisterType<INominationRepository, NominationRepository>();
        }
    }
}
