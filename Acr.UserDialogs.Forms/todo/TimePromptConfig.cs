using System;


namespace Acr.UserDialogs.Forms
{
    public class TimePromptConfig
    {
        public string Title { get; set; }
        public TimeSpan? MinTime { get; set; }
        public TimeSpan? MaxTime { get; set; }
        public TimeSpan? SelectedTime { get; set; }
    }
}
