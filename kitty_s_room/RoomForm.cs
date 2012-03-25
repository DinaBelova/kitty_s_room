using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kitty_s_room {
    public partial class RoomForm : Form {
        private RoomCore roomCore = RoomCore.instance;

        private Bitmap background;
        private bool changed;
        
        public RoomForm() {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e) {
            roomCore.initialize(this.Width, this.Height);
            timer.Enabled = true;

            background = new Bitmap(ImagePool.Instance.floor, Width, Height);
        }

        private void timer_Tick(object sender, EventArgs e) {
            // roomCore.Resize(Width, Height);
            roomCore.refresh();

            if (changed) {
                changed = false;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(background, 0, 0);
            roomCore.drawObjects(e.Graphics); 
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e) {
            roomCore.select(e.X, e.Y);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            roomCore.mouseDown(e);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (roomCore.mouseMove(e)) {
                changed = true;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            roomCore.mouseUp(e);
        }     
    }
}
