using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterTestForms
{
    public partial class FSpicturebox : Form
    {

        public FSpicturebox()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }


        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
        public void changePicture(string picture)
        {
            pictureBox1.Image = Image.FromFile(picture);
            pictureBox1.Size = Bounds.Size;
        }
        public void changePicture (PictureBox image)
        {
            pictureBox1.Image = image.Image;
        }
        public void clearPicture()
        {
            pictureBox1.Image = null;
        }

        public void fitPictureToFrame()
        {
            pictureBox1.Size = Size;
        }
    }
}
