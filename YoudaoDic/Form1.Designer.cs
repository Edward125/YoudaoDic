namespace YoudaoDic
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTranslation = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtInputWord = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnAdd2Dic = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtNextTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSequence = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEN = new System.Windows.Forms.TextBox();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnChn = new System.Windows.Forms.Button();
            this.btnEng = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDic = new System.Windows.Forms.TextBox();
            this.txtVoice = new System.Windows.Forms.TextBox();
            this.timerNext = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.webExplain = new System.Windows.Forms.WebBrowser();
            this.lstWordList = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTranslation
            // 
            this.btnTranslation.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranslation.Location = new System.Drawing.Point(11, 53);
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.Size = new System.Drawing.Size(102, 32);
            this.btnTranslation.TabIndex = 0;
            this.btnTranslation.Text = "Translation";
            this.btnTranslation.UseVisualStyleBackColor = true;
            this.btnTranslation.Click += new System.EventHandler(this.btnTranslation_Click);
            // 
            // txtSource
            // 
            this.txtSource.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(10, 18);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(322, 25);
            this.txtSource.TabIndex = 1;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            this.txtSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSource_KeyPress);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(1070, 561);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(322, 54);
            this.txtResult.TabIndex = 2;
            this.txtResult.Visible = false;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // txtInputWord
            // 
            this.txtInputWord.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputWord.Location = new System.Drawing.Point(69, 22);
            this.txtInputWord.Name = "txtInputWord";
            this.txtInputWord.Size = new System.Drawing.Size(203, 25);
            this.txtInputWord.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtInputWord, "双击选择单词库文本");
            this.txtInputWord.DoubleClick += new System.EventHandler(this.txtInputWord_DoubleClick);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(281, 17);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(55, 32);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "录入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "单词本";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInputWord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(173, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "背诵单词本录入";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRead);
            this.groupBox2.Controls.Add(this.btnAdd2Dic);
            this.groupBox2.Controls.Add(this.txtSource);
            this.groupBox2.Controls.Add(this.btnTranslation);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(173, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询翻译";
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(119, 55);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(86, 32);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnAdd2Dic
            // 
            this.btnAdd2Dic.Enabled = false;
            this.btnAdd2Dic.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd2Dic.Location = new System.Drawing.Point(211, 55);
            this.btnAdd2Dic.Name = "btnAdd2Dic";
            this.btnAdd2Dic.Size = new System.Drawing.Size(122, 32);
            this.btnAdd2Dic.TabIndex = 3;
            this.btnAdd2Dic.Text = "Add To Dictionary";
            this.btnAdd2Dic.UseVisualStyleBackColor = true;
            this.btnAdd2Dic.Click += new System.EventHandler(this.btnAdd2Dic_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnPause);
            this.groupBox3.Controls.Add(this.txtStatus);
            this.groupBox3.Controls.Add(this.txtNextTime);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtTime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtStart);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnSequence);
            this.groupBox3.Controls.Add(this.btnRandom);
            this.groupBox3.Controls.Add(this.btnOK);
            this.groupBox3.Controls.Add(this.txtEN);
            this.groupBox3.Location = new System.Drawing.Point(530, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 147);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "背单词";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(324, 99);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(54, 32);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "Stop";
            this.toolTip1.SetToolTip(this.btnStop, "点击停止背单词");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(243, 99);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 32);
            this.btnPause.TabIndex = 17;
            this.btnPause.Text = "Pause";
            this.toolTip1.SetToolTip(this.btnPause, "点击暂停/继续背单词");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(17, 72);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(353, 21);
            this.txtStatus.TabIndex = 16;
            // 
            // txtNextTime
            // 
            this.txtNextTime.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNextTime.Location = new System.Drawing.Point(209, 104);
            this.txtNextTime.Name = "txtNextTime";
            this.txtNextTime.ReadOnly = true;
            this.txtNextTime.Size = new System.Drawing.Size(28, 22);
            this.txtNextTime.TabIndex = 15;
            this.txtNextTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "AutoNext";
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(277, 29);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(28, 22);
            this.txtTime.TabIndex = 13;
            this.txtTime.Text = "5";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(243, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Time";
            // 
            // txtStart
            // 
            this.txtStart.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(188, 28);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(49, 22);
            this.txtStart.TabIndex = 11;
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            this.txtStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start";
            // 
            // btnSequence
            // 
            this.btnSequence.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSequence.Location = new System.Drawing.Point(76, 22);
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Size = new System.Drawing.Size(76, 32);
            this.btnSequence.TabIndex = 9;
            this.btnSequence.Text = "Sequence";
            this.btnSequence.UseVisualStyleBackColor = true;
            this.btnSequence.Click += new System.EventHandler(this.btnSequence_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(6, 22);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(68, 32);
            this.btnRandom.TabIndex = 8;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(311, 21);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtEN
            // 
            this.txtEN.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEN.Location = new System.Drawing.Point(17, 104);
            this.txtEN.Name = "txtEN";
            this.txtEN.ReadOnly = true;
            this.txtEN.Size = new System.Drawing.Size(117, 25);
            this.txtEN.TabIndex = 5;
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCN.Location = new System.Drawing.Point(1039, 187);
            this.txtCN.Multiline = true;
            this.txtCN.Name = "txtCN";
            this.txtCN.ReadOnly = true;
            this.txtCN.Size = new System.Drawing.Size(353, 230);
            this.txtCN.TabIndex = 4;
            this.txtCN.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1061, 399);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(77, 32);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnChn
            // 
            this.btnChn.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChn.Location = new System.Drawing.Point(1023, 437);
            this.btnChn.Name = "btnChn";
            this.btnChn.Size = new System.Drawing.Size(81, 32);
            this.btnChn.TabIndex = 1;
            this.btnChn.Text = "ChnToEng";
            this.btnChn.UseVisualStyleBackColor = true;
            this.btnChn.Visible = false;
            this.btnChn.Click += new System.EventHandler(this.btnChn_Click);
            // 
            // btnEng
            // 
            this.btnEng.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEng.Location = new System.Drawing.Point(1061, 516);
            this.btnEng.Name = "btnEng";
            this.btnEng.Size = new System.Drawing.Size(77, 32);
            this.btnEng.TabIndex = 0;
            this.btnEng.Text = "EngToChn";
            this.btnEng.UseVisualStyleBackColor = true;
            this.btnEng.Visible = false;
            this.btnEng.Click += new System.EventHandler(this.btnEng_Click);
            // 
            // txtDic
            // 
            this.txtDic.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDic.Location = new System.Drawing.Point(69, 20);
            this.txtDic.Name = "txtDic";
            this.txtDic.Size = new System.Drawing.Size(265, 25);
            this.txtDic.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtDic, "双击选择单词库文本");
            this.txtDic.TextChanged += new System.EventHandler(this.txtDic_TextChanged);
            this.txtDic.DoubleClick += new System.EventHandler(this.txtDic_DoubleClick);
            // 
            // txtVoice
            // 
            this.txtVoice.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoice.Location = new System.Drawing.Point(425, 20);
            this.txtVoice.Name = "txtVoice";
            this.txtVoice.Size = new System.Drawing.Size(300, 25);
            this.txtVoice.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtVoice, "双击选择单词库文本");
            this.txtVoice.TextChanged += new System.EventHandler(this.txtVoice_TextChanged);
            this.txtVoice.DoubleClick += new System.EventHandler(this.txtVoice_DoubleClick);
            // 
            // timerNext
            // 
            this.timerNext.Interval = 1000;
            this.timerNext.Tick += new System.EventHandler(this.timerNext_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtVoice);
            this.groupBox4.Controls.Add(this.txtDic);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(172, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 57);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "离线词库语音设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(346, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "离线语音";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "离线词库";
            // 
            // webExplain
            // 
            this.webExplain.Location = new System.Drawing.Point(173, 227);
            this.webExplain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webExplain.Name = "webExplain";
            this.webExplain.Size = new System.Drawing.Size(744, 414);
            this.webExplain.TabIndex = 9;
            // 
            // lstWordList
            // 
            this.lstWordList.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWordList.FormattingEnabled = true;
            this.lstWordList.ItemHeight = 14;
            this.lstWordList.Location = new System.Drawing.Point(6, 15);
            this.lstWordList.Name = "lstWordList";
            this.lstWordList.Size = new System.Drawing.Size(142, 592);
            this.lstWordList.TabIndex = 11;
            this.lstWordList.SelectedIndexChanged += new System.EventHandler(this.lstWordList_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstWordList);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(12, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 633);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "单词列表";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(1039, 475);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 35);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 653);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.webExplain);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEng);
            this.Controls.Add(this.btnChn);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtCN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtInputWord;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd2Dic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChn;
        private System.Windows.Forms.Button btnEng;
        private System.Windows.Forms.TextBox txtEN;
        private System.Windows.Forms.TextBox txtCN;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnRead;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnSequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Timer timerNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNextTime;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVoice;
        private System.Windows.Forms.TextBox txtDic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.WebBrowser webExplain;
        private System.Windows.Forms.ListBox lstWordList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
    }
}

