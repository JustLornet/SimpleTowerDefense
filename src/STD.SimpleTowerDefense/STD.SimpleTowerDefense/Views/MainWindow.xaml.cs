using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

        UserControl _testView;

        public MainWindow(IRegionManager regionManager, IContainerExtension container)
        {
            InitializeComponent();

            _regionManager = regionManager;
            _container = container;

            this.Loaded += Test_Loaded;
            //regionManager.RegisterViewWithRegion("TestContentRegion", typeof(TestWindow));
        }

        private void Test_Loaded (object sender, RoutedEventArgs e)
        {


            var testRegion = _regionManager.Regions["Map"];
            _testView = _container.Resolve<MapWindow>();
            testRegion.Add(_testView);
            //testRegion.Deactivate(_testView);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testRegion = _regionManager.Regions["TestContentRegion"];

            if (testRegion.ActiveViews.Any())
            {
                testRegion.Deactivate(_testView);
            }
            else
            {

                testRegion.Activate(_testView);
            }
        }
    }
}
