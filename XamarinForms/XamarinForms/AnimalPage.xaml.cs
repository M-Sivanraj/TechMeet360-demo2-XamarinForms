using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForms
{
    public partial class AnimalPage : ContentPage
    {
        public AnimalPage()
        {
            AnimalsViewModel vm;
            InitializeComponent();
            BindingContext = vm = new AnimalsViewModel();

            btnAnimals.Clicked += async (sender, e) =>
            {
                btnAnimals.IsEnabled = false;

                await vm.GetAnimals();

                btnAnimals.IsEnabled = true;
            };
        }
    }
}
