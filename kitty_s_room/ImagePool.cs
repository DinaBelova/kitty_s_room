using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kitty_s_room {
    public class ImagePool {
        public Dictionary<ImageEnum, Image> imageObject { get; protected set; }
        public Image floor { get; protected set; }

        protected ImagePool() {
            floor = Images.floor;

            System.Console.Write(Images.cat);

            imageObject.Add(ImageEnum.kitty, Images.cat);
            imageObject.Add(ImageEnum.ball, Images.ball);
            imageObject.Add(ImageEnum.bowl, Images.bowl);
            imageObject.Add(ImageEnum.carpet, Images.carpet);
            imageObject.Add(ImageEnum.lotok, Images.lotok);
        }


        public void DrawImage(Graphics gr, PointF pos, ImageEnum en) {
            gr.DrawImage(imageObject[en], pos.X, pos.Y);
        }

        private sealed class SingletonCreator {
            private static readonly ImagePool instance = new ImagePool();
            public static ImagePool Instance { get { return instance; } }
        }

        public static ImagePool Instance {
            get { return SingletonCreator.Instance; }
        }
    }
}
