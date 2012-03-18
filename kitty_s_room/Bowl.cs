using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kitty_s_Room {

    class Bowl: BaseObject {
        public Bowl(PointF pos) {
            this.width = 50;
            this.height = 50;
            this.position = pos; 
        }

        public override void draw(Graphics graph) {
            ImagePool.Instance.DrawImage(graph, position, ImageEnum.bowl);
        }

        public override void move() {
            throw new NotImplementedException();
        }
    }
}
