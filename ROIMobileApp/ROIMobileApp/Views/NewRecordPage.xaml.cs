using ROIMobileApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROIMobileApp.Views
{
    public partial class NewRecordPage : ContentPage
    {
        private RestService _restService;
        public Record Record { get; set; }

        public NewRecordPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            foreach (StackLayout view in NewRecordForm.Children.Where(x => x is StackLayout).ToList())
            {
                foreach (View subView in view.Children)
                {
                    if (subView is Entry)
                    {
                        if ((subView as Entry).Text == null || (subView as Entry).Text == "")
                        {
                            await DisplayAlert("Error", $"The record cannot have empty values. Please fill in the empty field/s with some content.", "OK");
                            return;
                        }
                    }
                }
            }

            try
            {
                object newRecord = new
                {
                    name = eName.Text,
                    phone = ePhone.Text,
                    departmentId = eDepId.Text,
                    street = eStreet.Text,
                    city = eCity.Text,
                    state = eState.Text,
                    zip = eZip.Text,
                    country = eCountry.Text
                };

                string recordId = await _restService.AddRecordAsync(Constants.ROIEndpoint + "AddPerson", newRecord);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                return;
            }

            foreach (StackLayout view in NewRecordForm.Children.Where(x => x is StackLayout).ToList())
            {
                foreach (View subView in view.Children)
                {
                    if (subView is Entry)
                    {
                        (subView as Entry).Text = "";
                    }

                }
            }

            await DisplayAlert("Success", $"The record has successfully created", "OK");
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(this.GetType().Name));
        }
    }
}