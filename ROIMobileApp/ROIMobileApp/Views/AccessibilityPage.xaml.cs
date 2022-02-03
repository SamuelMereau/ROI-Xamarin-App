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
    public partial class AccessibilityPage : ContentPage
    {
        private List<string> ColourList = new List<string> { "White", "Dark Grey", "Blue", "Green", "Pink" };

        public AccessibilityPage()
        {
            InitializeComponent();
            ColourPicker.ItemsSource = ColourList;
            ColourPicker.SelectedItem = "White";
            TextSizeEntry.Text = "16";
        }

        /// <summary>
        /// Update colour selected from picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColourPicker_Unfocused(object sender, FocusEventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedColour = picker.SelectedItem;

            switch (selectedColour)
            {
                case "White":
                    Application.Current.Resources["SelectedBackgroundColour"] = Color.White;
                    break;
                case "Dark Grey":
                    Application.Current.Resources["SelectedBackgroundColour"] = Color.DarkGray;
                    break;
                case "Blue":
                    Application.Current.Resources["SelectedBackgroundColour"] = "#9CC2E5";
                    break;
                case "Green":
                    Application.Current.Resources["SelectedBackgroundColour"] = "#A8D08D";
                    break;
                case "Pink":
                    Application.Current.Resources["SelectedBackgroundColour"] = Color.Pink;
                    break;
                default:
                    Application.Current.Resources["SelectedBackgroundColour"] = Color.White;
                    break;
            }
        }

        private async void TextSizeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (TextSizeEntry.Text == "")
            {
                await DisplayAlert("Text Size cannot be empty", "Please enter a text font size", "OK");
                TextSizeEntry.Text = "16";
            } 
            else
            {
                try
                {
                    Application.Current.Resources.Remove("SelectedFontSize");
                    var newStyle = new Style(typeof(Label))
                    {
                        Setters =
                        {
                            new Setter { Property = Label.FontSizeProperty, Value = double.Parse(TextSizeEntry.Text) }
                        }
                    };
                    Application.Current.Resources.Add("SelectedFontSize", newStyle);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}