using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using STD.Domain.Map.MapForming.Sections.SectionBuilders;

namespace STD.Domain.Map.MapForming.Sections.SectionContainer
{
    /// <summary>
    /// Отвечает за поддержание всех секций в актульном состоянии - они должны быть созданы и иметь верный размер в зав-ти от карты
    /// </summary>
    internal sealed class SectionsContainerProxy<TSection> : ISectionsContainer, ISectionsContainerController where TSection : SectionBase
    {
        private SectionsContainer _container = null!;

        private readonly IMapCalculator _sectionCalculator;

        private Size _mapSize;

        private int _sectionsAmount;

        private Canvas? _canvas;

        /// <summary>
        /// Индикатор того, что свойства, необходимые для создания контейнера уже были установлены
        /// Свойство можно установить лишь раз
        /// </summary>
        private bool _isParamsSet = false;

        private readonly SectionBuilder _sectionBuilder;

        internal SectionsContainerProxy(IMapCalculator sectionCalculator, SectionBuilder sectionBuilder)
        {
            _sectionCalculator = sectionCalculator;
            _sectionBuilder = sectionBuilder;
        }

        public SectionBase[,] Sections => _isParamsSet ? _container.Sections :
            throw new OperationCanceledException("Сначала необходимо установить параметры для заполнения контейнера");

        public SectionBase Section(Point point) => _isParamsSet ? _container.Section(point) :
            throw new OperationCanceledException("Сначала необходимо установить параметры для заполнения контейнера");

        public SectionBase Section(int rowNumber, int columnNumber) => _isParamsSet ? _container.Section(rowNumber, columnNumber) :
            throw new OperationCanceledException("Сначала необходимо установить параметры для заполнения контейнера");

        public void InitContainer(Size mapSize, int sectionsAmount, Canvas canvas)
        {
            if (_isParamsSet)
                return;

            _mapSize = mapSize;
            _canvas = canvas ?? throw new ArgumentNullException("Canvas не может быть null");
            _sectionsAmount = sectionsAmount;

            _isParamsSet = true;
            FillContainer();
        }

        private void FillContainer()
        {
            if (!_isParamsSet)
                throw new ArgumentException("Перед заполнением контейнера необходимо установить все его свойства");

            Size sectionSize = _sectionCalculator.CalculateSectionSize(_mapSize, _sectionsAmount);

            var columnsAmount = _sectionCalculator.CalculateColumnsAmount(_mapSize, sectionSize);
            var rowsAmount = _sectionCalculator.CalculateRowsAmount(_mapSize, sectionSize);

            var sections = new SectionBase[rowsAmount, columnsAmount];

            for (int i = 0; i < columnsAmount; i++)
            {
                for (int j = 0; j < rowsAmount; j++)
                {
                    var section = _sectionBuilder.SetType(typeof(TSection)).SetInitSize(sectionSize).AddSectionToCanvas(_canvas!).Build(j, i);

                    sections[j, i] = section;
                }
            }

            _container = new(sections);
        }

        void ISectionsContainerController.Access(MapBase map)
        {
            if(map.MapCanvas is null)
                throw new ArgumentNullException("Canvas не может быть null");

            InitContainer(map.MapSize, (int)map.SectionsAmount, (Canvas)map.MapCanvas);
        }
    }
}
