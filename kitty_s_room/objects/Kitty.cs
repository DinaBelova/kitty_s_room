using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Kitty: BaseObject {

        public Kitty(PointF pos) {
            this.position.X = pos.X - 100;
            this.position.Y = pos.Y - 100;

            SizeF sz = new SizeF(250, 200);
            this.size = new RectangleF(position, sz);
        }

        public override void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, this.size, ImageEnum.kitty);
        }

        public override void move() {
            throw new NotImplementedException();
        }
    }
}
