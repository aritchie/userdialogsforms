using System;
using System.Windows.Input;


namespace Acr.UserDialogs.Forms
{
    public class PromptConfig
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string OkLabel { get; set; }
        public string CancelLabel { get; set; }
        public bool IsCancellable { get; set; }

        public string ValuePlaceholder { get; set; }
        public string CurrentValue { get; set; }
        // TODO: ability to set error message
        //public ICommand OkCommand { get; set; }
    }
}
