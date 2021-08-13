using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Text.RegularExpressions;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.VisualBasic;
using CColor = System.Drawing.Color;

namespace SmartReader
{
    public partial class Form1 : Form
    {
        string word;
        public static string replaceWith="", replaceWhat="";
        int findPos = 0;
        SpeechSynthesizer reader;
        SpeechRecognitionEngine rec;
      SpeechSynthesizer speaker;
        //declare the object
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        MatchCollection collection;
        static int totalFounds = 0, foundCounter;
        SpeechSynthesizer r;
        int darkOrLight=1;
        int voiceMode = 1;
        static Boolean findClicked = false;
        string fontcolor, fontt, fontsize,fontstyle, voicetype,mode;
        FontDialog font=new FontDialog();
        String username, pass;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string mode,string fStyle,string fontt,string fColor,string voiceT,string fsize,string user,string pass)
        {
            InitializeComponent();

            if (mode == "Light")
            {
                DarkModeToggleSwitch.Checked = false;
            }
            else if (mode == "Dark")
            {

                DarkModeToggleSwitch.Checked = true;
            }
            if (voiceT == "Male")
            {
                maleToolStripMenuItem.Checked = true;

          
            }
            else if (voiceT == "Female")
            {
                femaleToolStripMenuItem.Checked = true;
            }
            this.username = user;
            this.pass = pass;
            richTextBox.SelectionFont = new System.Drawing.Font(fontt, float.Parse(fsize));
            richTextBox.SelectionColor = CColor.FromName(fColor);
           
            }

        public delegate String ReturnText();

        private void openFile_Click(object sender, EventArgs e)
        {


            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = @"E:\";
            of.Title = "Select Text File";
            of.Filter = "Text Files|*.txt";
            of.FilterIndex = 2;
            of.Multiselect = false;

            if (of.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Text = "";
                if (of.SafeFileName.EndsWith(".txt"))
                {
                    String[] fileText = System.IO.File.ReadAllLines(of.FileName);
                    String txt = "";
                    ReturnText rtxt = () => {
                        foreach (String s in fileText)
                        {
                            txt += s + "\n";
                        }
                        return txt;
                    };
                    richTextBox.Text += rtxt();
                }
            }
            /*OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        openFileDialog1.Filter =
               "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
               "All files (*.*)|*.*";

                        openFileDialog1.Multiselect = true;
                        openFileDialog1.Title = "Select Photos";

                        DialogResult dr = openFileDialog1.ShowDialog();
                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            foreach (String file in openFileDialog1.FileNames)
                            {
                                try
                                {
                                    PictureBox imageControl = new PictureBox();
                                    imageControl.Height = 400;
                                    imageControl.Width = 400;

                                    Image.GetThumbnailImageAbort myCallback =
                                            new Image.GetThumbnailImageAbort(ThumbnailCallback);
                                    Bitmap myBitmap = new Bitmap(file);
                                    Image myThumbnail = myBitmap.GetThumbnailImage(300, 300,
                                        myCallback, IntPtr.Zero);
                                    imageControl.Image = myThumbnail;

                                    richTextBox.Controls.Add(imageControl);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message);
                                }
                            }*/
            //}
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void newSmartReader_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ReadText()
        {

           // reader.Dispose();
            if (richTextBox.Text != "")    //if text area is not empty
            {
             //   reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox.Text);
                //label2.Text = "SPEAKING";
                PauseBtn.Enabled = true;
               // stopBtn.Enabled = true;
                reader.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(reader_SpeakCompleted);
                
            }
            else
            {
                speaker.SpeakAsync("Please enter some text in the textbox");
                //MessageBox.Show("Please enter some text in the textbox",
                // "Message", MessageBoxButtons.OK);
            }
        }
        private void readText_Click(object sender, EventArgs e)
        {
            ReadText();
        }

        //event handler
        void reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            //MessageBox.Show("IDLE");
        }
        private void richTextBox_SelectionChanged(object sender,EventArgs e) {
            toolStripStatusLabel1.Text = String.Format("Ln {0}, Col {1}", CurrentLine, CurrentColumn);
        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = String.Format("Ln {0}, Col {1}", CurrentLine, CurrentColumn);
            if (richTextBox.Text.Length > 0)
            {
                cutMenuItem.Enabled = true;
                copyMenuItem.Enabled = true;
            }
            else {
                cutMenuItem.Enabled = false;
                copyMenuItem.Enabled = false;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.DarkModeToggleSwitch.Checked)
            {

            }
            else {
                panel1.BackColor = Color.LightSteelBlue;
                panel2.BackColor = Color.LightSteelBlue;
                menuStrip.BackColor = Color.LightSteelBlue;
            }
            font = new FontDialog();
            speaker = new SpeechSynthesizer();
            reader = new SpeechSynthesizer(); //create new object
            
          
        }

