using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Domain.Map.MapForming.Sections.SectionBuilders
{
    internal sealed class SectionBuilder
    {
        private Type _sectionType = null!;

        internal TypedSectionBuilder SetType(Type type)
        {
            _sectionType = type;

            return new TypedSectionBuilder(_sectionType);
        }
    }
}
