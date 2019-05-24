using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;

namespace Acr.UserDialogs.Forms
{
    public struct LoginArgs
    {
        public LoginArgs(string value, string password)
        {
            this.LoginValue = value;
            this.Password = password;
        }


        public string LoginValue { get; }
        public string Password { get; }
    }


    public class LoginResult
    {
        public static void Success() => new LoginResult(null);
        public static void Fail(string error) => new LoginResult(error);

        LoginResult(string error)
        {
            this.ErrorMessage = error;
        }


        public bool IsSuccess => this.ErrorMessage == null;
        public string ErrorMessage { get; }
    }

    public class LoginConfig
    {
        //public LoginConfig()
        //event Action Close;

        public Func<LoginArgs, Task<LoginResult>> ValidateLogin { get; set; }
        public Func<PopupPage> GetPage { get; set; }

        public string LoginValueLabel { get; set; }
        public string LoginValuePlaceholder { get; set; }
        public string LoginValue { get; set; }

        public string PasswordLabel { get; set; }
        public string PasswordPlaceholder { get; set; }

        public bool IsCancellable { get; set; }
        public string CancelLabel { get; set; }

    }
}
