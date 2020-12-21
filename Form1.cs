using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /* Размер рисовалки w = 900px, h = 700 px*/
    public partial class Form1 : Form
    {
        double _aX = 0, _aY = 0, _aL = 0, _bX = 0, _bY = 0, _bL = 0, _cX = 0, _cY = 0, _cL = 0; int _net = 50; 


      
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _net = Convert.ToInt32(textBox10.Text); 
            }
            catch {
            textBox10.BackColor = Red;
            }
        }

        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Сложение", "Вычитание" }); comboBox1.SelectedIndex = 0; 
        }

        public void ax()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 300), new Point(900, 300)); 
            g.DrawLine(new Pen(Brushes.Black, 2), new Point(350, 0), new Point(350, 700)); 
                                                                                     

           
        }

        public void net() 
        {
            for (int i = 350; i < 900; i = i + _net) // отрисока сетки оу по правую сторону
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Brushes.Gray, 1), new Point(i, 0), new Point(i, 700));
            }

            for (int i = 350; i > 0; i = i - _net) // отрисока сетки оу по левую сторону
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Brushes.Gray, 1), new Point(i, 0), new Point(i, 700));
            }


            for (int i = 300; i < 700; i = i + _net) // отрисока сетки ох по правую сторону
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Brushes.Gray, 1), new Point(0, i), new Point(900, i));
            }

            for (int i = 300; i > 0; i = i - _net) // отрисока сетки ох по левую сторону
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Brushes.Gray, 1), new Point(0, i), new Point(900, i));
            }

        }

        public void input()
        {
            try
            {
                _aX = Convert.ToDouble(textBox7.Text) * _net;
                _aY = Convert.ToDouble(textBox2.Text) * _net;

                _bX = Convert.ToDouble(textBox4.Text) * _net;
                _bY = Convert.ToDouble(textBox5.Text) * _net;
                
                
            }
            catch
            {
               textBox7.BackColor = Red;
               textBox2.BackColor = Red;
               textBox4.BackColor = Red;
               textBox5.BackColor = Red;
               
               
               
               
            }

        }

        public void count()
        {
            input();
            if (comboBox1.SelectedIndex == 0)
            {
                _cX = _aX + _bX;
                _cY = _aY + _bY;
            }
            if (comboBox1.SelectedIndex == 1)      
            {
                _cX = _aX - _bX;                
                _cY = _aY - _bY;
            }


        }



        public void convert() 
        {
            input();
            count();

            _aL = Math.Sqrt((_aX) * (_aX) + (_aY) * (_aY));
            _bL = Math.Sqrt((_bX) * (_bX) + (_bY) * (_bY));

            _aX = (_aX + 350); 
            _aY = (300 - _aY);

            _bX = (_bX + 350); 
            _bY = (300 - _bY);

            _cX = (_cX + 350); 
            _cY = (300 - _cY);

            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Blue, 1), new Point(350, 300), new Point(Convert.ToInt32(_aX), Convert.ToInt32(_aY)));



            g.DrawLine(new Pen(Brushes.Blue, 1), new Point(350, 300), new Point(Convert.ToInt32(_bX), Convert.ToInt32(_bY)));



            if (comboBox1.SelectedIndex == 0)
            {
                g.DrawLine(new Pen(Brushes.Red, 1), new Point(350, 300), new Point(Convert.ToInt32(_cX), Convert.ToInt32(_cY)));


            }
            if (comboBox1.SelectedIndex == 1)
            {
                g.DrawLine(new Pen(Brushes.Red, 1), new Point(Convert.ToInt32(_bX), Convert.ToInt32(_bY)), new Point(Convert.ToInt32(_aX), Convert.ToInt32(_aY)));

            }


        }

        private void button1_Click(object sender, EventArgs e) 
        {
            Graphics g = pictureBox1.CreateGraphics(); 
            g.Clear(SystemColors.Control);
            net();
            ax();
            convert();
            output();
        }

        private void output()
        {
            input();
            textBox3.Text = Convert.ToString(_aL/_net);
            textBox6.Text = Convert.ToString(_bL/_net);
            if (comboBox1.SelectedIndex == 0){ 

                _cX = (_aX / _net) + (_bX / _net);
                _cY = (_aY / _net) + (_bY / _net);

                textBox1.Text = Convert.ToString(_cX);
                textBox8.Text = Convert.ToString(_cY);
                _cL = Math.Sqrt((_cX) * (_cX) + (_cY) * (_cY));
                textBox9.Text = Convert.ToString(_cL);
                textBox11.Visible = false;
                textBox12.Visible = false;

            }

            if (comboBox1.SelectedIndex == 1) 
            {
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox11.Text = Convert.ToString(_bY / _net);
                textBox12.Text = Convert.ToString(_bX / _net);
                textBox1.Text = Convert.ToString(_aX / _net);
                textBox8.Text = Convert.ToString(_aY / _net);
                _cL = Math.Sqrt(((_bY / _net) -(_aY / _net)) * ((_bY / _net) - (_aY / _net)) + ((_bX / _net) - (_aX / _net)) * ((_bX / _net) - (_aX / _net)));
                textBox9.Text = Convert.ToString(_cL); // из формулы что длинна вектора это корень из ((х2-х1)^2 + (y2-y1)^2)
            }




        }
    }
}
