using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace PrinterTestForms
{


    public partial class Form1 : Form
    {

        private FSpicturebox n;
        public enum material
        {
            m1 = 0,
            m2, m3, m4
        };
        public enum axis
        {
            x = 'X',
            y = 'Y',
            z = 'Z'
        }
        private double _layerHeight = Properties.Settings.Default.Z_layerHeight; //Expressed in millimeters
        private int _numberOfLayers = 0;
        private double _totalHeight = 0;
        private int _currentImage = 0;
        private bool? absoluteMode = null;
        public Tuple<axis, double> X_putAwayPosition = new Tuple<axis, double>(axis.x, Properties.Settings.Default.X_putAwayPosition);
        public Tuple<axis, double> X_takeOutPosition = new Tuple<axis, double>(axis.x, Properties.Settings.Default.X_printingPosition);
        public Tuple<axis, double> X_toClipPosition = new Tuple<axis, double>(axis.x, Properties.Settings.Default.X_toClipPosition);
        public Tuple<axis, double> X_cleaningPosition = new Tuple<axis, double>(axis.x, Properties.Settings.Default.X_materialChangePosition);
        public List<Tuple<axis, double>> Y_towerPositionsHookPush = new List<Tuple<axis, double>>() {
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPush1 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPush2 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPush3 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPush4 }
        };
        public List<Tuple<axis, double>> Y_towerPositionsHookDisengaged = new List<Tuple<axis, double>>() {
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookDisengaged1 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookDisengaged2 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookDisengaged3 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookDisengaged4 }
        };
        public List<Tuple<axis, double>> Y_towerPositionsHookPull = new List<Tuple<axis, double>>() {
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPull1 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPull2 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPull3 },
            { axis.y, Properties.Settings.Default.Y_towerPositionsHookPull4 }
        };
        public Tuple<axis, double> Z_heightToRaiseBed = new Tuple<axis, double>(axis.z, Properties.Settings.Default.Z_heightToRaiseBed);
        private material _currentMaterial = material.m1;
        List<material> _activeMaterials = new List<material>();
        List<string> _materialDirectories = new List<string>() { null, null, null, null, };
        List<int> _layersRemainingForMaterial = new List<int>() { 0, 0, 0, 0, };
        List<int> _finalLayerForMaterial = new List<int>() { 0, 0, 0, 0 };
        List<bool> _thisLayerHasMaterial = new List<bool>() { false, false, false, false };
        List<Queue<string>> _fileNames = new List<Queue<string>>() { new Queue<string>(), new Queue<string>(), new Queue<string>(), new Queue<string>() };
        String comPort = string.Empty;
        public int baud = Properties.Settings.Default.printerBaudRate;
        Queue<String> commands = new Queue<string>();
        String lastMessageSent = string.Empty;
        SettingsForm set = new SettingsForm();

        /// <summary>
        /// Indicates whether the Arduino is ready to receive further commands (Last string recieved from Arduino == "ok"
        /// </summary>
        bool _readyToReceive = true;


        public Form1()
        {
            InitializeComponent();
            //Initializes new instance of the projected picture and sets the image to full screen.
            n = new FSpicturebox();
            n.StartPosition = FormStartPosition.Manual;
            n.Bounds = Screen.AllScreens.Last().Bounds;
            n.BackColor = Color.Black;
            n.FormBorderStyle = FormBorderStyle.None;
            n.Show();
            n.WindowState = FormWindowState.Maximized;
            n.fitPictureToFrame();

            //Format the listboxes and preview images within the material image display tabs;
            mat1list.Bounds = tabPage1.Bounds;
            mat2list.Bounds = tabPage2.Bounds;
            mat3list.Bounds = tabPage3.Bounds;
            mat4list.Bounds = tabPage4.Bounds;
            previewPic1.Bounds = tabpreview1.Bounds;
            previewPic1.BackColor = Color.Black;
            previewPic2.Bounds = tabpreview2.Bounds;
            previewPic2.BackColor = Color.Black;
            previewPic3.Bounds = tabpreview3.Bounds;
            previewPic3.BackColor = Color.Black;
            previewPic4.Bounds = tabpreview4.Bounds;
            previewPic4.BackColor = Color.Black;
            PreviewBar.Maximum = 0;

            //Populates the combobox with a list of available COM ports and sets the comPort field to the first value.
            string[] ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
            if (ports.Length > 0)
            {
                comPort = ports[0];
                serialPort1 = new SerialPort(comPort, baud);
                statusText.Text = comPort + " selected";
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                serialPort1.Open();
                serialPort1.DtrEnable = true;
            }
            else statusText.Text = "Arduino not connected.";
        }


        // --------------------------Algorithm Operations ----------------------------------------

        /// <summary>
        /// Assigns the _currentMaterial field to the next material to be printed. Optimized based on _thisLayerHasMaterial
        /// Further optimization: sequence should be picked to match materials between layers
        /// </summary>
        public material nextMaterial()
        {
            material nextMaterial = new material();
            switch (_currentMaterial)
            {
                case material.m1:
                    if (_thisLayerHasMaterial[(int)material.m2]) nextMaterial = material.m2;
                    else if (_thisLayerHasMaterial[(int)material.m3]) nextMaterial = material.m3;
                    else nextMaterial = material.m4;
                    break;
                case material.m2:
                    if (_thisLayerHasMaterial[(int)material.m1]) nextMaterial = material.m1;
                    else if (_thisLayerHasMaterial[(int)material.m3]) nextMaterial = material.m3;
                    else nextMaterial = material.m4;
                    break;
                case material.m3:
                    if (_thisLayerHasMaterial[(int)material.m4]) nextMaterial = material.m4;
                    else if (_thisLayerHasMaterial[(int)material.m2]) nextMaterial = material.m2;
                    else nextMaterial = material.m1;
                    break;
                case material.m4:
                    if (_thisLayerHasMaterial[(int)material.m3]) nextMaterial = material.m3;
                    else if (_thisLayerHasMaterial[(int)material.m2]) nextMaterial = material.m2;
                    else nextMaterial = material.m1;
                    break;
            }
            return nextMaterial;
        }

        public bool checkImage()
        {
            //if image has white pixels, then
            return true;
        }

        /// <summary>
        /// Sends the strings contained in the commands queue to the printer
        /// </summary>
        public void processCommands()
        {
            if (serialPort1.IsOpen)
            {
                while (commands.Count > 0)
                {
                    string command = commands.Dequeue();
                    serialBox.AppendText("<<TX>> " + command + System.Environment.NewLine);
                    while (!sendMessage(command)) ;
                }
            }
            else serialBox.AppendText("<<ERROR>> " + "No Printer Detected" + System.Environment.NewLine);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                string returnMessage = serialPort1.ReadTo("\n");
                serialBox.AppendText(">>RX<< " + returnMessage + System.Environment.NewLine);
                if (returnMessage == "ok")
                {
                    _readyToReceive = true;
                }
            }
        }


        // ---------------------------Printer Operations------------------------------------------
        private void PRINT()
        {

        }

        private void setRelativeCoordinates()
        {
            commands.Enqueue("G91");
            absoluteMode = true;
        }
        private void setAbsoluteCoordinates()
        {
            commands.Enqueue("G90");
            absoluteMode = false;

        }
        /// <summary>
        /// Performs the sequence of movements required to change from the _currentMaterial to "mat"
        /// </summary>
        /// <param name="mat">The material that will be available once the operation is finished</param>
        private void changeToMaterial(material mat)
        {
            putAwayMaterial();
            queueMaterial(mat);
            takeOutMaterial();
            _currentMaterial = mat;
        }

        /// <summary>
        /// Puts away the _currentMaterial
        /// </summary>
        private void putAwayMaterial()
        {
            setRelativeCoordinates();
            move(Z_heightToRaiseBed);
            setAbsoluteCoordinates();
            move(X_putAwayPosition);
            move(Y_towerPositionsHookDisengaged[(int)_currentMaterial]);
            move(X_cleaningPosition);
        }

        /// <summary>
        /// Changes the position of the material tower to the "mat" position
        /// </summary>
        /// <param name="mat">The desired material</param>
        private void queueMaterial(material mat)
        {
            setAbsoluteCoordinates();
            move(Y_towerPositionsHookDisengaged[(int)mat]);
        }

        /// <summary>
        /// Takes out _currentMaterial
        /// </summary>
        private void takeOutMaterial()
        {
            setAbsoluteCoordinates();
            move(X_toClipPosition);
            move(Y_towerPositionsHookPull[(int)_currentMaterial]);
            move(X_takeOutPosition);
            //move(z, )
        }

        /// <summary>
        /// Performs a shear operation to release the part from the print window
        /// </summary>
        private void shear()
        {
            //Insert G-code to shear layer
        }

        /// <summary>
        /// Performs a cleaning operation on the part to prepare it for material change
        /// </summary>
        private void clean()
        {
            //Insert G-code to clean material
        }
        private void move(Tuple<axis, double> movement)
        {
            commands.Enqueue("G1 " + movement.Item1.ToString().ToUpper() + movement.Item2.ToString());
        }

        /// <summary>
        /// Sends the specified axes to the home position
        /// </summary>
        /// <param name="axes">optional: specify the axi(e)s to home. Passing no arguments will home all axes.</param>
        private void home(params axis[] axes)
        {
            String message = "G28 ";
            foreach (axis axis in axes)
            {
                string ax = axis.ToString();
                if (ax.ToUpper().Equals("X") || ax.ToUpper().Equals("Y") || ax.ToUpper().Equals("Z"))
                {
                    message += ax.ToUpper() + " ";
                }
            }
            commands.Enqueue(message);
        }






        //-------------------------------GUI Methods ----------------------------------------
        private void PreviewBar_Scroll(object sender, ScrollEventArgs e)
        {
            layerText.Text = (PreviewBar.Value + 1).ToString();
            foreach (material mat in _activeMaterials)
            {
                if (_finalLayerForMaterial[(int)mat] > PreviewBar.Value) updatePreviewImage(mat, PreviewBar.Value);
                else updatePreviewImage(mat);
            }
        }
        /// <summary>
        /// Updates the preview box with the specified image. If no file number is specified, then the image will be black
        /// </summary>
        /// <param name="mat">the material preview to be updated</param>
        /// <param name="fileNumber">the file number of the material to preview</param>
        private void updatePreviewImage(material mat, int fileNumber = -1)
        {
            PictureBox pic = new PictureBox();
            switch (mat)
            {
                case material.m1:
                    pic = previewPic1;
                    break;
                case material.m2:
                    pic = previewPic2;
                    break;
                case material.m3:
                    pic = previewPic3;
                    break;
                case material.m4:
                    pic = previewPic4;
                    break;
            }
            if (fileNumber == -1) pic.Image = null;
            else pic.Image = Image.FromFile(_fileNames[(int)mat].ElementAt(fileNumber));

        }



        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void showPreviewButton_Click(object sender, EventArgs e)
        {
            PictureBox image = new PictureBox();
            switch (previewTabs.SelectedIndex)
            {
                case 0:
                    image = previewPic1;
                    break;
                case 1:
                    image = previewPic2;
                    break;
                case 2:
                    image = previewPic3;
                    break;
                case 3:
                    image = previewPic4;
                    break;
            }
            n.changePicture(image);
        }

        private void showBlankButton_Click(object sender, EventArgs e)
        {
            n.clearPicture();
        }
        //Material checkboxes that update the image directories and display the image lists
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try { populateMaterialFields(material.m1, tabPage1, mat1list, checkBox1, previewPic1, tabpreview1); }
            catch { }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try { populateMaterialFields(material.m2, tabPage2, mat2list, checkBox2, previewPic2, tabpreview2); }
            catch { }

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try { populateMaterialFields(material.m3, tabPage3, mat3list, checkBox3, previewPic3, tabpreview3); }
            catch { }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try { populateMaterialFields(material.m4, tabPage4, mat4list, checkBox4, previewPic4, tabpreview4); }
            catch { }
        }

        //This method encapsulates the actions taken when a material checkbox is toggled, which includes
        //updating directory, image count, and file name fields
        private void populateMaterialFields(material mat, TabPage filesTab, ListBox list, CheckBox box, PictureBox previewPic, TabPage previewTab)
        {
            if (box.Checked)
            {
                FolderBrowserDialog d = new FolderBrowserDialog();
                d.Description = "Select Material " + ((int)mat + 1).ToString();
                if (d.ShowDialog() == DialogResult.OK)
                {
                    _materialDirectories[(int)mat] = d.SelectedPath;
                    _layersRemainingForMaterial[(int)mat] = Directory.GetFiles(d.SelectedPath).Length;
                    Queue<string> temp = new Queue<string>(Directory.GetFiles(d.SelectedPath));
                    _fileNames.RemoveAt((int)mat);
                    _fileNames.Insert((int)mat, temp);
                }
                list.Items.Clear();
                foreach (string item in Directory.GetFiles(d.SelectedPath).Select(Path.GetFileName))
                {
                    list.Items.Add(item);
                }
                filesTab.Controls.Add(list);
                list.Size = filesTab.Size;
                filesTab.Text = "Material " + ((int)mat + 1).ToString();
                previewTab.Text = filesTab.Text;
                tabControl1.SelectedTab = filesTab;
                string finalFile = _fileNames[(int)mat].Last();
                finalFile = finalFile.Substring(finalFile.Length - 8, 4);
                _finalLayerForMaterial[(int)mat] = Convert.ToInt32(finalFile);
                updatePreviewImage(mat, PreviewBar.Value);
                _activeMaterials.Add(mat);
            }
            else
            {
                filesTab.Controls.Clear();
                filesTab.Text = "---";
                previewTab.Text = "---";
                _materialDirectories[(int)mat] = null;
                _layersRemainingForMaterial[(int)mat] = 0;
                _fileNames[(int)mat] = new Queue<string>();
                _finalLayerForMaterial[(int)mat] = 0;
                previewPic.Image = null;
                _activeMaterials.Remove(mat);
            }
            _numberOfLayers = findTotalLayers();
        }


        //Handles the selection of the COM port.
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            serialBox.Clear();
            serialPort1.Close();
            comPort = comboBox1.SelectedItem.ToString();
            serialPort1 = new SerialPort(comPort, baud);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            statusText.Text = comPort + " selected";
            serialPort1.Open();
            serialPort1.DtrEnable = true;
            _readyToReceive = true;

        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
        }

        private int findTotalLayers()
        {
            int max = 0;
            foreach (int layers in _finalLayerForMaterial)
            {
                if (layers > max) max = layers;
            }
            PreviewBar.Maximum = max + 8;
            return max;
        }

        //Handles cases where the message box content is sent when the send button is pressed
        private void sendButton_Click(object sender, EventArgs e)
        {
            sendMessageInTextBox();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialBox.Clear();
                serialPort1.Close();
                comPort = comboBox1.SelectedItem.ToString();
                serialPort1 = new SerialPort(comPort, baud);
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                statusText.Text = comPort + " Reset";
                serialPort1.Open();
                serialPort1.DtrEnable = true;
                _readyToReceive = true;
            }

        }

        private void homeXButton_Click(object sender, EventArgs e)
        {
            home(axis.x);
            Thread t = new Thread(() => processCommands());
            t.Start();
            t.Join();

        }
        private void homeYButton_Click(object sender, EventArgs e)
        {
            home(axis.y);
            Thread t = new Thread(() => processCommands());
            t.Start();
            t.Join();

        }
        private void homeZButton_Click(object sender, EventArgs e)
        {
            home(axis.z);
            Thread t = new Thread(() => processCommands());
            t.Start();
            t.Join();

        }
        private void homeXYButton_Click(object sender, EventArgs e)
        {
            home(axis.x, axis.y);
            Thread t = new Thread(() => processCommands());
            t.Start();
            t.Join();
        }

        //handles the cases where the message box content is sent via the return key
        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && messageBox.Text != string.Empty)
            {
                sendMessageInTextBox();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                messageBox.Text = lastMessageSent;
            }


        }
        private void sendMessageInTextBox()
        {
            String message = messageBox.Text;
            messageBox.Clear();
            serialBox.AppendText("<<TX>> " + message + System.Environment.NewLine);
            if (serialPort1.IsOpen)
            {
                sendMessage(message);
            }
            else serialBox.AppendText("<<ERROR>> " + "No Printer Detected" + System.Environment.NewLine);
            statusText.Text = "Manual command sent to Arduino.";
            lastMessageSent = message;
        }
        private bool sendMessage(string msg)
        {
            bool success = false;
            if (_readyToReceive == true)
            {
                _readyToReceive = false;
                serialPort1.WriteLine(msg);
                success = true;
            }
            return success;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (!set.Visible)
            {
                set.setSerialPort(serialPort1);
                set.Show();
            }
        }
    }
    public static class TupleListExtensions
    {
        public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list,
                T1 item1, T2 item2)
        {
            list.Add(Tuple.Create(item1, item2));
        }
    }

}

