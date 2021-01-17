using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tekla.Structures.Model;
using TestToTekla.classes;
using s =  System.Windows.Shapes;

namespace TestToTekla
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            s.Polygon polygon = new s.Polygon();
            
            Coordinates coordinates = new Coordinates(new PointS() { X = 0, Y = 0 }, Math.PI / 2, 50, 4);
            foreach (PointS item in coordinates.Points)
            {
                polygon.Points.Add(new Point() { X = item.X, Y = item.Y });
            }

            polygon.Fill = Brushes.Red;
            polygon.Stroke = Brushes.Black;
            polygon

            polygon.HorizontalAlignment = HorizontalAlignment.Center;
            polygon.VerticalAlignment = VerticalAlignment.Center;

            MG.Children.Add(polygon);

            

            
        }

        

       

        

        

    }
}
