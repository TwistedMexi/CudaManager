using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUDA_Manager
{
    public partial class Guide : Form
    {
        public Guide()
        {
            InitializeComponent();
            rtInfo.RightMargin = rtInfo.Width - 30;
        }

        private void lbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtInfo.Text = "\r\n";

            switch (lbTopics.SelectedIndex)
            {
                case (0):
                    AddText(rtInfo, "Active Miner\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Active Miner indicates the miner that is currently being used. This allows you to keep track of the failover and tells you which pool is being used at any given point in time.");
                    break;

                case (1):
                    AddText(rtInfo, "Adding Miners\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("There are three ways to add miners:\r\n\r\n");
                    AddText(rtInfo, "Importing\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("In most cases, you can import an existing batch file by clicking the \"Import Miner\" button. This will import any additional commands in the batch file as well, for a more advanced configuration.\r\n\r\n");
                    AddText(rtInfo, "Creating\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("You can create a new miner easily by filling out the form with the information provided by your pool of choice. The nickname field is the label it will be given in the manager.\r\n\r\n");
                    AddText(rtInfo, "Cloning\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("You can clone the settings of a miner by selecting \"Load Settings\" and changing the fields as necessary. This will keep any additional batch commands from the original.\r\n\r\n");
                    break;

                case (2):
                    AddText(rtInfo, "Always on Top\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Always on Top enables the CUDA Manager window to stay in front of other windows you may have open, even when it's not in focus. To enable this, you just need to click \"Always on Top\" from the \"Tools\" menu.");
                    break;

                case (3):
                    AddText(rtInfo, "Failover\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Failover is the main feature of CUDA Manager, bringing a long desired option in cudaminer to fruition.\r\n\r\n");
                    AddText(rtInfo, "What's it do?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Have you ever left your miner running all day, only to come home and realize the pool you were using went down 10 minutes after you left? Failover makes this a thing of the past by detecting this, and moving on to another pool you've specified in the meantime.\r\n\r\n");
                    AddText(rtInfo, "How do I use it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Create or import a miner and click \"Add Miner to Manager\". The miner will be added to the list to the left. The first miner will be started first. Now add more miners the same way, and then use the buttons under the Failover grid to put them in the desired order. If your first pool goes down, the second pool will be started, and so on.\r\n\r\n");
                    AddText(rtInfo, "Retry Limit\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("The retry limit is how many times to try reconnecting to a pool that's gone down, before moving on to the next miner. Each retry occurs after approximately 15 seconds.\r\n\r\n");
                    break;

                case (4):
                    AddText(rtInfo, "Fan Controller\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The fan controller enables you to specify fan speeds for your GPU instead of relying on your GPU to do it automatically.\r\n\r\n");
                    AddText(rtInfo, "How can I check my fan's speed?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Click on your GPU temperature at the bottom, and your fan speed will be listed there.\r\n\r\n");
                    AddText(rtInfo, "How do I change the speed?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("You can change the fan speed by clicking on your GPU temperature, going to Set Fan Speed:, and picking your preferred option from the drop-down.");
                    break;

                case (5):
                    AddText(rtInfo, "Ghosting\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Ghosting is more of a luxury than a necessity. When enabled, it turns the console transparent so it can be overlayed on a video or other app. When mining, this can cause lag when interacting with the window, so this feature isn't for everyone.\r\n\r\n");
                    AddText(rtInfo, "How do I use it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("When the console is maximized, ghosting is available from the Tools menu.");
                    break;

                case (6):
                    AddText(rtInfo, "GPU Temperature\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The temperature for each GPU is displayed at the bottom of CUDA Manager. This temperature comes straight from the GPU's core sensor.");
                    break;

                case (7):
                    AddText(rtInfo, "Hashrate\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Hashrate is essentially the measurement of your GPU's mining performance. The higher the hashrate, the better your mining experience.\r\n\r\n");
                    AddText(rtInfo, "Average Hashrate\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Your average hashrate is displayed at the bottom. This is an average over the entire mining session and becomes more accurate over time.");
                    break;

                case (8):
                    AddText(rtInfo, "Maximize Console\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The maximize console option, when enabled, expands the output console to the entire window. Many users prefer the simple console window, so this options allows that aspect to be retained.\r\n\r\n");
                    AddText(rtInfo, "How do I enable it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("The Maximize Console option can be toggled from the Tools menu.");
                    break;

                case (9):
                    AddText(rtInfo, "Miner Log\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The miner log provides an overview of your mining session. In addition to an hourly entry, it will add an entry for any events such has high temperature or failover. It's cleared every time CUDA Manager is exited.\r\n\r\n");
                    AddText(rtInfo, "How do I access it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("The \"View Miner Log\" option can be accessed from the File menu. You can also save the log from the File menu.");
                    break;

                case (10):
                    AddText(rtInfo, "Minimize to Tray\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The Minimize to Tray option sets the default minimize behavior to hide the app to the system tray.\r\n\r\n");
                    AddText(rtInfo, "How do I toggle it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("The \"Minimize to Tray\" option can be toggled from the Tools menu.");
                    break;

                case (11):
                    AddText(rtInfo, "Output Console\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("The output console displays all standard cudaminer output, as you would see if you were running cudaminer directly.");
                    break;

                case (12):
                    AddText(rtInfo, "Protective Cooling\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Protective cooling is one of the more advanced, beginner-friendly features of CUDA Manager. When enabled, if your GPU reaches 80°C or higher, it will activate. When activated, the GPU fans are turned up to 100% until the temperature returns to a safe level, or until the user can intervene to correct the problem.\r\n\r\n");
                    AddText(rtInfo, "Why is the threshold 80°C?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Though video card specifications will typically list their \"max temperature\" ranging well into the 90's, these temperatures are the absolute maximum before the video card potentially crashes. Video cards start sustaining long-term damage at higher operating temperatures. 80°C was chosen as a universal standard and in general, a video card that's expected to live a long life should never be operating at these temperatures for long periods of time.\r\n\r\n");
                    AddText(rtInfo, "How do I toggle it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("The feature can be toggled by clicking on the GPU temperature at the bottom and clicking \"Protective Cooling\". We highly recommend leaving this option enabled unless your GPU fans are having trouble running at 100%.\r\n\r\n");
                    AddText(rtInfo, "Automatic Shut-off\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("In the event the GPU reaches 100°C, CUDA Manager will flag the GPU as unstable. If the GPU's temperature does not lower within 30 seconds, CUDA Manager will halt the miner and add an entry to the log. This protection can not be disabled. If this is occurring repeatedly, please check your computer's fans and make sure the air flow is optimal.\r\n\r\n");
                    break;

                case (13):
                    AddText(rtInfo, "Save Config\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("When adding a miner, you may not always know what the configuration for your GPU is. Cudaminer will run autotune to find this for you, but it can be time consuming. CUDA Manager captures the config from autotune for you. When autotune picks a config that seems to be performing well for you, you can save the config to skip autotune from then on.\r\n\r\n");
                    AddText(rtInfo, "How do I save it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("You can save a preferred config by clicking on the config at the bottom and choosing \"Save Config\" from the slide-out menu.");
                    break;

                case (14):
                    AddText(rtInfo, "Switching Miners\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Miners can be re-arranged using the 'Move Up', 'Move Down', and 'Remove' buttons. If you want to start a specific miner without moving it to the top, you can select the miner and right-click it, then select \"Start Selected Miner\". The failover will loop over from there.");
                    break;

                case (15):
                    AddText(rtInfo, "Warnings\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("When warnings are enabled, the system tray icon will display balloons showing the warning, such as when Protective Cooling is activated or when a failover occurs.\r\n\r\n");
                    AddText(rtInfo, "How do I toggle it?\r\n", Color.Black, FontStyle.Bold);
                    rtInfo.AppendText("Warnings can be toggled by right-clicking the system tray icon and selecting the 'Show Warnings' option.");
                    break;

                case (16):
                    AddText(rtInfo, "Yays\r\n\r\n", Color.SteelBlue, (FontStyle.Bold | FontStyle.Underline));
                    rtInfo.AppendText("Yays indicate the amount of accepted work you've done toward your pool. The yays at the bottom are your average per minute, and are - to some effect - a luck indicator.");
                    break;
            }

        }
        private void AddText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void AddText(RichTextBox box, string text, Color color, FontStyle font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionFont = new Font(box.Font.FontFamily, box.Font.Size, font);
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void rtInfo_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                rtInfo.RightMargin = rtInfo.Width - 30;
        }
    }
}
