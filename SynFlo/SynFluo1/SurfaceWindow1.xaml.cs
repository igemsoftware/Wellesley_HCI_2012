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
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {

        //public Storyboard mySB;
        Random r;
        //Storyboard myStoryboard;
        //PointAnimation myPointAnimation;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();
           // myStoryboard = FindResource("myStoryboard") as Storyboard;
            //myPointAnimation = FindResource("myPointAnimation") as PointAnimation;
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
            r = new Random(100);
            r.Next();
            r.Next();
            r.Next();
            r.Next();
        }

        private void Handle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve current mouse coordinates.
            double newX = e.GetPosition(null).X;
            double newY = e.GetPosition(null).Y;
            Point myPoint = new Point();
            myPoint.X = newX;
            myPoint.Y = newY;
           // myPointAnimation.To = myPoint;
            //myStoryboard.Begin();
        }

        // Start the animation when the critter is added
        private void Start_Animation(object sender, EventArgs e)
        {

            //mySB.Begin();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void environmentSV_TouchUp(object sender, TouchEventArgs e)
        {

            //double newX = e.Device.GetCenterPosition(this).X;
            //double newY = e.Device.GetCenterPosition(this).Y; 

            //// Retrieve current mouse coordinates.
            ////double newX = e.GetPosition(null).X;
            ////double newY = e.GetPosition(null).Y;
            //Point myPoint = new Point();
            //myPoint.X = newX;
            //myPoint.Y = newY;

            //critterSVI2.myPAni.To = myPoint;
            //critterSVI3.mySB.Begin();
        }

        /*Begin New Code*/


    }
}