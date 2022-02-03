using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROIMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpView : ContentPage
    {
        private string _pageName;

        private string _recordsView = "All created records created in the application will be listed on the Records page. Each record shows the ID and Name of the record. To view the full details of a record, press a record item to open the Record Details view.\n\nThe tab menu at the bottom of the screen will allow you to access different features of the application, including adding and deleting a record.The “All Records” tab will return you to the Records view, while the “Add” and “Remove” tabs will navigate you to their respective pages.";
        private string _recordDetailsView = "When a record is selected, the Records Detail page will open and provide you with the full details associated with a record. These details are read-only and cannot be edited. To update/edit the details in the record, press the “Update Record” button to navigate to the Update Record view.\n\nThe tab menu at the bottom of the screen will allow you to access different features of the application, including adding and deleting a record.The “All Records” tab will return you to the Records view, while the “Add” and “Remove” tabs will navigate you to their respective pages.";
        private string _updateRecordView = "The Update Record view allows you to edit the details associated with a record. Each item has a textbox, which when pressed allow you to edit the item’s contents. When the changes are made, press the Confirm button to submit the changes to the record. When submitted, the record’s details will immediately update with the new details.\n\nThe tab menu at the bottom of the screen will allow you to access different features of the application, including adding and deleting a record.The “All Records” tab will return you to the Records view, while the “Add” and “Remove” tabs will navigate you to their respective pages.";
        private string _deleteRecordView = "The Remove Record view allows you to delete a record from the list of records in the application. A textbox is offered which allows you to input an ID for a record. The Record ID for each record is found in the Records view (located at the “All Records” tab) and the Record Details page. Once the Record ID is inputted, press the Confirm Deletion button to delete the record. Alternatively, you can press the “Cancel” button to return to the Records view.\n\nThe tab menu at the bottom of the screen will allow you to access different features of the application, including adding and deleting a record.The “All Records” tab will return you to the Records view, while the “Add” and “Remove” tabs will navigate you to their respective pages.";
        private string _newRecordView = "The New Record view allows you to create a new record to add to the application. Each item in the record has a textbox which when selected allow content to be inputted. When all items are filled, press the “Add Record” button to add the record.\n\nThe tab menu at the bottom of the screen will allow you to access different features of the application, including adding and deleting a record.The “All Records” tab will return you to the Records view, while the “Add” and “Remove” tabs will navigate you to their respective pages.";

        public HelpView(string pageName)
        {
            InitializeComponent();
            _pageName = pageName;

            switch (_pageName)
            {
                case "AllRecordsPage":
                    HelpContent.Text = _recordsView;
                    break;
                case "DeleteRecordPage":
                    HelpContent.Text = _deleteRecordView;
                    break;
                case "NewRecordPage":
                    HelpContent.Text = _newRecordView;
                    break;
                case "RecordDetailsPage":
                    HelpContent.Text = _recordDetailsView;
                    break;
                case "UpdateRecordPage":
                    HelpContent.Text = _updateRecordView;
                    break;
            }
        }
    }
}