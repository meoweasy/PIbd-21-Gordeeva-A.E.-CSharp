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
        /// Признак наличия задней части танка
        /// </summary>
        public bool TankBack { private set; get; }
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
        /// <param name="backSpoiler">Признак наличия задней части танка</param>
        /// <param name="sportLine">Признак наличия скина на танк</param>
        public SportCar(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool tankGun, bool sideSpoiler, bool tankBack, bool tankSkin) :
        base(maxSpeed, weight, mainColor, 100, 60)
        {
            DopColor = dopColor;
            TankGun = tankGun;
            SideSpoiler = sideSpoiler;
            TankBack = tankBack;
            TankSkin = tankSkin;
        }


        public override void DrawTransport(Graphics g)
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