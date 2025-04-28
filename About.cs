using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VisproProject
{
    public partial class About : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        private string userRole;
        private string fullname;

        private bool dragging = false;
        private Point offset;

        private bool isDropdownVisible = false;
        public About(string role, string name)
        {
            alamat = "server=localhost; database=db_vispro; username=root; password=Quiland15september_;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            ApplyBlurEffect();
            SetupUI();

            userRole = role;
            fullname = name;

            // Misal lo punya label buat nampilin info user
            userStatus.Text = (role == "Cashier") ? $"Cashier : {name}" : "Admin";

            panelHeader.MouseDown += new MouseEventHandler(PanelHeader_MouseDown);
            panelHeader.MouseMove += new MouseEventHandler(PanelHeader_MouseMove);
            panelHeader.MouseUp += new MouseEventHandler(PanelHeader_MouseUp);
        }

        private void SetupUI()
        {
            // Sembunyikan dropdown di awal
            dropdownPanel.Visible = false;
        }

        private void ApplyBlurEffect()
        {
            int accentState = 3; // 3 = Enable blur (Windows 10/11)
            AccentPolicy accent = new AccentPolicy { AccentState = accentState };
            int size = Marshal.SizeOf(accent);

            IntPtr accentPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(accent, accentPtr, false);

            WindowCompositionAttributeData data = new WindowCompositionAttributeData
            {
                Attribute = 19, // WCA_ACCENT_POLICY
                Data = accentPtr,
                SizeOfData = size
            };

            SetWindowCompositionAttribute(this.Handle, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public int AccentState;
            public int Flags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }

        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Left = Cursor.Position.X - offset.X;
                this.Top = Cursor.Position.Y - offset.Y;
            }
        }

        private void PanelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void roundedPictureBox1_Click(object sender, EventArgs e)
        {
            isDropdownVisible = !isDropdownVisible;
            dropdownPanel.Visible = isDropdownVisible;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();

            Dashboard dashboard = new Dashboard();
            dashboard.SetUserRole(userRole, fullname);
            dashboard.Show();
        }

        public void SetUserRole(string role, string fullname)
        {
            if (role == "Cashier")
            {
                userStatus.Text = $"Cashier : {fullname}"; // Format khusus Cashier
            }
            else if (role == "Admin")
            {
                userStatus.Text = "Admin"; // Admin tetap "Admin" tanpa nama
            }
        }

        private void btnLapangan_Click(object sender, EventArgs e)
        {
            this.Hide();

            Lapangan lapangan = new Lapangan(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            lapangan.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();

            History history = new History(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            history.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();

            History history = new History(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            history.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmaccount account = new frmaccount(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            account.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Show();
        }
    }
}
