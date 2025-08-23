using FontAwesomeIconsTools;
using FontAwesomeIconsTools.Helper;

namespace TestIcons
{
    public partial class Form1 : Form
    {

        private Random random = new Random();

        // A simplified list of Font Awesome icon codes for demonstration
        // In a real application, you'd have a more comprehensive list or a way to load them.
        private List<string> fontAwesomeIconCodes = new List<string>
        {
            "\uf000", "\uf001", "\uf002", "\uf003", "\uf004", "\uf005", "\uf006", "\uf007", "\uf008", "\uf009",
            "\uf00a", "\uf00b", "\uf00c", "\uf00d", "\uf00e", "\uf010", "\uf011", "\uf012", "\uf013", "\uf014",
            "\uf015", "\uf016", "\uf017", "\uf018", "\uf019", "\uf01a", "\uf01b", "\uf01c", "\uf01d", "\uf01e",
            "\uf020", "\uf021", "\uf022", "\uf023", "\uf024", "\uf025", "\uf026", "\uf027", "\uf028", "\uf029",
            "\uf02a", "\uf02b", "\uf02c", "\uf02d", "\uf02e", "\uf02f", "\uf030", "\uf031", "\uf032", "\uf033",
            "\uf034", "\uf035", "\uf036", "\uf037", "\uf038", "\uf039", "\uf03a", "\uf03b", "\uf03c", "\uf03d",
            "\uf03e", "\uf040", "\uf041", "\uf042", "\uf043", "\uf044", "\uf045", "\uf046", "\uf047", "\uf048",
            "\uf049", "\uf04a", "\uf04b", "\uf04c", "\uf04d", "\uf04e", "\uf050", "\uf051", "\uf052", "\uf053",
            "\uf054", "\uf055", "\uf056", "\uf057", "\uf058", "\uf059", "\uf05a", "\uf05b", "\uf05c", "\uf05d",
            "\uf05e", "\uf060", "\uf061", "\uf062", "\uf063", "\uf064", "\uf065", "\uf066", "\uf067", "\uf068",
             "\uf0e1", "\uf0e2", "\uf0e3", "\uf0e4", "\uf0e5", "\uf0e6", "\uf0e7", "\uf0e8", "\uf0e9", "\uf0ea",
            "\uf0eb", "\uf0ec", "\uf0ed", "\uf0ee", "\uf0ef", "\uf0f0", "\uf0f1", "\uf0f2", "\uf0f3", "\uf0f4",
            "\uf0f5", "\uf0f6", "\uf0f7", "\uf0f8", "\uf0f9", "\uf0fa", "\uf0fb", "\uf0fc", "\uf0fd", "\uf0fe",
            "\uf0ff", "\uf100", "\uf101", "\uf102", "\uf103", "\uf104", "\uf105", "\uf106", "\uf107", "\uf108",
            "\uf109", "\uf10a", "\uf10b", "\uf10c", "\uf10d", "\uf10e", "\uf10f", "\uf110", "\uf111", "\uf112",
            "\uf113", "\uf114", "\uf115", "\uf116", "\uf117", "\uf118", "\uf119", "\uf11a", "\uf11b", "\uf11c",
            "\uf11d", "\uf11e", "\uf11f", "\uf120", "\uf121", "\uf122", "\uf123", "\uf124", "\uf125", "\uf126",
            "\uf127", "\uf128", "\uf129", "\uf12a", "\uf12b", "\uf12c", "\uf12d", "\uf12e", "\uf12f", "\uf130",
            "\uf131", "\uf132", "\uf133", "\uf134", "\uf135", "\uf136", "\uf137", "\uf138", "\uf139", "\uf13a",
            "\uf13b", "\uf13c", "\uf13d", "\uf13e", "\uf13f", "\uf140", "\uf141", "\uf142", "\uf143", "\uf144"

        };
        public Form1()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(GenerateIconsForm_Load);


        }

        private void GenerateIconsForm_Load(object sender, EventArgs e)
        {
            // Create a FlowLayoutPanel to arrange icons dynamically
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            this.Controls.Add(flowLayoutPanel);

            for (int i = 0; i < 200; i++)
            {
                FontAwesomeIcon iconControl = new FontAwesomeIcon();
                if (i == 0)
                {
                    iconControl.IconCode = "\uf007";
                    Button btn = new Button();
                    btn.Size = new Size(100, 100);
                    btn.Image = FlatIcon.GetIconImage("\uf007", Color.Green,new Size(40,40));
                    btn.Text = "ok";
                    btn.ImageAlign = ContentAlignment.MiddleLeft;
                    flowLayoutPanel.Controls.Add(btn);
                }
                else
                    // Set a random icon code
                    iconControl.IconCode = fontAwesomeIconCodes[random.Next(fontAwesomeIconCodes.Count)];

                // Set a random color
                iconControl.IconColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
               //if(i<10)
               // {
               //     // Random border thickness between 1 and 5
               //     iconControl.BorderThickness = random.Next(1, 6); 
               //     iconControl.BorderColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
               // }
              
                // Set a random icon size percentage (1-100)
                iconControl.IconSize = random.Next(10, 101);

                // Set a fixed size for the control itself, so the percentage works relative to this size
                iconControl.Size = new Size(100, 100); // Each icon control will be 50x50 pixels

                flowLayoutPanel.Controls.Add(iconControl);
            }
        }
    }
}
