using Accord.Math;
using Accord.Statistics.Kernels;
using IronBarCode;
using OnBarcode.Barcode.BarcodeScanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeGenerator
{
    public partial class Form1 : Form
    {
        public string textFile = @"C:\Users\Dell\Desktop\testing.txt";
        public string destFile = @"C:\Users\Dell\Desktop\dest.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region commented
            string brCodeString = textBox1.Text;
            string _data = brCodeString;
            string _filename = "BCTesting.png";
            GeneratedBarcode MyBarCode = IronBarCode.BarcodeWriter.CreateBarcode(_data, BarcodeWriterEncoding.QRCode);
            MyBarCode.AddBarcodeValueTextBelowBarcode();
            MyBarCode.SetMargins(50);

            MyBarCode.ChangeBarCodeColor(Color.Purple);
            MyBarCode.SaveAsPng(_filename);
            // This line opens the image in your default image viewer4
            pictureBox1.Image = new Bitmap(_filename);
            System.Diagnostics.Process.Start(_filename);
            #endregion


            #region Byte to string conversion 
            //if (File.Exists(textFile))
            //{
            //    // Read entire text file content in one string    
            //    string text = File.ReadAllText(textFile);
            //    var bytesToCompress =  Encoding.UTF8.GetBytes(text);
            //    byte[] compressedData = Zip(bytesToCompress);
            //    byte[] uncompressedData = Unzip(compressedData);


            //    string byteToString = Encoding.ASCII.GetString(compressedData);
            //    byte[] stringToByte = Encoding.ASCII.GetBytes(byteToString);

            //    string uncompressedString = Encoding.UTF8.GetString(uncompressedData);

            //    MessageBox.Show("UnCompresed String Length: " + text.Length.ToString() + Environment.NewLine + "Compressed String Length: " + byteToString.Length.ToString()
            //        + " UnCompressed Again: " + uncompressedString.Length
            //        );

            //}
            //else
            //{
            //    MessageBox.Show("File Not Found.");
            //} 
            #endregion
        }

        public static byte[] Zip(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                {
                    gzipStream.Write(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] Unzip(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {

                using (var outputStream = new MemoryStream())
                {
                    using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        decompressStream.CopyTo(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }
           
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
    }
}
