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
    }
}
