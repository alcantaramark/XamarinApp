using System;
using MarkApp.Interfaces;
using MarkApp.Services;
using MarkApp.ViewModels;
using Autofac;

  

namespace MarkApp.Helpers
{
    public class AppContainer
    {
        #region Private Members
        private static IContainer _container;
        #endregion

        #region Constructors
        public AppContainer()
        {
        }
        #endregion

        #region public methods
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //View Models
            builder.RegisterType<NewDiaryViewModel>();
            builder.RegisterType<PostDataViewModel>();
            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<PermissionService>().As<IPermissionService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<PhotoService>().As<IPhotoService>();
            builder.RegisterType<FileService>().As<IFileService>();
            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        #endregion
    }
}
