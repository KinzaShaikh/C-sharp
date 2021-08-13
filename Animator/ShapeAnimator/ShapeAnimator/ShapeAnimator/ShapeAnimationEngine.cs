using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeAnimator
{
    class ShapeAnimationEngine
    {
        public List<Circle> circles = new List<Circle>();
        public List<Square> Squares = new List<Square>();

        internal void AddCircle(Point p, int r, string color)
        {
            Circle c = new Circle(p, r, color);
            circles.Add(c);
        }
        internal void AddSquare(int x, int y,int a, string color) {
            Square s = new Square(x,y, a, color);
            Squares.Add(s);
        }
    }
}
