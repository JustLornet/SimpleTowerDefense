using NUnit.Framework;
using STD.Domain.Map.MapForming.Sections.SectionContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = System.Windows.Point;

namespace STD.Tests.Map
{
    [TestFixture]
    public class Calculator
    {
        [Test]
        public void CalculateSectionPosition_FirstPos()
        {
            //arrange

            var calculator = new SquareSectionCalculator();
            var mapSize = new Size(8, 4);
            var sectionSize = new Size(2, 1);
            var sectionNumber = 1;

            // act
            var sectionPos = calculator.CalculateSectionPosition(mapSize, sectionSize, sectionNumber);

            var expected = new Point(1, 0.5);

            Assert.AreEqual(expected, sectionPos);
        }
    }
}
