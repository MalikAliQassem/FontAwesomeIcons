using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesomeIconsTools
{
    public class FontAwesomeIcon : Control
    {
        [Browsable(false)]
        public AmanFlatManager AmanManager => AmanFlatManager.Instance;
        // خط FontAwesome
        private Font fontAwesome;

        // رمز الأيقونة (Unicode)
        private string iconCode = "\ue0db"; // رمز افتراضي

        // لون الأيقونة
        private Color iconColor = Color.Black;

        // حجم الأيقونة كنسبة مئوية (1-100)
        private int iconSizePercentage = 100;

        // لون الحدود
        private Color borderColor = Color.Transparent;
        // سمك الحدود
        private int borderThickness = 0;

        public FontAwesomeIcon()
        {
            fontAwesome = AmanManager.GetIconFont();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.BackColor = Color.Transparent;
            this.Padding = new Padding(2);

            // تعيين حجم التحكم الأولي (يمكن تعديله حسب الحاجة)
            this.Size = new Size(100, 100);
        }

        [Localizable(true)]
        [Category("IconCode")]
        [Description("IconCode")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IconCode
        {
            get { return iconCode; }
            set
            {
                iconCode = value;
                this.Invalidate(); // إعادة رسم التحكم
            }
        }

        [Localizable(true)]
        [Category("IconColor")]
        [Description("IconColor")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                this.Invalidate(); // إعادة رسم التحكم
            }
        }

        [Localizable(true)]
        [Category("IconSize")]
        [Description("IconSize as a percentage (1-100) of the control\'s smaller dimension (width or height).")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IconSize
        {
            get { return iconSizePercentage; }
            set
            {
                if (value >= 1 && value <= 100)
                {
                    iconSizePercentage = value;
                    this.Invalidate(); // إعادة رسم التحكم
                }
                else
                    iconSizePercentage = 100;
            }
        }

        [Localizable(true)]
        [Category("Border")]
        [Description("The color of the border.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Localizable(true)]
        [Category("Border")]
        [Description("The thickness of the border in pixels.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                if (value >= 0)
                {
                    borderThickness = value;
                    this.Invalidate();
                }
                else
                    borderThickness = 0;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate(); // إعادة رسم الأيقونة عند تغيير حجم الكنترول
        }

        // رسم الأيقونة
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Parent?.BackColor ?? Color.Transparent);

            // حساب الحجم الفعلي للأيقونة بناءً على النسبة المئوية وأبعاد الكنترول
            int actualIconSize = (int)(Math.Min(this.Width - Padding.Left - Padding.Right,
                                                this.Height - Padding.Top - Padding.Bottom) * ((iconSizePercentage/2) / 100.0));

            // التأكد من أن الحجم الفعلي لا يقل عن قيمة معقولة
            actualIconSize = Math.Max(5, actualIconSize);

            // تحديث الخط بحجم الأيقونة الفعلي
            fontAwesome = AmanManager.GetIconFont(size: actualIconSize);

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            SizeF textSize = G.MeasureString(iconCode, fontAwesome);

            // حساب موقع الرسم مع مراعاة الـ Padding والمركز
            float x = (this.Width - textSize.Width) / 2.0f;
            float y = (this.Height - textSize.Height) / 2.0f;

            G.DrawString(IconCode, fontAwesome, new SolidBrush(iconColor), new PointF(x, y));

            // رسم الحدود إذا كان سمك الحدود أكبر من 0
            if (borderThickness > 0)
            {
                using (Pen borderPen = new Pen(borderColor, borderThickness))
                {
                    // رسم مستطيل الحدود حول الكنترول
                    G.DrawRectangle(borderPen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                }
            }
        }
    }

    //public class FontAwesomeIcon : Control
    //{
    //    [Browsable(false)]
    //    public AmanFlatManager AmanManager => AmanFlatManager.Instance;
    //    // خط FontAwesome
    //    private Font fontAwesome;

    //    // رمز الأيقونة (Unicode)
    //    private string iconCode = "\ue0db"; // رمز افتراضي

    //    // لون الأيقونة
    //    private Color iconColor = Color.Black;

    //    // حجم الأيقونة كنسبة مئوية (1-100)
    //    private int iconSizePercentage = 100;

    //    public FontAwesomeIcon()
    //    {
    //        fontAwesome = AmanManager.GetIconFont();
    //        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    //        this.SetStyle(ControlStyles.Opaque, true);
    //        this.SetStyle(ControlStyles.ResizeRedraw, true);

    //        this.BackColor = Color.Transparent;
    //        this.Padding = new Padding(2);

    //        // تعيين حجم التحكم الأولي (يمكن تعديله حسب الحاجة)
    //        this.Size = new Size(100, 100);
    //    }

    //    [Localizable(true)]
    //    [Category("IconCode")]
    //    [Description("IconCode")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public string IconCode
    //    {
    //        get { return iconCode; }
    //        set
    //        {
    //            iconCode = value;
    //            this.Invalidate(); // إعادة رسم التحكم
    //        }
    //    }

    //    [Localizable(true)]
    //    [Category("IconColor")]
    //    [Description("IconColor")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public Color IconColor
    //    {
    //        get { return iconColor; }
    //        set
    //        {
    //            iconColor = value;
    //            this.Invalidate(); // إعادة رسم التحكم
    //        }
    //    }

    //    [Localizable(true)]
    //    [Category("IconSize")]
    //    [Description("IconSize as a percentage (1-100) of the control's smaller dimension (width or height).")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public int IconSize
    //    {
    //        get { return iconSizePercentage; }
    //        set
    //        {
    //            if (value >= 1 && value <= 100)
    //            {
    //                iconSizePercentage = value;
    //                this.Invalidate(); // إعادة رسم التحكم
    //            }
    //            else
    //            {
    //                iconSizePercentage = 100;
    //            }
    //        }
    //    }

    //    protected override void OnSizeChanged(EventArgs e)
    //    {
    //        base.OnSizeChanged(e);
    //        this.Invalidate(); // إعادة رسم الأيقونة عند تغيير حجم الكنترول
    //    }

    //    // رسم الأيقونة
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);
    //        e.Graphics.Clear(Parent?.BackColor ?? Color.Transparent);

    //        // حساب الحجم الفعلي للأيقونة بناءً على النسبة المئوية وأبعاد الكنترول
    //        int actualIconSize = (int)(Math.Min(this.Width - Padding.Left - Padding.Right,
    //                                            this.Height - Padding.Top - Padding.Bottom) * ((iconSizePercentage/2) / 100.0));

    //        // التأكد من أن الحجم الفعلي لا يقل عن قيمة معقولة
    //        actualIconSize = Math.Max(5, actualIconSize);

    //        // تحديث الخط بحجم الأيقونة الفعلي
    //        fontAwesome = AmanManager.GetIconFont(size: actualIconSize);

    //        Graphics G = e.Graphics;
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

    //        SizeF textSize = G.MeasureString(iconCode, fontAwesome);

    //        // حساب موقع الرسم مع مراعاة الـ Padding والمركز
    //        float x = (this.Width - textSize.Width) / 2.0f;
    //        float y = (this.Height - textSize.Height) / 2.0f;

    //        G.DrawString(IconCode, fontAwesome, new SolidBrush(iconColor), new PointF(x, y));
    //    }
    //}

    //public class FontAwesomeIcon : Control
    //{
    //    [Browsable(false)]
    //    public AmanFlatManager AmanManager => AmanFlatManager.Instance;
    //    // خط FontAwesome
    //    private Font fontAwesome;

    //    // رمز الأيقونة (Unicode)
    //    private string iconCode = "\ue0db";// "\uf2b9"; // رمز افتراضي

    //    // لون الأيقونة
    //    private Color iconColor = Color.Black;

    //    // حجم الأيقونة
    //    private int iconSize = 24;

    //    private int OvericonSize = 20;

    //    public FontAwesomeIcon()
    //    {
    //        fontAwesome = AmanManager.GetIconFont();
    //        //LoadFontAwesome();
    //        // تمكين الرسم الشفاف
    //        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    //        this.SetStyle(ControlStyles.Opaque, true);
    //        this.SetStyle(ControlStyles.ResizeRedraw, true);

    //        this.BackColor = Color.Transparent;
    //        // تعيين Padding (اختياري)
    //        this.Padding = new Padding(2);

    //        // تعيين حجم التحكم بناءً على حجم الأيقونة
    //        this.Size = new Size(iconSize + Padding.Left + Padding.Right + OvericonSize, iconSize + Padding.Top + Padding.Bottom + OvericonSize);
    //    }

    //    protected override void OnSizeChanged(EventArgs e)
    //    {


    //    }

    //    [Localizable(true)]
    //    [Category("IconCode")]
    //    [Description("IconCode")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public string IconCode
    //    {
    //        get { return iconCode; }
    //        set
    //        {
    //            iconCode = value;
    //            this.Invalidate(); // إعادة رسم التحكم
    //        }
    //    }

    //    [Localizable(true)]
    //    [Category("IconColor")]
    //    [Description("IconColor")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public Color IconColor
    //    {
    //        get { return iconColor; }
    //        set
    //        {
    //            iconColor = value;
    //            this.Invalidate(); // إعادة رسم التحكم
    //        }
    //    }

    //    [Localizable(true)]
    //    [Category("IconSize")]
    //    [Description("IconSize")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public int IconSize
    //    {
    //        get { return iconSize; }
    //        set
    //        {
    //            iconSize = value;
    //            fontAwesome = AmanManager.GetIconFont(size: Math.Max(5, iconSize));
    //            this.Size = new Size(iconSize + Padding.Left + Padding.Right + OvericonSize, iconSize + Padding.Top + Padding.Bottom + OvericonSize); // تغيير حجم التحكم

    //            this.Invalidate(); // إعادة رسم التحكم
    //        }
    //    }

    //    // تحميل خط FontAwesome
    //    private void LoadFontAwesome()
    //    {
    //        fontAwesome = AmanManager.GetIconFont();
    //    }

    //    // رسم الأيقونة
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        //base.OnPaint(e);
    //        e.Graphics.Clear(Parent?.BackColor ?? Color.Transparent);
    //        // تأكد من تحميل الخط
    //        if (fontAwesome == null)
    //            LoadFontAwesome();


    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        var W = Width - 1;
    //        var H = Height - 1;

    //        GraphicsPath GP = new GraphicsPath(); 

    //        var _with8 = G;
    //        _with8.SmoothingMode = SmoothingMode.HighQuality;
    //        _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with8.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with8.Clear(Color.Transparent);


    //        SizeF textSize = _with8.MeasureString(iconCode, fontAwesome);

    //        //// حساب موقع الرسم مع مراعاة الـ Padding والمركز
    //        float x = (this.Width - textSize.Width) / 2;// + Padding.Left - Padding.Right;
    //        float y = (this.Height - textSize.Height) / 2;// + Padding.Top - Padding.Bottom;

    //        _with8.DrawString(IconCode, fontAwesome, new SolidBrush(iconColor), new PointF(x, y));
    //        //g.DrawString(iconCode, fontAwesome, new SolidBrush(iconColor), new PointF(Padding.Left, Padding.Top));
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();


    //    }
    //}

}
