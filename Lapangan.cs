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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VisproProject
{
    public partial class Lapangan : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        private bool isDropdownVisible = false;

        private bool dragging = false;
        private Point offset;
        public Lapangan()
        {
            alamat = "server=localhost; database=db_vispro; username=root; password=Quiland15september_;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            ApplyBlurEffect();
            SetupUI();

            panelHeader.MouseDown += new MouseEventHandler(PanelHeader_MouseDown);
            panelHeader.MouseMove += new MouseEventHandler(PanelHeader_MouseMove);
            panelHeader.MouseUp += new MouseEventHandler(PanelHeader_MouseUp);

            this.dateTime.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.btncourt1.Click += new System.EventHandler(this.btncourt1_Click);
            this.btncourt2.Click += new System.EventHandler(this.btncourt2_Click);
            this.btncourt3.Click += new System.EventHandler(this.btncourt3_Click);
        }

        private void SetupUI()
        {
            // Sembunyikan dropdown di awal
            dropdownPanel.Visible = false;
            //datechangepanel.Visible = false;
            panelJam.Visible = false;
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

        private void btncourt1_Click(object sender, EventArgs e)
        {
            //isDropdownVisible = !isDropdownVisible;
            //panelJam.Visible = isDropdownVisible;
            //lblJadwalTitle.Visible = true;
            //lblJadwalTitle.Text = "Jadwal Court 1";

            //if (!panelJam.Visible || lblJadwalTitle.Text != "Jadwal Court 1")
            //{
            //    panelJam.Visible = true;
            //    lblJadwalTitle.Text = "Jadwal Court 1";
            //}
            //else
            //{
            //    panelJam.Visible = false;
            //}
            //panelJam.Visible = true;
            ShowSchedulePanel("Court 1");
            UpdateCourtButtons("COURT 1");
        }

        private void btncourt2_Click(object sender, EventArgs e)
        {
            //isDropdownVisible = !isDropdownVisible;
            //panelJam.Visible = isDropdownVisible;
            //lblJadwalTitle.Text = "Jadwal Court 2";
            //if (!panelJam.Visible || lblJadwalTitle.Text != "Jadwal Court 2")
            //{
            //    panelJam.Visible = true;
            //    lblJadwalTitle.Text = "Jadwal Court 2";
            //}
            //else
            //{
            //    panelJam.Visible = false;
            //}
            //panelJam.Visible = true;
            ShowSchedulePanel("Court 2");
            UpdateCourtButtons("COURT 2");
        }

        private void btncourt3_Click(object sender, EventArgs e)
        {
            //isDropdownVisible = !isDropdownVisible;
            //panelJam.Visible = isDropdownVisible;
            //lblJadwalTitle.Text = "Jadwal Court 3";

            //if (!panelJam.Visible || lblJadwalTitle.Text != "Jadwal Court 3")
            //{
            //    panelJam.Visible = true;
            //    lblJadwalTitle.Text = "Jadwal Court 3";
            //}
            //else
            //{
            //    panelJam.Visible = false;
            //}
            //panelJam.Visible = true;
            ShowSchedulePanel("Court 3");
            UpdateCourtButtons("COURT 3");
        }

        //private void LoadBookings(DateTime date)
        //{
        //    bookings = new Dictionary<string, List<string>>();

        //    using (MySqlConnection conn = new MySqlConnection(alamat))
        //    {
        //        conn.Open();
        //        string query = "SELECT field, time_slot FROM tbl_reservasi WHERE date = @date AND status != 'Dibatalkan'";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string court = reader["field"].ToString();
        //            string time = reader["time_slot"].ToString();

        //            if (!bookings.ContainsKey(court))
        //                bookings[court] = new List<string>();

        //            bookings[court].Add(time);
        //        }
        //    }

        //    UpdateCourtButtons();
        //}

        private void UpdateCourtButtons(string courtName)
        {
            // Simpan data booking di Dictionary
            Dictionary<string, string> bookedSlots = new Dictionary<string, string>();

            // Hapus semua tombol lama di panelJam
            //panelJam.Controls.Clear();

            // Query database untuk mendapatkan data reservasi lapangan yang dipilih
            string query = $"SELECT time_slot, status FROM tbl_reservasi WHERE field = '{courtName}' AND date = '{dateTime.Value.ToString("yyyy-MM-dd")}'";

            // Buat koneksi ke database
            using (MySqlConnection koneksi = new MySqlConnection(alamat))
            {
                koneksi.Open();
                MySqlCommand perintah = new MySqlCommand(query, koneksi);
                MySqlDataReader reader = perintah.ExecuteReader();

                while (reader.Read())
                {
                    bookedSlots[reader["time_slot"].ToString()] = reader["status"].ToString();
                }

                reader.Close();
            }

            // List jam yang tersedia
            string[] availableSlots = new string[]
            {
        "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00",
        "13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00", "17:00 - 18:00",
        "18:00 - 19:00", "19:00 - 20:00", "20:00 - 21:00", "21:00 - 22:00"
            };

            // Buat tombol untuk setiap slot waktu
            int x = 50, y = 43;
            foreach (string slot in availableSlots)
            {
                Button btn = new Button();
                btn.Text = slot;
                btn.Size = new Size(120, 27);
                btn.Location = new Point(x, y);

                // Mengatur tampilan tombol agar flat
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1; // Menghilangkan border
                btn.FlatAppearance.MouseOverBackColor = Color.LightGray; // Warna saat hover
                btn.FlatAppearance.MouseDownBackColor = Color.DarkGray; // Warna saat ditekan

                // Mengatur font Segoe UI ukuran 8
                btn.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                // Cek apakah slot ini sudah dibooking
                if (bookedSlots.ContainsKey(slot))
                {
                    if (bookedSlots[slot] == "Mendatang" || bookedSlots[slot] == "Selesai")
                    {
                        btn.BackColor = Color.Red; // Sudah dibooking
                        btn.Enabled = false; // Nonaktifkan tombol
                    }
                    else
                    {
                        btn.BackColor = Color.Green; // Masih bisa dibooking
                    }
                }
                else
                {
                    btn.BackColor = Color.Green; // Masih tersedia
                }

                panelJam.Controls.Add(btn);

                // Atur posisi tombol (misal grid 4 kolom)
                x += 120;
                if (x > 560) // Misalnya 4 kolom, balik ke baris baru
                {
                    x = 50;
                    y += 30;
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Cek lapangan mana yang terakhir dipilih
            if (btncourt1.BackColor == Color.Gray) // Misalnya Court 1 sedang dipilih
            {
                UpdateCourtButtons("COURT 1");
            }
            else if (btncourt2.BackColor == Color.Gray)
            {
                UpdateCourtButtons("COURT 2");
            }
            else if (btncourt3.BackColor == Color.Gray)
            {
                UpdateCourtButtons("COURT 3");
            }
        }

        private void ShowSchedulePanel(string courtName)
        {
            // Tampilkan panel
            panelJam.Visible = true;

            // Ubah teks label sesuai dengan court yang dipilih
            lblJadwalTitle.Text = $"Jadwal {courtName}";

            lblJadwalTitle.Visible = true;

            // Pastikan DateTimePicker juga muncul
            dateTime.Visible = true;
        }
    }
}
