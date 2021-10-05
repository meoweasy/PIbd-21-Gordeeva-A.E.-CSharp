using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP
{
    class SportCar
    {
        /// Левая координата отрисовки танка
        private float _startPosX;

        /// Правая кооридната отрисовки танка
        private float _startPosY;

        /// Ширина окна отрисовки
        private int _pictureWidth=1179;

        /// Высота окна отрисовки
        private int _pictureHeight=521;

        /// Ширина отрисовки танка
        private readonly int carWidth = 145;

        /// Высота отрисовки танка
        private readonly int carHeight = 75;

        /// Максимальная скорость
        public int MaxSpeed { private set; get; }

        /// Вес танка
        public float Weight { private set; get; }

        /// Основной цвет танка
        public Color MainColor { private set; get; }

        /// Дополнительный цвет
        public Color DopColor { private set; get; }

        /// Признак наличия пушки
        public bool TankGun { private set; get; }

        /// Признак наличия боковых спойлеров
        public bool SideSpoiler { private set; get; }

        /// Признак наличия заднего спойлера
        public bool TankBack { private set; get; }

        /// Признак наличия скина на танк
        public bool TankSkin { private set; get; }

        /// Инициализация свойств
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool tankGun, bool sidespoiler, bool tankback, bool tankskin)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            TankGun = tankGun;
            SideSpoiler = sidespoiler;
            TankBack = tankback;
            TankSkin = tankskin;
        }

        /// Установка позиции танка
        public void SetPosition(int x, int y, int width, int height)
        {
            _pictureHeight = height;
            _pictureWidth = width;
            _startPosX = x;
            _startPosY = y;

        }

        /// Изменение направления пермещения
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX + step > 0 - _startPosX)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0 )
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brBlack = new SolidBrush(Color.Black);
            Brush brWhite = new SolidBrush(Color.White);
            Brush br = new SolidBrush(MainColor);
            Brush br2 = new SolidBrush(DopColor);
            //пушка
            if (TankGun)
            {
                g.FillRectangle(br, _startPosX + 90, _startPosY + 7, 45, 15);
                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 7, 45, 15);
                g.FillRectangle(brBlack, _startPosX + 135, _startPosY + 7, 10, 16);


            }
            if (SideSpoiler)
            {
                //нижняя часть
                g.DrawRectangle(pen, _startPosX + 15, _startPosY + 46, 90, 30);
                g.DrawEllipse(pen, _startPosX - 1, _startPosY + 45, 30, 30);
                g.FillEllipse(br, _startPosX + 90, _startPosY + 45, 30, 30);
                g.DrawEllipse(pen, _startPosX + 90, _startPosY + 46, 30, 30);
                g.FillRectangle(br, _startPosX + 15, _startPosY + 45, 90, 30);
                //люк
                g.FillEllipse(brBlack, _startPosX + 45, _startPosY - 7, 30, 30);
                
                //4 колесо
                g.FillEllipse(brBlack, _startPosX + 87, _startPosY + 46, 28, 28);
                g.FillEllipse(brWhite, _startPosX + 97, _startPosY + 56, 10, 10);
                //2 колесо
                g.FillEllipse(brBlack, _startPosX + 38, _startPosY + 55, 18, 18);
                g.FillEllipse(brWhite, _startPosX + 44, _startPosY + 61, 6, 6);
                //3 колесо
                g.FillEllipse(brBlack, _startPosX + 66, _startPosY + 55, 18, 18);
                g.FillEllipse(brWhite, _startPosX + 72, _startPosY + 61, 6, 6);

            }
            //основа танка
            g.FillRectangle(brBlack, _startPosX + 15, _startPosY + 30, 90, 15);
            g.FillRectangle(br, _startPosX + 30, _startPosY, 60, 30);
            g.DrawRectangle(pen, _startPosX + 30, _startPosY, 60, 30);

            //скин на танк
            if (TankSkin)
            {
                g.FillEllipse(br2, _startPosX + 36, _startPosY + 5, 10, 10);
                g.FillEllipse(br2, _startPosX + 38, _startPosY + 8, 15, 15);
                g.FillEllipse(br2, _startPosX + 36, _startPosY + 12, 10, 10);
                g.FillEllipse(br2, _startPosX + 45, _startPosY + 3, 17, 17);

                g.FillEllipse(br2, _startPosX + 73, _startPosY + 3, 17, 17);
                g.FillEllipse(br2, _startPosX + 73, _startPosY + 12, 10, 10);

                g.FillEllipse(br2, _startPosX + 55, _startPosY + 20, 10, 10);
                g.FillEllipse(br2, _startPosX + 60, _startPosY + 15, 13, 10);
            }
            if (TankBack)
            {
                //задняя часть
                g.FillEllipse(br, _startPosX, _startPosY + 45, 30, 30);
                //1 колесо
                g.FillEllipse(brBlack, _startPosX + 6, _startPosY + 46, 28, 28);
                g.FillEllipse(brWhite, _startPosX + 16, _startPosY + 56, 10, 10);

            }
        }
    }
}