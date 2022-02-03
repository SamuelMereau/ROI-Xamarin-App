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
    public partial class UpdateRecordPage : ContentPage
    {
        private RestService _restService;
        private Record _record;

        public Record RecordObj
        {
            get { return _record; }
            set { _record = value; }
        }

        public UpdateRecordPage(Record record)
        {
            InitializeComponent();
            RecordObj = record;
            BindingContext = this;
            _restService = new RestService();
        }

        /// <summary>
        /// Update confirmed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            foreach (StackLayout view in UpdateRecordForm.Children.Where(x => x is StackLayout).ToList())
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
                object updatedRecord = new
                {
                    personId = _record.Id,
                    name = eName.Text,
                    phone = ePhone.Text,
                    departmentId = eDepId.Text,
                    street = eStreet.Text,
                    city = eCity.Text,
                    state = eState.Text,
                    zip = eZip.Text,
                    country = eCountry.Text
                };

                string recordId = await _restService.UpdateRecordAsync(Constants.ROIEndpoint + "UpdatePerson", updatedRecord);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                return;
            }

            await DisplayAlert("Success", $"The record with the ID of {_record.Id} has successfully updated", "OK");    
            await Navigation.PopToRootAsync();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(this.GetType().Name));
        }
    }
}