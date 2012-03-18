using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Tray: BaseObject {
        public Tray(PointF pos) {
            this.position.X = pos.X - 135;
            this.position.Y = pos.Y;

            SizeF sz = new SizeF(120, 100);
            this.size = new RectangleF(position, sz);
        }

        public override void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, this.size, ImageEnum.lotok);
        }

        public override void move() {
            throw new NotImplementedException();
        }
    }
}
