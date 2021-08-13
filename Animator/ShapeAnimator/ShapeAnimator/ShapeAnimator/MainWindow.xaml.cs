using System;
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

namespace ShapeAnimator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShapeAnimationEngine engine = new ShapeAnimationEngine();

        public MainWindow()
        {

            InitializeComponent();
            is_first = true;
            colorChoice = "Red";
            shapeChoice = "Circle";
        }

        Boolean is_first;
        Point first_point;
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
          
             Point p = e.GetPosition(MyCanvas);
            if (is_first)
            {
                
                first_point = p;
                is_first = false;
            }
            else {
                
                double distance = (Math.Sqrt(Math.Pow((first_point.X - p.X), 2) + Math.Pow((first_point.Y - p.Y), 2)));
                if (shapeChoice == "Circle")
                {
                    engine.AddCircle(first_point, (int)distance, colorChoice);
                    Repaint();
                }
                else if (shapeChoice == "Square") {

                    int x, y;
                    if (first_point.X < p.X)
                    {
                        x = (int)first_point.X;
                        y = (int)first_point.Y;
                    }
                    else {
                        x = (int)p.X;
                        y = (int)p.Y;
                    }
                  
                    engine.AddSquare(x,y,(int)distance,colorChoice);
                   Repaint();
                }
                is_first=true;
            }

             // Better approach: Draw just one circle
        }
        String shapeChoice;
        private void Repaint()
        {
            MyCanvas.Children.Clear();
            foreach (Circle c in engine.circles)
            {
                
               DrawCircle(c, c.Color);
            }
            foreach (Square s in engine.Squares)
            {

                DrawSquare(s, s.Color);
            }
        }
        String colorChoice ;
        private void DrawSquare(Square s, string color) {
             Rectangle r = new Rectangle() {
                Width = s.width,
                Height = s.height,
                StrokeThickness = 1
            };
            if (color == "Red")
                r.Stroke = Brushes.Red;
            else if (color == "Green")
                r.Stroke = Brushes.Green;
            else if (color == "Blue")
                r.Stroke = Brushes.Blue;
            else
                r.Stroke = Brushes.Black;
            Canvas.SetLeft(r, s.x-s.width/2);
            Canvas.SetTop(r, s.y-s.width/2);
           
            MyCanvas.Children.Add(r);
        }
        private void DrawCircle(Circle c, string color)
        {
          
                Ellipse e = new Ellipse()
                {
                    Width = c.Radius,
                    Height = c.Radius,

                    StrokeThickness = 1
                };
                if (color == "Red")
                    e.Stroke = Brushes.Red;
                else if (color == "Green")
                    e.Stroke = Brushes.Green;
                else if (color == "Blue")
                    e.Stroke = Brushes.Blue;
                else
                    e.Stroke = Brushes.Black;

                e.SetValue(Canvas.LeftProperty, c.Center.X - c.Radius / 2);
                e.SetValue(Canvas.TopProperty, c.Center.Y - c.Radius / 2);

                MyCanvas.Children.Add(e);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Step();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
        
            Step();
          
            StepSquare();
        }
       
        private void StepSquare() {
            List<int>remove = new List<int>();
            int count = 0;
            foreach (Square s in engine.Squares)
            {
    
                // Right wall

                if (s.x+s.width > MyCanvas.Width + s.width/2)
                {
                       s.deltaX = -s.deltaX;

                }

                if (s.y + s.height > MyCanvas.Height + s.height / 2)
                {
                        s.deltaY = -s.deltaY;
                }

                if (s.y + s.width < s.width + s.width / 2)
                {
                   
                    s.deltaY = -s.deltaY;

                }

                if (s.x + s.width < s.width + s.width / 2)
                {
                  
                    s.deltaX = -s.deltaX;

                }
               
                
                    s.x += s.deltaX;
                    s.y += s.deltaY;
                

                if ((s.x+s.width/2  <= 300 ) &&(s.y+s.width/2 <=300) ) {
                    remove.Add(count);
                }

                count++;
            }
            
            foreach(int i in remove) {

                engine.Squares[i].Color = "Black";

            }
            Repaint();
            foreach (int i in remove)
            {
                engine.Squares.RemoveAt(i);

            }

        }
        private void Step()
        {
            List<int> remove = new List<int>();
            int count = 0;
            foreach (Circle c in engine.circles)
            {
                

                // Right wall

                if (c.Center.X + c.Radius > MyCanvas.Width + c.Radius/2)
                {
                    c.deltaX = -c.deltaX;
                    
                }

                if (c.Center.Y + c.Radius > MyCanvas.Height + c.Radius/2) {
                     c.deltaY = -c.deltaY;
                }

                if (c.Center.Y + c.Radius < c.Radius+c.Radius/2)
                {
                    c.deltaY= -c.deltaY;

                }

                if (c.Center.X + c.Radius < c.Radius + c.Radius / 2)
                {
                     c.deltaX= -c.deltaX;

                }
                
                c.Center.X += c.deltaX;
                c.Center.Y += c.deltaY;

                if ( c.Center.X+c.Radius/2  <= 300 &&  c.Center.Y+c.Radius/2  <= 300)
                {
                    remove.Add(count);
                }

                count++;


            }
            foreach (int i in remove)
            {

                engine.circles[i].Color = "Black";

            }
            Repaint();
            foreach (int i in remove)
            {
                engine.circles.RemoveAt(i);

            }
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            colorChoice = "Blue";
            Repaint();
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            colorChoice = "Green";
            Repaint();
        }
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            colorChoice = "Red";
            Repaint();
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            shapeChoice = "Square";
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            shapeChoice = "Circle";
        }
    }
}
