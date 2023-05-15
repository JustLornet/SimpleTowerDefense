using System.Windows;
using System;

namespace STD.Domain.Map.MapForming.Sections
{
    internal sealed class Position
    {
        private Point _coordinates;

        private int _columnNumber;

        private int _rowNumber;

        internal Position((int row, int column) matrixPos)
        {
            _rowNumber = matrixPos.row;
            _columnNumber = matrixPos.column;
        }

        internal void SetCoordinatesViaSize(Size sectionsSize)
        {
            double x = sectionsSize.Width * _columnNumber;
            double y = sectionsSize.Height * _rowNumber;

            Coordinates = new Point(x, y);
        }

        internal Point Coordinates
        {
            get
            {
                if (_coordinates != default)
                    return _coordinates;

                throw new OperationCanceledException($"Для задания координат сначала треубется вызвать метод {nameof(SetCoordinatesViaSize)}");
            }
            private set
            {
                _coordinates = value;
                PositionChangedHandler?.Invoke(value);
            }
        }

        internal event Action<Point>? PositionChangedHandler;
    }
}