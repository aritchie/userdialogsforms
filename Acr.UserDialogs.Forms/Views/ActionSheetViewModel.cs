using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace Acr.UserDialogs.Forms.Views
{
    public class ActionSheetViewModel : ViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public bool IsCancellable { get; set; }
        public string CancelLabel { get; set; }
        public ICommand Cancel { get; set; }

        public List<ActionSheetItemViewModel> Items { get; set; }
    }
}
