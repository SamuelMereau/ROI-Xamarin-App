using ROIMobileApp.Classes;
using ROIMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROIMobileApp.Views
{
    public partial class AllRecordsPage : ContentPage
    {
        private RestService _restService;
        public Command<Record> RecordTapped { get; }
        
        public AllRecordsPage()
        {
            InitializeComponent();

            _restService = new RestService();

            InitializeRecords();

            BindingContext = this;

            RecordTapped = new Command<Record>(OnRecordTapped);
            rfRecords.Command = new Command(async () => await ExecuteLoadRecordsCommand());
        }

        async void InitializeRecords()
        {
            rfRecords.IsRefreshing = true;
            try
            {
                List<Record> records = await _restService.GetRecordsAsync(Constants.ROIEndpoint + "GetPeople");
                cvRecords.ItemsSource = records;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            rfRecords.IsRefreshing = false;
        }

        async Task RefreshRecords()
        {
            try
            {
                cvRecords.ItemsSource = null;
                List<Record> records = await _restService.GetRecordsAsync(Constants.ROIEndpoint + "GetPeople");
                cvRecords.ItemsSource = records;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async Task ExecuteLoadRecordsCommand()
        {
            IsBusy = true;
            await RefreshRecords();
            IsBusy = false;
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Record selectedRecord = e.CurrentSelection[0] as Record;
        }

        async void OnRecordTapped(Record record)
        {
            // Push page onto stack
            await Navigation.PushAsync(new RecordDetailsPage(record));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(this.GetType().Name));
        }

        private async void RecordsView_Appearing(object sender, EventArgs e)
        {
            await RefreshRecords();
        }
    }
}