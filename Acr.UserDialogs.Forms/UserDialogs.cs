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
            var vm = new AlertViewModel
            {
                Title = config.Title,
                Message = config.Message,
                OkText = config.OkLabel ?? "OK",
                Ok = PopAction(() => tcs.TrySetResult(null))
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
            var vm = new AlertViewModel
            {
                Title = config.Title,
                Message = config.Message,
                OkText = config.OkLabel ?? "OK",
                CancelText = config.CancelLabel ?? "Cancel",
                Ok = PopAction(() => tcs.TrySetResult(true)),
                Cancel = PopAction(() => tcs.TrySetResult(false)),
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

                IsCancellable = config.IsCancellable,
                CancelLabel = config.CancelLabel ?? "Cancel",
                Cancel = PopAction(() => { }),
            };
            await PopupNavigation.Instance.PushAsync(new ActionSheetPage
            {
                BindingContext = vm
            });
        }


        public async Task<PromptResult> Prompt(PromptConfig config, CancellationToken cancelToken = default)
        {
            var tcs = new TaskCompletionSource<PromptResult>();
            var vm = new PromptViewModel
            {
                Title = config.Title,
                Message = config.Message,
                Value = config.CurrentValue ?? String.Empty,
                ValuePlaceholder = config.ValuePlaceholder ?? String.Empty,
                IsCancellable = config.IsCancellable,
                OkLabel = config.OkLabel ?? "OK",
                CancelLabel = config.CancelLabel ?? "Cancel"
            };
            vm.Ok = PopAction(() => tcs.TrySetResult(new PromptResult(true, vm.Value.Trim())));
            vm.Cancel = PopAction(() => tcs.TrySetResult(new PromptResult(true, vm.Value.Trim())));

            await PopupNavigation.Instance.PushAsync(new PromptPage
            {
                BindingContext = vm
            });
            return await tcs.Task;
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
