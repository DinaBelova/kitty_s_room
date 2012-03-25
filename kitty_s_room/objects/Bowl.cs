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

        public override ImageEnum getImageEnum() {
            return ImageEnum.bowl;
        }
    }
}
