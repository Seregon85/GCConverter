using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GCConverter
{
    public partial class GCConverter : Form
    {
        public GCConverter()
        {
            InitializeComponent();
        }

        public string filename;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open save file";
            openFileDialog.Filter = "GC save files|*.gci";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                txtFilename.Text = filename;

                try
                {
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    int hexIn;
                    string hex;
                    string fileContent = "";

                    for (int i = 0; i <= 3; i++)
                    {
                        hexIn = fs.ReadByte();
                        hex = string.Format("{0:X2}", hexIn);
                        fileContent += hex;
                    }

                    fs.Close();

                    if (fileContent.Substring(6, 2) == "50") //PAL save file
                    {
                        rdPAL.Enabled = false;
                        rdNTSCU.Enabled = true;
                        rdNTSCJ.Enabled = true;
                        rdNTSCU.Checked = true;
                        btnConvert.Enabled = true;
                        txtStatus.Text = "Selected file is PAL. ";
                    }
                    else if (fileContent.Substring(6, 2) == "45") //NTSC-U save file
                    {
                        rdPAL.Enabled = true;
                        rdNTSCU.Enabled = false;
                        rdNTSCJ.Enabled = true;
                        rdPAL.Checked = true;
                        btnConvert.Enabled = true;
                        txtStatus.Text = "Selected file is NTSC-U. ";
                    }
                    else if (fileContent.Substring(6, 2) == "4A") //NTSC-J save file
                    {
                        rdPAL.Enabled = true;
                        rdNTSCU.Enabled = true;
                        rdNTSCJ.Enabled = false;
                        rdNTSCU.Checked = true;
                        btnConvert.Enabled = true;
                        txtStatus.Text = "Selected file is NTSC-J. ";
                    }
                    else
                    {
                        rdPAL.Enabled = false;
                        rdNTSCU.Enabled = false;
                        rdNTSCJ.Enabled = false;
                        rdPAL.Checked = false;
                        rdNTSCU.Checked = false;
                        rdNTSCJ.Checked = false;
                        btnConvert.Enabled = false;
                        txtStatus.Text = "Invalid Gamecube save file. ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string region;
            try
            {
                if (rdPAL.Checked)
                    region = "PAL";
                else if (rdNTSCU.Checked)
                    region = "NTSC-U";
                else if (rdNTSCJ.Checked)
                    region = "NTSC-J";
                else
                    region = "PAL";

                if (File.Exists(filename + ".BAK"))
                    File.Delete(filename + ".BAK");

                File.Copy(filename, filename + ".BAK");

                writeRegion(filename, region);

                txtStatus.Text += "\r\nThe save file " + filename + " was converted successfully to " + region + ".";
                txtStatus.Text += "\r\nBackup of original file was saved as " + filename + ".BAK.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void writeRegion(string fileName, string region)
        {
            try
            { 
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite)))
                {
                    bw.BaseStream.Seek(0x3, SeekOrigin.Begin);
                    if (region == "PAL")
                        bw.Write(0xFF313050);
                    else if (region == "NTSC-U")
                        bw.Write(0xFF313045);
                    else if (region == "NTSC-J")
                        bw.Write(0xFF31304A);

                    bw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}