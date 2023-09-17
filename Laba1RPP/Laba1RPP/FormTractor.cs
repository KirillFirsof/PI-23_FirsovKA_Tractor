using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1RPP
{
    public partial class FormTractor : Form
    {
        private DrawningTractor _car;

        public FormTractor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод прорисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new(pictureBoxCar.Width, pictureBoxCar.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _car?.DrawTransport(gr);
            pictureBoxCar.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new();
            _car = new DrawningCar();
            _car.Init(rnd.Next(100, 300), rnd.Next(1000, 2000),
           Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            _car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100),
           pictureBoxCar.Width, pictureBoxCar.Height);
            toolStripStatusLabelSpeed.Text = $"Скорость: {_car.Car.Speed}";
            toolStripStatusLabelWeight.Text = $"Вес: {_car.Car.Weight}";
            toolStripStatusLabelBodyColor.Text = $"Цвет:
       { _car.Car.BodyColor.Name}
            ";
        Draw();
        }
        /// <summary>
        /// Изменение размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                case "buttonUp":
                    _car?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _car?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _car?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _car?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
        /// <summary>
        /// Изменение размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxCar_Resize(object sender, EventArgs e)
        {
            _car?.ChangeBorders(pictureBoxCar.Width, pictureBoxCar.Height);
            Draw();
        }
    }
}
