using System;
using System.Reactive;


namespace Acr.UserDialogs.Forms
{
    public interface IUserDialogs
    {
        IObservable<Unit> Alert(AlertConfig config);
        IObservable<bool> Confirm(ConfirmConfig config);
        //IObservable<PromptResult> Prompt(PromptConfig config);

        //void ActionSheet(ActionSheetConfig config);

    }
}
