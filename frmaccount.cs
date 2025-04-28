using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VisproProject
{
    public partial class frmaccount : Form
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
        public frmaccount(string role, string name)
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

            //panelProfile.BackColor = Color.Gray;
            //panelCashier.BackColor = Color.Transparent;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Show();
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            panelProfile.BackColor = Color.Gray; // Aktifkan Profile
            panelCashier.BackColor = Color.Transparent; // Nonaktifkan Cashier

            roundpanelCashier.Visible = false;
            roundpanelProfile.Visible = true;
            LoadProfileDataAdmin();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            panelProfile.BackColor = Color.Transparent; // Nonaktifkan Profile
            panelCashier.BackColor = Color.Gray; // Aktifkan Cashier

            roundpanelProfile.Visible = false;
            roundpanelCashier.Visible = true;
            LoadCashierData();
        }

        private void frmaccount_Load(object sender, EventArgs e)
        {
            if (userRole == "Cashier")
            {
                panelCashier.Visible = false;
                LoadProfileDataCashier();
            }
            else{
                panelCashier.Visible = true;
                LoadProfileDataAdmin();
            }

            roundpanelCashier.Visible = false;
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
        private void LoadProfileDataAdmin()
        {
            try
            {
                koneksi.Open();

                // Contoh query: ambil data dari tabel user/kasir/admin berdasarkan nama
                string query = "SELECT fullname, status, jamKerja, noTelepon FROM tbl_users WHERE status = 'Admin'";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                //cmd.Parameters.AddWithValue("@role", fullname); // fullname itu dari konstruktor tadi

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Isi label dari hasil database
                    profileName.Text = reader["fullname"].ToString();
                    profileStatus.Text = reader["status"].ToString();
                    profileJam.Text = reader["jamKerja"].ToString();
                    profileTelepon.Text = reader["noTelepon"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load profile: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void LoadProfileDataCashier()
        {
            try
            {
                koneksi.Open();

                // Contoh query: ambil data dari tabel user/kasir/admin berdasarkan nama
                string query = "SELECT fullname, status, jamKerja, noTelepon FROM tbl_users WHERE status = 'Cashier'";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                //cmd.Parameters.AddWithValue("@fullname", fullname); // fullname itu dari konstruktor tadi

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Isi label dari hasil database
                    profileName.Text = reader["fullname"].ToString();
                    profileStatus.Text = reader["status"].ToString();
                    profileJam.Text = reader["jamKerja"].ToString();
                    profileTelepon.Text = reader["noTelepon"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load profile: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtFullname.Text != "" && txtPassword.Text != "" && txtJam.Text != "" && txtTelepon.Text != "")
                {
                    //string folderPath = Path.Combine(Application.StartupPath, "C:\\Users\\ASUS\\source\\repos\\koneksidb\\uploads");

                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}

                    // Membuat nama unik untuk file gambar agar tidak tertimpa
                    //string fileName = Guid.NewGuid().ToString() + ".jpg";
                    //string filePath = Path.Combine(folderPath, fileName);

                    // Simpan gambar dari PictureBox ke folder
                    //pictureBox1.Image.Save(filePath);

                    query = string.Format("insert into tbl_users  values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", txtID.Text, txtUsername.Text, txtPassword.Text, txtFullname.Text, txtJam.Text, txtTelepon.Text, Status.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        frmaccount_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != "" && txtUsername.Text != "" && txtID.Text != "")
                {
                    query = string.Format("update tbl_users set password = '{0}', fullname = '{1}', Status = '{2}' where id_Admin = '{3}'", txtPassword.Text, txtFullname.Text, Status.Text, txtID.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        frmaccount_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("Delete from tbl_users where id_Admin = '{0}'", txtID.Text);
                        ds.Clear();
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();
                        if (res == 1)
                        {
                            MessageBox.Show("Delete Data Suksess ...");
                        }
                        else
                        {
                            MessageBox.Show("Gagal Delete data");
                        }
                    }
                    frmaccount_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void LoadCashierData()
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_users where status = 'Cashier'");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridViewCashier.DataSource = ds.Tables[0];
                dataGridViewCashier.Columns[0].Width = 100;
                dataGridViewCashier.Columns[0].HeaderText = "ID Cashier";
                dataGridViewCashier.Columns[1].Width = 150;
                dataGridViewCashier.Columns[1].HeaderText = "Username";
                dataGridViewCashier.Columns[2].Width = 120;
                dataGridViewCashier.Columns[2].HeaderText = "Password";
                dataGridViewCashier.Columns[3].Width = 120;
                dataGridViewCashier.Columns[3].HeaderText = "Fullname";
                dataGridViewCashier.Columns[4].Width = 120;
                dataGridViewCashier.Columns[4].HeaderText = "Jam Kerja";
                dataGridViewCashier.Columns[5].Width = 120;
                dataGridViewCashier.Columns[5].HeaderText = "Nomor Telepon";
                dataGridViewCashier.Columns[6].Width = 120;
                dataGridViewCashier.Columns[6].HeaderText = "Status";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
