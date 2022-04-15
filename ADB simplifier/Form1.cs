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
    public partial class ADBGUI : Form
    {
        private Point offset;
        bool live, doe, connected, mousedown;
        string prev = "", prev2 = "", found, test, ms, model;
        string[] rpc, ab;
        //            ^
        //ab is being  used dont worry bout it
        WebClient net = new WebClient();
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        private Process adbp = new Process();
        private Process scrcpy = new Process();
        public ADBGUI()
        {
            InitializeComponent();
            ClientSize = new Size(600, 365);
            appdrawer.Location = new Point(190, 120);
            VRM.Location = new Point(190, 90);
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\resources\\adb.exe"))
            {
                net.DownloadFile("https://cdn.discordapp.com/attachments/937597423071666186/963970216084246588/adb.zip", "adb.zip");
                ZipFile.ExtractToDirectory("adb.zip", Directory.GetCurrentDirectory() + "\\resources");
                File.Delete("adb.zip");
            }
        }

        private void bs_Click(object sender, EventArgs e) => adb("devices", true);
        string adb(string command, bool e)
        {
            try
            {
                if (ds.Text.Length > 3)
                {
                    command = " -s " + ds.Text.Trim() + " " + command;
                }
            }
            catch
            {

            }

            adbp.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\resources\\adb.exe";
            adbp.StartInfo.Arguments = command;
            adbp.StartInfo.RedirectStandardError = true;
            adbp.StartInfo.RedirectStandardOutput = true;
            adbp.StartInfo.CreateNoWindow = true;
            adbp.StartInfo.UseShellExecute = false;
            adbp.Start();
            if (command.Contains("connect") || command.Length > 5)
            {
                if (!adbp.WaitForExit(5000))
                {
                    adbp.Kill();
                }
            }
            else
            {
                adbp.WaitForExit();
            }
            if (e)
            {
                string error = adbp.StandardError.ReadToEnd();
                script.Text = adbp.StandardOutput.ReadToEnd() + error;
                script.SelectionStart = script.Text.Length - error.Length + 1;
                script.SelectionLength = script.Text.Length;
                script.SelectionColor = Color.Red;
            }
            return adbp.StandardOutput.ReadToEnd() + adbp.StandardError.ReadToEnd();
        }
        private void scrcpyButton_Click(object sender, EventArgs e)
        {
            string args = "";
            if (model.Trim() == "Quest 2") args = "--crop 1600:900:2017:510";
            else if (model.Trim() == "Quest") args = "--crop 1280:720:1500:350";
            scrcpy.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\resources\\scrcpy.exe";
            scrcpy.StartInfo.Arguments = args;
            scrcpy.StartInfo.RedirectStandardError = true;
            scrcpy.StartInfo.RedirectStandardOutput = true;
            scrcpy.StartInfo.RedirectStandardInput = true;
            scrcpy.StartInfo.CreateNoWindow = true;
            scrcpy.StartInfo.UseShellExecute = false;
            scrcpy.Start();
        }
        //needs a cart fix
        private void bs4_Click(object sender, EventArgs e)
        {
            adb("tcpip 5555", false);
            MessageBox.Show("tcpip started, please wait untill device reconnects.");
            adb("connect " + adb("shell ip addr show wlan0", false).Split("\r".ToCharArray())[2].Split("/".ToCharArray())[0].Replace("inet", "").Trim(), true);
        }

        private void bs3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "APK files (*.APK)|*.APK| All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                adb("install \"" + ofd.FileName + "\"", true);
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            offset.X = e.X;
            offset.Y = e.Y;
        }
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
                adb(cl.Text, true);
                cl.Clear();
            }
        }
        //there was a note here but now its not needed(adb listing: 2)
        private void sc_Tick(object sender, EventArgs e)
        {

            ab = adb("devices", false).Split("\r".ToCharArray());
            connected = !ab[1].Contains("device") ? false : true;
            ds.Items.Clear();
            if (ds.Text.Length > 3)
            {
                found = adb("shell dumpsys battery", false);
                if (found.Contains("not found"))
                {
                    ds.Text = "";
                    percent.Text = "";
                }
            }
            if (connected)
            {
                model = adb("shell getprop ro.product.model", false);
                VR.Visible = model.Contains("Quest");
                foreach (string beanis in ab)
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
                    try
                    {
                        ds.SelectedIndex = 0;
                    }
                    catch { }
                }
            }
            else
            {
                ds.Items.Clear();
                VR.Visible = false;
                VRM.Visible = false;
            }
            if (ds.Text.Length > 3)
            {
                if (found != null)
                {
                    try
                    {
                        percent.Text = connected ? found.Split("\r".ToCharArray())[10].Remove(0, 10) : "";
                    }
                    catch { }
                }
            }
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
        //can mabye be shortened to hell i need to test it(im not proud of this "if spam") FIXED

        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Enter", "Return", "Back", "Space" };
        int[] keycodes = { 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 66, 66, 67, 62 };
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
                    adb("shell input keyboard text '" + settext.Text + "'", false);
                    settext.Clear();
                }
            }
            else
            {
                key(keycodes[Array.IndexOf(letters, e.KeyCode.ToString())]);
            }
        }

        private void tsSet_Click(object sender, EventArgs e)
        {
            if (tsButton.Text != "")
            {
                adb("shell setprop debug.oculus.textureWidth " + tsButton.Text, false);
                adb("shell setprop debug.oculus.textureHeight  " + tsButton.Text, false);
            }
            else
            {
                MessageBox.Show("You must set a value first!");
            }

        }
        private void fpset_Click(object sender, EventArgs e)
        {
            if (fpsetb.Text != "")
            {
                adb("shell setprop debug.oculus.refreshRate " + fpsetb.Text, true);
            }
            else
            {
                MessageBox.Show("You must set a value first!");
            }
        }

        private void lset_Click(object sender, EventArgs e)
        {
            if (setlb.Text != "")
            {
                adb("shell setprop debug.oculus.cpuLevel " + setlb.Text, true);
                adb("shell setprop debug.oculus.gpuLevel " + setlb.Text, true);
            }
            else
            {
                MessageBox.Show("You must set a value first!");
            }
        }
        private void delbut_Click(object sender, EventArgs e)
        {
            adb("uninstall " + draw.Text, true);
            draw.Text = "";
        }


        //adb use: 2
        private void apppop_Tick(object sender, EventArgs e)
        {
            doe = false;
            if (connected)
            {
                draw.Items.Clear();
                test = adb("shell dumpsys window animator", false);
                ms = "running: ";
                foreach (string beans in adb("shell pm list packages -3", false).Split("\r".ToCharArray()))
                {
                    if (beans.Length > 1 && !beans.Contains("environment"))
                    {
                        draw.Items.Add(beans.Substring(9));
                        if (!doe)
                        {
                            if (test.Contains(beans.Substring(9)))
                            {
                                ms += beans.Substring(9);
                                doe = true;
                            }
                            if (drp.Checked)
                            {
                                //need shit here that will only update presence only when theres a change to update
                                if (la.Text.Substring(8).Trim() == "")
                                {
                                    presence.details = "nothing!";
                                    presence.largeImageKey = "";
                                }
                                else
                                {
                                    presence.details = "Playing: " + la.Text.Substring(8).Trim();
                                    if (Array.Exists(rpc[0].Split("\"".ToCharArray()), element => element == la.Text.Substring(8).Trim()))
                                    {
                                        presence.details = "Playing: " + rpc[1].Split("\"".ToCharArray())[Array.IndexOf(rpc[0].Split("\"".ToCharArray()), la.Text.Substring(8).Trim())];
                                    }
                                    presence.largeImageKey = la.Text.Substring(8).Replace(".", "_").ToLower().Trim();
                                }
                                DiscordRpc.UpdatePresence(ref presence);
                            }
                        }
                        if (ms != la.Text)
                        {
                            la.Text = ms;
                        }
                    }
                }
            }
        }
        private void drp_CheckedChanged(object sender, EventArgs e)
        {
            if (drp.Checked)
            {
                rpc = net.DownloadString("https://pastebin.com/raw/LXBguAnh").Split("\r".ToCharArray());
                if (!File.Exists("discord-rpc-w32.dll"))
                {
                    net.DownloadFile("https://cdn.discordapp.com/attachments/947224516034187356/962914900357828688/discord-rpc-w32.dll", "discord-rpc-w32.dll");
                }
                handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("867565943290462218", ref this.handlers, true, null);
                presence.details = "nothing!";
                DiscordRpc.UpdatePresence(ref presence);
            }
            else
            {
                DiscordRpc.Shutdown();
            }
        }
        private void CC_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ForeColor = colorDialog.Color;
                ds.ForeColor = colorDialog.Color;
                script.ForeColor = colorDialog.Color;
                draw.ForeColor = colorDialog.Color;
                settext.ForeColor = colorDialog.Color;
                cl.ForeColor = colorDialog.Color;
                sp.BackColor = colorDialog.Color;
                fpsetc.ForeColor = colorDialog.Color;
                tsDrop.ForeColor = colorDialog.Color;
                setls.ForeColor = colorDialog.Color;
            }
        }
        private void key(int keyevent) => adb("shell input keyevent " + keyevent, false);
        private void button1_Click_1(object sender, EventArgs e) => adb("shell svc usb setFunctions mtp true", true);
        private void VRMC_Click(object sender, EventArgs e) => VRM.Visible = false;
        private void VR_Click(object sender, EventArgs e) => VRM.Visible = !VRM.Visible;
        private void fpsetb_Click(object sender, EventArgs e) => fpsetc.DroppedDown = !fpsetc.DroppedDown;
        private void button1_Click(object sender, EventArgs e) => Close();
        private void bs2_Click(object sender, EventArgs e) => adb("reboot", true);
        private void fpsetc_SelectedIndexChanged(object sender, EventArgs e) => fpsetb.Text = fpsetc.Text;
        private void setlb_Click(object sender, EventArgs e) => setls.DroppedDown = !setls.DroppedDown;
        private void tsButton_Click(object sender, EventArgs e) => tsDrop.DroppedDown = !tsDrop.DroppedDown;
        private void panel1_MouseUp(object sender, MouseEventArgs e) => mousedown = false;
        private void percent_Click(object sender, EventArgs e) => ds.DroppedDown = !ds.DroppedDown;
        private void app_Click(object sender, EventArgs e) => appdrawer.Visible = !appdrawer.Visible;
        private void drawe_Click(object sender, EventArgs e) => draw.DroppedDown = !draw.DroppedDown;
        private void button2_Click(object sender, EventArgs e) => appdrawer.Visible = false;
        private void setls_SelectedIndexChanged(object sender, EventArgs e) => setlb.Text = setls.Text;
        private void tsDrop_SelectedIndexChanged(object sender, EventArgs e) => tsButton.Text = tsDrop.Text;
        private void disprox_Click(object sender, EventArgs e) => adb("shell am broadcast -a com.oculus.vrpowermanager.prox_close", true);
        private void eperimode_Click(object sender, EventArgs e) => adb("shell setprop debug.oculus.experimentalEnabled 1 ", true);
        private void bs5_Click(object sender, EventArgs e) => adb("disconnect", true);
        private void start_Click(object sender, EventArgs e) => adb("shell monkey -p " + draw.Text + " 1", false);
        private void cr_Click(object sender, EventArgs e) => adb("shell am force-stop " + draw.Text, false);
    }
}