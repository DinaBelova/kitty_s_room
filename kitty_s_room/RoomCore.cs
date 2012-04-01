using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace kitty_s_room {
    class RoomCore {
        public static RoomCore INSTANCE = new RoomCore();

        public int windowWidth;
        public int windowHeight;
        private List<BaseObject> objectList;
        public BaseObject draggingObject;
        private int dragShiftX;
        private int dragShiftY;

        public RoomCore() { }

        public void initialize(int width, int height) {
            this.windowWidth = width;
            this.windowHeight = height;
            this.objectList = new List<BaseObject>();

            Kitty kitty = new Kitty(new PointF((float)(windowWidth / 2.0), (float)(windowHeight / 2.0)));
            Ball ball = new Ball(new PointF(0, 0));
            Bowl bowl = new Bowl(new PointF((float)this.windowWidth, (float)this.windowHeight));
            Tray tray = new Tray(new PointF((float)this.windowWidth, 0));
            Carpet carpet = new Carpet(new PointF(0, (float)this.windowHeight));

            this.objectList.Add(carpet);
            this.objectList.Add(bowl);
            this.objectList.Add(tray);
            this.objectList.Add(ball);
            this.objectList.Add(kitty);
        }

        public bool refresh() {
            if (this.objectList == null) {
                throw new ApplicationException("Необходимо сначала вызвать метод инициализации initialize()");
            }

            bool visibleChanges = false;
            foreach (BaseObject obj in this.objectList) {
                visibleChanges |= obj.move();
            }

            return visibleChanges;
        }

        internal void drawObjects(Graphics graph) {
            if (this.objectList == null) {
                throw new ApplicationException("Необходимо сначала вызвать метод инициализации initialize()");
            }

            foreach (BaseObject obj in this.objectList) {
                obj.draw(graph);
            }
        }

        public void select(int x, int y) {
            for (int i = 0; i < objectList.Count; i++) {
                BaseObject currentObject = objectList[i];
                if (hitTest(currentObject, x, y)) {
                    if (currentObject.selected) {
                        currentObject.selected = false;
                    } else {
                        currentObject.selected = true;
                    }
                }
            }
        }

        public void mouseDown(MouseEventArgs e) {
            for (int i = objectList.Count - 1; i >= 0; i--) {
                BaseObject currentObject = objectList[i];
                if (hitTest(currentObject, e.X, e.Y)) {
                    draggingObject = currentObject;
                    dragShiftX = e.X - (int)currentObject.position.X;
                    dragShiftY = e.Y - (int)currentObject.position.Y;
                    break;
                }
            }

            mouseMove(e);
        }

        private bool hitTest(BaseObject obj, int x, int y) {
            if (!(x >= obj.position.X && x <= obj.position.X + obj.size.Width && y >= obj.position.Y && y <= obj.position.Y + obj.size.Height)) {
                return false;
            }

            Bitmap bitmap = obj.getBitmap();
            if (bitmap.GetPixel(x - (int)obj.position.X, y - (int)obj.position.Y).A < 5) {
                return false;
            }

            return true;
        }

        public bool mouseMove(MouseEventArgs e) {
           if (draggingObject != null) {
               draggingObject.position.X = e.X - dragShiftX;
               draggingObject.position.Y = e.Y - dragShiftY;
               return true;
           }

           return false;
        }

        public void mouseUp(MouseEventArgs e) {
            mouseMove(e);
            draggingObject = null;
        }
    }
}
