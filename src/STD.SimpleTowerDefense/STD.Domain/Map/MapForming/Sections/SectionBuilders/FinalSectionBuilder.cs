using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace STD.Domain.Map.MapForming.Sections.SectionBuilders
{
    internal sealed class FinalSectionBuilder
    {
        private Type _sectionType;

        private Size _sectionSize;

        private Canvas _canvas = null!;

        internal FinalSectionBuilder(Type sectionType, Size sectionSize, Canvas canvas)
        {
            _sectionSize = sectionSize;
            _canvas = canvas;
            _sectionType = sectionType;
        }

        internal SectionBase Build(int row, int column)
        {
            var newSection = SectionTypeFactory.CreateSection(_sectionType, _canvas, (row, column));
            newSection.Size = _sectionSize;

            return newSection;
        }
    }
}
