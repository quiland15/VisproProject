using MySql.Data.MySqlClient;
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

namespace VisproProject
{
    public partial class History : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        private bool isDropdownVisible = false;

        private bool dragging = false;
        private Point offset;
        public History()
        {
            alamat = "server=localhost; database=db_vispro; username=root; password=Quiland15september_;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            ApplyBlurEffect();
            SetupUI();

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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();

            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void btnLapangan_Click(object sender, EventArgs e)
        {
            this.Hide();

            Lapangan lapangan = new Lapangan();
            lapangan.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();

            History history = new History();
            history.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();

            About about = new About();
            about.Show();
        }

        private void roundedPictureBox1_Click(object sender, EventArgs e)
        {
            isDropdownVisible = !isDropdownVisible;
            dropdownPanel.Visible = isDropdownVisible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Show();
        }

        private void History_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_reservasi");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Customer";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[2].HeaderText = "Kontak";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Lapangan";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Waktu";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Tanggal";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Status";

                //txtID.Clear();
                //txtNama.Clear();
                //txtPassword.Clear();
                //txtUsername.Clear();
                //txtID.Focus();
                //btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
                //btnClear.Enabled = false;
                //btnSave.Enabled = true;
                //btnSearch.Enabled = true;
                //pictureBox1.Image = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
