using System;
using System.Reactive.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs.Forms;


namespace Samples
{
    public class MainViewModel
    {
        readonly IUserDialogs dialogs = new UserDialogs();


        public MainViewModel()
        {
            this.ActionSheet = new Command(() =>
            {
                this.dialogs.ActionSheet(
                    new ActionSheetConfig
                    {
                        Title = "TEST ACTIONSHEET",
                        Message = "HELL I AM TALKING TO YOU",

                    }
                    .Add("1", () => dialogs.Alert("1"))
                    .Add("2", () => dialogs.Alert("2"))
                );
            });
            this.Alert = new Command(async () =>
            {
                await this.dialogs
                    .Alert(new AlertConfig
                    {
                        Title = "TEST TITLE",
                        Message = "This is a really long piece of text that can fit in a scrollview.  You can ramble on and on and on and on and on and on and on",
                        OkLabel = "HI"
                    });
            });
            this.Confirm = new Command(async () =>
            {
                var result = await this.dialogs
                    .Confirm(new ConfirmConfig
                    {
                        Title = "TEST TITLE",
                        Message = "This is a really long piece of text that can fit in a scrollview.  You can ramble on and on and on and on and on and on and on",
                        OkLabel = "Yes",
                        CancelLabel = "No"
                    });
            });
            this.Prompt = new Command(async () =>
            {
                var result = await this.dialogs.Prompt("Test", "Hello");
                this.dialogs.Toast($"OK: {result.Ok} - Text: {result.Value}");
            });
            this.Toast = new Command(() =>
            {
                this.dialogs.Toast(new ToastConfig
                {
                    Message = "Hello from the toast window",
                    MessageTextColor = Color.White,
                    BackgroundColor = Color.Black,
                    DisplayTime = TimeSpan.FromSeconds(5),
                    OnTap = () =>
                    {
                    }
                });
            });
        }


        public ICommand ActionSheet { get; }
        public ICommand Alert { get; }
        public ICommand Confirm { get; }
        public ICommand Prompt { get; }
        public ICommand Toast { get; }
    }
}
