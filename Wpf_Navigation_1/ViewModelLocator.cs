using Autofac;
using Autofac.Configuration;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;
using Wpf_Navigation_1.Services;
using Wpf_Navigation_1.ViewModels;

namespace Wpf_Navigation_1
{
    class ViewModelLocator
    {
        private AppViewModel appViewModel;
        private FirstViewModel firstViewModel;
        private SecondViewModel secondViewModel;
        private ThirdViewModel thirdViewModel;

        private INavigationService navigationService;
        public static IContainer Container;

        public ViewModelLocator()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                Container = builder.Build();

                navigationService = Container.Resolve<INavigationService>();
                appViewModel = Container.Resolve<AppViewModel>();
                firstViewModel = Container.Resolve<FirstViewModel>();
                secondViewModel = Container.Resolve<SecondViewModel>();
                thirdViewModel = Container.Resolve<ThirdViewModel>();

                navigationService.Register<FirstViewModel>(firstViewModel);
                navigationService.Register<SecondViewModel>(secondViewModel);
                navigationService.Register<ThirdViewModel>(thirdViewModel);

                navigationService.Navigate<SecondViewModel>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public ViewModelBase GetAppViewModel()
        {
            return appViewModel;
        }
    }
}
