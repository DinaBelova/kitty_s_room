using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kitty_s_room.strategies {
    class KittyLifeStrategy: ObjectStrategy<Kitty> {
        private List<ObjectStrategy<Kitty>> strategies = new List<ObjectStrategy<Kitty>>();

        public KittyLifeStrategy(Kitty obj): base(obj) {
            // strategies should be sorted by their priorities
            strategies.Add(new KittyBallFollowingStrategy(obj));
        }

        public override bool isExecutable() {
            return true; // it is the router for strategies
        }

        public override bool execute() {
            bool visibleChanges = false;
            foreach (ObjectStrategy<Kitty> strategy in strategies) {
                if (strategy != null && strategy.isExecutable()) {
                    visibleChanges |= strategy.execute();
                    break;
                }
            }

            return visibleChanges;
        }
    }
}
