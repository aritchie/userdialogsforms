using System;
using System.Windows.Input;

namespace Acr.UserDialogs.Forms
{
    public class PromptConfig
    {
        public string EntryPlaceholder { get; set; }
        public string CurrentValue { get; set; }
        // TODO: ability to set error message
        public ICommand OkCommand { get; set; }
    }
}