        private void ReadTextBtn_Click(object sender, EventArgs e)
        {

            ReadText();
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
              //      MessageBox.Show("PAUSED");
                    ResumeBtn.Enabled = true;

                }
            }
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                //    MessageBox.Show("Speaking");
                }
                ResumeBtn.Enabled = false;
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            
        }
        public void SaveAudioFromText() {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "WAV file|*.wav";
            sav.ValidateNames = true;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                string fileN = sav.FileName;
                var reader = new SpeechSynthesizer();
                var fileName = string.Format(fileN);
                reader.SetOutputToWaveFile(fileName);

                var builder = new PromptBuilder();
                if (richTextBox.Text != "")
                {
                    builder.StartVoice(VoiceGender.Male);
                    builder.AppendText(string.Format(richTextBox.Text));
                    builder.EndVoice();
                }
                else
                {
                    speaker.SpeakAsync("Please enter some text");

                    //                MessageBox.Show("Write something");
                }
                reader.Rate = 0;
                reader.Speak(builder);
                MessageBox.Show(fileN);
            }
            else { }
            
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveAudioFromText();

        }


        private void listenBtn_Click(object sender, EventArgs e)
        {
             rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            //SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            rec.SetInputToDefaultAudioDevice();
            rec.LoadGrammar(new DictationGrammar());
            rec.RecognizeAsync(RecognizeMode.Multiple);
            //rec.RecognizeAsync(RecognizeMode.Multiple);
            rec.SpeechRecognized +=new EventHandler<SpeechRecognizedEventArgs>( Rec_SpeechRecognized);
            richTextBox.Text += "\n";
        }

        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox.Text += e.Result.Text;
        }

        void SpeechHypothesizing(object sender, SpeechHypothesizedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void jarvisModeBtn_Click(object sender, EventArgs e)
        {
            r = new SpeechSynthesizer();
            if (maleToolStripMenuItem.Checked == true)
            {

                r.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);

            }
            else if (femaleToolStripMenuItem.Checked == true)
            {
                r.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);

            }
            richTextBox.Text += "\n";
            richTextBox.Text += "I can do this";
            r.Speak("I can do this");
            richTextBox.Text += "\n";
            richTextBox.Text += "A: Open notepad";
            r.Speak("Say A to Open notepad");
            richTextBox.Text += "\n";
            richTextBox.Text += "I: Open Paint";
            r.Speak("Say I to Open paint");
            richTextBox.Text += "\n";
            richTextBox.Text += "P: Open Powerpoint";
            r.Speak("Say P to Open Powerpoint");
            richTextBox.Text += "\n";
            richTextBox.Text += "M: Open MS Word";
            r.Speak("Say M to Open MS word");
            richTextBox.Text += "\n";
            richTextBox.Text += "Y: Open Youtube";
            r.Speak("Say Y to Open Youtube");
            richTextBox.Text += "\n";
            richTextBox.Text += "O: Open Command Line";
            r.Speak("Say O to Open Command Line");
            richTextBox.Text += "\n";
            richTextBox.Text += "G: Open Google";
            r.Speak("Say G to Open Google");
            r.Dispose();

            Choices commands = new Choices();
            commands.Add(new string[] { "A", "I", "P", "M", "Y", "O", "G" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammer = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;



        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string res = e.Result.Text;
            if (res == "A")
            {
                System.Diagnostics.Process.Start("notepad.exe");
                speaker.SpeakAsync("Notepad has opened");

            }
            else if (res == "I") {
                System.Diagnostics.Process.Start("mspaint.exe");
                speaker.SpeakAsync("Paint has opened");

            }else if (res == "P")
            {
                System.Diagnostics.Process.Start("POWERPNT.EXE");
                speaker.SpeakAsync("Power Point has opened");


            }
            else if (res == "M") {

                System.Diagnostics.Process.Start("WINWORD.EXE");
                speaker.SpeakAsync("MS Word has opened");

            }
            else if (res=="Y")
            {

                speaker.SpeakAsync("Youtube has opened");

                System.Diagnostics.Process.Start("https://www.youtube.com/");

            }
            else if (res == "O")
            {
                speaker.SpeakAsync("Command Line has opened");

                System.Diagnostics.Process.Start("cmd.exe");

            }
            else if (res == "G")
            {

                speaker.SpeakAsync("Google has opened");
                System.Diagnostics.Process.Start("http://google.com");

            }
            else
            {
                speaker.SpeakAsync("Invalid Input please try again");


            }
        }

        private void disableListeningBtn_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void findMenuItem_Click(object sender, EventArgs e)
        {

            word = Interaction.InputBox("Enter Text to find : ", "Find", "", 100, 100);
            try
            {
                string s = word;
                richTextBox.Focus();
                findPos = richTextBox.Find(s, findPos, RichTextBoxFinds.None);
                richTextBox.Select(findPos, s.Length);
                findPos += word.Length;
             }
            catch
            {
                MessageBox.Show("No Occurences Found");
                findPos = 0;
            }
        }

        private void replaceMenuItem_Click(object sender, EventArgs e)
        {
            Replace rep = new Replace();
            if (this.DarkModeToggleSwitch.Checked)
            {
                rep.DarkMode();
            }
            else
            {
                rep.LightMode();
            }
            rep.ShowDialog();
            if (replaceWith != "" && replaceWhat != "") {
                richTextBox.Text = richTextBox.Text.Replace(replaceWhat, replaceWith);
            }
        }

        private void selectAlMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            font.ShowColor = true;
            font.ShowEffects = true;
            font.ShowApply = true;
            font.ShowHelp = true;

            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox.ForeColor = font.Color;
                richTextBox.Font = font.Font;
            }

        }

        private void findNextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string s = word;
                richTextBox.Focus();
                findPos = richTextBox.Find(s, findPos, RichTextBoxFinds.None);
                richTextBox.Select(findPos, s.Length);
                findPos += word.Length;
            }
            catch
            {
                MessageBox.Show("No Occurences Found");
                findPos = 0;
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void audToTextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.InitialDirectory = "E:\\";
            ofile.Filter = "WAV Files |*.wav";

            ofile.FilterIndex = 2;
            if (ofile.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Text += "\n";
                richTextBox.Text += AudioToText(ofile.FileName);
               // MessageBox.Show(ofile.FileName);
            }
                
            }

            private void buttonFileOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         }

        private void btnSendMail_Click(object sender, EventArgs e)
        {

        }
        public void TextTopdf() {
            try
            {
                if (richTextBox.Text != "")
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                    {

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {

                            Document doc = new Document(PageSize.A4.Rotate());
                            try
                            {
                                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                doc.Open();
                                doc.Add(new Paragraph(richTextBox.Text));

                                speaker.SpeakAsync("Text is converted to pdf SuccessFully");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                doc.Close();
                            }
                           
                        }

                    }

                }
                else
                {
                    speaker.SpeakAsync("please Write somr thing in the text box");

                    //MessageBox.Show("Write Something!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnTextTopdf_Click(object sender, EventArgs e)
        {
            
        }

        private void findText()
        {

            String searchText="";// = this.FindTextBox.Text;

            foundCounter = 0;
            Regex pattern = new Regex(searchText, RegexOptions.IgnoreCase);
            Match match = pattern.Match(richTextBox.Text);
            collection = pattern.Matches(richTextBox.Text);
            totalFounds = collection.Count;
            if (match.Success)
            {
                
                String str = collection[0].Value;
                //MessageBox.Show(str+" "+collection[0].Index+" "+str.Length);
                richTextBox.Select(collection[0].Index, str.Length);
                richTextBox.SelectionBackColor = Color.Aqua;
                foundCounter++;
                findClicked = true;
            }
            else
            {
                speaker.SpeakAsync("Text does not found");
                


                //MessageBox.Show("Not found");
            }
        }
        private void findNextText()
        {
            if (findClicked && foundCounter < totalFounds)
            {

                String str = collection[foundCounter].Value;
                richTextBox.Select(collection[foundCounter].Index, str.Length);
                richTextBox.SelectionBackColor = Color.Aqua;
                foundCounter++;
            }
        }

        private void OpenPdf_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string fileN;
            OpenFileDialog pdfile = new OpenFileDialog();
            pdfile.Filter = "PDF|*.pdf";
            if (pdfile.ShowDialog() == DialogResult.OK)
            {
                fileN = pdfile.FileName;
                using (PdfReader pReader = new PdfReader(fileN))
                {

                    for (int pageNo = 1; pageNo <= pReader.NumberOfPages; pageNo++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string text = PdfTextExtractor.GetTextFromPage(pReader, pageNo, strategy);
                        text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                        sb.Append(text);

                    }
                }
                richTextBox.Text += sb.ToString();
            }
        }

        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            
        }

        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maleToolStripMenuItem.Checked == true) {
                voiceMode = 1;
                femaleToolStripMenuItem.Checked = false;
                reader.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
                speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);

            }
            else {

                maleToolStripMenuItem.Checked = false;
            }
           
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (femaleToolStripMenuItem.Checked == true)
            {
                voiceMode = 2;
                maleToolStripMenuItem.Checked = false;
                reader.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
                speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            }
            else
            {

                femaleToolStripMenuItem.Checked = false;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                richTextBox.WordWrap = true;
            }
            else {
                richTextBox.WordWrap = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listenDisable_Click(object sender, EventArgs e)
        {
            rec.RecognizeAsyncStop();

        }

        private void voiceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MailBtn_Click(object sender, EventArgs e)
        {
            //speaker = new SpeechSynthesizer();
            string a = "Before sending mail please make sure you change your google settings and allow less secure apps thank you!";
            speaker.SpeakAsync(a);
            ChooseMail obj = new ChooseMail(richTextBox,speaker);
            obj.StartPosition = FormStartPosition.CenterScreen;
            if (this.DarkModeToggleSwitch.Checked)
            {
                obj.DarkMode();
            }
            else {
                obj.LightMode();
            }
            obj.ShowDialog();
            
            //reader.Pause();

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (darkOrLight == 2) {
                mode = "Dark";
            }
            else
            {
                mode = "Light";
            }
            if (voiceMode == 1)
            {
                voicetype = "Male";
            }
            else {
                voicetype = "Female";
            }
            fontt = richTextBox.SelectionFont.Name;
            fontsize = richTextBox.SelectionFont.Size.ToString();
            fontstyle = richTextBox.Font.Style.ToString();
            fontcolor = richTextBox.SelectionColor.Name;

            UserProfile profile = new UserProfile(mode,fontstyle,fontt,fontcolor,voicetype,fontsize,username,pass);
            if (this.DarkModeToggleSwitch.Checked)
            {
                profile.DarkMode();

            }
            else {
                profile.LightMode();
            }
            profile.ShowDialog();
            
        }

        private void buttonSavePdf_Click(object sender, EventArgs e)
        {
            TextTopdf();
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listenAndWrite_Click(object sender, EventArgs e)
        {
            rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            //SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            rec.SetInputToDefaultAudioDevice();
            rec.LoadGrammar(new DictationGrammar());
            rec.RecognizeAsync(RecognizeMode.Multiple);
            //rec.RecognizeAsync(RecognizeMode.Multiple);
            rec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Rec_SpeechRecognized);
            richTextBox.Text += "\n";
        }

        private void timeDateMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text += "\n";
            richTextBox.Text += DateTime.Now.ToString();
        }

        private void viewHelpMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bing.com/search?q=get+help+with+notepad+in+windows+10&filters=guid:%224466414-en-dia%22%20lang:%22en%22&form=T00032&ocid=HelpPane-BingIA");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void findPreviousMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dark mode  " + mode + " Voice " + voicetype + " font " + fontt + " fontsize " + fontsize + " fontstyle " + fontstyle+ " fontColor" + fontcolor);

        }

        private void saveFille_Click(object sender, EventArgs e)
        {
            SaveFileDialog sF = new SaveFileDialog();
            sF.Title = "Save file";
            sF.InitialDirectory = @"E:\";
            sF.Filter = "Text Files|*.txt";
            sF.FilterIndex = 1;

            if (sF.ShowDialog() == DialogResult.OK)
            {

                if (sF.CheckFileExists == false)
                {

                    String[] RTxt = { richTextBox.Text };
                    System.IO.File.WriteAllLines(sF.FileName, RTxt);
                }
            }
        }
        public int CurrentColumn
        {
            get { return richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine() + 1; }
        }

        public int CurrentLine
        {
            get { return richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart) + 1; }
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                toolStripStatusLabel1.Text = String.Format("Ln {0}, Col {1}", CurrentLine, CurrentColumn);
                statusStrip1.Visible = true;
            }
            else
            {
                statusStrip1.Visible = false;
            }
        }

        private void DarkModeToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            ChooseMail m = new ChooseMail();
            if (DarkModeToggleSwitch.Checked) {
                darkOrLight = 2;
                this.richTextBox.ForeColor = Color.White;
                m.DarkMode();
                richTextBox.ForeColor = Color.White;
                this.BackColor = Color.DarkGray;
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.Black;
                richTextBox.BackColor = Color.DarkSlateGray;
                menuStrip.BackColor = Color.DarkSlateGray;
                fileToolStripMenuItem.ForeColor = Color.White;
                editToolStripMenuItem.ForeColor = Color.White;
                formatToolStripMenuItem.ForeColor = Color.White;
                viewToolStripMenuItem.ForeColor = Color.White;
                helpToolStripMenuItem.ForeColor = Color.White; 
                voiceTypeToolStripMenuItem.ForeColor = Color.White;
                labelAudTotext.ForeColor = Color.White;
                labelDark.ForeColor = Color.White;
                labelDis.ForeColor = Color.White;
                PauseLbl.ForeColor = Color.White;
                labelDisable.ForeColor = Color.White;
                labelEn.ForeColor = Color.White;
                labelEnable.ForeColor = Color.White; 
                labelJarvis.ForeColor = Color.White;
                labelPdf.ForeColor = Color.White;
                labelPlay.ForeColor = Color.White;
                labelProfile.ForeColor = Color.White;
                labelResume.ForeColor = Color.White;
                labelSp.ForeColor = Color.White;
                labelSpeech.ForeColor = Color.White;
                MailLabel.ForeColor = Color.White;

            } else {
                m.LightMode();
                darkOrLight = 1;
                richTextBox.ForeColor = Color.Black;
                this.BackColor = Color.White;
                panel1.BackColor = Color.LightSteelBlue;
                panel2.BackColor = Color.LightSteelBlue;
                richTextBox.BackColor = Color.White;
                menuStrip.BackColor = Color.LightSteelBlue;
                fileToolStripMenuItem.ForeColor = Color.Black;
                editToolStripMenuItem.ForeColor = Color.Black;
                formatToolStripMenuItem.ForeColor = Color.Black;
                viewToolStripMenuItem.ForeColor = Color.Black;
                helpToolStripMenuItem.ForeColor = Color.Black;
                voiceTypeToolStripMenuItem.ForeColor = Color.Black;
                labelAudTotext.ForeColor = Color.Black;
                labelDark.ForeColor = Color.Black;
                labelDis.ForeColor = Color.Black;
                PauseLbl.ForeColor = Color.Black;
                labelDisable.ForeColor = Color.Black;
                labelEn.ForeColor = Color.Black;
                labelEnable.ForeColor = Color.Black;
                labelJarvis.ForeColor = Color.Black;
                labelPdf.ForeColor = Color.Black;
                labelPlay.ForeColor = Color.Black;
                labelProfile.ForeColor = Color.Black;
                labelResume.ForeColor = Color.Black;
                labelSp.ForeColor = Color.Black;
                labelSpeech.ForeColor = Color.Black;
                MailLabel.ForeColor = Color.Black;


            }
        }

        string AudioToText(String fName) {

            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sr.LoadGrammar(gr);
            sr.SetInputToWaveFile(@fName);
            sr.BabbleTimeout = new TimeSpan(Int32.MaxValue);
            sr.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
            sr.EndSilenceTimeout = new TimeSpan(100000000);
            sr.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var recText = sr.Recognize();
                    if (recText == null)
                    {
                        break;
                    }

                    sb.Append(recText.Text);

                    speaker.SpeakAsync("Conversion is Completed Successfully");
                    
                    // MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                    break;
                }
            }
            return sb.ToString();
        }

    }
}