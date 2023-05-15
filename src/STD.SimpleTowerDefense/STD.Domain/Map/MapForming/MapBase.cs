using STD.Domain.Map.MapForming.Sections.SectionContainer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace STD.Domain.Map.MapForming
{
    internal abstract class MapBase
    {
        // размер карты в зависимости от размера окна
        private MapSize _mapSize;

        private ContentControl _uiContainer = new();

        private ISectionsContainer _sectionContainer { get; }

        protected abstract string ImgPath { get; }

        protected abstract MapSize DefaultMapSize { get; }

        internal MapBase(ISectionsContainer sectionContainer)
        {
            _sectionContainer = sectionContainer;            

            MapCanvas = new((Size)DefaultMapSize);
            
            //TODO: реализовать присвоение изображения нормально
            ((Canvas)MapCanvas).Children.Add(new Image()
            {
                Source = new BitmapImage(new Uri(ImgPath)),
                Width = MapSize.Width,
                Height = MapSize.Height,
            });
            
            // проверяем, если в качетсве контейнера передан объект для создания и контроля секций,
            // а не мок для тестов, вызываем метод access для доинициации - передачи доп параметров
            if (sectionContainer is ISectionsContainerController containerController)
                containerController.Access(this);
            
            _mapSize!.SizeChanged += ChangeCanvasSize;

            _uiContainer.Content = (Canvas)MapCanvas;
        }

        internal ISectionsContainer SectionContainer
        {
            get => _sectionContainer;
        }

        internal SmartCanvas MapCanvas { get; }

        internal abstract SectionsAmount SectionsAmount { get; }

        internal Size MapSize
        {
            get => _mapSize.IsValid ? (Size)_mapSize : (Size)DefaultMapSize;
            set => _mapSize.Size = value;
        }

        internal ContentControl UiContainer
        {
            get
            {
                var isWrongType = _uiContainer.Content is null || _uiContainer.Content is not Canvas;
                var isNoChildren = _uiContainer.Content is Canvas canvas && canvas.Children.Count == 0;

                if (isWrongType || isNoChildren)
                    throw new InvalidOperationException("Ошибка контейнера. Контейнер секций не готов");

                return _uiContainer;
            }
        }

        internal void ChangeCanvasSize(Size size)
        {
            MapCanvas.Size = size;
        }
    }
}
