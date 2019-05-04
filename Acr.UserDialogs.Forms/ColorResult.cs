using System;
using System.Drawing;


namespace Acr.UserDialogs.Forms
{
    public struct ColorResult
    {
        public ColorResult(Color? color) => this.SelectedColor = color;
        public bool Success => this.SelectedColor != null;
        public Color? SelectedColor { get; }
    }
}
