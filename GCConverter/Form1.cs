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

        public string[] filenames;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open save file";
            openFileDialog.Filter = "GC save files|*.gci";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filenames = openFileDialog.FileNames;
                txtFilename.Text = String.Join("; ", filenames);
                if (filenames.Length > 1)
                {
                    rdPAL.Enabled = true;
                    rdNTSCU.Enabled = true;
                    rdNTSCJ.Enabled = true;
                    rdNTSCU.Checked = true;
                    btnConvert.Enabled = true;
                    txtStatus.Text = "Multiple files selected. ";
                }
                else
                {

                    try
                    {
                        FileStream fs = new FileStream(filenames[0], FileMode.Open);
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
                        //Other possible save files according to https://wiki.dolphin-emu.org/index.php?title=GameIDs
                        else if (fileContent.Substring(6, 2) == "44" || //Germany
                            fileContent.Substring(6, 2) == "46" || //France
                            fileContent.Substring(6, 2) == "48" || //Netherlands
                            fileContent.Substring(6, 2) == "49" || //Italy
                            fileContent.Substring(6, 2) == "4B" || //Korea
                            fileContent.Substring(6, 2) == "4C" || //Japanese PAL Import
                            fileContent.Substring(6, 2) == "4D" || //American PAL Import
                            fileContent.Substring(6, 2) == "4E" || //Japanese NTSC Import
                            fileContent.Substring(6, 2) == "52" || //Russia
                            fileContent.Substring(6, 2) == "53" || //Spain
                            fileContent.Substring(6, 2) == "55" || //PAL alternate languages
                            fileContent.Substring(6, 2) == "56" || //Scandinavia
                            fileContent.Substring(6, 2) == "57" || //Taiwan - Hong Kong - Macau
                            fileContent.Substring(6, 2) == "58" || //PAL alternate language - NTSC special release
                            fileContent.Substring(6, 2) == "59" || //PAL alternate language - NTSC special release
                            fileContent.Substring(6, 2) == "5A") //PAL alternate language - NTSC special release)
                        {
                            rdPAL.Enabled = true;
                            rdNTSCU.Enabled = true;
                            rdNTSCJ.Enabled = true;
                            rdNTSCU.Checked = true;
                            btnConvert.Enabled = true;
                            txtStatus.Text = "Selected file has a special region code. ";
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

                txtStatus.ScrollBars = ScrollBars.Vertical;
                foreach (string filename in filenames)
                {
                    if (File.Exists(filename + ".BAK"))
                        File.Delete(filename + ".BAK");

                    File.Copy(filename, filename + ".BAK");

                    writeRegion(filename, region);

                    txtStatus.Text += "\r\n\r\nThe save file " + Path.GetFileName(filename) + " was converted successfully to " + region + ". ";
                    txtStatus.Text += "Backup of original file was saved as " + Path.GetFileName(filename) + ".BAK.";
                }
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
                        bw.Write((byte)0x50);
                    else if (region == "NTSC-U")
                        bw.Write((byte)0x45);
                    else if (region == "NTSC-J")
                        bw.Write((byte)0x4A);

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
