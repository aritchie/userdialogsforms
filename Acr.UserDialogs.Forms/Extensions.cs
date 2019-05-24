using System;
using System.Threading.Tasks;


namespace Acr.UserDialogs.Forms
{
    public static class Extensions
    {
        public static Task Alert(this IUserDialogs dialogs, string message, string title = null, string okText = null)
            => dialogs.Alert(new AlertConfig
            {
                Title = title,
                Message = message
            });


        public static Task<bool> Confirm(this IUserDialogs dialogs, string message, string title = null, string okText = null, string cancelText = null)
            => dialogs.Confirm(new ConfirmConfig
            {
                Title = title,
                Message = message,
                OkText = okText,
                CancelText = cancelText
            });


        public static void Toast(this IUserDialogs dialogs, string message, TimeSpan? timeSpan = null, Action onTap = null)
            => dialogs.Toast(new ToastConfig
            {
                Message = message,
                DisplayTime = timeSpan ?? TimeSpan.FromSeconds(3),
                OnTap = onTap
            });
    }
}
