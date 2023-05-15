using STD.Domain.Map.MapForming;
using STD.Domain.Map.MapForming.Sections.SectionBuilders;
using STD.Domain.Map.MapForming.Sections.SectionContainer;
using STD.Domain.Map.MapForming.Sections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STD.SimpleTowerDefense.Views
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : UserControl
    {
        public MapWindow()
        {
            InitializeComponent();

            TestMap map = new(new SectionsContainerProxy<SquareSection>(new SquareSectionCalculator(), new SectionBuilder()));

            this.Content = map.UiContainer;

            //Debug.Print("check");

            //var testC = new Canvas()
            //{
            //    Width = 100,
            //    Height = 100,
            //    Background = Brushes.Black,
            //    Focusable = true,
            //};

            //testC.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => Debug.Print("testttt");
            //this.Content = testC;

            //this.Content = map.MapCanvas;
            //map.MapCanvas.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => Debug.Print("testttt");
            //this.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => Debug.Print("test yhis");

            //var canv = new Canvas
            //{
            //    Width = 200,
            //    Height = 200,
            //    Background = new SolidColorBrush(Colors.Red),
            //    Focusable = true,
            //};

            //canv.Style = (Style)this.Resources["SectionTriggers"];

            //this.Content = canv;
            //canv.GotFocus += ChangeColor;
            //canv.MouseMove += ChangeColor;
            //canv.ForceCursor = true;

            //this.Loaded += AfterLoad;

            //void ChangeColor(object sender, RoutedEventArgs eventArgs)
            //{
            //    (sender as Canvas).Background = new SolidColorBrush(Colors.Black);
            //}
        }

        private void AfterLoad(object sender, RoutedEventArgs args)
        {
            

            //this.AddChild(customCanvas);
        }
    }
}
