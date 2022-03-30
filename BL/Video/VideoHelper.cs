using System.Drawing;
using FFMpegCore;
using FFMpegCore.Enums;

namespace BL.Video;
public static class VideoHelper
{
    public static void ExtractVideo(string Folder, string BinaryFolder, string TemporaryFilesFolder, string InputPath, string OutputToFile)
    {
        System.IO.Directory.CreateDirectory(Folder);
        GlobalFFOptions.Configure(
            new FFOptions
            {
                BinaryFolder = BinaryFolder,
                TemporaryFilesFolder = TemporaryFilesFolder
            }
        );

        var outPut = $"{Folder}/{OutputToFile}";

        FFMpegArguments.
            FromFileInput(InputPath).
            OutputToFile(outPut, true,
                              Options => Options.
                                    WithVideoCodec(VideoCodec.Png).
                                    WithCustomArgument("-vf fps=1").
                                    WithHardwareAcceleration(HardwareAccelerationDevice.Auto)
                              ).

            ProcessSynchronously();
    }
    public static void Remove(string Folder)
    {
        DirectoryInfo d = new DirectoryInfo(Folder);
        FileInfo[] files = d.GetFiles("*.png").OrderBy(f => f.Name).ToArray();
        Bitmap? tmp = null;
        foreach (var f in files)
        {
            if (tmp == null)
            {
                tmp = new Bitmap(f.FullName);
            }

            else
            {
                using Bitmap doublon = new Bitmap(f.FullName);
                double diff = CompareImages(tmp, doublon, 10);
                if (diff > 5)
                {
                    tmp.Dispose();
                    tmp = new Bitmap(f.FullName);
                }
                else
                    File.Delete(f.FullName);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        };
    }
    public static double CompareImages(Bitmap InputImage1, Bitmap InputImage2, int Tollerance)
    {
        Bitmap Image1 = new Bitmap(InputImage1, new Size(128, 128));
        Bitmap Image2 = new Bitmap(InputImage2, new Size(128, 128));
        int Image1Size = Image1.Width * Image1.Height;
        int Image2Size = Image2.Width * Image2.Height;
        Bitmap Image3;
        if (Image1Size > Image2Size)
        {
            Image1 = new Bitmap(Image1, Image2.Size);
            Image3 = new Bitmap(Image2.Width, Image2.Height);
        }
        else
        {
            Image1 = new Bitmap(Image1, Image2.Size);
            Image3 = new Bitmap(Image2.Width, Image2.Height);
        }
        for (int x = 0; x < Image1.Width; x++)
        {
            for (int y = 0; y < Image1.Height; y++)
            {
                Color Color1 = Image1.GetPixel(x, y);
                Color Color2 = Image2.GetPixel(x, y);
                int r = Color1.R > Color2.R ? Color1.R - Color2.R : Color2.R - Color1.R;
                int g = Color1.G > Color2.G ? Color1.G - Color2.G : Color2.G - Color1.G;
                int b = Color1.B > Color2.B ? Color1.B - Color2.B : Color2.B - Color1.B;
                Image3.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }
        int Difference = 0;
        for (int x = 0; x < Image1.Width; x++)
        {
            for (int y = 0; y < Image1.Height; y++)
            {
                Color Color1 = Image3.GetPixel(x, y);
                int Media = (Color1.R + Color1.G + Color1.B) / 3;
                if (Media > Tollerance)
                    Difference++;
            }
        }
        double UsedSize = Image1Size > Image2Size ? Image2Size : Image1Size;
        double result = Difference * 100 / UsedSize;
        Image1.Dispose();
        Image2.Dispose();
        Image3.Dispose();
        return Difference * 100 / UsedSize;
    }
}