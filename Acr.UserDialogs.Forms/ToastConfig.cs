using System;
using System.Drawing;
using Rg.Plugins.Popup.Pages;


namespace Acr.UserDialogs.Forms
{
    public class ToastConfig
    {
        //public static PopupPage GetPage { get; set; }
        //public void Close
        public Action OnTap { get; set; }
        public Color BackgroundColor { get; set; } = Color.Black;
        public Color MessageTextColor { get; set; } = Color.White;
        public string Message { get; set; }
        public TimeSpan DisplayTime { get; set; } = TimeSpan.FromSeconds(3);
        public ToastPosition Position { get; set; } = ToastPosition.Bottom;
    }
}
