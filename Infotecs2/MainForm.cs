using System;
using System.Linq;
using System.Windows.Forms;
using Infotecs2.control;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

using System.Threading;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace Infotecs2
{
    public partial class MainForm : Form
    {
        int time_Update;
        string first_url;
        SyndicationFeed feed;
        bool FORMAT = true;
        public MainForm()
        {
            InitializeComponent();
        }

       
        public static XmlReaders DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(XmlReaders));
            using (FileStream fs = new FileStream("../../config.xml", FileMode.OpenOrCreate))
            {
                XmlReaders settings_xml = (XmlReaders)xml.Deserialize(fs);
                return settings_xml;
            }  
        }

        // Проверка url
        public static Boolean checkedURL(string url)
        {
            try
            {
                //Проверка существования указанного url-адреса
                //В случае ошибки подключения в функции xml.Load(doc) идет обработка исключения
                XmlDocument xml = new XmlDocument();
                xml.Load(url);
                return true;
            }
            catch
            {
                //TextBoxRssFeed.Text = Properties.Settings.Default.Url;
                MessageBox.Show($"Неправильный адрес {url}.\nПроверьте данные!","Ошибка введеного URL!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Проверка частоты обновлений 
        public static Boolean checkedUpdate(string time)
        {
            int res;
            bool isInt = Int32.TryParse(time, out res);
            if (isInt) 
            {
                if (res > 0)
                {
                    return true;
                }
                else 
                {
                    MessageBox.Show($"Введенные число не является положительным!\nПроверьте данные!", "Ошибка введеной частоты обновления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
            else 
            {
                MessageBox.Show($"Введенные данные не являются целым положительным числом!\nПроверьте данные!", "Ошибка введеной частоты обновления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
        }

        //Получение данный (исключения посмотреть)
        private void GetData(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                listBox1.Items.Add(item.Title.Text + " Дата публикации:" + $"{item.PublishDate.ToString("F")}");
            }
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                XmlReaders settings = DeserializeXML();

                if (checkedURL(settings.url) && (checkedUpdate(settings.update_time)))
                    {
                    first_url = settings.url;
                    time_Update = int.Parse(settings.update_time);
                    listBox1.Items.Clear();
                    GetData(first_url);
                    timer1.Enabled = true;
                    timer1.Interval = time_Update;
              
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ne)
            { 
                MessageBox.Show($"Возникли проблемы с файлом конфигурации!\nТекст ошибки\n<<{ne.Message}>>", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   { }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Settings();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }


        

        //Двоеное нажатие на элемент
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string title = listBox1.SelectedItem.ToString();
                foreach(SyndicationItem item in feed.Items)
                    {
                    if (Equals(title, item.Title.Text + " Дата публикации:" + $"{item.PublishDate.ToString("F")}"))
                    {
                        try 
                        { 
                            System.Diagnostics.Process.Start(item.Links[0].Uri.ToString()); 
                        }
                        catch 
                        { 
                            MessageBox.Show("Не удалось открыть ссылку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           listBox1.Items.Clear();
           GetData(first_url);
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty).Trim();
        }

        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
            const string stripFormatting = @"<[^>]*(>|$)";
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);
            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text.Trim();
        }
        // Описание статьи
        private int lastX;
        private int lastY;
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X != this.lastX || e.Y != this.lastY)
            {
                int newHoveredIndex = listBox1.IndexFromPoint(e.Location);
                if (newHoveredIndex >= 0)
                {
                    try
                    {
                        if (FORMAT)
                        {
                            toolTip1.SetToolTip(listBox1, HtmlToPlainText(feed.Items.ToList()[newHoveredIndex].Summary.Text));
                            //toolTip1.SetToolTip(listBox1, StripHTML(feed.Items.ToList()[newHoveredIndex].Summary.Text) + "\n");
                        }
                        else
                        {
                             toolTip1.SetToolTip(listBox1, feed.Items.ToList()[newHoveredIndex].Summary.Text);
                        }
                    }
                    catch
                    {
                        toolTip1.SetToolTip(listBox1, "Описание не найдено...");
                    }
                }
                this.lastX = e.X;
                this.lastY = e.Y;
            }  
        }

        private void fornatRB_CheckedChanged(object sender, EventArgs e)
        {
            FORMAT = true;
        }

        private void NoFormatrb_CheckedChanged(object sender, EventArgs e)
        {
            FORMAT = false;
        }
    }
}
