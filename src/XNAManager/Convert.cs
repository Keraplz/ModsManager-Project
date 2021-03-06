﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    class Convert
    {
        //static System.Diagnostics.Process process = new System.Diagnostics.Process();
        //static System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        public static void XNB_PNG()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = System.IO.Directory.GetCurrentDirectory(),
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                using (Process p = Process.Start(startInfo))
                {
                    foreach (string s in Directory.GetFiles("Content", "*.xnb", SearchOption.AllDirectories))
                    {
                        if (s.ToLower().Contains("atlas") || s.ToLower().Contains("sfx")) { }
                        else
                        {
                            string sDir;
                            if (Path.GetDirectoryName(s).Length >= 10)
                            {
                                sDir = Path.GetDirectoryName(s).Remove(0, 8);
                            }
                            else sDir = Path.GetDirectoryName(s).Remove(0, 8);
                            string sFile = Path.GetFileNameWithoutExtension(s);

                            //Console.WriteLine(" s => " + s);

                            p.StandardInput.WriteLine(@"xnb_node extract " + s + @" XNAManager\_content\" + sDir + sFile + ".yaml");
                        }
                    }

                    p.StandardInput.WriteLine("exit");
                    p.WaitForExit();
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
            }
        }

        private static string TEXTURE_2D_TYPE = "Microsoft.Xna.Framework.Content.Texture2DReader, Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553";
        private static int HEADER_SIZE = 3 + 1 + 1 + 1;
        private static int COMPRESSED_FILE_SIZE = 4;
        private static int TYPE_READER_COUNT_SIZE = 1;
        private static int TYPE_SIZE = 2 + TEXTURE_2D_TYPE.Length + 4;
        private static int SHARED_RESOURCE_COUNT_SIZE = 1;
        private static int OBJECT_HEADER_SIZE = 21;

        private static int METADATA_SIZE = HEADER_SIZE + COMPRESSED_FILE_SIZE + TYPE_READER_COUNT_SIZE + TYPE_SIZE + SHARED_RESOURCE_COUNT_SIZE + OBJECT_HEADER_SIZE;
        public static int PNG_XNB(string pngFile, string xnbFile, bool compressed, bool reach = true)
        {
            string PNGFile_ = pngFile;
            string XNBFile_ = xnbFile;

            try
            {
                if (Path.GetExtension(pngFile).ToLower() != ".png") // Path.GetExtension(xnbFile).ToLower() != ".xnb"
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(pngFile), Path.GetFileNameWithoutExtension(pngFile) + ".png")))
                        return 0;
                    else PNGFile_ = Path.Combine(Path.GetDirectoryName(pngFile), Path.GetFileNameWithoutExtension(pngFile) + ".png");

                if (Path.GetExtension(xnbFile).ToLower() != ".xnb")
                    XNBFile_ = Path.Combine(Path.GetDirectoryName(xnbFile), Path.GetFileNameWithoutExtension(xnbFile) + ".xnb");

                if (Path.GetDirectoryName(xnbFile) != "" && !Directory.Exists(Path.GetDirectoryName(xnbFile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(xnbFile));

                using (Bitmap png = new Bitmap(PNGFile_))
                {
                    using (FileStream outFs = new FileStream(XNBFile_, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriterWrapper bw = new BinaryWriterWrapper(new BinaryWriter(outFs)))
                        {
                            bw.WriteChars("XNB"); // format-identifier
                            bw.WriteChars("w");   // target-platform
                            bw.WriteByte((byte)5);  // xnb-format-version
                            byte flagBits = 0;
                            if (!reach)
                            {
                                flagBits |= 0x01;
                            }
                            if (compressed && XCompress.isItAvailable())
                            {
                                flagBits |= 0x80;
                            }
                            bw.WriteByte(flagBits); // flag-bits; 00=reach, 01=hiprofile, 80=compressed, 00=uncompressed
                            if (compressed && XCompress.isItAvailable())
                            {
                                writeCompressedData(bw, png);
                            }
                            else
                            {
                                bw.WriteInt(compressedFileSize(png)); // compressed file size
                                writeData(png, bw);
                            }
                            return 1;
                        }
                    }
                }
            }
            catch (Exception _Exception)
            {
                MMUIProgramInfo _Info = new MMUIProgramInfo(Games.SpeedRunners);
                MMUIBugReport ReportForm = new MMUIBugReport(_Info, _Exception);

                LogFile.WriteError(_Exception);
                ReportForm.Show();

                return 0;
            }
        }

        private static int imageSize(Bitmap png)
        {
            return 4 * png.Height * png.Width;
        }
        private static int compressedFileSize(Bitmap png)
        {
            return METADATA_SIZE + imageSize(png);
        }

        private static void writeCompressedData(BinaryWriterWrapper bw, Bitmap png)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] uncompressedData;
                using (BinaryWriterWrapper mw = new BinaryWriterWrapper(new BinaryWriter(stream)))
                {
                    writeData(png, mw);
                    uncompressedData = stream.ToArray();
                }
                byte[] compressedData = XCompress.Compress(uncompressedData);
                bw.WriteInt(6 + 4 + 4 + compressedData.Length); // compressed file size including headers
                bw.WriteInt(uncompressedData.Length); // uncompressed data size (exluding headers! only the data)
                bw.WriteByteArray(compressedData);
            }
        }

        private static void writeData(Bitmap png, BinaryWriterWrapper bw)
        {
            bw.Write7BitEncodedInt(1);       // type-reader-count
            bw.WriteString(TEXTURE_2D_TYPE); // type-reader-name
            bw.WriteInt(0);                  // reader version number
            bw.Write7BitEncodedInt(0);       // shared-resource-count
            // writing the image pixel data
            bw.WriteByte(1); // type id + 1 (referencing the TEXTURE_2D_TYPE)
            bw.WriteInt(0);  // surface format; 0=color
            bw.WriteInt(png.Width);
            bw.WriteInt(png.Height);
            bw.WriteInt(1); // mip count
            bw.WriteInt(imageSize(png)); // number of bytes in the image pixel data
            BitmapData bitmapData = png.LockBits(new Rectangle(0, 0, png.Width, png.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                var length = bitmapData.Stride * bitmapData.Height;
                byte[] bytes = new byte[length];
                Marshal.Copy(bitmapData.Scan0, bytes, 0, length);
                for (int i = 0; i < bytes.Length; i += 4)
                {
                    byte b = bytes[i];
                    bytes[i] = bytes[i + 2];
                    bytes[i + 2] = b;
                }
                bw.WriteByteArray(bytes);
            }
            finally
            {
                png.UnlockBits(bitmapData);
            }
        }

        public class XCompress
        {
            public enum XMEMCODEC_TYPE
            {
                XMEMCODEC_DEFAULT = 0,
                XMEMCODEC_LZX = 1
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct XMEMCODEC_PARAMETERS_LZX
            {
                [FieldOffset(0)]
                public int Flags;
                [FieldOffset(4)]
                public int WindowSize;
                [FieldOffset(8)]
                public int CompressionPartitionSize;
            }

            [DllImport("xcompress32.dll", EntryPoint = "XMemCompress")]
            public static extern int XMemCompress(int Context,
                                                  byte[] pDestination, ref int pDestSize,
                                                  byte[] pSource, int pSrcSize);

            [DllImport("xcompress32.dll", EntryPoint = "XMemCreateCompressionContext")]
            public static extern int XMemCreateCompressionContext(
                XMEMCODEC_TYPE CodecType, ref XMEMCODEC_PARAMETERS_LZX pCodecParams,
                int Flags, ref int pContext);

            [DllImport("xcompress32.dll", EntryPoint = "XMemDestroyCompressionContext")]
            public static extern void XMemDestroyCompressionContext(int Context);

            [DllImport("xcompress32.dll", EntryPoint = "XMemDecompress")]
            public static extern int XMemDecompress(int Context,
                                                    byte[] pDestination, ref int pDestSize,
                                                    byte[] pSource, int pSrcSize);

            [DllImport("xcompress32.dll", EntryPoint = "XMemCreateDecompressionContext")]
            public static extern int XMemCreateDecompressionContext(
                XMEMCODEC_TYPE CodecType,
                ref XMEMCODEC_PARAMETERS_LZX pCodecParams,
                int Flags, ref int pContext);

            [DllImport("xcompress32.dll", EntryPoint = "XMemDestroyDecompressionContext")]
            public static extern void XMemDestroyDecompressionContext(int Context);

            public static byte[] Compress(byte[] decompressedData)
            {
                // Setup our compression context
                int compressionContext = 0;

                XMEMCODEC_PARAMETERS_LZX codecParams;
                codecParams.Flags = 0;
                codecParams.WindowSize = 64 * 1024;
                codecParams.CompressionPartitionSize = 256 * 1024;

                XMemCreateCompressionContext(
                    XMEMCODEC_TYPE.XMEMCODEC_LZX,
                    ref codecParams, 0, ref compressionContext);

                // Now lets compress
                int compressedLen = decompressedData.Length * 2;
                byte[] compressed = new byte[compressedLen];
                int decompressedLen = decompressedData.Length;
                XMemCompress(compressionContext,
                    compressed, ref compressedLen,
                    decompressedData, decompressedLen);
                // Go ahead and destory our context
                XMemDestroyCompressionContext(compressionContext);

                // Resize our compressed data
                Array.Resize<byte>(ref compressed, compressedLen);

                // Now lets return it
                return compressed;
            }

            public static byte[] Decompress(byte[] compressedData, byte[] decompressedData)
            {
                // Setup our decompression context
                int DecompressionContext = 0;

                XMEMCODEC_PARAMETERS_LZX codecParams;
                codecParams.Flags = 0;
                codecParams.WindowSize = 64 * 1024;
                codecParams.CompressionPartitionSize = 256 * 1024;

                XMemCreateDecompressionContext(
                    XMEMCODEC_TYPE.XMEMCODEC_LZX,
                    ref codecParams, 0, ref DecompressionContext);

                // Now lets decompress
                int compressedLen = compressedData.Length;
                int decompressedLen = decompressedData.Length;
                try
                {
                    XMemDecompress(DecompressionContext,
                        decompressedData, ref decompressedLen,
                        compressedData, compressedLen);
                }
                catch
                {
                }
                // Go ahead and destory our context
                XMemDestroyDecompressionContext(DecompressionContext);
                // Return our decompressed bytes
                return decompressedData;
            }

            public static bool isItAvailable()
            {
                try
                {
                    Compress(new byte[1]);
                    return true;
                }
                catch (DllNotFoundException e)
                {
                    if (e.Message.Contains("xcompress32.dll"))
                    {
                        return false;
                    }
                    throw e;
                }
            }
        }

        class BinaryWriterWrapper : IDisposable
        {
            private BinaryWriter bw;

            public BinaryWriterWrapper(BinaryWriter bw)
            {
                this.bw = bw;
            }

            public void WriteByte(byte b)
            {
                this.bw.Write(b);
            }

            public void WriteInt(int v)
            {
                this.bw.Write(v);
            }

            public void WriteChars(string s)
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
                this.bw.Write(bytes);
            }

            public void Write7BitEncodedInt(int i)
            {
                while (i >= 0x80)
                {
                    this.WriteByte((byte)(i & 0xff));
                    i >>= 7;
                }
                this.WriteByte((byte)i);
            }

            public void WriteString(String s)
            {
                Write7BitEncodedInt(s.Length);
                WriteChars(s);
            }

            public void WriteColor(Color c)
            {
                this.WriteByte(c.R);
                this.WriteByte(c.G);
                this.WriteByte(c.B);
                this.WriteByte(c.A);
            }

            public void WriteByteArray(byte[] data)
            {
                this.bw.Write(data);
            }

            public void Close()
            {
                this.bw.Close();
            }

            public void Dispose()
            {
                Close();
            }
        }


    }
}
