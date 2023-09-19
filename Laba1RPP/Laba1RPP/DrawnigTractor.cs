using System;

namespace Laba1RPP
{
    public class DrawningTractor
    {
        /// <summary>
        /// Класс-сущность
        /// </summary>
        public EntityTractor Tractor { private set; get; }
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Верхняя кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int? _pictureWidth = null;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int? _pictureHeight = null;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private readonly int _carWidth = 80;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        private readonly int _carHeight = 65;
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="bodyColor">Цвет кузова</param>
        public void Init(int speed, float weight, Color bodyColor)
        {
            Tractor = new EntityTractor();
            Tractor.Init(speed, weight, bodyColor);
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            // TODO проверки
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            if (!_pictureWidth.HasValue || !_pictureHeight.HasValue)
            {
                return;
            }
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + _carWidth + Tractor.Step < _pictureWidth)
                    {
                        _startPosX += Tractor.Step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - Tractor.Step > 0)
                    {
                        _startPosX -= Tractor.Step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if(_startPosY - Tractor.Step > 0)
                    {
                        _startPosY -= Tractor.Step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + _carHeight + Tractor.Step < _pictureHeight)
                    {
                        _startPosY += Tractor.Step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            if (_startPosX < 0 || _startPosY < 0
            || !_pictureHeight.HasValue || !_pictureWidth.HasValue)
            {
                return;
            }
            Pen pen = new(Color.Black);
            
            //Гусеницы
            Brush brGray = new SolidBrush(Color.Gray);
            g.FillEllipse(brGray, _startPosX, _startPosY + 41, 25, 25);
            g.FillEllipse(brGray, _startPosX + 55, _startPosY + 41, 25, 25);
            g.FillRectangle(brGray, _startPosX + 13, _startPosY + 41, 54, 25);
            //колеса
            Brush brBlack = new SolidBrush(Color.Black);
            g.FillEllipse(brBlack, _startPosX, _startPosY + 45, 15, 15);
            g.FillEllipse(brBlack, _startPosX + 65, _startPosY + 45, 15, 15);
            g.FillEllipse(brBlack, _startPosX + 35, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 20, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 50, _startPosY + 55, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 25, _startPosY + 40, 10, 10);
            g.FillEllipse(brBlack, _startPosX + 45, _startPosY + 40, 10, 10);
            //кузов
            Brush br = new SolidBrush(Tractor?.BodyColor ?? Color.Black);
            g.FillRectangle(br, _startPosX, _startPosY + 20, 80, 20);
            g.FillRectangle(br, _startPosX + 60, _startPosY, 10, 20);
            g.FillRectangle(br, _startPosX, _startPosY, 40, 20);

            //Окно
            Brush brBlue = new SolidBrush(Color.Blue);
            g.FillRectangle(brBlue, _startPosX + 10, _startPosY + 3, 25, 15);

            //Колеса
            g.FillEllipse(br, _startPosX + 2, _startPosY + 47, 11, 11);
            g.FillEllipse(br, _startPosX + 67, _startPosY + 47, 11, 11);
            g.FillEllipse(br, _startPosX + 37, _startPosY + 57, 6, 6);
            g.FillEllipse(br, _startPosX + 22, _startPosY + 57, 6, 6);
            g.FillEllipse(br, _startPosX + 52, _startPosY + 57, 6, 6);
            g.FillEllipse(br, _startPosX + 27, _startPosY + 42, 6, 6);
            g.FillEllipse(br, _startPosX + 47, _startPosY + 42, 6, 6);

            //границы трактора
            g.DrawRectangle(pen, _startPosX, _startPosY + 20, 80, 20);
            g.DrawRectangle(pen, _startPosX + 60, _startPosY, 10, 20);
            g.DrawRectangle(pen, _startPosX, _startPosY, 40, 20);
        }
        /// <summary>
        /// Смена границ формы отрисовки
        /// </summary>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void ChangeBorders(int width, int height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
            if (_pictureWidth <= _carWidth || _pictureHeight <= _carHeight)
            {
                _pictureWidth = null;
                _pictureHeight = null;
                return;
            }
            if (_startPosX + _carWidth > _pictureWidth)
            {
                _startPosX = _pictureWidth.Value - _carWidth;
            }
            if (_startPosY + _carHeight > _pictureHeight)
            {
                _startPosY = _pictureHeight.Value - _carHeight;
            }
        }
    }
}

