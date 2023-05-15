using STD.Domain.Map.MapForming.Sections;
using STD.Domain.Map.MapForming.Sections.SectionBuilders;
using STD.Domain.Map.MapForming.Sections.SectionContainer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace STD.Domain.Map.MapForming
{
    internal class TestMap : MapBase
    {
        internal TestMap(ISectionsContainer sectionContainer) : base(sectionContainer)
        {
            // костыль - .NET создает экземпляр SectionContainer только после того, как он понадобится (что наподобие лениваости)
            // должно уйти после перехода на призму и создание объектов через DI контейнеры в конструкторе
            // TODO: исправить
            //var sections = SectionContainer.Sections;
        }

        internal override SectionsAmount SectionsAmount => new(81);

        protected override MapSize DefaultMapSize => new(500, 500);

        protected override string ImgPath => @"C:\Projects\SimpleTowerDefense\src\STD.SimpleTowerDefense\Images\Maps\TestMap";
    }
}