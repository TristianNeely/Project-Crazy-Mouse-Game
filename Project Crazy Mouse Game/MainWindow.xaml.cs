﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Project_Crazy_Mouse_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    
    public partial class MainWindow : Window
    {

        public static Random _random = new Random();
        int playerScore = 0;
        public static int xMouseLocation = 20;
        public static int yMouseLocation = 20;
        public static bool stopThread = false;

        //double Score1 = 0;
        double time1 = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            Thread crazyMouseThread = new Thread(new ThreadStart(CrazyMouseThread));
            crazyMouseThread.Start();   
        }


        public void stop()
        {
            //DispatcherTimer dt = new DispatcherTimer();
            Thread.Sleep(100000);
            
           

        }


        public static void CrazyMouseThread()
        {
            int moveX = 0;
            int moveY = 0;

            while (stopThread == false)
            {
                moveX = _random.Next(xMouseLocation) - (xMouseLocation / 2);
                moveY = _random.Next(yMouseLocation) - (xMouseLocation / 2);


                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + moveX, System.Windows.Forms.Cursor.Position.Y + moveY);
                Thread.Sleep(50);

                
                
            }


        }

        


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            

            if (Button1.Height <= 100)
            {
                
               

                
                //DispatcherTimer dt = new DispatcherTimer();
                dt.Stop();
                stopThread = true;

                MessageBox.Show("Congrats You Win!");
                Environment.Exit(0);
                
            }
            else
            {

                //Increment Score
                playerScore++;
                scorebox.Text = playerScore.ToString();

                //Increment Randomness
                xMouseLocation = xMouseLocation + 2;
                yMouseLocation = yMouseLocation + 2;

                // Shrink the target
                Button1.Height = Button1.Height - 5;
                Button1.Width = Button1.Width - 7;

            }
            
           // Score1++;
            //scorebox.Text = Convert.ToString(Score1);
        }


       


        private void Clockdoe_Click(object sender, RoutedEventArgs e)
        {

            while (true) 
            {
                if (time1 <= 100)
                {

                    time1++;
                    Thread.Sleep(1000);
                    Timer1.Text = Convert.ToString(time1);
                    
                  

                }
               
             
                
                    

                
            }
           
               
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
           

        }
        DispatcherTimer dt = new DispatcherTimer();
        private int increment = 0;

        private void dtTicker(object sender, EventArgs e)
        {
            //DispatcherTimer dt = new DispatcherTimer();
            increment++;
            TimerLabel.Content = increment.ToString();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
