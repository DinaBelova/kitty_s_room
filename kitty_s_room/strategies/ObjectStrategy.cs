using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kitty_s_room.strategies {
    abstract class ObjectStrategy<T> {
        protected T obj;
        protected RoomCore core;

        public ObjectStrategy(T obj) {
            this.obj = obj;
            core = RoomCore.INSTANCE;
        }

        public abstract bool isExecutable();

        public abstract bool execute();
    }
}
