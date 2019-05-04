using System;


namespace Acr.UserDialogs.Forms
{
    public class PromptResult
    {
        public PromptResult(bool ok, string value)
        {
            this.Ok = ok;
            this.Value = value;
        }


        public bool Ok { get; }
        public string Value { get; }
    }
}
