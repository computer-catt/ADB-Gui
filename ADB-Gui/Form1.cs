using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;
using DiscordRpcDemo;
using System.Threading.Tasks;

namespace ADB_Gui
{
    public partial class ADBGUI : Form
    {
        private Point offset;
        bool doe, connected, mousedown;
        public string found, test, ms, model;
        string[] rpc, ab;
        //            ^
        //ab is being  used dont worry bout it
        WebClient net = new WebClient();
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        private Process adbp = new Process();
        private Process scrcpy = new Process();
        public Color colore = Color.Lime;
        public static string comm = "", Device = "";
        public ADBGUI()
        {
            InitializeComponent();
            adbp.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\resources\\adb.exe";
            adbp.StartInfo.RedirectStandardError = true;
            adbp.StartInfo.RedirectStandardOutput = true;
            adbp.StartInfo.CreateNoWindow = true;
            adbp.StartInfo.UseShellExecute = false;
            ClientSize = new Size(600, 365);
            appdrawer.Location = new Point(190, 120);
            settings.Location = new Point(190, 50);
            VRM.Location = new Point(220, 60);
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\resources\\adb.exe"))
            {
                net.DownloadFile("https://cdn.discordapp.com/attachments/937597423071666186/963970216084246588/adb.zip", "adb.zip");
                ZipFile.ExtractToDirectory("adb.zip", Directory.GetCurrentDirectory() + "\\resources");
                File.Delete("adb.zip");
            }
            load(true);
        }
        public void load(bool LoadOrSave)
        {
            if (LoadOrSave)
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/ADBGui/options"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ADBGui");
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ADBGui\options", "Lime\r");
                }
                else
                {
                    string[] save = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ADBGui\options");
                    color(ColorTranslator.FromHtml(save[0]));
                    if (save.Length > 1)
                    {
                        for (int i = 0; i < save[1].Split(';').Length; i++)
                        {
                            items.Controls.Add(new item() { Nam = save[1].Split(';')[i].Split(',')[0], Command = save[1].Split(';')[i].Split(',')[1], ForeColor = ForeColor });
                        }
                    }
                }
            }
            else
            {
                string sitems = "";
                foreach (Control ditem in items.Controls)
                {
                    if (ditem is item Item)
                    {
                        sitems += Item.Nam + "," + Item.Command + ";";
                    }
                }
                if (sitems.EndsWith(";"))
                {
                    sitems = sitems.Remove(sitems.Length - 1);
                }
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ADBGui\options", new string[] { ForeColor.ToArgb().ToString(), sitems });
            }
        }

        public string adb(string command, bool e)
        {
            if (Device.Length > 3) command = " -s " + Device.Trim() + " " + command;
            adbp.StartInfo.Arguments = command;
            adbp.Start();
            if (command.Contains("connect") | (command.Trim() == "")) if (!adbp.WaitForExit(5000)) adbp.Kill();
                else adbp.WaitForExit();
            if (e)
            {
                string error = adbp.StandardError.ReadToEnd();
                script.Text = adbp.StandardOutput.ReadToEnd() + error;
                script.SelectionStart = script.Text.Length - error.Length + 1;
                script.SelectionLength = script.Text.Length;
                script.SelectionColor = Color.Red;
            }
            try
            {
                return adbp.StandardOutput.ReadToEnd() + adbp.StandardError.ReadToEnd();
            }
            catch { return ""; }
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



        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                Point lol = PointToScreen(e.Location);
                Location = new Point(lol.X - offset.X, lol.Y - offset.Y);
            }
        }

        private async void sc_Tick(object sender, EventArgs e)
        {
            ab = await Task.Run(() => adb("devices", false).Split("\r".ToCharArray()));
            try
            {
                connected = !ab[1].Contains("device") ? false : true;
            }
            catch { }
            ds.Items.Clear();
            if (Device.Length > 3)
            {
                found = await Task.Run(() => adb("shell dumpsys battery", false));
                if (found.Contains("not found"))
                {
                    Device = "";
                    percent.Text = "";
                }
            }
            if (connected)
            {
                model = await Task.Run(() => adb("shell getprop ro.product.model", false));
                VR.Visible = model.Contains("Quest");
                foreach (string beanis in ab) if (!beanis.Contains("List of devices attached") && beanis.Contains("device")) if (beanis.Length > 3) ds.Items.Add(beanis.Replace("device", "").Trim());
                if (Device.Length < 3)
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
            if (Device.Length > 3)
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


        private void settext_KeyDown(object sender, KeyEventArgs e)
        {
            if (settext.Text == "")
            {
                if (e.KeyCode == Keys.Enter) key(66);
                if (e.KeyCode == Keys.Back) key(67);

            }
            if (e.KeyCode == Keys.Enter)
            {
                adb("shell input keyboard text '" + settext.Text + "'", false);
                settext.Clear();
            }
        }
        //adb use: 2
        private async void apppop_Tick(object sender, EventArgs e)
        {
            doe = false;
            if (connected)
            {
                //draw.Items.Clear();
                test = await Task.Run(() => adb("shell dumpsys window animator", false));

                ms = "running: ";
                foreach (string beans in await Task.Run(() => adb("shell pm list packages -3", false).Split("\r".ToCharArray())))
                {
                    if (beans.Length > 1 && !beans.Contains("environment"))
                    {
                        //draw.Items.Add(beans.Trim().Substring(8));
                        if (!doe)
                        {
                            if (test.Contains(beans.Trim().Substring(8)))
                            {
                                ms += beans.Trim().Substring(8);
                                doe = true;
                            }
                            if (ms != la.Text) la.Text = ms;
                            if (ms.Contains("not found")) la.Text = "Device not found!";
                        }
                    }
                }
                if (drp.Checked)
                {

                    if (presence.details.Replace("Playing: ", "").Replace("nothing!", "").Trim() != la.Text.Substring(8).Trim())
                    {
                        if (la.Text.Substring(8).Trim() == "")
                        {
                            presence.details = "nothing!";
                            presence.largeImageKey = "";
                        }
                        else
                        {
                            presence.details = "Playing: " + la.Text.Substring(8).Trim();
                            if (Array.Exists(rpc[0].Split("\"".ToCharArray()), element => element == la.Text.Substring(8).Trim())) presence.details = "Playing: " + rpc[1].Split("\"".ToCharArray())[Array.IndexOf(rpc[0].Split("\"".ToCharArray()), la.Text.Substring(8).Trim())];
                            presence.largeImageKey = la.Text.Substring(8).Replace(".", "_").ToLower().Trim();
                        }
                        DiscordRpc.UpdatePresence(ref presence);
                    }
                }
            }
            else
            {
                draw.DroppedDown = false;
            }
        }
        private void drp_CheckedChanged(object sender, EventArgs e)
        {
            if (drp.Checked)
            {
                rpc = net.DownloadString("https://raw.githubusercontent.com/DED0026/ADB-GUl/main/compatstuff").Split("\n".ToCharArray());
                if (!File.Exists("discord-rpc-w32.dll")) net.DownloadFile("https://cdn.discordapp.com/attachments/947224516034187356/962914900357828688/discord-rpc-w32.dll", "discord-rpc-w32.dll");
                handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("867565943290462218", ref this.handlers, true, null);
                presence.details = "nothing!";
                DiscordRpc.UpdatePresence(ref presence);
            }
            else DiscordRpc.Shutdown();
        }
        private void CC_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color(colorDialog.Color);
            }
        }
        void color(Color color)
        {
            ForeColor = color;
            ds.ForeColor = color;
            script.ForeColor = color;
            draw.ForeColor = color;
            settext.ForeColor = color;
            cl.ForeColor = color;
            sp.BackColor = color;
            fpsetc.ForeColor = color;
            tsDrop.ForeColor = color;
            setls.ForeColor = color;
            name.ForeColor = color;
            com.ForeColor = color;
            TT.ForeColor = color;
            colore = color;
            foreach (Control ditem in items.Controls)
            {
                if (ditem.GetType() == typeof(item))
                {
                    ditem.ForeColor = color;
                }
            }

        }
        private async void draw_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    draw.Items.Clear();
                    foreach (string beans in await Task.Run(() => adb("shell pm list packages -3", false).Split("\r".ToCharArray()))) if (beans.Length > 1 && !beans.Contains("environment")) draw.Items.Add(beans.Trim().Substring(8));
                }
            }
            catch
            { }
        }
        private void TT_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.Graphics.DrawLine(new Pen(colore), 0, e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Height - 1);
            e.Graphics.DrawLine(new Pen(colore), 0, e.Bounds.Height - 25, e.Bounds.Width, e.Bounds.Height - 25);
            e.Graphics.DrawLine(new Pen(colore), 0, e.Bounds.Height - 25, 0, e.Bounds.Height);
            e.Graphics.DrawLine(new Pen(colore), e.Bounds.Width - 1, e.Bounds.Height - 25, e.Bounds.Width - 1, e.Bounds.Height);
        }
        private void cl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cl.Text.ToLower().StartsWith("adb")) cl.Text = cl.Text.Substring(3);
                adb(cl.Text, true);
                cl.Clear();
            }
        }
        private void tsSet_Click(object sender, EventArgs e)
        {
            if (tsButton.Text != "")
            {
                adb("shell setprop debug.oculus.textureWidth " + tsButton.Text, false);
                adb("shell setprop debug.oculus.textureHeight  " + tsButton.Text, false);
            }
            else MessageBox.Show("You must set a value first!");
        }
        private void lset_Click(object sender, EventArgs e)
        {
            if (setlb.Text != "")
            {
                adb("shell setprop debug.oculus.cpuLevel " + setlb.Text, true);
                adb("shell setprop debug.oculus.gpuLevel " + setlb.Text, true);
            }
            else MessageBox.Show("You must set a value first!");
        }
        private void cuscomc_Tick(object sender, EventArgs e)
        {
            if (connected)
            {
                if (comm != "")
                {
                    adb(comm, true);
                    comm = "";
                }
            }
        }
        private void bs3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "APK files (*.APK)|*.APK| All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK) adb("install \"" + ofd.FileName + "\"", true);
        }
        private async void bs4_Click(object sender, EventArgs e)
        {
            adb("tcpip 5555", false);
            await Task.Delay(2000);
            adb("connect " + adb("shell ip addr show wlan0", false).Split("\r".ToCharArray())[2].Split("/".ToCharArray())[0].Replace("inet", "").Trim(), true);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            offset.X = e.X;
            offset.Y = e.Y;
        }
        private void ca_Click(object sender, EventArgs e)
        {
            items.Controls.Add(new item() { Nam = name.Text, Command = com.Text, ForeColor = ForeColor });
            name.Text = "";
            com.Text = "";
        }
        private void delbut_Click(object sender, EventArgs e)
        {
            adb("uninstall " + draw.Text, true);
            draw.Text = "";
        }
        private void fpset_Click(object sender, EventArgs e)
        {
            if (fpsetb.Text != "") adb("shell setprop debug.oculus.refreshRate " + fpsetb.Text, true);
            else MessageBox.Show("You must set a value first!");
        }
        private void key(int keyevent) => Task.Run(() => adb("shell input keyevent " + keyevent, false));
        private void button1_Click_1(object sender, EventArgs e) => adb("shell svc usb setFunctions mtp true", true);
        private void bs_Click(object sender, EventArgs e) => adb("devices", true);
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
        private void VRMGD_Click(object sender, EventArgs e) => adb("shell setprop debug.oculus.guardian_pause 1", true);
        private void VRMGE_Click(object sender, EventArgs e) => adb("shell setprop debug.oculus.guardian_pause 0", true);
        private void settingsc_Click(object sender, EventArgs e) => settings.Visible = false;
        private void settingsba_Click(object sender, EventArgs e) => settings.Visible = !settings.Visible;
        private void drawe_Click(object sender, EventArgs e) => draw.DroppedDown = !draw.DroppedDown;
        private void button2_Click(object sender, EventArgs e) => appdrawer.Visible = false;
        private void setls_SelectedIndexChanged(object sender, EventArgs e) => setlb.Text = setls.Text;
        private void ADBGUI_FormClosing(object sender, FormClosingEventArgs e) => load(false);
        private void frc_Click(object sender, EventArgs e) => adb("shell setprop debug.oculus.fullRateCapture 0", false);
        private void ds_SelectedIndexChanged(object sender, EventArgs e) => Device = ds.Text;
        private void frco_Click(object sender, EventArgs e) => adb("adb shell setprop debug.oculus.fullRateCapture 1", false);
        private void tsDrop_SelectedIndexChanged(object sender, EventArgs e) => tsButton.Text = tsDrop.Text;
        private void disprox_Click(object sender, EventArgs e) => adb("shell am broadcast -a com.oculus.vrpowermanager.prox_close", true);
        private void eperimode_Click(object sender, EventArgs e) => adb("shell setprop debug.oculus.experimentalEnabled 1 ", true);
        private void bs5_Click(object sender, EventArgs e) => adb("disconnect", true);
        private void start_Click(object sender, EventArgs e) => adb("shell am start -n " + adb("shell dumpsys package " + draw.Text.Trim() + " | grep -A 1 'filter' | head -n 1 | cut -d ' ' -f 10", false).Trim(), true);
        private void cr_Click(object sender, EventArgs e) => adb("shell am force-stop " + draw.Text, false);
    }
}