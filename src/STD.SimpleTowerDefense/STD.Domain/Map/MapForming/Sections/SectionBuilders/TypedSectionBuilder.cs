using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace STD.Domain.Map.MapForming.Sections.SectionBuilders
{
    internal sealed class TypedSectionBuilder
    {
        private Type _sectionType;

        private Size _sectionSize;

        private Canvas _canvas = null!;

        internal TypedSectionBuilder(Type sectionType) 
        {
            _sectionType = sectionType;
        }

        internal TypedSectionBuilder SetInitSize(Size size)
        {
            _sectionSize = size;

            return this;
        }

        internal FinalSectionBuilder AddSectionToCanvas(Canvas canvas)
        {
            _canvas = canvas;

            return new FinalSectionBuilder(_sectionType, _sectionSize, _canvas);
        }
    }
}
