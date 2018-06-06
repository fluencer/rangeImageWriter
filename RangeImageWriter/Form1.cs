using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace RangeImageWriter
{
    public partial class Form1 : Form
    {
        #region lcms variables
        //LCMS Data
        byte[][] _pRectifiedRngData;

        int PROF_INTERVAL = 5;
        int UINBPROFILES = 1000;
        int UIPROFILENBPOINTS = 2080;
        int INTUINBPROFILES = 500;
        int INTUIPROFILENBPOINTS = 1040;
        int IMAGE_LENGTH;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename;
            funcSlctFile(out filename);
            txtBoxIPFldr.Text = filename;
        }

        private void funcSlctFile(out string filename)
        {
            filename = "";
            try
            {
                FolderBrowserDialog flderDilog1 = new FolderBrowserDialog();
                flderDilog1 = new FolderBrowserDialog();
                string folder_path;
                if (flderDilog1.ShowDialog() == DialogResult.OK)
                {
                    filename = flderDilog1.SelectedPath;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not get this folder from disk. Original error: " + ex.Message);
            }
        }

        private void btnSlctFlder2_Click(object sender, EventArgs e)
        {
            string filename;
            funcSlctFile(out filename);
            txtBoxIPFldr.Text = filename;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] fisFileList = Directory.GetFiles(txtBoxIPFldr.Text, "*.fis");
            string path = Path.GetDirectoryName(txtBoxIPFldr.Text);
            List<String> FisFileList = new List<String>();
            FisFileList.AddRange(fisFileList);

            foreach (String file in FisFileList)
            {
                UInt32 errorcode = LoadLCMSData(file);
                String saveFilePath = file.Replace(".fis", ".png");
                saveFilePath = saveFilePath.Replace("\\data\\", "\\imgData\\");

                byte[,] imageL = new byte[UINBPROFILES, UIPROFILENBPOINTS];
                byte[,] imageR = new byte[UINBPROFILES, UIPROFILENBPOINTS];

                rasterToMatrix(out imageL, out imageR);
                byte[] temp = _pRectifiedRngData[0];

                try
                {
                    ImageConverter imgConverter = new ImageConverter();

                }
                catch (Exception ex)
                {

                }
                

            }
        }

        private UInt32 LoadLCMSData(string fisfile)
        {

            char[] curFileChar2 = new char[200];

            for (int i = 0; i < fisfile.Length; i++)
                curFileChar2[i] = fisfile[i];

            curFileChar2[fisfile.Length] = '\0';

            UInt32 errorcode = LCMSWrapper.LcmsOpenRoadSection(curFileChar2);
            if (errorcode != 0)
            {
                LCMSWrapper.LcmsCloseRoadSection();
                return errorcode;
            }


            int uiNbProfiles = UINBPROFILES;
            int uiProfileNbPoints = UIPROFILENBPOINTS;

            if (_pRectifiedRngData == null)
            {
                _pRectifiedRngData = new byte[2][];
                _pRectifiedRngData[0] = new byte[uiNbProfiles * uiProfileNbPoints];
                _pRectifiedRngData[1] = new byte[uiNbProfiles * uiProfileNbPoints];
            }
            else
            {
                Array.Clear(_pRectifiedRngData[0], 0, uiNbProfiles * uiProfileNbPoints);
                Array.Clear(_pRectifiedRngData[1], 0, uiNbProfiles * uiProfileNbPoints);
            }

            errorcode = LCMSWrapper.LcmsGetRectifiedRngIm(_pRectifiedRngData);
            if (errorcode != 0)
            {
                LCMSWrapper.LcmsCloseRoadSection();
                return errorcode;
            }

            LCMSWrapper.LcmsCloseRoadSection();


            return 0;
        }
        private void rasterToMatrix(out byte[,] rangeImL, out byte[,] rangeImR)
        {
            rangeImL = new byte[UINBPROFILES,UIPROFILENBPOINTS];
            rangeImR = new byte[UINBPROFILES,UIPROFILENBPOINTS];

            Buffer.BlockCopy(_pRectifiedRngData[0], 0, rangeImL, 0, UINBPROFILES * UIPROFILENBPOINTS);
        }
    }
}
