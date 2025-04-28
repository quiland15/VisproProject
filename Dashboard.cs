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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VisproProject
{
    public partial class Dashboard : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        private bool isDropdownVisible = false;

        private bool dragging = false;
        private Point offset;
        public Dashboard()
        {
            alamat = "server=localhost; database=db_vispro; username=root; password=Quiland15september_;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            LoadDashboardData();

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

        private void roundedPictureBox1_Click(object sender, EventArgs e)
        {
            isDropdownVisible = !isDropdownVisible;
            dropdownPanel.Visible = isDropdownVisible;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select id, customer, field, time_slot, date, status, harga, kasirName from tbl_reservasi WHERE date BETWEEN CURDATE() - INTERVAL 2 DAY AND CURDATE()");
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
                dataGridView1.Columns[2].HeaderText = "Lapangan";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Waktu";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Tanggal";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Harga";
                dataGridView1.Columns[7].Width = 100;
                dataGridView1.Columns[7].HeaderText = "Kasir";

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

            LoadDashboardData();
            //HitungPendapatan(4, 2025);

            Timer timer = new Timer();
            timer.Interval = 10000; // 10 detik
            timer.Tick += (s, ev) => LoadDashboardData();
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Show();
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            this.Hide();

            Lapangan lapangan = new Lapangan(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            //Lapangan lapangan = new Lapangan();
            lapangan.Show();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            this.Hide();

            Lapangan lapangan = new Lapangan(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            //Lapangan lapangan = new Lapangan();
            lapangan.Show();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            History history = new History(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            //Lapangan lapangan = new Lapangan();
            history.Show();
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            this.Hide();

            History history = new History(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            history.Show();
        }

        private void btnLapangan_Click(object sender, EventArgs e)
        {
            this.Hide();

            Lapangan lapangan = new Lapangan(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            //Lapangan lapangan = new Lapangan();
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

            About about = new About(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            about.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmaccount account = new frmaccount(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            account.Show();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (MySqlConnection koneksi = new MySqlConnection(alamat))
                {
                    koneksi.Open();

                    // Ambil jumlah reservasi hari ini
                    string queryReservasi = "SELECT COUNT(*) FROM tbl_reservasi WHERE DATE(date) = CURDATE()";
                    MySqlCommand cmdReservasi = new MySqlCommand(queryReservasi, koneksi);
                    lblReservasiHariIni.Text = cmdReservasi.ExecuteScalar().ToString();

                    // Ambil total customer
                    string queryCustomer = "SELECT COUNT(DISTINCT customer) FROM tbl_reservasi";
                    MySqlCommand cmdCustomer = new MySqlCommand(queryCustomer, koneksi);
                    lblTotalCustomer.Text = cmdCustomer.ExecuteScalar().ToString();

                    // Ambil pendapatan bulan ini
                    //string queryPendapatan = "SELECT SUM(total) FROM tbl_reservasi WHERE MONTH(date) = MONTH(CURDATE()) AND YEAR(date) = YEAR(CURDATE())";
                    //MySqlCommand cmdPendapatan = new MySqlCommand(queryPendapatan, koneksi);
                    //object result = cmdPendapatan.ExecuteScalar();
                    //lblPendapatanBulanIni.Text = result != DBNull.Value ? "Rp." + result.ToString() : "Rp.0";

                    koneksi.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        //private void HitungPendapatan(int bulan, int tahun)
        //{
        //    string connectionString = "server=localhost; database=db_vispro; User ID=root; password=Quiland15september_;"; // Ganti dengan connection string ke database
        //    string query = "SELECT SUM(harga) AS totalPendapatan FROM tbl_reservasi WHERE MONTH(date) = @bulan AND YEAR(date) = @tahun";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@bulan", bulan);
        //        cmd.Parameters.AddWithValue("@tahun", tahun);

        //        conn.Open();
        //        var result = cmd.ExecuteScalar();
        //        lblPendapatanBulanIni.Text = result != DBNull.Value ? result.ToString() : "0";
        //    }
        //}
    }
}
