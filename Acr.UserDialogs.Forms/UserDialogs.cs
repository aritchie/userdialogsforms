using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Acr.UserDialogs.Forms.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;


namespace Acr.UserDialogs.Forms
{
    public class UserDialogs : IUserDialogs
    {
        public IObservable<Unit> Alert(AlertConfig config) => Observable.Create<Unit>(async ob =>
        {
            var popped = false;
            var vm = new AlertViewModel
            {
                Title = config.Title,
                Message = config.Message,
                OkText = config.OkText,
                Ok = PopAction(() =>
                {
                    popped = true;
                    ob.OnNext(Unit.Default);
                    ob.OnCompleted();
                }),
            };
            await PopupNavigation.Instance.PushAsync(new AlertPage
            {
                BindingContext = vm
            });

            return () =>
            {
                if (!popped)
                    Pop();
            };
        });


        public IObservable<bool> Confirm(ConfirmConfig config) => Observable.Create<bool>(async ob =>
        {
            //if (useYesNo)
            //{
            //    cancel = this.localize["No"];
            //    ok = this.localize["Yes"];
            //}
            var popped = false;
            var vm = new AlertViewModel
            {
                Title = config.Title,
                Message = config.Message,
                OkText = config.OkText,
                CancelText = config.CancelText,
                Ok = PopAction(() =>
                {
                    popped = true;
                    ob.OnNext(true);
                    ob.OnCompleted();
                }),
                Cancel = PopAction(() =>
                {
                    popped = true;
                    ob.OnNext(false);
                    ob.OnCompleted();
                }),
            };
            await PopupNavigation.Instance.PushAsync(new AlertPage
            {
                BindingContext = vm
            });

            return () =>
            {
                if (!popped)
                    Pop();
            };
        });


        public async void ActionSheet(ActionSheetConfig config)
        {
            var vm = new ActionSheetViewModel
            {
                Title = config.Title,
                Message = config.Message,
                Items = config
                    .Items
                    .Select(x => new ActionSheetItemViewModel
                    {
                        Text = x.Title,
                        Icon = x.Icon,
                        Action = PopAction(x.Action)
                    })
                    .ToList(),

                CancelText = "Cancel",
                Cancel = PopAction(() => { }),

                OkText = "Ok",
                Ok = PopAction(() => { })
            };
            await PopupNavigation.Instance.PushAsync(new ActionSheetPage
            {
                BindingContext = vm
            });
        }


        static void Pop() => Device.BeginInvokeOnMainThread(async () => await PopupNavigation.Instance.PopAsync());


        static ICommand PopAction(Action postAction) => new Command(
            () => Device.BeginInvokeOnMainThread(async () =>
            {
                await PopupNavigation.Instance.PopAsync();
                postAction();
            })
        );
    }
}
