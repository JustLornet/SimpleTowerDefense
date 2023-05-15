using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STD.Domain.Tower.ValueObjects
{
    /// <summary>
    /// Инициализация типа, отвечающего за контроль хп сущности
    /// </summary>
    internal sealed class HitPoints
    {
        private int _actualHitPoints;

        private int _maxHitPoints;

        private int _minHitPoints = 0;

        /// <summary>
        /// Актульаное кол-во ХП приравнивается к максимальному
        /// </summary>
        /// <param name="maxHitPoints">Максимальное кол-во ХП</param>
        /// <exception cref="ArgumentException"></exception>
        internal HitPoints(int maxHitPoints)
        {
            if (maxHitPoints <= 0)
                throw new ArgumentException("Значение хп не может принимать переданные значения");

            _actualHitPoints = maxHitPoints;
            _maxHitPoints = maxHitPoints;
        }

        internal HitPoints(int maxHitPoints, int actualHitPoints)
        {
            if(maxHitPoints <= 0 && actualHitPoints < 0)
            {
                throw new ArgumentException("Значение хп не может принимать переданные значения");
            }

            _actualHitPoints = actualHitPoints;
            _maxHitPoints = maxHitPoints;
        }

        internal HitPoints(int minHitPoints, int maxHitPoints, int actualHitPoints) : this(maxHitPoints, actualHitPoints)
        {
            if (minHitPoints < 0)
            {
                throw new ArgumentException("Значение хп не может принимать переданные значения");
            }

            _minHitPoints = minHitPoints;
        }

        internal void SetNewHp(int hp)
        {
            if (CheckHpValueValid(hp))
            {
                if(hp != _actualHitPoints)
                {
                    HitPointsChanged?.Invoke(_actualHitPoints - hp);

                    _actualHitPoints = hp;
                 
                    HitPointsGetNewValue?.Invoke(_actualHitPoints);

                    if (_actualHitPoints == _minHitPoints)
                        HpIsMinimalHandler?.Invoke();
                }
            }
        }

        internal int ActualHP
        {
            get => _actualHitPoints;
        }

        /// <summary>
        /// Событие изменение величины хп. В аргументах передает новое значение ХП
        /// </summary>
        internal event Action<int>? HitPointsGetNewValue;

        /// <summary>
        /// Событие изменение ХП. В аргументах указывает разницу в хп
        /// </summary>
        internal event Action<int>? HitPointsChanged;

        /// <summary>
        /// ХП существа стало равно его минимальному кол-ву ХП. Смэрть?
        /// </summary>
        internal event Action? HpIsMinimalHandler;

        public static explicit operator int (HitPoints hitPoints)
        {
            return hitPoints.ActualHP;
        }

        private bool CheckHpValueValid(int hp)
        {
            if (hp >= _minHitPoints && hp <= _maxHitPoints)
            {
                return true;
            }

            return false;
        }
    }
}
