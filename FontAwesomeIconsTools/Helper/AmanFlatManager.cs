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
        //Font_Awesome_6_Pro_Solid Font_Awesome_6_Duotone_Solid Font_Awesome_6_Pro_Regular
        private static Dictionary<IconFontType,string> FontTypeFamilies;
        private static IconFontType fontFamilyType = IconFontType.Regular;
        public void SetFontType( IconFontType fontType)
        {
            fontFamilyType = fontType;
        }
        private AmanFlatManager()
        {
            FontTypeFamilies=new Dictionary<IconFontType, string>()
            {
                { IconFontType.Regular,"Font_Awesome_6_Pro_Regular" },
                { IconFontType.Solid,"Font_Awesome_6_Pro_Solid" },
                { IconFontType.Duotone,"Font_Awesome_6_Duotone_Solid" },
            };
            RobotoFontFamilies = new Dictionary<string, FontFamily>();
            addFont(Resources.fa_regular_400);
            addFont(Resources.fa_duotone_900);
            addFont(Resources.fa_solid_900);
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

        public Font GetIconFont(Font? font = null, int size = 12, IconFontType? fontType=null)
        {
            var type = fontType ?? fontFamilyType;
            if (font == null)
                return new Font(RobotoFontFamilies[FontTypeFamilies[type]], size);//"Font_Awesome_6_Pro_Regular"
            return new Font(RobotoFontFamilies[FontTypeFamilies[type]], font.Size, font.Style, font.Unit);

        }
    }
}
