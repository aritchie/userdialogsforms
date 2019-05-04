using System;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace Acr.UserDialogs.Forms.Views
{
    public abstract class ViewModel : ReactiveObject
    {
        public CompositeDisposable Disposer { get; } = new CompositeDisposable();


        [Reactive] public bool IsBusy { get; set; }
        //protected virtual void BindBusy(this IReactiveCommand command) => command
        //    .IsExecuting
        //    .Subscribe(
        //        _ => this.IsBusy = true,
        //        _ => this.IsBusy = false,
        //        () => this.IsBusy = false
        //    )
        //    .DisposeWith(this.Disposer);
    }
}
