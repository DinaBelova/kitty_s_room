using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Bowl: BaseObject {
        public Bowl(PointF pos) {
            this.position.X = pos.X - 65;
            this.position.Y = pos.Y - 90;

            this.size = new SizeF(50, 50);
        }

        public override void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, new RectangleF(this.position, this.size), ImageEnum.bowl);
        }

        public override void move() {}
    }
}
