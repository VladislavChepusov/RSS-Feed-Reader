using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infotecs2;
using Infotecs2.Properties;
using Infotecs2.control;
using System.Xml.Serialization;
using System.IO;

namespace Infotecs2
{
    public partial class Settings : Form
    {
        string url;
        string update_time;
        public Settings()
        {
            InitializeComponent();
        }

        private void back()
        {
            this.Hide();
            var form1 = new MainForm();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
        private void save(string url,string time)
        {
            XmlReaders xr = new XmlReaders(url,time);
            XmlSerializer xml = new XmlSerializer(typeof(XmlReaders));
            using (FileStream fs = new FileStream("../../config.xml", FileMode.Create))
            {
                xml.Serialize(fs, xr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checke = true;
            if (MainForm.checkedURL(tb_URL.Text))
            {
                url = tb_URL.Text;
            }
            else
            {
                tb_URL.Text = url;
                checke = false;
            }
            if (MainForm.checkedUpdate(tb_Update.Text))
            {
                update_time = tb_Update.Text;
            }
            else
            {
                tb_Update.Text = update_time;
                checke = false;
            }

            if (checke)
            {
                save(url, update_time);
                MessageBox.Show("Изменения успешно внесены", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                back();
            }
          
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                XmlReaders settings = MainForm.DeserializeXML();

                if (MainForm.checkedURL(settings.url) && (MainForm.checkedUpdate(settings.update_time)))
                {
                    tb_URL.Text = url = settings.url;
                    tb_Update.Text= update_time = settings.update_time;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ne)
            {

                //MessageBox.Show(ne.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"Возникли проблемы с файлом конфигурации!\nТекст ошибки\n<<{ne.Message}>>", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }
        }
  
      
        private void btn_back_Click(object sender, EventArgs e)
        {
            back();
        }

    }
}
