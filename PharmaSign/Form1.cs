using PharmaSign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaSign
{
    public partial class Form1 : Form
    {
        Point lastPoint;

        public Form1()
        {
            InitializeComponent();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { this.Left += e.X - lastPoint.X; this.Top += e.Y - lastPoint.Y; }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void ResetColor()
        {
            this.button1.BackColor = Color.Brown;
            this.button2.BackColor = Color.Brown;
            this.button7.BackColor = Color.Brown;
            this.button8.BackColor = Color.Brown;
            this.button9.BackColor = Color.Brown;
            this.button10.BackColor = Color.Brown;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ResetColor();
            uC1DB1.BringToFront();
            button1.BackColor = Color.Maroon;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ResetColor();
            uC2CONF1.BringToFront();
            button2.BackColor = Color.Maroon;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ResetColor();
            uC3WEB1.BringToFront();
            button7.BackColor = Color.Maroon;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ResetColor();
            uccontacts1.BringToFront();
            button8.BackColor = Color.Maroon;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ResetColor();
            ucabout1.BringToFront();
            button9.BackColor = Color.Maroon;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            ResetColor();
            button10.BackColor = Color.Maroon;
        }
    }
}
