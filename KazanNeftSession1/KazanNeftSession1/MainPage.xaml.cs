using KazanNeftSession1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;


namespace KazanNeftSession1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<Department> listDepartment = new List<Department>();
        List<assetgroups> listAssetGroups = new List<assetgroups>();

        List<GlobalVariables.assetListItem> listAssets = new List<GlobalVariables.assetListItem>();
        WebClient webClient = new WebClient();

        String url = "http://10.0.2.2:3000";
        public MainPage()
        {
            InitializeComponent();

            List<string> employee = new List<string>()
            {
                "Ethan", "John", "Joe", "Tommy", "Frank"
            };

            webClient.Headers.Add("Content-Type", "application/json");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadPickers();
            loadAssetlist();
        }


        private async void loadPickers()
        {
            var getDepartments = await webClient.UploadDataTaskAsync($"{url}/api/getDepartments", "POST", Encoding.UTF8.GetBytes(""));
            listDepartment = JsonConvert.DeserializeObject<List<Department>>(Encoding.Default.GetString(getDepartments));
            pickerDept.ItemsSource = listDepartment;


            var getAssetGroups = await webClient.UploadDataTaskAsync($"{url}/api/getAssetGroups", "POST", Encoding.UTF8.GetBytes(""));
            listAssetGroups = JsonConvert.DeserializeObject<List<assetgroups>>(Encoding.Default.GetString(getAssetGroups));
            pickerAssetGroup.ItemsSource = listAssetGroups;
        }

        private async void loadAssetlist()
        {
            using(var webApi = new WebClient())
            {
                webApi.Headers.Add("Content-Type", "Application/json");
                var response = await webApi.UploadDataTaskAsync($"{url}/api/getAssets", "POST", Encoding.UTF8.GetBytes(""));
                /*var listOfAssets*/ listAssets = JsonConvert.DeserializeObject<List<GlobalVariables.assetListItem>>(Encoding.Default.GetString(response));
                assetList.ItemsSource = listAssets;
            }

        }

        private async void btnEdit_click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            var selectedListItem = (StackLayout)btn.Parent;
            //get the ID of the asset
            var label = (StackLayout)selectedListItem.Children[1];
            var assetId = ((Label)label.Children[1]).Text;
            await Navigation.PushAsync(new EditAsset(int.Parse(assetId)));
        }

        private void btnMove_click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Clicked(object sender, EventArgs e)
        {

        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(searchInput.Text.Trim() != string.Empty)
            {
                var searchQuery = (from a in listAssets
                                   where a.AssetName.ToLower().Contains(searchInput.Text.ToLower()) || a.AssetSN.Contains(searchInput.Text.ToLower())
                                   select a).ToList();
                assetList.ItemsSource = searchQuery;
            }
            else
            {
                assetList.ItemsSource = listAssets;
            }
        }

        private void pickerDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDept = ((Department)pickerDept.SelectedItem).Name;
            if(pickerAssetGroup.SelectedItem != null)
            {
                var selectedAg = ((assetgroups)pickerAssetGroup.SelectedItem).Name;
                var searchQuery = listAssets.Where(a => a.DepartmentName == selectedDept && a.AssetGroup == selectedAg).ToList();
                assetList.ItemsSource = searchQuery;

            }
            else if(pickerAssetGroup.SelectedItem == null)
            {
                var searchQuery = listAssets.Where(a => a.DepartmentName == selectedDept);
            }
            else
            {
                assetList.ItemsSource = listAssets;
            }
        }
        private void pickerAssetGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAg = ((assetgroups)pickerAssetGroup.SelectedItem).Name;
            if(pickerDept.SelectedItem != null)
            {
                var selectedDept = ((Department)pickerDept.SelectedItem).Name;
                var searchQuery = listAssets.Where(a => a.DepartmentName == selectedDept && a.AssetGroup == selectedAg).ToList();
                assetList.ItemsSource = searchQuery;
            }
            else if(pickerDept.SelectedItem == null)
            {
                var searchQuery = listAssets.Where(a => a.AssetGroup == selectedAg).ToList();
                assetList.ItemsSource = searchQuery;
            }
            else
            {
                assetList.ItemsSource = listAssets;
            }

        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAsset());
        }
    }
}
