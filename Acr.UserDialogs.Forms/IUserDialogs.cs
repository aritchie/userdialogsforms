using System;
using System.Threading;
using System.Threading.Tasks;

namespace Acr.UserDialogs.Forms
{
    public interface IUserDialogs
    {


        Task Alert(AlertConfig config, CancellationToken cancelToken = default);
        Task<bool> Confirm(ConfirmConfig config, CancellationToken cancelToken = default);
        Task<PromptResult> Prompt(PromptConfig config, CancellationToken cancelToken = default);
        void Login(LoginConfig config);
        //Task<ColorResult> PickColor(ColorPickerConfig config, CancellationToken cancelToken = default);
        //Task<DatePromptResult> DatePrompt(DatePromptConfig config, CancellationToken? cancelToken = default);
        //Task<TimePromptResult> TimePrompt(TimePromptConfig config, CancellationToken? cancelToken = default);

        void ActionSheet(ActionSheetConfig config);
        void Progress(ProgressConfig config);
        void Toast(ToastConfig config);
    }
}
