using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KazanNeftSession1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAsset : ContentPage
    {
        public EditAsset(int assetID)
        {
            InitializeComponent();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {

        }
        private void btnCancel_Clicked(object sender, EventArgs e)
        {

        }
    }
}