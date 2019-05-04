using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace Acr.UserDialogs.Forms.Views
{
    public class ActionSheetViewModel : ViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public string CancelText { get; set; } = "Cancel";
        public ICommand Cancel { get; set; }

        public string OkText { get; set; } = "Ok";
        public ICommand Ok { get; set; }

        public List<ActionSheetItemViewModel> Items { get; set; }
    }
}
