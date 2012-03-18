using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kitty_s_Room {
    abstract class BaseObject {
        public PointF position;
        public int width;
        public int height;

        public abstract void draw(Graphics graph);
        public abstract void move();

        public bool hitTest(int x, int y) {
            return (x >= position.X && x <= position.X + width && y >= position.Y && y <= position.Y + height);
        }
    }
}
