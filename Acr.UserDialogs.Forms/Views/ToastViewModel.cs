using System;
using System.Drawing;
using System.Windows.Input;


namespace Acr.UserDialogs.Forms.Views
{
    public class ToastViewModel
    {
        public string Message { get; set; }
        public Color MessageTextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Rg.Plugins.Popup.Enums.MoveAnimationOptions PositionIn { get; set; }
        public Rg.Plugins.Popup.Enums.MoveAnimationOptions PositionOut { get; set; }
        public ICommand Tap { get; set; }
    }
}
