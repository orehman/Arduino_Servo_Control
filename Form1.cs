using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool stpBtnClk = false;
        SerialPort sp = new SerialPort();
        private void Form1_Load(object sender, EventArgs e)
        {
            sp.Close();
            sp.PortName = "COM4";
            sp.BaudRate = 9600;
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.Encoding = Encoding.Default;
            sp.Open();
            sp.RtsEnable = true;
        }

        private void onBtn_Click(object sender, EventArgs e)
        {
            stpBtnClk = false;
        //    for(int i=0; i<180; i++)
        //{
        //    //SendByte(i); // Send byte '1' to the Arduino
        //    byte[] buffer = new byte[] { Convert.ToByte(i) };
        //    sp.Write(buffer, 0, 1);


        //    System.Threading.Thread.Sleep(20);
        //}
            for (; ;)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 180);
                byte[] buffer = new byte[] { Convert.ToByte(randomNumber) };
                sp.Write(buffer, 0, 1);

                System.Threading.Thread.Sleep(1000);

                if (stpBtnClk == true)
                {
                    break;
                }
            }
        }

        private void stpBtn_Click(object sender, EventArgs e)
        {

        }

        //private void SendByte(byte byteToSend)
        //{
        //    byte[] bytes = new byte[] { byteToSend };
        //    sp.Write(bytes, 0, bytes.Length);
        //}
      

    }
}