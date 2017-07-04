using System.ComponentModel;
using System.Runtime.InteropServices;
using Kuriimu.Kontract;

namespace image_nintendo
{
    public enum ChnkTexFormat : byte
    {
        BGR555
    }

    public enum TXIMBitDepth : int
    {
        BPP8 = 1,
        BPP4 = 2,
        BPP2 = 4,
        BPP3 = 99
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CHNK
    {
        public Magic Magic;
        public int DecompressedSize;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TXIF
    {
        public short Unk1;
        public short Unk2;
        public int ImageSize;
        public int MapSize;
        public int PaletteSize;
        public short Width;
        public short Height;
        public int ImageCount;
    }

    public class Section
    {
        public CHNK Chunk;
        public Magic Magic;
        public int Size;
        public byte[] Data;
    }

    public sealed class ChnkTexBitmapInfo : BitmapInfo
    {
        [Category("Properties")]
        [ReadOnly(true)]
        public ChnkTexFormat Format { get; set; }

        [Category("Properties")]
        [ReadOnly(true)]
        public TXIMBitDepth BitDepth { get; set; }

        [Category("Properties")]
        [ReadOnly(true)]
        public bool HasTX4I { get; set; }
    }
}