using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP
{
    /// <summary>
    /// Класс отрисовки танка
    /// </summary>
    public class SportCar : Car
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия пушки
        /// </summary>
        public bool TankGun { private set; get; }
        /// <summary>
        /// Признак наличия боковой части танка
        /// </summary>
        public bool SideSpoiler { private set; get; }

        /// <summary>
        /// Признак наличия скина на танк
        /// </summary>
        public bool TankSkin { private set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес танка</param>
        /// <param name="mainColor">Основной цвет танка</param>
        /// <param name="dopColor">Дополнительный танка</param>
        /// <param name="frontSpoiler">Признак наличия пушки</param>
        /// <param name="sideSpoiler">Признак наличия боковой части танка</param>
        /// <param name="sportLine">Признак наличия скина на танк</param>
        public SportCar(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool tankGun, bool sideSpoiler, bool tankSkin) :
        base(maxSpeed, weight, mainColor, 100, 60)
        {
            DopColor = dopColor;
            TankGun = tankGun;
            SideSpoiler = sideSpoiler;
            TankSkin = tankSkin;
        }

        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public SportCar(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                TankGun = Convert.ToBoolean(strs[4]);
                SideSpoiler = Convert.ToBoolean(strs[5]);
                TankSkin = Convert.ToBoolean(strs[6]);
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brGreen = new SolidBrush(Color.Green);
            Brush br = new SolidBrush(MainColor);
            Brush br2 = new SolidBrush(DopColor);
            //пушка
            if (TankGun)
            {
                g.FillRectangle(br2, _startPosX + 90, _startPosY + 7, 45, 15);
                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 7, 45, 15);
                g.FillRectangle(br, _startPosX + 135, _startPosY + 7, 10, 16);
            }

            if (SideSpoiler)
            {
                //люк
                g.FillEllipse(br, _startPosX + 45, _startPosY - 7, 30, 30);
            }

            //основа танка
            base.DrawTransport(g);
            g.FillRectangle(br2, _startPosX + 30, _startPosY, 60, 30);

            //скин на танк
            if (TankSkin)
            {
                g.FillEllipse(brGreen, _startPosX + 36, _startPosY + 5, 10, 10);
                g.FillEllipse(brGreen, _startPosX + 38, _startPosY + 8, 15, 15);
                g.FillEllipse(brGreen, _startPosX + 36, _startPosY + 12, 10, 10);
                g.FillEllipse(brGreen, _startPosX + 45, _startPosY + 3, 17, 17);

                g.FillEllipse(brGreen, _startPosX + 73, _startPosY + 3, 17, 17);
                g.FillEllipse(brGreen, _startPosX + 73, _startPosY + 12, 10, 10);

                g.FillEllipse(brGreen, _startPosX + 55, _startPosY + 20, 10, 10);
                g.FillEllipse(brGreen, _startPosX + 60, _startPosY + 15, 13, 10);
            }
        }
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return
            $"{base.ToString()}{separator}{DopColor.Name}{separator}{TankGun}{separator}{SideSpoiler}{separator}{TankSkin}";
        }
    }
}