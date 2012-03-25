using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Carpet: BaseObject {
        public Carpet(PointF pos) {
            this.position.X = pos.X;
            this.position.Y = pos.Y - 235;

            this.size = new SizeF(120, 200);
        }

        public override void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, new RectangleF(this.position, this.size), ImageEnum.carpet);
        }

        public override void move() {}
    }
}
