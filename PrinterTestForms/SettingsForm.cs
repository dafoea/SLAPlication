﻿using System;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_putAwayPosition = (double)numericUpDown1.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_printingPosition = (double)numericUpDown16.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_toClipPosition = (double)numericUpDown15.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_materialChangePosition = (double)numericUpDown17.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush1 = (double)numericUpDown14.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush2 = (double)numericUpDown13.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush3 = (double)numericUpDown12.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush4 = (double)numericUpDown11.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged1 = (double)numericUpDown10.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged2 = (double)numericUpDown9.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged3 = (double)numericUpDown8.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged4 = (double)numericUpDown7.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull1 = (double)numericUpDown6.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull2 = (double)numericUpDown5.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull3 = (double)numericUpDown4.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull4 = (double)numericUpDown3.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_heightToRaiseBed = (double)numericUpDown2.Value;
            Properties.Settings.Default.Save();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.printerBaudRate = Convert.ToInt32(textBox1.Text);
            Properties.Settings.Default.Save();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.printerBaudRate.ToString();
            numericUpDown1.Value = (decimal)Properties.Settings.Default.X_putAwayPosition;
            numericUpDown2.Value = (decimal)Properties.Settings.Default.Z_heightToRaiseBed;
            numericUpDown3.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull4;
            numericUpDown4.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull3;
            numericUpDown5.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull2;
            numericUpDown6.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull1;
            numericUpDown7.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged4;
            numericUpDown8.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged3;
            numericUpDown9.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged2;
            numericUpDown10.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged1;
            numericUpDown11.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush4;
            numericUpDown12.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush3;
            numericUpDown13.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush2;
            numericUpDown14.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush1;
            numericUpDown15.Value = (decimal)Properties.Settings.Default.X_toClipPosition;
            numericUpDown16.Value = (decimal)Properties.Settings.Default.X_printingPosition;
            numericUpDown17.Value = (decimal)Properties.Settings.Default.X_materialChangePosition;
            numericUpDown18.Value = (decimal)Properties.Settings.Default.Z_layerHeight;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_layerHeight = (double)numericUpDown18.Value;
            Properties.Settings.Default.Save();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
