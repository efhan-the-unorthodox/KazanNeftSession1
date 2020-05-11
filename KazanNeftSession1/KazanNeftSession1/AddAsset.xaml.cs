using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KazanNeftSession1.Models;
using Newtonsoft.Json;

namespace KazanNeftSession1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAsset : ContentPage
    {
        WebClient webClient = new WebClient();

        List<Department> listDepartment = new List<Department>();
        List<assetgroups> listAssetGroups = new List<assetgroups>();
        List<GlobalVariables.Locations> listLocation = new List<GlobalVariables.Locations>();
        List<GlobalVariables.Employee> listEmployee = new List<GlobalVariables.Employee>();

        String url = "http://10.0.2.2:3000";

        public AddAsset()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadPickers();
        }

        private async void loadPickers()
        {
            var getDepartments = await webClient.UploadDataTaskAsync($"{url}/api/getDepartments", "POST", Encoding.UTF8.GetBytes(""));
            listDepartment = JsonConvert.DeserializeObject<List<Department>>(Encoding.Default.GetString(getDepartments));
            pickerDept.ItemsSource = listDepartment;

            var getAssetGroups = await webClient.UploadDataTaskAsync($"{url}/api/getAssetGroups", "POST", Encoding.UTF8.GetBytes(""));
            listAssetGroups = JsonConvert.DeserializeObject<List<assetgroups>>(Encoding.Default.GetString(getAssetGroups));
            pickerAssetGroup.ItemsSource = listAssetGroups;

            var getEmployees = await webClient.UploadDataTaskAsync($"{url}/api/getEmployees", "POST", Encoding.UTF8.GetBytes(""));
            listEmployee = JsonConvert.DeserializeObject<List<GlobalVariables.Employee>>(Encoding.Default.GetString(getEmployees));

            var getLocations = await webClient.UploadDataTaskAsync($"{url}/api/getLocations", "POST", Encoding.UTF8.GetBytes(""));
            listLocation = JsonConvert.DeserializeObject<List<GlobalVariables.Locations>>(Encoding.Default.GetString(getLocations));
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {

        }
        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}