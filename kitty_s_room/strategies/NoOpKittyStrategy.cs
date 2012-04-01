using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kitty_s_room.strategies
{
    class NoOpKittyStrategy: ObjectStrategy<Kitty> {
        public static ObjectStrategy<Kitty> INSTANCE = new NoOpKittyStrategy();

        private NoOpKittyStrategy() : base(null) { }

        public override bool isExecutable() {
            return true;
        }

        public override bool execute() {
            // no operations
            return false;
        }
    }
}
