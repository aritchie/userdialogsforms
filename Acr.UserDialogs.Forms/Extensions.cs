using System;
using System.Reactive;


namespace Acr.UserDialogs.Forms
{
    public static class Extensions
    {
        public static IObservable<Unit> Alert(this IUserDialogs dialogs, string message, string title = null, string okText = null)
            => dialogs.Alert(new AlertConfig
            {
                Title = title,
                Message = message
            });


        public static IObservable<bool> Confirm(this IUserDialogs dialogs, string message, string title = null, string okText = null, string cancelText = null)
            => dialogs.Confirm(new ConfirmConfig
            {
                Title = title,
                Message = message,
                OkText = okText,
                CancelText = cancelText
            });
    }
}
