using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TP
{
    public class Car : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected readonly int carWidth = 90;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        protected readonly int carHeight = 50;

        /// <summary>
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ';';

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Car(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Car(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        /// <summary>
        /// Конструкторс изменением размеров машины
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="carWidth">Ширина отрисовки автомобиля</param>
        /// <param name="carHeight">Высота отрисовки автомобиля</param>
        protected Car(int maxSpeed, float weight, Color mainColor, int carWidth, int
       carHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.carWidth = carWidth;
            this.carHeight = carHeight;
        }
        public override void MoveTransport(Direction direction)
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
                    if (_startPosY - step > 0)
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
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            Brush brWhite = new SolidBrush(Color.White);
            //нижняя часть
            g.DrawRectangle(pen, _startPosX + 15, _startPosY + 46, 90, 30);
            g.DrawEllipse(pen, _startPosX - 1, _startPosY + 45, 30, 30);
            g.FillEllipse(brWhite, _startPosX + 90, _startPosY + 45, 30, 30);
            g.DrawEllipse(pen, _startPosX + 90, _startPosY + 46, 30, 30);
            g.FillRectangle(brWhite, _startPosX + 15, _startPosY + 45, 90, 30);
            //4 колесо
            g.FillEllipse(br, _startPosX + 87, _startPosY + 46, 28, 28);
            g.FillEllipse(brWhite, _startPosX + 97, _startPosY + 56, 10, 10);
            //2 колесо
            g.FillEllipse(br, _startPosX + 38, _startPosY + 55, 18, 18);
            g.FillEllipse(brWhite, _startPosX + 44, _startPosY + 61, 6, 6);
            //3 колесо
            g.FillEllipse(br, _startPosX + 66, _startPosY + 55, 18, 18);
            g.FillEllipse(brWhite, _startPosX + 72, _startPosY + 61, 6, 6);

            //основа танка
            g.FillRectangle(br, _startPosX + 15, _startPosY + 30, 90, 15);
            g.DrawRectangle(pen, _startPosX + 30, _startPosY, 60, 30);

            //задняя часть
            g.FillEllipse(brWhite, _startPosX, _startPosY + 45, 30, 30);
            //1 колесо
            g.FillEllipse(br, _startPosX + 6, _startPosY + 46, 28, 28);
            g.FillEllipse(brWhite, _startPosX + 16, _startPosY + 56, 10, 10);
        }

        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }
    }
}
