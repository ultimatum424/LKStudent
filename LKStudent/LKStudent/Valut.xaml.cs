using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LKStudent
{
    public partial class Valut : ContentPage
    {
        RateViewModel viewModel;
        public Valut()
        {
            InitializeComponent();

            //viewModel = new RateViewModel("urlTemp1", "", "");

            this.BindingContext = viewModel;
        }
    }
}
