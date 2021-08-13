using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeAnimator
{
    class Square
    {
        public int x, y;
        public int width;
        public int height;
        public string Color;
        public int deltaX = 1; // -10 to go left, +10 to go right
        public int deltaY = 1;

        public Square(int x,int y, int a, string color) {
            this.Color = color;
            this.height = a;
            this.width = a;
            this.x = x;
            this.y = y;
        }


    }
}
