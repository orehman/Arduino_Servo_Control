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
        

        SerialPort sp = new SerialPort();
        private void Form1_Load(object sender, EventArgs e)
        {
            // Setting up specifications for serial communication
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

        // This occurs when clicking the "ON" button on the form
        private void onBtn_Click(object sender, EventArgs e)
        {
            // Infinite loop that outputs random numbers from 0-180 to emulate output from Kinect
            // Need some kind of breakout but this is fine just for testing
            for (; ;)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 180);
                byte[] buffer = new byte[] { Convert.ToByte(randomNumber) };        // Convert from int to byte to output to Serial
                sp.Write(buffer, 0, 1);

                // 1 second pause
                System.Threading.Thread.Sleep(1000);



                // This loop just output 1-180 incrementally to test the servo
                //    for(int i=0; i<180; i++)
                //{
                //    //SendByte(i); // Send byte '1' to the Arduino
                //    byte[] buffer = new byte[] { Convert.ToByte(i) };
                //    sp.Write(buffer, 0, 1);


                //    System.Threading.Thread.Sleep(20);
                //}
            }
        }

     
        // Testing a function to convert from int to byte

        //private void SendByte(byte byteToSend)
        //{
        //    byte[] bytes = new byte[] { byteToSend };
        //    sp.Write(bytes, 0, bytes.Length);
        //}
      

    }
}