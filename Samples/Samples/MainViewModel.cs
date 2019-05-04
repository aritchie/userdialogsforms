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
                    .AddAction("1", () => dialogs.Alert("1"))
                    .AddAction("2", () => dialogs.Alert("2"))
                );
            });
            this.Alert = new Command(async () =>
            {
                await this.dialogs
                    .Alert(new AlertConfig
                    {
                        Title = "TEST TITLE",
                        Message = "This is a really long piece of text that can fit in a scrollview.  You can ramble on and on and on and on and on and on and on",
                        OkText = "HI"
                    })
                    .ToTask();
            });
            this.Confirm = new Command(async () =>
            {
                await this.dialogs
                    .Confirm(new ConfirmConfig
                    {
                        Title = "TEST TITLE",
                        Message = "This is a really long piece of text that can fit in a scrollview.  You can ramble on and on and on and on and on and on and on",
                        OkText = "Yes",
                        CancelText = "No"
                    })
                    .ToTask();
            });
        }


        public ICommand ActionSheet { get; }
        public ICommand Alert { get; }
        public ICommand Confirm { get; }
    }
}
