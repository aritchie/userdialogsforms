using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs.Forms.Views;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;


namespace Acr.UserDialogs.Forms
{
    public class UserDialogs : IUserDialogs
    {
        public async Task Alert(AlertConfig config, CancellationToken cancelToken = default)
        {
            var tcs = new TaskCompletionSource<object>();
            var popped = false;
            var vm = new AlertViewModel
            {
                Title = config.Title,
                Message = config.Message,
                OkText = config.OkText,
                Ok = PopAction(() =>
                {
                    if (popped)
                        return;

                    popped = true;
                    tcs.TrySetResult(null);
                }),
            };
            await PopupNavigation.Instance.PushAsync(new AlertPage
            {
                BindingContext = vm
            });

            await tcs.Task;
        }


        public async Task<bool> Confirm(ConfirmConfig config, CancellationToken cancelToken = default)
        {
            var tcs = new TaskCompletionSource<bool>();
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
                    tcs.TrySetResult(true);
                }),
                Cancel = PopAction(() =>
                {
                    popped = true;
                    tcs.TrySetResult(false);
                }),
            };

            await PopupNavigation.Instance.PushAsync(new AlertPage
            {
                BindingContext = vm
            });

            return await tcs.Task;
        }


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


        public Task<PromptResult> Prompt(PromptConfig config, CancellationToken cancelToken = default)
        {
            throw new NotImplementedException();
        }

        public void Login(LoginConfig config)
        {
            throw new NotImplementedException();
        }

        public void Progress(ProgressConfig config)
        {
            throw new NotImplementedException();
        }

        public async void Toast(ToastConfig config)
        {
            var vm = new ToastViewModel
            {
                Message = config.Message,
                MessageTextColor = config.MessageTextColor,
                BackgroundColor = config.BackgroundColor,
                PositionIn = config.Position == ToastPosition.Top
                    ? MoveAnimationOptions.Top
                    : MoveAnimationOptions.Bottom,
                Tap = PopAction(() =>
                    config.OnTap?.Invoke()
                )
            };
            var toast = new ToastPage
            {
                BindingContext = vm
            };
            await PopupNavigation.Instance.PushAsync(toast);

            Task.Delay(config.DisplayTime)
                .ContinueWith(_ => Pop());
        }


        static void Pop() => Device.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                    await PopupNavigation.Instance.PopAsync();
            }
            catch
            {
                // swallow
            }
        });


        static ICommand PopAction(Action postAction) => new Command(
            () => Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await PopupNavigation.Instance.PopAsync();
                }
                catch
                {
                    // swallow
                }
                postAction();
            })
        );
    }
}
