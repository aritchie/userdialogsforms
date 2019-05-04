using System;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;


namespace Acr.UserDialogs.Forms.Views
{
    public class AlertViewModel : ViewModel
    {
        [Reactive] public string Title { get; set; }
        [Reactive] public string Message { get; set; }

        public bool IsCancelVisible => this.Cancel != null;
        public string CancelText { get; set; }
        public ICommand Cancel { get; set; }

        public string OkText { get; set; }
        public ICommand Ok { get; set; }
    }
}
