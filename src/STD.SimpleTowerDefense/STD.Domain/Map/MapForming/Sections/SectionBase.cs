using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace STD.Domain.Map.MapForming.Sections
{
    internal abstract class SectionBase
    {
        private readonly Canvas _parentCanvas;
        protected readonly Shape _coreComponent;

        /// <summary>
        /// Автоматическое добавление экзмепляра к Canvas
        /// </summary>
        /// <param name="canvas"></param>
        protected SectionBase(Canvas canvas, Shape uiElement, (int row, int column) matrixPosition)
        {
            _parentCanvas = canvas;
            _coreComponent = uiElement;

            //TODO: настройки цвета и пр. отображение переделать в тип наподобие options, который передавать через конструктор
            // для дальнейшей кастомизации карты
            _coreComponent.StrokeThickness = 1;
            _coreComponent.Stroke = Brushes.Gray;
            Panel.SetZIndex(_coreComponent, 100);

            _coreComponent.MouseEnter += delegate
            {
                _coreComponent.Fill = Brushes.LightGreen;
                _coreComponent.Opacity = 0.4;
                _coreComponent.Stroke = Brushes.Green;
            };
            _coreComponent.MouseLeave += delegate
            {
                _coreComponent.Fill = null;
                _coreComponent.Opacity = 1;
                _coreComponent.Stroke = Brushes.Gray;
            };

            _parentCanvas.Children.Add(_coreComponent);

            Position = new(matrixPosition);
            SizeChangedHandler += Position.SetCoordinatesViaSize;
            Position.PositionChangedHandler += ActualizePositionOnCanvas;
        }

        /// <summary>
        /// Задает или отображает текущее положение секции (без изменения размера)
        /// </summary>
        internal Point Coordinates => Position.Coordinates;

        internal virtual Size Size
        {
            get
            {
                return _coreComponent.RenderSize;
            }
            set
            {
                _coreComponent.Width = value.Width;
                _coreComponent.Height = value.Height;

                SizeChangedHandler?.Invoke(value);
            }
        }

        internal Position Position = null!;

        private void ActualizePositionOnCanvas(Point point)
        {
            Canvas.SetLeft(_coreComponent, point.X);
            Canvas.SetTop(_coreComponent, point.Y);
        }

        private event Action<Size> SizeChangedHandler;
    }
}
