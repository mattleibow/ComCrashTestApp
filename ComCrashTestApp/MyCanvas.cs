using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Runtime.InteropServices;

namespace ComCrashTestApp;

public partial class MyCanvas : Canvas
{
    private IntPtr pixels;
    private WriteableBitmap? bitmap;
    private ImageBrush? brush;

    public void DoSomething()
    {
        CreateBitmap();

        // Fill the bitmap with solid red
        // In BGRA format: B=0, G=0, R=255, A=255
        unsafe
        {
            var size = 4 * 100 * 100; // Assuming 4 bytes per pixel (BGRA)
            var pixelData = (byte*)pixels;
            for (var i = 0; i < size; i += 4)
            {
                pixelData[i] = 0;       // Blue
                pixelData[i + 1] = 0;   // Green
                pixelData[i + 2] = 255; // Red
                pixelData[i + 3] = 255; // Alpha (fully opaque)
            }
        }

        bitmap?.Invalidate();
    }


    private void CreateBitmap()
    {
        if (bitmap == null)
        {
            bitmap = new WriteableBitmap(100, 100);
            pixels = bitmap.GetPixels();

            brush = new ImageBrush
            {
                ImageSource = bitmap,
                AlignmentX = AlignmentX.Left,
                AlignmentY = AlignmentY.Top,
                Stretch = Stretch.None
            };

            Background = brush;
        }
    }
}
