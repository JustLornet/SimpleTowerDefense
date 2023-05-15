using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace STD.Domain.Map.MapForming.Sections.SectionBuilders
{
    internal static class SectionTypeFactory
    {
        private static readonly Dictionary<Type, Func<Canvas, (int, int), SectionBase>> _sectionsCreator = new();

        static SectionTypeFactory()
        {
            _sectionsCreator[typeof(SquareSection)] = delegate (Canvas canvas, (int, int) matrixPosition)
            {
                return new SquareSection(canvas, matrixPosition);
            };
        }

        internal static SectionBase CreateSection(Type sectionType, Canvas canvas, (int, int) matrixPosition)
        {
            return _sectionsCreator[sectionType](canvas, matrixPosition);
        }
    }
}
