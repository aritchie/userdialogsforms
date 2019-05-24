using System;
using Xamarin.Forms;

namespace Acr.UserDialogs.Forms
{
    public class PromptConfig
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string OkLabel { get; set; }
        public string CancelLabel { get; set; }
        public bool IsCancellable { get; set; }
        public Keyboard Keyboard { get; set; }

        public string ValuePlaceholder { get; set; }
        public string CurrentValue { get; set; }
        // TODO: ability to set error message
        //public ICommand OkCommand { get; set; }

        public PromptConfig SetTitle(string title)
        {
            this.Title = title;
            return this;
        }


        public PromptConfig SetKeyboard(Keyboard keyboard)
        {
            this.Keyboard = keyboard;
            return this;
        }


        public PromptConfig SetMessage(string message)
        {
            this.Message = message;
            return this;
        }
    }
}
