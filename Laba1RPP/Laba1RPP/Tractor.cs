using System;
namespace Laba1RPP
{
    public class EntityTractor
    {
        /// <summary>
        /// Скорость
        /// </summary>
        public int Speed { get; private set; }
        /// <summary>
        /// Вес
        /// </summary>
        public float Weight { get; private set; }
        /// <summary>
        /// Цвет кузова
        /// </summary>
        public Color BodyColor { get; private set; }
        /// <summary>
        /// Шаг перемещения автомобиля
        /// </summary>
        public float Step => Speed * 100 / Weight;
        /// <summary>
        /// Инициализация полей объекта-класса автомобиля
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="weight"></param>
        /// <param name="bodyColor"></param>
        /// <returns></returns>
        public void Init(int speed, float weight, Color bodyColor)
        {
            Random rnd = new();
            Speed = speed <= 0 ? rnd.Next(50, 150) : speed;
            Weight = weight <= 0 ? rnd.Next(40, 70) : weight;
            BodyColor = bodyColor;
        }
    }

}
