using ROIMobileApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROIMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteRecordPage : ContentPage
    {
        private RestService _restService;

        public DeleteRecordPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        /// <summary>
        /// Return to Records view when Cancel button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AllRecords");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string recordId = await _restService.DeleteRecordAsync(Constants.ROIEndpoint + "DeletePerson", int.Parse(RecordId.Text)); 
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                return;
            }
            await DisplayAlert("Success", $"The record with the ID of {RecordId.Text} has successfully deleted", "OK");
            await Shell.Current.GoToAsync("//AllRecords");
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(this.GetType().Name));
        }
    }
}