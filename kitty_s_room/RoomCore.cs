﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room
{
    class RoomCore
    {
        public int windowWidth;
        public int windowHeight;
        private List<BaseObject> objectList;

        public RoomCore() { }
        public static RoomCore instance = new RoomCore();

        public void initialize(int width, int height)
        {
            this.windowWidth = width;
            this.windowHeight = height;
            this.objectList = new List<BaseObject>();

            // добавить объекты в лист объектов: котенок, мячик, лоток, миска, коврик
            Kitty kitty = new Kitty(new PointF((float)(windowWidth / 2.0), (float)(windowHeight / 2.0)));
            Ball ball = new Ball(new PointF(0, 0));
            Bowl bowl = new Bowl(new PointF((float)this.windowWidth, (float)this.windowHeight));
            Tray tray = new Tray(new PointF((float)this.windowWidth, 0));
            Carpet carpet = new Carpet(new PointF(0, (float)this.windowHeight));

            this.objectList.Add(kitty);
            this.objectList.Add(ball);
            this.objectList.Add(bowl);
            this.objectList.Add(tray);
            this.objectList.Add(carpet);
        }

        public void refresh()
        {
            if (this.objectList == null)
            {
                throw new ApplicationException("Необходимо сначала вызвать метод инициализации initialize()");
            }

            foreach (BaseObject obj in this.objectList)
            {
                obj.move();
            }
        }

        internal void drawWindow(Graphics graph)
        {
            if (this.objectList == null)
            {
                throw new ApplicationException("Необходимо сначала вызвать метод инициализации initialize()");
            }

            foreach (BaseObject obj in this.objectList)
            {
                obj.draw(graph);
            }
        }

        public void select(int x, int y)
        {
            //заглушка
        }
    }
}