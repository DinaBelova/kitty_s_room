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

            this.size = new SizeF(120, 100);
        }

        public override ImageEnum getImageEnum() {
            return ImageEnum.lotok;
        }
    }
}
