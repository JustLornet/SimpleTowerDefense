using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace STD.Domain.Map.MapForming.Sections
{
    internal sealed class SquareSection : SectionBase
    {
        internal SquareSection(Canvas canvas, (int, int) matrixPosition) : base(canvas, new Rectangle(), matrixPosition) { }

        internal override Size Size
        {
            get
            {
                return _coreComponent.RenderSize;
            }
            set
            {
                if (value.Width != value.Height)
                    throw new ArgumentException("Для данного типа размер должен быть симметричным");

                base.Size = value;
            }
        }
    }
}
