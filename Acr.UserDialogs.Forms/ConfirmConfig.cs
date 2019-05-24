using System;


namespace Acr.UserDialogs.Forms
{
    public class ConfirmConfig : AlertConfig
    {
        public string CancelLabel { get; set; }


        public ConfirmConfig SetTitle(string title)
        {
            this.Title = title;
            return this;
        }


        public ConfirmConfig SetMessage(string message)
        {
            this.Message = message;
            return this;
        }


        public ConfirmConfig UseYesNo()
        {
            this.OkLabel = "Yes";
            this.CancelLabel = "No";
            return this;
        }
    }
}
