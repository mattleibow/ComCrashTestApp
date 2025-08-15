using Microsoft.UI.Xaml.Media.Imaging;
using SkiaSharp.Views.WinUI.Native;
using System;
using Windows.Storage.Streams;

namespace ComCrashTestApp;

public static class TestExtensions
{
    internal static IntPtr GetPixels(this WriteableBitmap bitmap) =>
        bitmap.PixelBuffer.GetByteBuffer();

    internal static IntPtr GetByteBuffer(this IBuffer buffer) =>
        (IntPtr)BufferExtensions.GetByteBuffer(buffer);
}
