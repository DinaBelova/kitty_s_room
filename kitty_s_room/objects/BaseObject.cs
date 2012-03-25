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
        private Bitmap bitmap;

        public abstract ImageEnum getImageEnum();

        public void move() { }
        
        public Image getImage() { 
            return ImagePool.Instance.imageObject[getImageEnum()];
        }

        public Bitmap getBitmap() {
            if (bitmap == null) {
                bitmap = new Bitmap(getImage(), size.ToSize());
            }

            return bitmap;
        }

        public void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, new RectangleF(this.position, this.size), getImageEnum());
        }
    }
}
