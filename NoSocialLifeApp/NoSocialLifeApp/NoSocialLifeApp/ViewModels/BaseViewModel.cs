using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{
        public class BaseViewModel : INotifyPropertyChanged
        {
            private string _title;
            public string Title
            {
                get { return _title; }
                set { SetProperty(ref _title, value); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(storage, value))
                {
                    return false;
                }

                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
            {
                var viewModelType = typeof(TViewModel);
                var viewModelTypeName = viewModelType.Name;
                var viewModelWordLength = "ViewModel".Length;
                var viewTypeName = $"NoSocialLifeApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
                var viewType = Type.GetType(viewTypeName);

                var page = Activator.CreateInstance(viewType) as Page;
                /*
                 * Evita passar por parametro a instancia do .. Service entre os ViewModels
                 * 
                if (viewModelType.GetTypeInfo().DeclaredConstructors.Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(IMonkeyHubApiService))))
                {
                    var argsList = args.ToList();
                    var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
                    argsList.Insert(0, monkeyHubApiService);
                    args = argsList.ToArray();
                }
                */
                var viewModel = Activator.CreateInstance(viewModelType, args);
                if (page != null)
                {
                    page.BindingContext = viewModel;
                }

                await Application.Current.MainPage.Navigation.PushAsync(page);
            }

        public async Task PushModalAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"NoSocialLifeApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page;
            /*
             * Evita passar por parametro a instancia do .. Service entre os ViewModels
             * 
            if (viewModelType.GetTypeInfo().DeclaredConstructors.Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(IMonkeyHubApiService))))
            {
                var argsList = args.ToList();
                var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
                argsList.Insert(0, monkeyHubApiService);
                args = argsList.ToArray();
            }
            */
            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                page.BindingContext = viewModel;
            }

            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public virtual Task LoadAsync()
            {
                return Task.FromResult(0);
            }

            public async Task DisplayAlert(string title, string message, string cancel)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, cancel);
            }

            public async Task DisplayAlert(string title, string message, string accept, string cancel)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            }

        protected void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

    }

}
