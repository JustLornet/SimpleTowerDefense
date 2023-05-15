using STD.Domain.Tower.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Domain.Tower
{
    internal class TestTower : TowerBase
    {
        internal override HitPoints HitPoints => new(100);

        internal override string TowerImgPath => @"C:\Projects\SimpleTowerDefense\src\STD.SimpleTowerDefense\Images\Towers\TestTower";
    }
}
