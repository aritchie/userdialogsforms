using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamarin.Forms;

namespace Acr.UserDialogs.Forms.Views
{
    public class PromptViewModel : ReactiveObject
    {
        [Reactive] public string Value { get; set; }
        public string ValuePlaceholder { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }
        public Keyboard Keyboard { get; set; }
        public string OkLabel { get; set; }
        public string CancelLabel { get; set; }
        public bool IsCancellable { get; set; }
        public ICommand Ok { get; set; }
        public ICommand Cancel { get; set; }
    }
}
