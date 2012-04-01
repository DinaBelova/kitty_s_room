using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using kitty_s_room.strategies;

namespace kitty_s_room {

    class Kitty: BaseObject {
        public ObjectStrategy<Kitty> strategy;

        public int speed = 5;    // px per tick
        public int health = 100;

        public Kitty(PointF pos) {
            this.position.X = pos.X - 100;
            this.position.Y = pos.Y - 100;

            this.size = new SizeF(250, 200);

            strategy = new KittyLifeStrategy(this);
        }

        public override ImageEnum getImageEnum() {
            return ImageEnum.kitty;
        }

        public override bool move() {
            if (strategy == null) {
                strategy = NoOpKittyStrategy.INSTANCE;
            }

            if (strategy.isExecutable()) {
                return strategy.execute();
            }

            return false;
        }
    }
}
