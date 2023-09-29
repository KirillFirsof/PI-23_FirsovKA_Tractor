using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1RPP
{
    /// <summary>
    /// Форма работы с объектом "Спортивный автомобиль"
    /// </summary>
    public partial class FormTractor : Form
    {
        private PictureBox pictureBoxTractor;
        private Button buttonCreate;
        private Button buttonTop;
        private Button buttonLeft;
        private Button buttonDown;
        private Button buttonRight;

        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawningTractor? _drawningTractor;
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public FormTractor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод прорисовки машины
        /// </summary>
        private void Draw()
        {
            if (_drawningTractor == null)
            {
                return;
            }
            Bitmap bmp = new(pictureBoxTractor.Width,
            pictureBoxTractor.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningTractor.DrawTransport(gr);
            pictureBoxTractor.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random random = new();
            _drawningTractor = new DrawningTractor();
            _drawningTractor.Init(random.Next(100, 300),
            random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Convert.ToBoolean(random.Next(0, 2)),
            Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)), pictureBoxTractor.Width, pictureBoxTractor.Height);
            _drawningTractor.SetPosition(random.Next(10, 100),
            random.Next(10, 100));
            Draw();
        }

        /// <summary>
        /// Изменение размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            if (_drawningTractor == null)
            {
                return;
            }
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                case "buttonUp":
                    _drawningTractor.MoveTransport(DirectionType.Up);
                    break;
                case "buttonDown":
                    _drawningTractor.MoveTransport(DirectionType.Down);
                    break;
                case "buttonLeft":
                    _drawningTractor.MoveTransport(DirectionType.Left);
                    break;
                case "buttonRight":
                    _drawningTractor.MoveTransport(DirectionType.Right);
                    break;
            }
            Draw();
        }

        private void InitializeComponent()
        {
            this.pictureBoxTractor = new System.Windows.Forms.PictureBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTractor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTractor
            // 
            this.pictureBoxTractor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTractor.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTractor.Name = "pictureBoxTractor";
            this.pictureBoxTractor.Size = new System.Drawing.Size(891, 490);
            this.pictureBoxTractor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTractor.TabIndex = 0;
            this.pictureBoxTractor.TabStop = false;
            this.pictureBoxTractor.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.Location = new System.Drawing.Point(12, 440);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(94, 29);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // buttonTop
            // 
            this.buttonTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTop.BackgroundImage = global::Laba1RPP.Properties.Resources.arrowUp;
            this.buttonTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTop.Location = new System.Drawing.Point(813, 412);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(30, 30);
            this.buttonTop.TabIndex = 2;
            this.buttonTop.UseVisualStyleBackColor = true;
            this.buttonTop.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = global::Laba1RPP.Properties.Resources.arrowLeft;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.Location = new System.Drawing.Point(777, 448);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::Laba1RPP.Properties.Resources.arrowDown;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDown.Location = new System.Drawing.Point(813, 448);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = global::Laba1RPP.Properties.Resources.arrowRight;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRight.Location = new System.Drawing.Point(849, 448);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // FormTractor
            // 
            this.ClientSize = new System.Drawing.Size(891, 490);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonTop);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBoxTractor);
            this.Name = "FormTractor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTractor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
