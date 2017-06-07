using NoSocialLifeApp.ViewModels;
using NoSocialLifeApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NoSocialLifeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());

            MainPage = new NavigationPage(new BuscaPage()
            {
                BindingContext = new BuscaViewModel()
            }
            );
            
            /*
            MainPage = new NavigationPage(new DetalhePage()
            {
                BindingContext = new DetalheViewModel(
                     new Item()
                     {
                         Titulo = "Mythic Game Master Emulator",
                         Publicacao = "2007",
                         Imagem = "https://cf.geekdo-images.com/images/pic2823310_t.jpg"
                     }
                 )
            });
            */
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
