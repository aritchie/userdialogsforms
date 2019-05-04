using System;
using Xamarin.Forms;


namespace Acr.UserDialogs.Forms.Views
{
    public class ToastViewModel : ViewModel
    {
        public double Progress { get; set; }
        public TimeSpan TimeToShow { get; set; }
        public ImageSource Icon { get; set; }
        public Color BackgroundColor { get; set; } = Color.White;
    }
}
