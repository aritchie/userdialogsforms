using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Acr.UserDialogs.Forms
{
    public class ActionSheetConfig
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public List<ActionSheetItem> Items { get; set; } = new List<ActionSheetItem>();
        public ActionSheetConfig AddAction(string title, Action action, ImageSource icon = null)
        {
            this.Items.Add(new ActionSheetItem(title, action, icon));
            return this;
        }
    }
}
