using System;
using System.Windows;

namespace STD.Domain.Map.MapForming
{
    internal sealed class MapSize
    {
        private Size _size;

        internal MapSize(double width, double height)
        {
            Size = new(width, height);
        }

        internal MapSize(Size size)
        {
            Size = size;
        }

        internal bool IsValid => _size.Width > 0 && _size.Height > 0;


        internal Size Size
        {
            get
            {
                if(!IsValid)
                    throw new OperationCanceledException($"Отсутствует корректный размер: {this}");

                return _size;
            }
            set
            {
                if (value is Size parsedValue)
                {
                    if (value.Width == 0 || value.Height == 0)
                        throw new OperationCanceledException("Неверный размер");

                    _size = value;
                    SizeChanged?.Invoke(value);

                    return;
                }

                throw new InvalidOperationException("Передаваоемый тип не является Size");
            }
        }

        /// <summary>
        /// Событие изменение размера. В аргумнетах передает новый размер
        /// </summary>
        internal event Action<Size>? SizeChanged;

        public static explicit operator Size (MapSize mapSize) => mapSize.Size;

        public override string ToString()
        {
            return $"Width - {_size.Width}, Height - {_size.Height}";
        }
    }
}