using System;


namespace Samples.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Rg.Plugins.Popup.Popup.Init();
            this.LoadApplication(new Samples.App());
        }
    }
}
