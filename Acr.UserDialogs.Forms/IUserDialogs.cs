using System;
using System.Reactive;


namespace Acr.UserDialogs.Forms
{
    public interface IUserDialogs
    {
        void ActionSheet(ActionSheetConfig config);
        IObservable<Unit> Alert(AlertConfig config);
        IObservable<bool> Confirm(ConfirmConfig config);
        //IObservable<PromptResult> Prompt(PromptConfig config);
    }
}
