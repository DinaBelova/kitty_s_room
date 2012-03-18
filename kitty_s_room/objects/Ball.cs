using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Ball: BaseObject {
        public Ball(PointF pos) {
            this.position = pos;

            SizeF sz = new SizeF(50, 50);
            this.size = new RectangleF(position, sz);
        }

         public override void draw(Graphics graph) {
             ImagePool.Instance.DrawImage(graph, this.size, ImageEnum.ball);
         }

         public override void move() {
             throw new NotImplementedException();
         }
    }
}
