using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;
using DiscordRpcDemo;

namespace ADB_simplifier
{
    public partial class Form1 : Form
    {
        bool mousedown;
        private Point offset;
        bool live;
        bool connected;
        string test;
        bool doe;
        string prev = "";
        string prev2 = "";
        string rpc;

        WebClient net = new WebClient();
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        private static Process adb = new Process();
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(600, 365);
            appdrawer.Location = new Point(190, 100);
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\adb\\adb.exe"))
            {
                net.DownloadFile("https://cdn.discordapp.com/attachments/937597423071666186/950150446159380590/adb.zip", "adb.zip");
                ZipFile.ExtractToDirectory("adb.zip", Directory.GetCurrentDirectory() + "\\adb");
                File.Delete("adb.zip");
            }
        }

        private void bs_Click(object sender, EventArgs e) => snr("devices", true);
        string snr(string pogge, bool e)
        {
            try
            {
                if (ds.Text.Length > 3)
                {
                    pogge = " -s " + ds.Text.Trim() + " " + pogge;
                }
            }
            catch
            {

            }
            adb.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\adb\\adb.exe";
            adb.StartInfo.Arguments = pogge;
            adb.StartInfo.RedirectStandardError = true;
            adb.StartInfo.RedirectStandardOutput = true;
            adb.StartInfo.RedirectStandardInput = true;
            adb.StartInfo.CreateNoWindow = true;
            adb.StartInfo.UseShellExecute = false;
            adb.Start();
            if (pogge.Contains("connect") || pogge.Length > 5)
            {
                if (!adb.WaitForExit(5000))
                {
                    adb.Kill();
                }
            }
            else
            {
                adb.WaitForExit();
            }
            if (e)
            {
                string error = adb.StandardError.ReadToEnd();
                script.Text = adb.StandardOutput.ReadToEnd() + error;
                script.SelectionStart = script.Text.Length - error.Length + 1;
                script.SelectionLength = script.Text.Length;
                script.SelectionColor = Color.Red;
            }
            return adb.StandardOutput.ReadToEnd() + adb.StandardError.ReadToEnd();
        }
        private void button1_Click(object sender, EventArgs e) => Close();
        private void bs2_Click(object sender, EventArgs e) => snr("reboot", true);
        private void bs4_Click(object sender, EventArgs e)
        {
        loop:
            if (snr("connect " + snr("shell ip addr show wlan0", false).Split("\r".ToCharArray())[2].Substring(10, 16).Replace("/", ""), true).StartsWith("cannot"))
            {
                snr("tcpip 5555", false);
                MessageBox.Show("tcpip ran wait a second before clicking ok");
                goto loop;
            }
        }

