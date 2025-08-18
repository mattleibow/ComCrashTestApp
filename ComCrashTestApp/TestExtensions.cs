using Microsoft.UI.Xaml.Media.Imaging;
using SkiaSharp.Views.WinUI.Native;
using System;
using Windows.Storage.Streams;

namespace ComCrashTestApp;

public static class TestExtensions
{
    internal static (IBuffer PB, IntPtr J) GetPixels(this WriteableBitmap bitmap)
    {
        var pb = bitmap.PixelBuffer;
        return (pb, pb.GetByteBuffer());
    }

    internal static IntPtr GetByteBuffer(this IBuffer buffer) =>
        (IntPtr)BufferExtensions.GetByteBuffer(buffer);
}
