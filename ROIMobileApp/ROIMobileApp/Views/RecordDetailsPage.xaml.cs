using ROIMobileApp.Classes;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ROIMobileApp.Views
{
    public partial class RecordDetailsPage : ContentPage
    {
        private Record _record;

        public Record RecordObj
        {
            get { return _record; }
            set { _record = value; }
        }

        public RecordDetailsPage(Record record)
        {
            InitializeComponent();
            RecordObj = record;
            BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateRecordPage(_record));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(this.GetType().Name));
        }
    }
}