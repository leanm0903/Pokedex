using System;
using System.Reflection;

using Autofac;

using Pokedex.Commons.RestService;
using Pokedex.Services;
using Pokedex.Services.Interfaces;
using Xamarin.Forms;

namespace Pokedex.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static IContainer container;
        protected ContainerBuilder ContainerBuilder;

        public static ViewModelLocator Instance { get; } = new ViewModelLocator();

        public ViewModelLocator()
        {
            ContainerBuilder = new ContainerBuilder();

            ContainerBuilder.RegisterType<RestService>().As<IRestService>().SingleInstance();
            ContainerBuilder.RegisterType<PokemonService>().As<IPokemonService>().SingleInstance();
            ContainerBuilder.RegisterType<PokemonListViewModel>().SingleInstance();
            ContainerBuilder.RegisterType<PokemonDetailViewModel>().SingleInstance();
        }

        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached(
         "AutoWireViewModel",
         typeof(bool),
         typeof(ViewModelLocator),
         default(bool),
         propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) =>
            (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) =>
            bindable.SetValue(AutoWireViewModelProperty, value);
        
        private static async void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = $"{viewName}Model, {viewAssemblyName}";

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType != null)
            {
                var viewModel = container.Resolve(viewModelType) as BaseViewModel;
                if (viewModel == null)
                {
                    return;
                }
                view.BindingContext = viewModel;
            }
        }
        
        public object Resolve(Type type) => container.Resolve(type);
        

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => ContainerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void Register<T>() where T : class => ContainerBuilder.RegisterType<T>();

        public void Build() => container = ContainerBuilder.Build();

    }
}

