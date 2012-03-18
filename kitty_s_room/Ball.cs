using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kitty_s_Room {

    class Ball: BaseObject {
        public Ball(PointF pos) {
            this.width = 50;
            this.height = 50;
            this.position = pos;
        }

         public override void draw(Graphics graph) {
             ImagePool.Instance.DrawImage(graph, position, ImageEnum.ball);
         }

         public override void move() {
             throw new NotImplementedException();
         }
    }
}
