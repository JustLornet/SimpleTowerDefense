using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace STD.SimpleTowerDefense.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        private UserControl _view;

        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        public string TestTitle => "dsflksdfskdf";

        public DelegateCommand TestCommand => new DelegateCommand(() =>
        {
            if (_view is null)
            {
                _view = (UserControl)_regionManager.Regions.First().Views.First();
            }

            var region = _regionManager.Regions.First();

            if (region.ActiveViews.Any())
            {
                region.Deactivate(_view);
            }
            else
            {
                region.Activate(_view);
            }
        } );
    }
}
