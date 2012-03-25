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

        public RoomForm() {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e) {
            roomCore.initialize(this.Width, this.Height);
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e) {
            // roomCore.Resize(Width, Height);
            roomCore.refresh();
            Bitmap bitmap = new Bitmap(ImagePool.Instance.floor, Width, Height);
            Graphics graph = Graphics.FromImage(bitmap);
            roomCore.drawWindow(graph);
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }

        private void RoomForm_Paint(object sender, PaintEventArgs e) {
            roomCore.drawWindow(e.Graphics);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e) {
            roomCore.select(e.X, e.Y);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            roomCore.mouseDown(e);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
            roomCore.mouseMove(e);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            roomCore.mouseUp(e);
        }

        
    }
}
