using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesomeIconsTools
{
    public class AmanFlatManager
    {
        private static AmanFlatManager _instance;
        private static Dictionary<string, FontFamily> RobotoFontFamilies;
        private PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        public static AmanFlatManager Instance => _instance ?? (_instance = new AmanFlatManager());
        private AmanFlatManager()
        { 
            RobotoFontFamilies = new Dictionary<string, FontFamily>();
            addFont(Resources.fa_regular_400);
            LoadIconFonts();
        }

        private void LoadIconFonts()
        {
            RobotoFontFamilies = new Dictionary<string, FontFamily>();
            foreach (FontFamily ff in privateFontCollection.Families.ToArray())
            {
                RobotoFontFamilies.Add(ff.Name.Replace(' ', '_'), ff);
            }
        }

        private void addFont(byte[] fontdata)
        {
            // Add font to system table in memory
            int dataLength = fontdata.Length;

            IntPtr ptrFont = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontdata, 0, ptrFont, dataLength);

            // GDI Font
            NativeTextRenderer.AddFontMemResourceEx(fontdata, dataLength, IntPtr.Zero, out _);

            // GDI+ Font
            privateFontCollection.AddMemoryFont(ptrFont, dataLength);
        }

        public Font GetIconFont(Font? font = null, int size = 12)
        {

            if (font == null)
                return new Font(RobotoFontFamilies["Font_Awesome_6_Pro_Regular"], size);
            return new Font(RobotoFontFamilies["Font_Awesome_6_Pro_Regular"], font.Size, font.Style, font.Unit);

        }
    }
}
