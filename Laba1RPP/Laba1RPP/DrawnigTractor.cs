using System;

namespace Laba1RPP
{
    internal class DrawningTractor
    {
        /// <summary>
        /// Класс-сущность
        /// </summary>
        public EntityTractor? EntityTractor { get; private set; }
        /// <summary>
        /// Ширина окна
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Левая координата прорисовки автомобиля
        /// </summary>
        private int _startPosX;
        /// <summary>
        /// Верхняя кооридната прорисовки автомобиля
        /// </summary>
        private int _startPosY;
        /// <summary>
        /// Ширина прорисовки автомобиля
        /// </summary>
        private readonly int _tractorWidth = 80;
        /// <summary>
        /// Высота прорисовки автомобиля
        /// </summary>
        private readonly int _tractorHeight = 60;
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="bodyColor">Цвет кузова</param>
        /// <param name="additionalColor">Дополнительный цвет</param>
        /// <param name="bodyKit">Признак наличия обвеса</param>
        /// <param name="wing">Признак наличия антикрыла</param>
        /// <param name="sportLine">Признак наличия гоночной полосы</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        /// <returns>true - объект создан, false - проверка не пройдена,нельзя создать объект в этих размерах</returns>
        public bool Init(int speed, double weight, Color bodyColor, Color
additionalColor, bool bodyKit, bool wing, bool sportLine, int width, int height)
        {
            // TODO: Продумать проверки
            _pictureWidth = width;
            _pictureHeight = height;
            EntityTractor = new EntityTractor();
            EntityTractor.Init(speed, weight, bodyColor, additionalColor,
            bodyKit, wing, sportLine);
            return true;
        }
        /// <summary>
        /// Установка позиции
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetPosition(int x, int y)
        {
            // TODO: Изменение x, y
            _startPosX = x;
            _startPosY = y;
        }
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(DirectionType direction)
        {
            if (EntityTractor == null)
            {
                return;
            }
            switch (direction)
            {
                //влево
                case DirectionType.Left:
                    if (_startPosX - EntityTractor.Step > 0)
                    {
                        _startPosX -= (int)EntityTractor.Step;
                    }
                    break;
                //вверх
                case DirectionType.Up:
                    if (_startPosY - EntityTractor.Step > 0)
                    {
                        _startPosY -= (int)EntityTractor.Step;
                    }
                    break;
                // вправо
                case DirectionType.Right:
                    if (_startPosX + _tractorWidth + EntityTractor.Step < _pictureWidth)
                    {
                        _startPosX += (int)EntityTractor.Step;
                    }
                    break;
                //вниз
                case DirectionType.Down:
                    if (_startPosY + _tractorHeight + EntityTractor.Step < _pictureHeight)
                    {
                        _startPosY += (int)EntityTractor.Step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            if (EntityTractor == null)
            {
                return;
            }
            Pen pen = new(Color.Black);
            Brush brGray = new SolidBrush(Color.Gray);
            Brush brBlack = new SolidBrush(Color.Black);
            Brush additionalBrush = new
            SolidBrush(EntityTractor.AdditionalColor);
            // обвесы
            if (EntityTractor.BodyKit)
            {

            }

            //Гусеницы         
            g.FillEllipse(brGray, _startPosX, _startPosY + 41, 25, 25);
            g.FillEllipse(brGray, _startPosX + 55, _startPosY + 41, 25, 25);
            g.FillRectangle(brGray, _startPosX + 13, _startPosY + 41, 54, 25);
            //колеса
            g.FillEllipse(brBlack, _startPosX, _startPosY + 45, 15, 15);
            g.FillEllipse(brBlack, _startPosX + 65, _startPosY + 45, 15, 15);
            g.FillEllipse(brBlack, _startPosX + 35, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 20, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 50, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 25, _startPosY + 40, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 45, _startPosY + 40, 10, 10);
            //кузов
            g.FillRectangle(additionalBrush, _startPosX, _startPosY + 20, 80, 20);
            g.FillRectangle(additionalBrush, _startPosX + 60, _startPosY, 10, 20);
            g.FillRectangle(additionalBrush, _startPosX, _startPosY, 40, 20);

            //Окно
            Brush brBlue = new SolidBrush(Color.Blue);
            g.FillRectangle(brBlue, _startPosX + 10, _startPosY + 3, 25, 15);

            //Колеса
            g.FillEllipse(additionalBrush, _startPosX + 2, _startPosY + 47, 11, 11);
            g.FillEllipse(additionalBrush, _startPosX + 67, _startPosY + 47, 11, 11);
            g.FillEllipse(additionalBrush, _startPosX + 37, _startPosY + 57, 6, 6);
            g.FillEllipse(additionalBrush, _startPosX + 22, _startPosY + 57, 6, 6);
            g.FillEllipse(additionalBrush, _startPosX + 52, _startPosY + 57, 6, 6);
            g.FillEllipse(additionalBrush, _startPosX + 27, _startPosY + 42, 6, 6);
            g.FillEllipse(additionalBrush, _startPosX + 47, _startPosY + 42, 6, 6);

            //границы трактора
            g.DrawRectangle(pen, _startPosX, _startPosY + 20, 80, 20);
            g.DrawRectangle(pen, _startPosX + 60, _startPosY, 10, 20);
            g.DrawRectangle(pen, _startPosX, _startPosY, 40, 20);
            // спортивная линия
            if (EntityTractor.SportLine)
            {

            }
            // крыло
            if (EntityTractor.Wing)
            {

            }
        }
    }
}

