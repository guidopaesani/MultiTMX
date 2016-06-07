using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MultiTMX_2_MonoTXTs
{
    public partial class MultiTMX2MonoTXTs : Form
    {
        public MultiTMX2MonoTXTs()
        {
            InitializeComponent();
            BkGdWorker.WorkerReportsProgress = true;
            BkGdWorker.WorkerSupportsCancellation = true;
            progressBar1.Visible = false;
            DescLabel.Text = "From a TMX, extract segments to individual, monolingual TXT files";
            label1.Text = "";
            resultLabel.Text = "Select a TMX and click Start";
            // TxBxInputFile.Text = @"C:\_WORK\_Customers\Facebook\TMXs\Facebook_es_ES.tmx";
            TxBxInputFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        static Dictionary<string, List<string>> StreamMultilingualTMX(string uri)
        {   
            Dictionary<string, List<string>> TXTs = new Dictionary<string, List<string>>();
            List<string> Segments;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            settings.DtdProcessing = DtdProcessing.Ignore;

            using (XmlReader reader = XmlReader.Create(uri, settings))
            //using (XmlReader reader = XmlReader.Create(uri))
            {
                XElement header = null; 
                XElement tuv = null;
                //int vCurrentLine = 0;
                reader.MoveToContent();
                //vCurrentLine++;
                // loop through elements
                while (reader.Read())
                {
                    //vCurrentLine++;
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "header")
                    {
                        header = XElement.ReadFrom(reader) as XElement;
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "tuv")
                    {
                        string vLang = "UNKNOWN";
                        string vSegment = "ERRROR";
                        tuv = XElement.ReadFrom(reader) as XElement;
                        if(tuv.HasAttributes==true)
                        {
                            foreach (XAttribute vAttr in tuv.Attributes())
                            {
                                if (vAttr.Name.LocalName=="lang") 
                                {
                                    vLang = vAttr.Value;
                                }
                            }
                        }
                        if(tuv.HasElements==true)
                        {
                            foreach (XElement vElement in tuv.Elements())
                            {
                                if (vElement.Name.LocalName=="seg")
                                {
                                    vSegment = vElement.Value;
                                }
                            }
                        }
                        if (!TXTs.TryGetValue(vLang, out Segments))
                        {
                            Segments = new List<string>();
                            TXTs[vLang] = Segments;
                        }
                        Segments.Add(vSegment);
                    }
                    //worker.ReportProgress(vCurrentLine / vTotalLines * 100);
                }
            }
            return TXTs;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (BkGdWorker.IsBusy != true)
            {
                // Start the asynchronous operation.
                progressBar1.Visible = true; 
                resultLabel.Text = "In progress...";
                progressBar1.Value = 0;
                timer.Enabled = true;
                timer.Tick += new EventHandler(timer_Tick);
                // Sets the timer interval to X seconds (milisecs).
                timer.Interval = 2000;
                timer.Start();
                BkGdWorker.RunWorkerAsync();
            }
        }

        private void timer_Tick(object sender, EventArgs e) 
        {
            progressBar1.Value += 1;
            if (progressBar1.Value > 50)
                progressBar1.Value = 50;
            resultLabel.Text = ("In progress..." + progressBar1.Value + "%");
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (BkGdWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                BkGdWorker.CancelAsync();
            }
        }

        // This event handler is where the time-consuming work is done. 
        private void BkGdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //for (int i = 1; i <= 10; i++)
            //{
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    //break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    Dictionary<string, List<string>> TXTs = StreamMultilingualTMX(TxBxInputFile.Text);
                    worker.ReportProgress(50);
                    timer.Stop();
                    int i = 0;
                    foreach (string vLanguage in TXTs.Keys)
                    {
                        string vFilename = Path.GetDirectoryName(TxBxInputFile.Text) + @"\" + Path.GetFileNameWithoutExtension(TxBxInputFile.Text) + "_" + vLanguage + ".txt";
                        File.WriteAllLines(vFilename, TXTs[vLanguage]);
                        i++;
                        System.Threading.Thread.Sleep(500);
                        int vProgress = Convert.ToInt32(((Decimal.Divide(i, TXTs.Keys.Count)) * 50) + 50);
                        worker.ReportProgress(vProgress);
                    }


                }
            //}
        }

        // This event handler updates the progress. 
        private void BkGdWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = ("In progress..." + e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }

        // This event handler deals with the results of the background operation. 
        private void BkGdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            openFileDialog1.Filter = "TMX Files (.tmx)|*.tmx|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            if (result == DialogResult.OK) // Test result.
            {
                TxBxInputFile.Text = openFileDialog1.FileName;
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void TxBxInputFile_TextChanged(object sender, EventArgs e)
        {
            if (TxBxInputFile.Text=="") return;
            if (File.Exists(TxBxInputFile.Text))
            {
                label1.Text = "File exists.";
            } else {
                label1.Text = "File does not exist.";
                return;
            }
            //count lines and test parsing
            int vTotalLines = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            settings.DtdProcessing = DtdProcessing.Ignore;

            using (XmlReader reader = XmlReader.Create(TxBxInputFile.Text, settings))
            //using (XmlReader reader = XmlReader.Create(TxBxInputFile.Text))
            {
                //reader.MoveToContent();
                //Encoding.Default.GetString(Encoding.UTF8.GetBytes(reader.);
                try
                {
                    while (reader.Read())
                    {
                        vTotalLines++;
                    }
                }
                catch (Exception Ex)
                {
                    label1.Text = Ex.Message;
                    //Regex.Replace(reader., @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                }
            }
        }
    }
}
