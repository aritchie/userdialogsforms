using System;
using Xamarin.Forms;


namespace Acr.UserDialogs.Forms
{
    public class ActionSheetItem
    {
        public ActionSheetItem(string title, Action action, ImageSource icon = null)
        {
            this.Title = title;
            this.Action = action;
            this.Icon = icon;
        }


        public ImageSource Icon { get; }
        public string Title { get; }
        public Action Action { get; }
    }
}
