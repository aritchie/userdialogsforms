using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace Acr.UserDialogs.Forms.Views
{
    public class ColorPickerViewModel : ViewModel
    {
        public ColorPickerViewModel()
        {
            this.selectedColor = this.WhenAnyValue(x => x.HexValue)
                .Skip(1)
                .Where(x => x.Length == 3 || x.Length == 6)
                .Select(Color.FromHex)
                .ToProperty(this, x => x.SelectedColor);

            this.HexValue = Color.White.ToString();
        }


        [Reactive] public string HexValue { get; set; }


        readonly ObservableAsPropertyHelper<Color> selectedColor;
        public Color SelectedColor => this.selectedColor.Value;
    }
}
