using System;


namespace Acr.UserDialogs.Forms
{
    public class ProgressConfig
    {
        // TODO: allow cancel from here?
        public Action Tap { get; set; }
        public string Message { get; set; }
        public bool IsDeterministic { get; set; }
        public double Value { get; set; }
    }
}
