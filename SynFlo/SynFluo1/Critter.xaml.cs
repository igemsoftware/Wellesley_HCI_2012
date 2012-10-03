using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using SynFluo1;
using System.Windows.Media.Animation;

namespace SynFluo1
{
    /// <summary>
    /// Interaction logic for Critter.xaml
    /// </summary>
    public partial class Critter : ScatterViewItem
    {

        public Storyboard mySB;
        public PointAnimation myPAni;

        public Critter()
        {
            InitializeComponent();
            //mySB = FindResource("moveCritter") as Storyboard;
            //myPAni = FindResource("critterPointAni") as PointAnimation;

            

            //mySB = new Storyboard();

          
            //myPAni = new PointAnimation();
            //myPAni.Duration = new Duration(new TimeSpan(0,0,5));
            //myPAni.From = new Point(100, 300);
            //myPAni.To = new Point(400, 100);
            //myPAni.RepeatBehavior = RepeatBehavior.Forever;
            
            

        }
        

        // Start the animation when the critter is added
        private void Start_Animation(object sender, EventArgs e)
        {
             
            //mySB.Begin();
        }

        private void Handle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            // Retrieve current mouse coordinates.
            double newX = e.GetPosition(null).X;
            double newY = e.GetPosition(null).Y;
            Point myPoint = new Point();
            myPoint.X = newX;
            myPoint.Y = newY;

            //myPAni.To = myPoint;
            //mySB.Begin();
        }



    }
}
