using STD.Domain.Map.MapForming;
using STD.Domain.Tower.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace STD.Domain.Tower
{
    internal abstract class TowerBase
    {
        private Image _towerImg;

        internal TowerBase()
        {
            // TODO: переделать передачу изображения
            // учитывать ширину и высоту
            _towerImg = new Image()
            {
                Source = new BitmapImage(new Uri(TowerImgPath)),
                Width = 50,
                Height = 50,
            };
        }

        internal abstract HitPoints HitPoints { get; }

        internal abstract string TowerImgPath { get; }
    }
}
