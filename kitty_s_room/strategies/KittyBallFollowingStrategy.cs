using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kitty_s_room.strategies
{
    class KittyBallFollowingStrategy: ObjectStrategy<Kitty> {
        private bool lastY = true;

        public KittyBallFollowingStrategy(Kitty obj) : base(obj) { }

        public override bool isExecutable() {
            return core.draggingObject is Ball;
        }

        public override bool execute() {
            Ball ball = (Ball) core.draggingObject;
            int xShift = (int) ((obj.position.X + obj.size.Width / 2) - (ball.position.X + ball.size.Width / 2));
            int yShift = (int) ((obj.position.Y + obj.size.Height / 2) - (ball.position.Y + ball.size.Height / 2));

            if (xShift != 0 && (lastY || Math.Abs(yShift) == 0)) {
                obj.position.X += (xShift < 0 ? 1 : -1) * Math.Min(obj.speed, Math.Abs(xShift));
                lastY = false;
                return true;
            } 
            
            if (yShift != 0) {
                obj.position.Y += (yShift < 0 ? 1 : -1) * Math.Min(obj.speed, Math.Abs(yShift));
                lastY = true;
                return true;
            }

            return false;
        }
    }
}
