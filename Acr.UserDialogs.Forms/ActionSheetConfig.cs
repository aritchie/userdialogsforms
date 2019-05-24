using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Acr.UserDialogs.Forms
{
    public class ActionSheetConfig
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string CancelLabel { get; set; }
        public bool IsCancellable { get; set; }


        public ActionSheetConfig AddCancel(string cancelLabel = null)
        {
            this.IsCancellable = true;
            this.CancelLabel = cancelLabel;
            return this;
        }


        public List<ActionSheetItem> Items { get; set; } = new List<ActionSheetItem>();
        public ActionSheetConfig Add(string title, Action action, ImageSource icon = null)
        {
            this.Items.Add(new ActionSheetItem(title, action, icon));
            return this;
        }


        public ActionSheetConfig SetTitle(string title)
        {
            this.Title = title;
            return this;
        }


        public ActionSheetConfig SetMessage(string message)
        {
            this.Message = message;
            return this;
        }
    }
}
