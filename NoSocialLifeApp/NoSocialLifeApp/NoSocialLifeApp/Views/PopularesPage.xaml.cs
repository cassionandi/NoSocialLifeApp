using NoSocialLifeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoSocialLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularesPage
    {
        private PopularesViewModel ViewModel => BindingContext as PopularesViewModel;

        public PopularesPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem != null)
            {
                ViewModel.ShowDetalheCommand.Execute(e.SelectedItem);
            }


        }
    }
}