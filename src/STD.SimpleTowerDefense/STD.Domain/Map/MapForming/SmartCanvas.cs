using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace STD.Domain.Map.MapForming
{
    internal sealed class SmartCanvas
    {
        private Canvas _canvas;

        internal SmartCanvas(Size defaultSize)
        {
            _canvas = new Canvas()
            {
                Width = defaultSize.Width,
                Height = defaultSize.Height,
                Background = Brushes.Aquamarine,
            };

            Panel.SetZIndex(_canvas, 10);
        }

        internal Canvas Canvas
        {
            get => _canvas;
        }

        internal Size Size
        {
            get
            {
                return Canvas.RenderSize;
            }
            set
            {
                Canvas.Width = value.Width;
                Canvas.Height = value.Height;
            }
        }

        public static explicit operator Canvas(SmartCanvas sCanvas) => sCanvas.Canvas;
    }
}
