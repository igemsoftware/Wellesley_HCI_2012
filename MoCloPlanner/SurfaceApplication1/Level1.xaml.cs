﻿using System;
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

namespace SurfaceApplication1
{
    /// <summary>
    /// Interaction logic for Level1.xaml
    /// </summary>
    public partial class Level1 : ScatterViewItem
    {
        private Point low; //Center coordinates when initialized (i.e. snapped to bottom)
        private Point high; //Center coordinates when snapped to top
        private double snapThreshold; //Threshold distance from a snap-to point for snapping behavior
        private double snapThreshold_L2; //Snap threshold WRT L2
        private Brush selected = Brushes.Navy;

        public static SurfaceWindow1 sw1;
        public Level1()
        {
            InitializeComponent();
            IsTopmostOnActivation = false;

            double parentHeight = 1080;
            double parentWidth = 1920;

            this.Height = parentHeight - 150; //Height of all tabs together
            low.Y = parentHeight - 100 + this.Height / 2;
            low.X = parentWidth / 2;

            this.Center = low;
            high = low;
            high.Y = high.Y - this.Height + 50; //50 for height of tabs?
            snapThreshold = 200;
            snapThreshold_L2 = 50;

            addL1Module();
        }

        //Testing out global variable checking with addition of new Parts
        private void partAdder_Click(object sender, RoutedEventArgs e)
        {
            addL1Module();
        }

        //Adds an L1Module template to Manual
        public void addL1Module()
        {
            L1Module l1 = new L1Module();
            l1.Template.Visibility = System.Windows.Visibility.Visible; 
            L1_manTab.Items.Add(l1);
            l1.Center = SurfaceWindow1.SetPosition(l1);
            l1.IsManipulationEnabled = false;
        }

        //Determines stopping/out of bounds conditions for manipulation of the shutter
        private void Level1_ContainerManipulationDelta(object sender, ContainerManipulationDeltaEventArgs e)
        {
            ScatterViewItem L1 = (ScatterViewItem)sender;
            //If its center is ever higher than its highest point, lower than its lowest point, or less than 50 higher than L2's center
            if ((L1.Center.Y < high.Y) || (L1.Center.Y > low.Y) || (L1.Center.Y > (sw1.L2.Center.Y - snapThreshold_L2)))
                L1.CancelManipulation();
            L1.Center = new Point(low.X, L1.Center.Y);
        }

        //Determines if snap-to behavior is appropriate and where to snap to
        private void Level1_ContainerManipulationCompleted(object sender, ContainerManipulationCompletedEventArgs e)
        {
            ScatterViewItem L1 = (ScatterViewItem)sender;
            //If its center is within the threshold of low.Y or high.Y or L2
            if (L1.Center.Y < high.Y + snapThreshold)
                L1.Center = new Point(low.X, high.Y);
            if (L1.Center.Y > low.Y - snapThreshold)
                L1.Center = new Point(low.X, low.Y);
            if (L1.Center.Y > (sw1.L2.Center.Y - snapThreshold_L2))
                L1.Center = new Point(low.X, sw1.L2.Center.Y - snapThreshold_L2);
        }

        //Makes tabcontrol accept touch input
        private void TabControl_TouchDown(object sender, TouchEventArgs e)
        {
            TabItem tab = (TabItem)sender;
            L1_buildTabs.SelectedItem = tab;
            e.Handled = true;
        }

        private void L1_buildTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabc = (TabControl)sender;
            if (tabc.SelectedIndex == 0)
            {
                //partAdder.IsEnabled = true;
                //partAdder.Visibility = System.Windows.Visibility.Visible;
                permMaker.IsEnabled = false;
                permMaker.Visibility = Visibility.Collapsed;
            }
            else
            {
                //partAdder.IsEnabled = false;
                //partAdder.Visibility = System.Windows.Visibility.Hidden;
                permMaker.IsEnabled = true;
                permMaker.Visibility = Visibility.Visible;
            }
        }

        //Generates permutations of L1 modules using selected Parts
        private void permMaker_Click(object sender, RoutedEventArgs e)
        {
            permMaker.IsEnabled = false;

            List<Part> selectedPromList = new List<Part>();
            List<Part> selectedRBSList = new List<Part>();
            List<Part> selectedCDSList = new List<Part>();
            List<Part> selectedTermList = new List<Part>();

            //if the background is a different color than the border, then part is selected and should be added to selected part list 
            foreach (Part p in sw1.L1.L1_prom.Items) { if (p.BorderBrush == selected) selectedPromList.Add(p); }
            foreach (Part r in sw1.L1.L1_rbs.Items) { if (r.BorderBrush == selected) selectedRBSList.Add(r); }
            foreach (Part c in sw1.L1.L1_cds.Items) { if (c.BorderBrush == selected) selectedCDSList.Add(c); }
            foreach (Part t in sw1.L1.L1_term.Items) { if (t.BorderBrush == selected) selectedTermList.Add(t); }
            
            if (selectedPromList.Count != 0 && selectedRBSList.Count != 0 && selectedCDSList.Count != 0 && selectedTermList.Count != 0)
            {


                //permutations are cleared and regenerated everytime
                sw1.L1.L1_permTab.Items.Clear();
                
                foreach (Part p in selectedPromList)
                {
                    foreach (Part r in selectedRBSList)
                    {
                        foreach (Part c in selectedCDSList)
                        {
                            foreach (Part t in selectedTermList)
                            {
                                //L1Module L = new L1Module(p, r, c, t);//////////////////////////////////////////////////
                                L1Module L = new L1Module(); 
                                L.L1Prom.copyPartInfoFrom(p);
                                L.L1RBS.copyPartInfoFrom(r);
                                L.L1CDS.copyPartInfoFrom(c);
                                L.L1Term.copyPartInfoFrom(t); 

                                sw1.L1.L1_permTab.Items.Add(L);
                                L.Center = SurfaceWindow1.SetPosition(L);
                                //generate Level1 modules and then add to the list called Level1module List.
                            }
                        }
                    }
                }
            }


            permMaker.IsEnabled = true;

        }

        
    }
}
