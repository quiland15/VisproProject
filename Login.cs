using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace VisproProject
{
    public partial class Login : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        private bool dragging = false;
        private Point offset;
        public Login()
        {
            alamat = "server=localhost; database=db_vispro; username=root; password=Quiland15september_;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();

            panelHeader.MouseDown += new MouseEventHandler(PanelHeader_MouseDown);
            panelHeader.MouseMove += new MouseEventHandler(PanelHeader_MouseMove);
            panelHeader.MouseUp += new MouseEventHandler(PanelHeader_MouseUp);
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("select username, password, status, fullname from tbl_users where username = '{0}'", txtUsername.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        string sandi;
                        string fullname = kolom["fullname"].ToString();
                        string userRole = kolom["status"].ToString();
                        sandi = kolom["password"].ToString();
                        if (sandi == txtPassword.Text)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.stop();
                            this.Hide();

                            Dashboard dashboard = new Dashboard();
                            dashboard.SetUserRole(userRole, fullname);
                            dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Anda salah input password");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none"; // Hilangkan kontrol UI
            axWindowsMediaPlayer1.stretchToFit = true; // Biar video bisa diperbesar
            //axWindowsMediaPlayer1.Dock = DockStyle.Fill; // Biar pas di form
            axWindowsMediaPlayer1.URL = "C:\\Users\\quila\\Downloads\\Snapinst.app_video_AQPn84gDaazePlIK7K4hoQYKM8fo0TDRcoVg61M9gZ3iosxS32UhLwsCDOtcugSvOBqhsPPV_r3VWlwiP7hyk_34aSRUSkYPL2Qa50M.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
