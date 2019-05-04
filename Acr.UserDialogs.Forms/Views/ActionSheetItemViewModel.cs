using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Acr.UserDialogs.Forms.Views
{
    public class ActionSheetItemViewModel
    {
        public string Text { get; set; }
        public ImageSource Icon { get; set; }
        public ICommand Action { get; set; }
    }
}