        private void bs3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "APK files (*.APK)|*.APK| All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                snr("install \"" + ofd.FileName + "\"", true);
            }
        }
        private void bs5_Click(object sender, EventArgs e) => snr("disconnect", true);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            offset.X = e.X;
            offset.Y = e.Y;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e) => mousedown = false;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                Point lol = PointToScreen(e.Location);
                Location = new Point(lol.X - offset.X, lol.Y - offset.Y);
            }
        }
        private void cl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cl.Text.ToLower().StartsWith("adb"))
                {
                    cl.Text = cl.Text.Substring(3);
                }
                snr(cl.Text, true);
                cl.Clear();
            }
        }

        private void sc_Tick(object sender, EventArgs e)
        {
            connected = !snr("devices", false).Split("\r".ToCharArray())[1].Contains("device") ? false : true;
            ds.Items.Clear();
            if (ds.Text.Length > 3)
            {
                if (snr(" shell dumpsys battery", false).Contains("not found"))
                {
                    ds.Text = "";
                }
            }
            if (connected)
            {
                foreach (string beanis in snr("devices", false).Split("\r".ToCharArray()))
                {
                    if (!beanis.Contains("List of devices attached") && beanis.Contains("device"))
                    {
                        if (beanis.Length > 3)
                        {
                            ds.Items.Add(beanis.Replace("device", "").Trim());
                        }
                    }

                }
                if (ds.Text.Length < 3)
                {
                    ds.SelectedIndex = 0;
                }
            }
            else
            {
                ds.Items.Clear();
            }
            try
            {
                percent.Text = connected ? snr("shell dumpsys battery", false).Split("\r".ToCharArray())[10].Remove(0, 10) : "";
            }
            catch { }
        }

        private void dababyc(object sender, EventArgs e)
        {
            live = true;
            dababy.SendToBack();
            prev = settext.Text;
            settext.Text = prev2;
            settext.ReadOnly = true;
        }

        private void instant_Click(object sender, EventArgs e)
        {
            live = false;
            instant.SendToBack();
            prev2 = settext.Text;
            settext.Text = prev;
            settext.ReadOnly = false;
        }

        private void settext_KeyDown(object sender, KeyEventArgs e)
        {
            if (!live)
            {
                if (settext.Text == "")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        key(66);
                    }
                    if (e.KeyCode == Keys.Back)
                    {
                        key(67);
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    dababy.PerformClick();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    snr("shell input keyboard text '" + settext.Text + "'", false);
                    settext.Clear();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    instant.PerformClick();
                }
                if (e.KeyCode == Keys.A)
                {
                    key(29);
                }
                if (e.KeyCode == Keys.B)
                {
                    key(30);
                }
                if (e.KeyCode == Keys.C)
                {
                    key(31);
                }
                if (e.KeyCode == Keys.D)
                {
                    key(32);
                }
                if (e.KeyCode == Keys.E)
                {
                    key(33);
                }
                if (e.KeyCode == Keys.F)
                {
                    key(34);
                }
                if (e.KeyCode == Keys.G)
                {
                    key(35);
                }
                if (e.KeyCode == Keys.H)
                {
                    key(36);
                }
                if (e.KeyCode == Keys.I)
                {
                    key(37);
                }
                if (e.KeyCode == Keys.J)
                {
                    key(38);
                }
                if (e.KeyCode == Keys.K)
                {
                    key(39);
                }
                if (e.KeyCode == Keys.L)
                {
                    key(40);
                }
                if (e.KeyCode == Keys.M)
                {
                    key(41);
                }
                if (e.KeyCode == Keys.N)
                {
                    key(42);
                }
                if (e.KeyCode == Keys.O)
                {
                    key(43);
                }
                if (e.KeyCode == Keys.P)
                {
                    key(44);
                }
                if (e.KeyCode == Keys.Q)
                {
                    key(45);
                }
                if (e.KeyCode == Keys.R)
                {
                    key(46);
                }
                if (e.KeyCode == Keys.S)
                {
                    key(47);
                }
                if (e.KeyCode == Keys.T)
                {
                    key(48);
                }
                if (e.KeyCode == Keys.U)
                {
                    key(49);
                }
                if (e.KeyCode == Keys.V)
                {
                    key(50);
                }
                if (e.KeyCode == Keys.W)
                {
                    key(51);
                }
                if (e.KeyCode == Keys.X)
                {
                    key(52);
                }
                if (e.KeyCode == Keys.Y)
                {
                    key(53);
                }
                if (e.KeyCode == Keys.X)
                {
                    key(54);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    key(66);
                }
                if (e.KeyCode == Keys.Back)
                {
                    key(67);
                }
                if (e.KeyCode == Keys.Space)
                {
                    key(62);
                }
            }
        }
        private void key(int keyevent) => snr("shell input keyevent " + keyevent, false);
        private void button1_Click_1(object sender, EventArgs e) => snr("shell svc usb setFunctions mtp true", false);
        private void percent_Click(object sender, EventArgs e) => ds.DroppedDown = !ds.DroppedDown;
        private void app_Click(object sender, EventArgs e) => appdrawer.Visible = !appdrawer.Visible;
        private void drawe_Click(object sender, EventArgs e) => draw.DroppedDown = !draw.DroppedDown;
        private void button2_Click(object sender, EventArgs e) => appdrawer.Visible = false;
        private void apppop_Tick(object sender, EventArgs e)
        {
            doe = false;
            if (connected)
            {
                if (appdrawer.Visible)
                {
                    draw.Items.Clear();
                    test = snr("shell dumpsys window animator", false);

                    la.Text = "running: ";
                    foreach (string beans in snr("shell pm list packages -3", false).Split("\r".ToCharArray()))
                    {
                        if (beans.Length > 1 && !beans.Contains("environment"))
                        {
                            draw.Items.Add(beans.Substring(9));
                            if (!doe)
                            {
                                if (test.Contains(beans.Substring(9)))
                                {
                                    la.Text += beans.Substring(9);
                                    doe = true;
                                }
                                if (drp.Checked)
                                {
                                    if (presence.details != la.Text.Substring(8))
                                    {
                                        if (la.Text.Substring(8).Trim() == "")
                                        {
                                            presence.details = "nothing!";
                                            presence.largeImageKey = "";
                                        }
                                        else
                                        {
                                            presence.details = la.Text.Substring(8);
                                            presence.largeImageKey = la.Text.Substring(8).Replace(".", "_").Trim();
                                        }
                                        DiscordRpc.UpdatePresence(ref presence);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void start_Click(object sender, EventArgs e) => snr("shell monkey -p " + draw.Text + " 1", false);
        private void cr_Click(object sender, EventArgs e) => snr("shell am force-stop " + draw.Text, false);

        private void drp_CheckedChanged(object sender, EventArgs e)
        {
            if (drp.Checked)
            {
                if (!File.Exists("discord-rpc-w32.dll"))
                {
                    net.DownloadFile("https://cdn.discordapp.com/attachments/947224516034187356/962914900357828688/discord-rpc-w32.dll", "discord-rpc-w32.dll");
                }
                handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("867565943290462218", ref this.handlers, true, null);
                handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("867565943290462218", ref this.handlers, true, null);
                presence.details = "nothing!";
                presence.state = "";
                presence.largeImageKey = "";
                presence.smallImageKey = "";
                presence.largeImageText = "";
                presence.smallImageText = "";
                DiscordRpc.UpdatePresence(ref presence);
            }
            else
            {
                DiscordRpc.Shutdown();
            }
        }
    }
}