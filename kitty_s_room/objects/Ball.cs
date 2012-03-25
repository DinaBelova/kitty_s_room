using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {

    class Ball: BaseObject {

        public Ball(PointF pos) {
            this.position = pos;

            this.size = new SizeF(50, 50);
        }

        public override ImageEnum getImageEnum() {
            return ImageEnum.ball;
        }
    }
}
