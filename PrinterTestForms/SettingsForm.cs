﻿using System;
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

namespace PrinterTestForms
{
    public partial class SettingsForm : Form
    {
        SerialPort port;
        bool testingPumpOscillations = false;
        bool testingPumpChange = false;

        /// <summary>
        /// Passes the serial port handler to the settings window so the test buttons will work
        /// </summary>
        /// <param name="p"> the serial port handler from the main form</param>
        public void setSerialPort(SerialPort p)
        {
            port = p;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            X_PutAwayPosition.Value = (decimal)Properties.Settings.Default.X_putAwayPosition;
            Z_HeightToRaiseBed.Value = (decimal)Properties.Settings.Default.Z_heightToRaiseBed;
            Y_TowerPositionHookPull4.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull4;
            Y_TowerPositionHoolPull3.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull3;
            Y_TowerPositionHoolPull2.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull2;
            Y_TowerPositionHoolPull1.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPull1;
            Y_TowerPositionHookDisengage4.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged4;
            Y_TowerPositionHookDisengage3.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged3;
            Y_TowerPositionHookDisengage2.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged2;
            Y_TowerPositionHookDisengage1.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookDisengaged1;
            Y_TowerPositionsHookPush4.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush4;
            Y_TowerPositionsHookPush3.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush3;
            Y_TowerPositionsHookPush2.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush2;
            Y_TowerPositionsHookPush1.Value = (decimal)Properties.Settings.Default.Y_towerPositionsHookPush1;
            X_ToClipPosition.Value = (decimal)Properties.Settings.Default.X_toClipPosition;
            X_PrintingPosition.Value = (decimal)Properties.Settings.Default.X_printingPosition;
            X_MaterialChangePosition.Value = (decimal)Properties.Settings.Default.X_materialChangePosition;
            Z_LayerHeight.Value = (decimal)Properties.Settings.Default.Z_layerHeight;
            StartingLayersCureTime.Value = (decimal)Properties.Settings.Default.startingLayersCureTime;
            NumberOfStartingLayers.Value = (decimal)Properties.Settings.Default.numberOfStartingLayers;
            X_FeedRate.Value = (decimal)Properties.Settings.Default.X_feedrate;
            Y_FeedRate.Value = (decimal)Properties.Settings.Default.Y_feedrate;
            Z_FeedRate.Value = (decimal)Properties.Settings.Default.Z_feedrate;
            CureTime1.Value = (decimal)Properties.Settings.Default.cureTime1;
            CureTime2.Value = (decimal)Properties.Settings.Default.cureTime2;
            CureTime3.Value = (decimal)Properties.Settings.Default.cureTime3;
            CureTime4.Value = (decimal)Properties.Settings.Default.cureTime4;
            shearProcessBox.Text = Properties.Settings.Default.ShearProcess;
            Zzero1.Value = (decimal)Properties.Settings.Default.Z_zeroMaterial1;
            Zzero2.Value = (decimal)Properties.Settings.Default.Z_zeroMaterial2;
            Zzero3.Value = (decimal)Properties.Settings.Default.Z_zeroMaterial3;
            Zzero4.Value = (decimal)Properties.Settings.Default.Z_zeroMaterial4;
            X_PullOutPosition.Value = (decimal)Properties.Settings.Default.X_pullOutPosition;
            SprayIntensity.Value = (decimal)Properties.Settings.Default.pumpIntensitySpraying;
            CleaningIntensity.Value = (decimal)Properties.Settings.Default.pumpIntensityCleaning;
            CleaningOscillations.Value = (decimal)Properties.Settings.Default.numberOfCleaningOscillations;
            CleaningDistPositive.Value = (decimal)Properties.Settings.Default.X_positiveCleaningOscillationDistance;
            cleaningDistNeg.Value = (decimal)Properties.Settings.Default.X_negativeCleaningOscillationDistance;
            FeedDuringOsc.Value = (decimal)Properties.Settings.Default.cleaningOscillationSpeed;
            positiveBedCleaningDistance.Value = (decimal)Properties.Settings.Default.Z_positiveCleaningOscillationDistance;
            negativeBedCleaningDistance.Value = (decimal)Properties.Settings.Default.Z_negativeCleaningOscillationDistance;
            dryingFanDuration.Value = (decimal)Properties.Settings.Default.dryingFanDuration;
            dryingFanIntensity.Value = (decimal)Properties.Settings.Default.dryingFanIntensity;
            bedRaiseDuringDry.Value = (decimal)Properties.Settings.Default.Z_heightToRaiseWhileDrying;
            
            updateCleaningTime();

        }

