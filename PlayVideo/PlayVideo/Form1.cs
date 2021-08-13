using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PlayVideo
{
    public partial class Form1 : Form
    {
        string path,title;
        string[] array = { "C:\\Users\\Kinza\\Downloads\\song1.MP4" };
        ListBox listBox1;
        string[] fileEntries = null;  //to get all the things in a folder
        bool nextsong = false; //to see when the next song should be played
        Timer timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();
            wmp.uiMode = "none";
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog op = new OpenFileDialog() { Filter = "MP4 files|*.mp4|All files|*.*" };
            if(op.ShowDialog() == DialogResult.OK)
            {
                path = op.FileName;
                title = op.SafeFileName;
                MessageBox.Show(path);
                wmp.URL = path;
            }*/
            timer1.Start();//start the timer to see when the next song should be played

            comboBox2.Items.Clear();
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fileEntries = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                foreach (string filename in fileEntries)
                {
                    string path1 = folderBrowserDialog1.SelectedPath;
                    string path2 = "desktop.ini";
                    string outpath = Path.Combine(path1, path2);
                    if (filename == outpath)
                    {
                        fileEntries[0] = null;
                    }
                    else
                    {
                        string I = Path.GetFileName(filename);

                        comboBox2.Items.Add(I);
                        wmp.URL = fileEntries[1];
                        comboBox2.Text = Path.GetFileName(fileEntries[1]); ;
                    }
                }
            }
        }
        int playing = 2;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            playing = comboBox2.SelectedIndex;
            playing++;
            wmp.URL = fileEntries[playing];
            nextsong = false;
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("C:\\Users\\Kinza\\Downloads\\song1.MP4");
        }
        int sikkerhed_for_musik_skrift = 1;
        private void wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            if (nextsong == true && fileEntries.Length > (playing + 1) && sikkerhed_for_musik_skrift == 1)
            {
                

                playing++;
                nextsong = false;

                wmp.URL = fileEntries[playing];

            }
            if (nextsong == true)
            {

                nextsong = false;
                sikkerhed_for_musik_skrift = 0;
                playing = 2;

                wmp.URL = fileEntries[1];


            }
            if (wmp.status == "Ready")
            {
                try
                {
                    WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)wmp.Ctlcontrols;
                    controls.play();
                }
                catch
                {

                }
            }
            comboBox2.Text = Path.GetFileName(fileEntries[playing]);


        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.play();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            nextsong = true;
            sikkerhed_for_musik_skrift = 1;
        }
    }
}
