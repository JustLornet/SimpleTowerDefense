using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STD.Domain.Map.MapForming.Sections
{
    internal class SquareSectionCalculator : IMapCalculator
    {
        public Size CalculateSectionSize(Size mapSize, int sectionsAmount)
        {
            var mapSpace = mapSize.Width * mapSize.Height;
            double sectionDimension = Math.Sqrt((double)(mapSpace / sectionsAmount));
            var parsedSectionDimension = sectionDimension;

            return new Size(parsedSectionDimension, parsedSectionDimension);
        }
    }
}
