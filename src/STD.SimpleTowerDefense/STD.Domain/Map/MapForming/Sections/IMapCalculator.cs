
using System;
using System.Windows;

namespace STD.Domain.Map.MapForming.Sections
{
    internal interface IMapCalculator
    {
        public Size CalculateSectionSize(Size mapSize, int sectionsAmount);

        public int CalculateColumnsAmount(Size mapSize, Size sectionSize)
        {
            int columns = (int)Math.Ceiling(mapSize.Height / sectionSize.Height);

            return columns;
        }

        public int CalculateRowsAmount(Size mapSize, Size sectionSize)
        {
            int columns = (int)Math.Ceiling(mapSize.Width / sectionSize.Width);

            return columns;
        }
    }
}