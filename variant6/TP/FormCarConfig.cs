using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP
{
    public partial class FormCarConfig : Form
    {
		/// <summary>
		/// Переменная-выбранная машина
		/// </summary>
		Car car = null;
		/// <summary>
		/// Событие
		/// </summary>
		//private event CarDelegate eventAddCar;
		private event Action<Car> eventAddLocomotive;
		public FormCarConfig()
		{
			InitializeComponent();
			MouseDown
			buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
		}
		/// <summary>
		/// Отрисовать машину
		/// </summary>
		private void DrawCar()
		{
			if (car != null)
			{
				Bitmap bmp = new Bitmap(pictureBoxCar.Width, pictureBoxCar.Height);
				Graphics gr = Graphics.FromImage(bmp);
				car.SetPosition(50, 130, pictureBoxCar.Width, pictureBoxCar.Height);
				car.DrawTransport(gr);
				pictureBoxCar.Image = bmp;
			}
		}
		/// <summary>
		/// Добавление события
		/// </summary>
		/// <param name="ev"></param>
		public void AddEvent(Action<Car> ev)
		{
			if (eventAddLocomotive == null)
			{
				eventAddLocomotive = ev;
			}
			else
			{
				eventAddLocomotive += ev;
			}
		}
		/// <summary>
		/// Передаем информацию при нажатии на Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelCar_MouseDown(object sender, MouseEventArgs e)
        {
			labelCar.DoDragDrop(labelCar.Name, DragDropEffects.Move | DragDropEffects.Copy);
		}
		/// <summary>
		/// Передаем информацию при нажатии на Label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelSportCar_MouseDown(object sender, MouseEventArgs e)
        {
			labelSportCar.DoDragDrop(labelSportCar.Name, DragDropEffects.Move | DragDropEffects.Copy);
		}
		/// <summary>
		/// Проверка получаемой информации (ее типа на соответствие требуемому)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void panelCar_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// Действия при приеме перетаскиваемой информации
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelCar_DragDrop(object sender, DragEventArgs e)
        {
			switch (e.Data.GetData(DataFormats.Text).ToString())
			{
				case "labelCar":
					car = new Car((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Black);
					break;
				case "labelSportCar":
					car = new SportCar((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Black, Color.LightGreen,
				 checkBox2.Checked, checkBox1.Checked, checkBox3.Checked);
					break;
			}
			DrawCar();
		}
		/// <summary>
		/// Отправляем цвет с панели
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
			(sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
		}
		/// <summary>
		/// Проверка получаемой информации (ее типа на соответствие требуемому)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(typeof(Color)))
			{
				e.Effect = DragDropEffects.Copy;

			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// Принимаем основной цвет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelBaseColo_DragDrop(object sender, DragEventArgs e)
        {
			if (car != null)
			{
				car.SetMainColor((Color)e.Data.GetData(typeof(Color)));
				DrawCar();
			}
		}
		/// <summary>
		/// Принимаем дополнительный цвет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
			if (car != null)
			{
				if (car is SportCar)
				{
					(car as SportCar).SetDopColor((Color)e.Data.GetData(typeof(Color)));
					DrawCar();
				}

			}
		}
		/// <summary>
		/// Добавление машины
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOk_Click(object sender, EventArgs e)
        {
			eventAddLocomotive?.Invoke(car);
			Close();
		}
        

    }
}
