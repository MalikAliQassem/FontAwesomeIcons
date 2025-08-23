using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesomeIconsTools
{
    public sealed class NativeTextRenderer : IDisposable
    {

        #region Fields and Consts

        private static readonly int[] _charFit = new int[1];

        private static readonly int[] _charFitWidth = new int[1000];

        private static readonly Dictionary<string, Dictionary<float, Dictionary<FontStyle, IntPtr>>> _fontsCache = new Dictionary<string, Dictionary<float, Dictionary<FontStyle, IntPtr>>>(StringComparer.InvariantCultureIgnoreCase);

        private readonly Graphics _g;

        private IntPtr _hdc;

        #endregion Fields and Consts

        public void Dispose()
        {
            if (_hdc != IntPtr.Zero)
            {
                SelectClipRgn(_hdc, IntPtr.Zero);
                _g.ReleaseHdc(_hdc);
                _hdc = IntPtr.Zero;
            }
        }


        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        [DllImport("gdi32.dll")]
        private static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
    }
}
