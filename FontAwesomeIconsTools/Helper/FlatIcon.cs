using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesomeIconsTools.Helper
{
    public class FlatIcon
    {

        public AmanFlatManager AmanManager => AmanFlatManager.Instance;
        public FlatIcon()
        {

        }

        public static Image GetIconImage(string Icon, Color? IColor = null, Size? size = null, int incFont = 0,IconFontType? fontType = null)
        {
            //"\uf2b9"
            // إنشاء Font من الخط الذي تم تحميله
            //Font fontAwesome = new Font(privateFonts.Families[0], 40); // حجم الخط 40
            if (IColor == null)
                IColor = Color.Black;
            if (size == null)
                size = new Size(100, 100);
            var fSize = (int)Math.Round((Math.Max(size.Value.Width, size.Value.Height) / 100.0M) * 40.0M + incFont);
            Font fontAwesome = AmanFlatManager.Instance.GetIconFont(size: Math.Max(5, fSize));
            // إنشاء Bitmap لرسم الأيقونة
            Bitmap bitmap = new Bitmap(size.Value.Width, size.Value.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // حجم الصورة 100x100
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent); // تعيين خلفية بيضاء
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //g.Clear(Color.Transparent);
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, size.Value.Width, size.Value.Height));
                SizeF textSize = g.MeasureString(Icon, fontAwesome);

                //// حساب موقع الرسم مع مراعاة الـ Padding والمركز
                float x = (bitmap.Width - textSize.Width) / 2;// + Padding.Left - Padding.Right;
                float y = (bitmap.Height - textSize.Height) / 2;// + Padding.Top - Padding.Bottom;
                                                                // رسم الأيقونة

                g.DrawString(Icon, fontAwesome, new SolidBrush(IColor.Value), new PointF(x, y));

                //g.Clear(Color.Transparent); // تعيين خلفية بيضاء
                //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                //// رسم الأيقونة كنص
                //g.DrawString(Icon, fontAwesome, new SolidBrush(IColor.Value), new PointF(10, 10)); // رمز FontAwesome
            }// Brushes.Black

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //imageList.Images.Add(Image.FromStream(ms));
                return Image.FromStream(ms);
            }

            //return bitmap;
        }
    }

}
