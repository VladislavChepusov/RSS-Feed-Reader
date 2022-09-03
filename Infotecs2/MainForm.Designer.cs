
namespace Infotecs2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoFormatrb = new System.Windows.Forms.RadioButton();
            this.fornatRB = new System.Windows.Forms.RadioButton();
            this.btnSetting = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.NoFormatrb);
            this.panel1.Controls.Add(this.fornatRB);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 480);
            this.panel1.TabIndex = 0;
            // 
            // NoFormatrb
            // 
            this.NoFormatrb.AutoSize = true;
            this.NoFormatrb.Location = new System.Drawing.Point(426, 10);
            this.NoFormatrb.Name = "NoFormatrb";
            this.NoFormatrb.Size = new System.Drawing.Size(240, 21);
            this.NoFormatrb.TabIndex = 3;
            this.NoFormatrb.Text = "Описание без форматирования";
            this.NoFormatrb.UseVisualStyleBackColor = true;
            this.NoFormatrb.CheckedChanged += new System.EventHandler(this.NoFormatrb_CheckedChanged);
            // 
            // fornatRB
            // 
            this.fornatRB.AutoSize = true;
            this.fornatRB.Checked = true;
            this.fornatRB.Location = new System.Drawing.Point(162, 10);
            this.fornatRB.Name = "fornatRB";
            this.fornatRB.Size = new System.Drawing.Size(233, 21);
            this.fornatRB.TabIndex = 2;
            this.fornatRB.TabStop = true;
            this.fornatRB.Text = "Описание с форматированием";
            this.fornatRB.UseVisualStyleBackColor = true;
            this.fornatRB.CheckedChanged += new System.EventHandler(this.fornatRB_CheckedChanged);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(3, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(124, 29);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Настройки";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(3, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1146, 420);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Описание";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1176, 521);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "FeederMain";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton NoFormatrb;
        private System.Windows.Forms.RadioButton fornatRB;
    }
}

