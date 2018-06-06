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
        byte[][] _pIntData;
        int UINBPROFILES = 1000;
        int UIPROFILENBPOINTS = 2080;
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
                UInt32 errorcode = LoadLCMSRangeData(file);
                UInt32 errorcode2 = LoadLCMSIntData(file);
                String saveFilePathLeft = file.Replace(".fis", ".png");
                saveFilePathLeft = saveFilePathLeft.Replace("\\Data\\", "\\imRangeData\\left\\");
                String saveFilePathRight = saveFilePathLeft.Replace("\\left", "\\right");
                String saveFilePathIntLeft = saveFilePathLeft.Replace("\\imRangeData", "\\imIntData");
                String saveFilePathIntRight = saveFilePathIntLeft.Replace("\\left", "\\right");

                byte[,] imRangeL = new byte[UINBPROFILES, UIPROFILENBPOINTS];
                byte[,] imRangeR = new byte[UINBPROFILES, UIPROFILENBPOINTS];
                byte[,] imIntL = new byte[UINBPROFILES, UIPROFILENBPOINTS];
                byte[,] imIntR = new byte[UINBPROFILES, UIPROFILENBPOINTS];

                rasterToMatrix(out imRangeL, out imRangeR, out imIntL, out imIntR);
                convertAndSave(imRangeL, saveFilePathLeft);
                convertAndSave(imRangeR, saveFilePathRight);
                convertAndSave(imIntL, saveFilePathIntLeft);
                convertAndSave(imIntR, saveFilePathIntRight);
                

            }
        }

        private UInt32 LoadLCMSRangeData(string fisfile)
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

        private UInt32 LoadLCMSIntData(string fisfile)
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

            if (_pIntData == null)
            {
                _pIntData = new byte[2][];
                _pIntData[0] = new byte[uiNbProfiles * uiProfileNbPoints];
                _pIntData[1] = new byte[uiNbProfiles * uiProfileNbPoints];
            }
            else
            {
                Array.Clear(_pIntData[0], 0, uiNbProfiles * uiProfileNbPoints);
                Array.Clear(_pIntData[1], 0, uiNbProfiles * uiProfileNbPoints);
            }

            errorcode = LCMSWrapper.LcmsGetIntData(_pIntData);
            if (errorcode != 0)
            {
                LCMSWrapper.LcmsCloseRoadSection();
                return errorcode;
            }

            LCMSWrapper.LcmsCloseRoadSection();


            return 0;
        }

        private void rasterToMatrix(out byte[,] rangeImL, out byte[,] rangeImR, out byte[,] intImL, out byte[,] intImR)
        {
            rangeImL = new byte[UINBPROFILES,UIPROFILENBPOINTS];
            rangeImR = new byte[UINBPROFILES,UIPROFILENBPOINTS];
            intImL = new byte[UINBPROFILES, UIPROFILENBPOINTS];
            intImR = new byte[UINBPROFILES, UIPROFILENBPOINTS];

            Buffer.BlockCopy(_pRectifiedRngData[0], 0, rangeImL, 0, UINBPROFILES * UIPROFILENBPOINTS);
            Buffer.BlockCopy(_pRectifiedRngData[1], 0, rangeImR, 0, UINBPROFILES * UIPROFILENBPOINTS);
            Buffer.BlockCopy(_pIntData[0], 0, intImL, 0, UINBPROFILES * UIPROFILENBPOINTS);
            Buffer.BlockCopy(_pIntData[1], 0, intImR, 0, UINBPROFILES * UIPROFILENBPOINTS);
        }

        private void convertAndSave(byte[,] inputImage, String saveFilePath)
        {
            //method to convert 2d byte array to bitmap
            int width = UIPROFILENBPOINTS;
            int height = UINBPROFILES;
            int stride = width * 4;
            int[,] integers = new int[height, width];

            for (int x = 0; x < height; ++x)
            {
                for (int y = 0; y < width; ++y)
                {
                    byte[] bgra = new byte[] { inputImage[x, y], inputImage[x, y], inputImage[x, y], 255 };
                    integers[x, y] = BitConverter.ToInt32(bgra, 0);
                }
            }

            // Copy into bitmap
            Bitmap bitmap;
            unsafe
            {
                fixed (int* intPtr = &integers[0, 0])
                {
                    bitmap = new Bitmap(width, height, stride, PixelFormat.Format32bppRgb, new IntPtr(intPtr));
                }
            }

            bitmap.Save(saveFilePath, ImageFormat.Png);
        }
    }
}
