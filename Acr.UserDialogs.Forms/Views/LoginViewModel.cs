using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace Acr.UserDialogs.Forms.Views
{
    public class LoginViewModel : ReactiveObject
    {
        [Reactive] public string ErrorMessage { get; set; }

        [Reactive] public string UserIdentifierLabel { get; set; }
        [Reactive] public string UserIdentifierPlaceholder { get; set; }
        [Reactive] public string UserIdentifier { get; set; }

        [Reactive] public string PasswordLabel { get; set; }
        [Reactive] public string PasswordPlaceholder { get; set; }
        [Reactive] public string Password { get; set; }

        public ICommand Login { get; set; }
    }
}
