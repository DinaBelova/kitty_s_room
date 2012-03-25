using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {
    abstract class BaseObject {
        public PointF position;
        public SizeF size;
        public bool selected;

        public abstract void draw(Graphics graph);
        public abstract void move();

        public bool hitTest(int x, int y) {
            return (x >= position.X && x <= position.X + size.Width && y >= position.Y && y <= position.Y + size.Height);
        }
    }
}
