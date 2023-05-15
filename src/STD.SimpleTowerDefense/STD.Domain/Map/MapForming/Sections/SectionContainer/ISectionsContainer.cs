using System.Collections.Generic;
using System.Windows;

namespace STD.Domain.Map.MapForming.Sections.SectionContainer
{
    internal interface ISectionsContainer
    {
        public SectionBase[,] Sections { get; }

        public SectionBase Section(Point point);

        public SectionBase Section(int rowNumber, int columnNumber);
    }
}