        private void updateCleaningTime()
        {
            double crossDist = Math.Sqrt(Math.Pow((double)(CleaningDistPositive.Value + cleaningDistNeg.Value), 2) + Math.Pow((double)(positiveBedCleaningDistance.Value + negativeBedCleaningDistance.Value), 2));
            double moveDist = (double)(cleaningDistNeg.Value + CleaningDistPositive.Value);
            double cycleDist = 2 * moveDist + 2 * crossDist;


            cleaningDuration.Text = (Math.Round(cycleDist * (double)CleaningOscillations.Value / (double)FeedDuringOsc.Value * 60) + (double)dryingFanDuration.Value).ToString();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_putAwayPosition = (double)X_PutAwayPosition.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_printingPosition = (double)X_PrintingPosition.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_toClipPosition = (double)X_ToClipPosition.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_materialChangePosition = (double)X_MaterialChangePosition.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush1 = (double)Y_TowerPositionsHookPush1.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush2 = (double)Y_TowerPositionsHookPush2.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush3 = (double)Y_TowerPositionsHookPush3.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPush4 = (double)Y_TowerPositionsHookPush4.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged1 = (double)Y_TowerPositionHookDisengage1.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged2 = (double)Y_TowerPositionHookDisengage2.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged3 = (double)Y_TowerPositionHookDisengage3.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookDisengaged4 = (double)Y_TowerPositionHookDisengage4.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull1 = (double)Y_TowerPositionHoolPull1.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull2 = (double)Y_TowerPositionHoolPull2.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull3 = (double)Y_TowerPositionHoolPull3.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_towerPositionsHookPull4 = (double)Y_TowerPositionHookPull4.Value;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_heightToRaiseBed = (double)Z_HeightToRaiseBed.Value;
            Properties.Settings.Default.Save();

        }
        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cureTime1 = (double)CureTime1.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startingLayersCureTime = (double)StartingLayersCureTime.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.numberOfStartingLayers = (int)NumberOfStartingLayers.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown22_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_feedrate = (int)X_FeedRate.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown23_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Y_feedrate = (int)Y_FeedRate.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown24_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_feedrate = (int)Z_FeedRate.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown26_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cureTime2 = (double)CureTime2.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown25_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cureTime3 = (double)CureTime3.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown27_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.cureTime4 = (double)CureTime4.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_layerHeight = (double)Z_LayerHeight.Value;
            Properties.Settings.Default.Save();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShearProcess = shearProcessBox.Text;
            Properties.Settings.Default.Save();
        }
        private void Zzero2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_zeroMaterial2 = (double)Zzero2.Value;
            Properties.Settings.Default.Save();
        }

        private void Zzero1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_zeroMaterial1 = (double)Zzero1.Value;
            Properties.Settings.Default.Save();
        }

        private void Zzero3_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_zeroMaterial3 = (double)Zzero3.Value;
            Properties.Settings.Default.Save();
        }

        private void Zzero4_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_zeroMaterial4 = (double)Zzero4.Value;
            Properties.Settings.Default.Save();
        }
        private void X_PullOutPosition_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_pullOutPosition = (double)X_PullOutPosition.Value;
            Properties.Settings.Default.Save();
        }

        private void SprayIntensity_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.pumpIntensitySpraying = (int)SprayIntensity.Value;
            SprayIntensity.Value = (decimal)((int)SprayIntensity.Value);
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }
        private void CleaningIntensity_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.pumpIntensityCleaning = (int)CleaningIntensity.Value;
            CleaningIntensity.Value = (decimal)((int)CleaningIntensity.Value);
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void CleaningOscillations_ValueChanged(object sender, EventArgs e)
        {
            if (CleaningOscillations.Value < 1)
            {
                MessageBox.Show("Error: Number of oscillations must be at least 1");
                CleaningOscillations.Value = 1m;
            }
            Properties.Settings.Default.numberOfCleaningOscillations = (int)CleaningOscillations.Value;
            CleaningOscillations.Value = (decimal)((int)CleaningOscillations.Value);
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void CleaningDistPositive_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_positiveCleaningOscillationDistance = (double)CleaningDistPositive.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void FeedDuringOsc_ValueChanged(object sender, EventArgs e)
        {
            if ((int)FeedDuringOsc.Value > Math.Min(Properties.Settings.Default.X_feedrate, Properties.Settings.Default.Z_feedrate))
            {
                MessageBox.Show("Cleaning feedrate cannot exceed the maximum values of the X and Z axis feedrates. Restoring valid value.");
                FeedDuringOsc.Value = (decimal)Math.Min(Properties.Settings.Default.X_feedrate, Properties.Settings.Default.Z_feedrate);
            }
            Properties.Settings.Default.cleaningOscillationSpeed = (int)FeedDuringOsc.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void cleaningDistNeg_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.X_negativeCleaningOscillationDistance = (double)cleaningDistNeg.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void positiveBedCleaningDistance_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_positiveCleaningOscillationDistance = (double)positiveBedCleaningDistance.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void negativeBedCleaningDistance_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_negativeCleaningOscillationDistance = (double)negativeBedCleaningDistance.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();
        }

        private void dryingFanDuration_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dryingFanDuration = (int)dryingFanDuration.Value;
            dryingFanDuration.Value = (int)dryingFanDuration.Value;
            Properties.Settings.Default.Save();
            updateCleaningTime();

        }
        private void dryingFanIntensity_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dryingFanIntensity = (int)dryingFanIntensity.Value;
            dryingFanIntensity.Value = (int)dryingFanIntensity.Value;
            Properties.Settings.Default.Save();
        }

        private void bedRaiseDuringDry_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Z_heightToRaiseWhileDrying = (double)bedRaiseDuringDry.Value;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 X" + X_PutAwayPosition.Value.ToString() + " F" + X_FeedRate.Value.ToString());
            }
        }
        private void X_PulloutPosition_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 X" + X_PullOutPosition.Value.ToString() + " F" + X_FeedRate.Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 X" + X_PrintingPosition.Value.ToString() + " F" + X_FeedRate.Value.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 X" + X_ToClipPosition.Value.ToString() + " F" + X_FeedRate.Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 X" + X_MaterialChangePosition.Value.ToString() + " F" + X_FeedRate.Value.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionsHookPush1.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionsHookPush2.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionsHookPush3.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionsHookPush4.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHookDisengage1.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHookDisengage2.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHookDisengage3.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHookDisengage4.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHoolPull1.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHoolPull2.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHoolPull3.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Y" + Y_TowerPositionHookPull4.Value.ToString() + " F" + Y_FeedRate.Value.ToString());
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G91");
                Task.Delay(100);
                port.WriteLine("G1 Z-" + Z_HeightToRaiseBed.Value.ToString() + " F" + Z_FeedRate.Value.ToString());
            }
        }

        private void testShearButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                string[] lines = Properties.Settings.Default.ShearProcess.Split('\n');
                foreach (string line in lines)
                {
                    Task.Delay(100);
                    port.WriteLine(line);
                }
            }
        }
        private void ZM1_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Z" + Zzero1.Value.ToString() + " F" + Z_FeedRate.Value.ToString());
            }
        }

        private void ZM2_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Z" + Zzero2.Value.ToString() + " F" + Z_FeedRate.Value.ToString());
            }
        }

        private void ZM3_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Z" + Zzero3.Value.ToString() + " F" + Z_FeedRate.Value.ToString());
            }
        }

        private void ZM4_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                Task.Delay(100);
                port.WriteLine("G90");
                Task.Delay(100);
                port.WriteLine("G1 Z" + Zzero4.Value.ToString() + " F" + Z_FeedRate.Value.ToString());
            }
        }


        private void SaveButton(object sender, EventArgs e)
        {
            string[] values = {
                Properties.Settings.Default.X_putAwayPosition.ToString(),
                Properties.Settings.Default.Z_heightToRaiseBed.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPull4.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPull3.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPull2.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPull1.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookDisengaged4.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookDisengaged3.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookDisengaged2.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookDisengaged1.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPush4.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPush3.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPush2.ToString(),
                Properties.Settings.Default.Y_towerPositionsHookPush1.ToString(),
                Properties.Settings.Default.X_toClipPosition.ToString(),
                Properties.Settings.Default.X_printingPosition.ToString(),
                Properties.Settings.Default.X_materialChangePosition.ToString(),
                Properties.Settings.Default.Z_layerHeight.ToString(),
                Properties.Settings.Default.startingLayersCureTime.ToString(),
                Properties.Settings.Default.numberOfStartingLayers.ToString(),
                Properties.Settings.Default.X_feedrate.ToString(),
                Properties.Settings.Default.Y_feedrate.ToString(),
                Properties.Settings.Default.Z_feedrate.ToString(),
                Properties.Settings.Default.cureTime1.ToString(),
                Properties.Settings.Default.cureTime2.ToString(),
                Properties.Settings.Default.cureTime3.ToString(),
                Properties.Settings.Default.cureTime4.ToString(),
                Properties.Settings.Default.Z_zeroMaterial1.ToString(),
                Properties.Settings.Default.Z_zeroMaterial2.ToString(),
                Properties.Settings.Default.Z_zeroMaterial3.ToString(),
                Properties.Settings.Default.Z_zeroMaterial4.ToString(),
                Properties.Settings.Default.X_pullOutPosition.ToString(),

                Properties.Settings.Default.pumpIntensitySpraying.ToString(),
                Properties.Settings.Default.pumpIntensityCleaning.ToString(),
                Properties.Settings.Default.numberOfCleaningOscillations.ToString(),
                Properties.Settings.Default.X_positiveCleaningOscillationDistance.ToString(),
                Properties.Settings.Default.X_negativeCleaningOscillationDistance.ToString(),
                Properties.Settings.Default.cleaningOscillationSpeed.ToString(),
                Properties.Settings.Default.Z_positiveCleaningOscillationDistance.ToString(),
                Properties.Settings.Default.Z_negativeCleaningOscillationDistance.ToString(),
                Properties.Settings.Default.dryingFanDuration.ToString(),
                Properties.Settings.Default.dryingFanIntensity.ToString(),
                Properties.Settings.Default.Z_heightToRaiseWhileDrying.ToString()
                
               


        };
            SaveFileDialog file = new SaveFileDialog();
            file.OverwritePrompt = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(file.FileName))
                {
                    FileInfo finfo1 = new FileInfo(file.FileName);
                    finfo1.IsReadOnly = false;
                }

                System.IO.File.WriteAllLines(file.FileName, values);
                FileInfo finfo2 = new FileInfo(file.FileName);
                finfo2.IsReadOnly = true;
            }
        }

        private void LoadButton(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader line = new StreamReader(file.FileName);
                X_PutAwayPosition.Value = Convert.ToDecimal(line.ReadLine());
                Z_HeightToRaiseBed.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHookPull4.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHoolPull3.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHoolPull2.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHoolPull1.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHookDisengage4.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHookDisengage3.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHookDisengage2.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionHookDisengage1.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionsHookPush4.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionsHookPush3.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionsHookPush2.Value = Convert.ToDecimal(line.ReadLine());
                Y_TowerPositionsHookPush1.Value = Convert.ToDecimal(line.ReadLine());
                X_ToClipPosition.Value = Convert.ToDecimal(line.ReadLine());
                X_PrintingPosition.Value = Convert.ToDecimal(line.ReadLine());
                X_MaterialChangePosition.Value = Convert.ToDecimal(line.ReadLine());
                Z_LayerHeight.Value = Convert.ToDecimal(line.ReadLine());
                StartingLayersCureTime.Value = Convert.ToDecimal(line.ReadLine());
                NumberOfStartingLayers.Value = Convert.ToDecimal(line.ReadLine());
                X_FeedRate.Value = Convert.ToDecimal(line.ReadLine());
                Y_FeedRate.Value = Convert.ToDecimal(line.ReadLine());
                Z_FeedRate.Value = Convert.ToDecimal(line.ReadLine());
                CureTime1.Value = Convert.ToDecimal(line.ReadLine());
                CureTime2.Value = Convert.ToDecimal(line.ReadLine());
                CureTime3.Value = Convert.ToDecimal(line.ReadLine());
                CureTime4.Value = Convert.ToDecimal(line.ReadLine());
                Zzero1.Value = Convert.ToDecimal(line.ReadLine());
                Zzero2.Value = Convert.ToDecimal(line.ReadLine());
                Zzero3.Value = Convert.ToDecimal(line.ReadLine());
                Zzero4.Value = Convert.ToDecimal(line.ReadLine());
                X_PullOutPosition.Value = Convert.ToDecimal(line.ReadLine());
                SprayIntensity.Value = Convert.ToDecimal(line.ReadLine());
                CleaningIntensity.Value = Convert.ToDecimal(line.ReadLine());
                CleaningOscillations.Value = Convert.ToDecimal(line.ReadLine());
                CleaningDistPositive.Value = Convert.ToDecimal(line.ReadLine());
                cleaningDistNeg.Value = Convert.ToDecimal(line.ReadLine());
                FeedDuringOsc.Value = Convert.ToDecimal(line.ReadLine());
                positiveBedCleaningDistance.Value = Convert.ToDecimal(line.ReadLine());
                negativeBedCleaningDistance.Value = Convert.ToDecimal(line.ReadLine());
                dryingFanDuration.Value = Convert.ToDecimal(line.ReadLine());
                dryingFanIntensity.Value = Convert.ToDecimal(line.ReadLine());
                bedRaiseDuringDry.Value = Convert.ToDecimal(line.ReadLine());

            }
        }

        private void testPumpChangeButton_Click(object sender, EventArgs e)
        {
            if(!testingPumpChange || testingPumpOscillations)
            {
                testingPumpChange = true;
                testingPumpOscillations = false;
                string message = "M104 S";
                int intensity = (int)((double)SprayIntensity.Value / 100.0 * 255);
                message += (intensity + 25).ToString();
                port.WriteLine(message);
            }
            else
            {
                port.WriteLine("M104 S0");
                testingPumpChange = false;
                testingPumpOscillations = false;
            }
        }

        private void testPumpOscillateButton_Click(object sender, EventArgs e)
        {
            if (testingPumpChange || !testingPumpOscillations)
            {
                testingPumpChange = false;
                testingPumpOscillations = true;
                string message = "M104 S";
                int intensity = (int)((double)CleaningIntensity.Value / 100.0 * 255);
                message += (intensity + 25).ToString();
                port.WriteLine(message);
            }
            else
            {
                port.WriteLine("M104 S0");
                testingPumpChange = false;
                testingPumpOscillations = false;
            }
        }
    }
}
