using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Domain.Map.MapForming.Sections.SectionContainer
{
    /// <summary>
    /// Отображает все имеющиеся секции из логики: координаты центра секции - сама секция
    /// Управляет передачей секций
    /// </summary>
    internal sealed class SectionsContainer : ISectionsContainer
    {
        private readonly SectionBase[,] _sectionsMatrix;

        internal SectionsContainer(SectionBase[,] sections)
        {
            _sectionsMatrix = sections;
        }

        internal int Count
        {
            get => _sectionsMatrix.Length;
        }

        public SectionBase[,] Sections => _sectionsMatrix.Length > 0 ? _sectionsMatrix :
            throw new OperationCanceledException("Контейнер не заполнен");

        public SectionBase Section(Point point)
        {
            if (_sectionsMatrix.Length == 0)
                throw new OperationCanceledException("Контейнер не заполнен");

            foreach (var section in _sectionsMatrix)
            {
                if (section.Coordinates.Equals(point))
                    return section;
            }

            throw new InvalidOperationException("Секции по этому адресу не существует");
        }

        public SectionBase Section(int rowNumber, int columnNumber)
        {
            if(_sectionsMatrix.Length == 0)
                throw new OperationCanceledException("Контейнер не заполнен");

            var searchingSection = _sectionsMatrix[rowNumber, columnNumber];

            if (searchingSection is null)
                throw new InvalidOperationException("Секции по этому адресу не существует");

            return searchingSection;
        }
    }
}
