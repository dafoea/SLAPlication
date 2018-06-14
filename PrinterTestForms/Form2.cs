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
    public partial class black_png_form : Form
    {
        public black_png_form()
        {
            InitializeComponent();
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = "Select File Location";
            if (d.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap(Properties.Resources.AllBlackImage);
                for (int number = (int)startingimgNUD.Value; number <= numberofimgNUD.Value; number++)
                {
                    if (number < 10)
                    {
                        b.Save(d.SelectedPath + "/" + imagePrefixBox.Text + "000" + number.ToString()+".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (number < 100)
                    {
                        b.Save(d.SelectedPath + "/" + imagePrefixBox.Text + "00" + number.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (number < 1000)
                    {
                        b.Save(d.SelectedPath + "/" + imagePrefixBox.Text + "0" + number.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        b.Save(d.SelectedPath + "/" + imagePrefixBox.Text + number.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    
                }
                MessageBox.Show("Finished", "Blank Image Generator");
            }
        }
    }
}
