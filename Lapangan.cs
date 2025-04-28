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

        private string userRole;
        private string fullname;
        public Lapangan(string role, string name)
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

            this.dateLapangan.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
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
            dashboard.SetUserRole(userRole, fullname);
            dashboard.Show();
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
            //ShowSchedulePanel("Court 1");
            panelJam.Visible = true;
            UpdateCourtButtons("COURT 1");
        }

        private void btncourt2_Click(object sender, EventArgs e)
        {
            //ShowSchedulePanel("Court 2");
            panelJam.Visible = true;
            UpdateCourtButtons("COURT 2");
        }

        private void btncourt3_Click(object sender, EventArgs e)
        {
            //ShowSchedulePanel("Court 3");
            panelJam.Visible = true;
            UpdateCourtButtons("COURT 3");
        }

        //private void UpdateCourtButtons(string courtName)
        //{
        //    panelJam.Controls.Clear();
        //    Dictionary<string, bool> bookedSlots = new Dictionary<string, bool>();

        //    using (MySqlConnection koneksi = new MySqlConnection(alamat))
        //    {
        //        koneksi.Open();
        //        string query = "SELECT time_slot FROM tbl_reservasi WHERE field = @court AND `date` = @date";

        //        using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
        //        {
        //            perintah.Parameters.AddWithValue("@court", courtName);
        //            perintah.Parameters.AddWithValue("@date", dateTime.Value.ToString("yyyy-MM-dd"));

        //            using (MySqlDataReader reader = perintah.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    bookedSlots[reader["time_slot"].ToString()] = true;
        //                }
        //            }
        //        }
        //    }

        //    string[] availableSlots = new string[]
        //    {
        //"08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00",
        //"13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00", "17:00 - 18:00",
        //"18:00 - 19:00", "19:00 - 20:00", "20:00 - 21:00", "21:00 - 22:00"
        //    };

        //    Label lblCourt = new Label();
        //    lblCourt.Text = courtName;
        //    lblCourt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    lblCourt.Size = new Size(200, 20);
        //    lblCourt.Location = new Point(50, 20);
        //    panelJam.Controls.Add(lblCourt);

        //    int x = 50, y = 50;
        //    Dictionary<Button, CheckBox> buttonCheckboxMap = new Dictionary<Button, CheckBox>();
        //    Button btnKonfirmasi = new Button();
        //    btnKonfirmasi.Text = "Konfirmasi";
        //    btnKonfirmasi.Size = new Size(80, 30);
        //    btnKonfirmasi.Location = new Point(600, y + 100);
        //    btnKonfirmasi.FlatStyle = FlatStyle.Flat;
        //    btnKonfirmasi.FlatAppearance.BorderSize = 1;
        //    btnKonfirmasi.Enabled = false;

        //    foreach (string slot in availableSlots)
        //    {
        //        Button btn = new Button();
        //        btn.Text = slot;
        //        btn.Size = new Size(120, 27);
        //        btn.Location = new Point(x, y);
        //        btn.FlatStyle = FlatStyle.Flat;
        //        btn.FlatAppearance.BorderSize = 1;
        //        btn.FlatAppearance.MouseOverBackColor = Color.LightGray;
        //        btn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
        //        btn.Font = new Font("Segoe UI", 8, FontStyle.Regular);

        //        CheckBox chk = new CheckBox();
        //        chk.Visible = false;
        //        chk.Checked = false;

        //        if (bookedSlots.ContainsKey(slot))
        //        {
        //            btn.BackColor = Color.Red;
        //            btn.Enabled = false;
        //        }
        //        else
        //        {
        //            btn.BackColor = Color.Green;
        //        }

        //        btn.Click += (sender, e) => {
        //            chk.Checked = !chk.Checked;
        //            btn.BackColor = chk.Checked ? Color.Yellow : Color.Green;
        //            btnKonfirmasi.Enabled = buttonCheckboxMap.Values.Any(cb => cb.Checked);
        //        };

        //        panelJam.Controls.Add(btn);
        //        buttonCheckboxMap[btn] = chk;

        //        x += 120;
        //        if (x > 560)
        //        {
        //            x = 50;
        //            y += 30;
        //        }
        //    }

        //    btnKonfirmasi.Click += (sender, e) => PesanSlot(courtName, buttonCheckboxMap);
        //    panelJam.Controls.Add(btnKonfirmasi);
        //}

        //private void PesanSlot(string courtName, Dictionary<Button, CheckBox> buttonCheckboxMap)
        //{
        //    List<string> selectedSlots = new List<string>();
        //    foreach (var pair in buttonCheckboxMap)
        //    {
        //        if (pair.Value.Checked)
        //        {
        //            selectedSlots.Add(pair.Key.Text);
        //        }
        //    }

        //    if (selectedSlots.Count == 0)
        //    {
        //        MessageBox.Show("Pilih minimal satu slot waktu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    using (MySqlConnection koneksi = new MySqlConnection(alamat))
        //    {
        //        koneksi.Open();
        //        foreach (string slot in selectedSlots)
        //        {
        //            string query = "INSERT INTO tbl_reservasi (field, date, time_slot, status) VALUES (@court, @date, @slot, 'Mendatang')";
        //            using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
        //            {
        //                perintah.Parameters.AddWithValue("@court", courtName);
        //                perintah.Parameters.AddWithValue("@date", dateTime.Value.ToString("yyyy-MM-dd"));
        //                perintah.Parameters.AddWithValue("@slot", slot);
        //                perintah.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    MessageBox.Show("Pemesanan berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    UpdateCourtButtons(courtName);
        //}
        private void UpdateCourtButtons(string courtName)
        {
            panelJam.Controls.Clear();
            Dictionary<string, bool> bookedSlots = new Dictionary<string, bool>();

            using (MySqlConnection koneksi = new MySqlConnection(alamat))
            {
                koneksi.Open();
                string query = "SELECT time_slot FROM tbl_reservasi WHERE field = @court AND `date` = @date";

                using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                {
                    perintah.Parameters.AddWithValue("@court", courtName);
                    perintah.Parameters.AddWithValue("@date", dateLapangan.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = perintah.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookedSlots[reader["time_slot"].ToString()] = true;
                        }
                    }
                }
            }

            string[] availableSlots = new string[]
            {
        "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00",
        "13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00", "17:00 - 18:00",
        "18:00 - 19:00", "19:00 - 20:00", "20:00 - 21:00", "21:00 - 22:00"
            };

            Label lblCourt = new Label();
            lblCourt.Text = courtName;
            lblCourt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCourt.Size = new Size(200, 20);
            lblCourt.Location = new Point(50, 20);
            panelJam.Controls.Add(lblCourt);

            int x = 50, y = 50;
            Dictionary<Button, CheckBox> buttonCheckboxMap = new Dictionary<Button, CheckBox>();
            Button btnKonfirmasi = new Button();
            btnKonfirmasi.Text = "Konfirmasi";
            btnKonfirmasi.Size = new Size(100, 30);
            btnKonfirmasi.FlatStyle = FlatStyle.Flat;
            btnKonfirmasi.FlatAppearance.BorderSize = 1;
            btnKonfirmasi.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            btnKonfirmasi.Location = new Point(panelJam.Width - 120, panelJam.Height - 50);
            btnKonfirmasi.Enabled = false;
            btnKonfirmasi.Visible = false;

            foreach (string slot in availableSlots)
            {
                Button btn = new Button();
                btn.Text = slot;
                btn.Size = new Size(120, 27);
                btn.Location = new Point(x, y);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.LightGray;
                btn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
                btn.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                CheckBox chk = new CheckBox();
                chk.Visible = false;
                chk.Checked = false;

                if (bookedSlots.ContainsKey(slot))
                {
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                }
                else
                {
                    btn.BackColor = Color.Green;
                }

                btn.Click += (sender, e) => {
                    chk.Checked = !chk.Checked;
                    btn.BackColor = chk.Checked ? Color.Yellow : Color.Green;
                    btnKonfirmasi.Enabled = buttonCheckboxMap.Values.Any(cb => cb.Checked);
                    btnKonfirmasi.Visible = btnKonfirmasi.Enabled;
                };

                panelJam.Controls.Add(btn);
                buttonCheckboxMap[btn] = chk;

                x += 120;
                if (x > 560)
                {
                    x = 50;
                    y += 30;
                }
            }

            btnKonfirmasi.Click += (sender, e) => TampilkanFormPemesanan(courtName, buttonCheckboxMap);
            panelJam.Controls.Add(btnKonfirmasi);
        }

        private void TampilkanFormPemesanan(string courtName, Dictionary<Button, CheckBox> buttonCheckboxMap)
        {
            panelJam.Controls.Clear();

            Label lblpesan = new Label();
            lblpesan.Text = "Konfirmasi Pesanan Anda";
            lblpesan.Size = new Size(250, 20);
            lblpesan.Location = new Point(50, 10);
            lblpesan.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            panelJam.Controls.Add(lblpesan);

            Label lblNama = new Label();
            lblNama.Text = "Nama :";
            lblNama.Location = new Point(50, 50);
            lblNama.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            panelJam.Controls.Add(lblNama);

            TextBox txtNama = new TextBox();
            txtNama.Location = new Point(150, 50);
            txtNama.Size = new Size(200, 20);
            txtNama.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            panelJam.Controls.Add(txtNama);

            Label lblKontak = new Label();
            lblKontak.Text = "Kontak :";
            lblKontak.Location = new Point(50, 90);
            lblKontak.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            panelJam.Controls.Add(lblKontak);

            TextBox txtKontak = new TextBox();
            txtKontak.Location = new Point(150, 90);
            txtKontak.Size = new Size(200, 20);
            txtKontak.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            panelJam.Controls.Add(txtKontak);

            Button btnSimpan = new Button();
            btnSimpan.Text = "Konfirmasi";
            btnSimpan.Size = new Size(100, 30);
            btnSimpan.Location = new Point(50, 130);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.FlatAppearance.BorderSize = 1;
            btnSimpan.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            btnSimpan.Click += (sender, e) => SimpanReservasi(courtName, txtNama.Text, txtKontak.Text, buttonCheckboxMap);
            panelJam.Controls.Add(btnSimpan);
        }

        private void SimpanReservasi(string courtName, string nama, string kontak, Dictionary<Button, CheckBox> buttonCheckboxMap)
        {
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(kontak))
            {
                MessageBox.Show("Nama dan kontak harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> selectedSlots = new List<string>();
            foreach (var pair in buttonCheckboxMap)
            {
                if (pair.Value.Checked)
                {
                    selectedSlots.Add(pair.Key.Text);
                }
            }

            int hargaPerJam = GetHargaPerJam(courtName);
            string cashierName = GetNamaCashier();

            using (MySqlConnection koneksi = new MySqlConnection(alamat))
            {
                koneksi.Open();
                foreach (string slot in selectedSlots)
                {
                    string query = "INSERT INTO tbl_reservasi (field, date, time_slot, customer, kontakPenyewa, status, harga, kasirName) VALUES (@court, @date, @slot, @nama, @kontak, 'Mendatang', @harga, @cashier)";
                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        perintah.Parameters.AddWithValue("@court", courtName);
                        perintah.Parameters.AddWithValue("@date", dateLapangan.Value.ToString("yyyy-MM-dd"));
                        perintah.Parameters.AddWithValue("@slot", slot);
                        perintah.Parameters.AddWithValue("@nama", nama);
                        perintah.Parameters.AddWithValue("@kontak", kontak);
                        perintah.Parameters.AddWithValue("@harga", hargaPerJam);
                        perintah.Parameters.AddWithValue("@cashier", cashierName); // ini cashier login
                        perintah.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Reservasi berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateCourtButtons(courtName);
        }

        private string GetNamaCashier()
        {
            string namaCashier = "";

            using (MySqlConnection koneksi = new MySqlConnection(alamat))
            {
                koneksi.Open();
                string query = "SELECT fullname FROM tbl_users WHERE fullname = @username";
                using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                {
                    perintah.Parameters.AddWithValue("@username", fullname);
                    object hasil = perintah.ExecuteScalar();
                    if (hasil != null)
                    {
                        namaCashier = hasil.ToString();
                    }
                }
            }

            return namaCashier;
        }

        private int GetHargaPerJam(string courtName)
        {
            switch (courtName)
            {
                case "COURT 1":
                    return 200000; // 200 ribu per jam
                case "COURT 2":
                case "COURT 3":
                    return 150000; // 150 ribu per jam
                default:
                    return 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmaccount account = new frmaccount(userStatus.Text.Contains("Cashier") ? "Cashier" : "Admin", userStatus.Text.Replace("Cashier : ", ""));
            account.Show();
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
    }
}
