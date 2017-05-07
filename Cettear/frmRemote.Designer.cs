namespace Cettear
{
	partial class frmRemote
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCaptureRange = new System.Windows.Forms.Button();
			this.btnCaptureOCR = new System.Windows.Forms.Button();
			this.btnCaptureRangeShow = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbLang1_Step2 = new System.Windows.Forms.ComboBox();
			this.cbLang1_Step1 = new System.Windows.Forms.ComboBox();
			this.cbLang1_OCR = new System.Windows.Forms.ComboBox();
			this.chkLang1_Step2 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtHotKey_CaptureOCR = new System.Windows.Forms.TextBox();
			this.txtHotKey_CaptureRangeShow = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtHotKey_CaptureRange = new System.Windows.Forms.TextBox();
			this.chkOCRView = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSelectServiceKeyFile = new System.Windows.Forms.Button();
			this.labApiKeyFileInfo = new System.Windows.Forms.Label();
			this.txtApiKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLang1_Save = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCaptureRange
			// 
			this.btnCaptureRange.Location = new System.Drawing.Point(4, 26);
			this.btnCaptureRange.Name = "btnCaptureRange";
			this.btnCaptureRange.Size = new System.Drawing.Size(135, 23);
			this.btnCaptureRange.TabIndex = 0;
			this.btnCaptureRange.Text = "캡처 범위 지정";
			this.btnCaptureRange.UseVisualStyleBackColor = true;
			this.btnCaptureRange.Click += new System.EventHandler(this.btnCaptureRange_Click);
			// 
			// btnCaptureOCR
			// 
			this.btnCaptureOCR.Location = new System.Drawing.Point(4, 84);
			this.btnCaptureOCR.Name = "btnCaptureOCR";
			this.btnCaptureOCR.Size = new System.Drawing.Size(135, 23);
			this.btnCaptureOCR.TabIndex = 1;
			this.btnCaptureOCR.Text = "캡쳐 && 번역";
			this.btnCaptureOCR.UseVisualStyleBackColor = true;
			this.btnCaptureOCR.Click += new System.EventHandler(this.btnCaptureOCR_Click);
			// 
			// btnCaptureRangeShow
			// 
			this.btnCaptureRangeShow.Location = new System.Drawing.Point(4, 55);
			this.btnCaptureRangeShow.Name = "btnCaptureRangeShow";
			this.btnCaptureRangeShow.Size = new System.Drawing.Size(135, 23);
			this.btnCaptureRangeShow.TabIndex = 4;
			this.btnCaptureRangeShow.Text = "캡쳐 범위 확인";
			this.btnCaptureRangeShow.UseVisualStyleBackColor = true;
			this.btnCaptureRangeShow.Click += new System.EventHandler(this.btnCaptureRangeShow_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(286, 322);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.txtHotKey_CaptureOCR);
			this.tabPage1.Controls.Add(this.txtHotKey_CaptureRangeShow);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtHotKey_CaptureRange);
			this.tabPage1.Controls.Add(this.chkOCRView);
			this.tabPage1.Controls.Add(this.btnCaptureRange);
			this.tabPage1.Controls.Add(this.btnCaptureRangeShow);
			this.tabPage1.Controls.Add(this.btnCaptureOCR);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(278, 296);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "리모콘";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLang1_Save);
			this.groupBox1.Controls.Add(this.cbLang1_Step2);
			this.groupBox1.Controls.Add(this.cbLang1_Step1);
			this.groupBox1.Controls.Add(this.cbLang1_OCR);
			this.groupBox1.Controls.Add(this.chkLang1_Step2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(6, 135);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 100);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "번역 언어 지정";
			// 
			// cbLang1_Step2
			// 
			this.cbLang1_Step2.FormattingEnabled = true;
			this.cbLang1_Step2.Location = new System.Drawing.Point(82, 62);
			this.cbLang1_Step2.Name = "cbLang1_Step2";
			this.cbLang1_Step2.Size = new System.Drawing.Size(121, 20);
			this.cbLang1_Step2.TabIndex = 12;
			// 
			// cbLang1_Step1
			// 
			this.cbLang1_Step1.FormattingEnabled = true;
			this.cbLang1_Step1.Location = new System.Drawing.Point(82, 40);
			this.cbLang1_Step1.Name = "cbLang1_Step1";
			this.cbLang1_Step1.Size = new System.Drawing.Size(121, 20);
			this.cbLang1_Step1.TabIndex = 12;
			// 
			// cbLang1_OCR
			// 
			this.cbLang1_OCR.FormattingEnabled = true;
			this.cbLang1_OCR.Location = new System.Drawing.Point(82, 16);
			this.cbLang1_OCR.Name = "cbLang1_OCR";
			this.cbLang1_OCR.Size = new System.Drawing.Size(121, 20);
			this.cbLang1_OCR.TabIndex = 12;
			// 
			// chkLang1_Step2
			// 
			this.chkLang1_Step2.Location = new System.Drawing.Point(8, 62);
			this.chkLang1_Step2.Name = "chkLang1_Step2";
			this.chkLang1_Step2.Size = new System.Drawing.Size(70, 20);
			this.chkLang1_Step2.TabIndex = 11;
			this.chkLang1_Step2.Text = "2차 언어";
			this.chkLang1_Step2.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "1차 언어";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "감지 언어";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHotKey_CaptureOCR
			// 
			this.txtHotKey_CaptureOCR.Location = new System.Drawing.Point(145, 86);
			this.txtHotKey_CaptureOCR.Name = "txtHotKey_CaptureOCR";
			this.txtHotKey_CaptureOCR.ReadOnly = true;
			this.txtHotKey_CaptureOCR.Size = new System.Drawing.Size(32, 21);
			this.txtHotKey_CaptureOCR.TabIndex = 9;
			this.txtHotKey_CaptureOCR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_CaptureOCR_KeyDown);
			// 
			// txtHotKey_CaptureRangeShow
			// 
			this.txtHotKey_CaptureRangeShow.Location = new System.Drawing.Point(145, 57);
			this.txtHotKey_CaptureRangeShow.Name = "txtHotKey_CaptureRangeShow";
			this.txtHotKey_CaptureRangeShow.ReadOnly = true;
			this.txtHotKey_CaptureRangeShow.Size = new System.Drawing.Size(32, 21);
			this.txtHotKey_CaptureRangeShow.TabIndex = 8;
			this.txtHotKey_CaptureRangeShow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_CaptureRangeShow_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(138, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "단축키";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHotKey_CaptureRange
			// 
			this.txtHotKey_CaptureRange.Location = new System.Drawing.Point(145, 28);
			this.txtHotKey_CaptureRange.Name = "txtHotKey_CaptureRange";
			this.txtHotKey_CaptureRange.ReadOnly = true;
			this.txtHotKey_CaptureRange.Size = new System.Drawing.Size(32, 21);
			this.txtHotKey_CaptureRange.TabIndex = 6;
			this.txtHotKey_CaptureRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_CaptureRange_KeyDown);
			// 
			// chkOCRView
			// 
			this.chkOCRView.AutoSize = true;
			this.chkOCRView.Location = new System.Drawing.Point(4, 113);
			this.chkOCRView.Name = "chkOCRView";
			this.chkOCRView.Size = new System.Drawing.Size(106, 16);
			this.chkOCRView.TabIndex = 5;
			this.chkOCRView.Text = "OCR 같이 표시";
			this.chkOCRView.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSelectServiceKeyFile);
			this.tabPage2.Controls.Add(this.labApiKeyFileInfo);
			this.tabPage2.Controls.Add(this.txtApiKey);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(278, 296);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "API";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnSelectServiceKeyFile
			// 
			this.btnSelectServiceKeyFile.Location = new System.Drawing.Point(226, 47);
			this.btnSelectServiceKeyFile.Name = "btnSelectServiceKeyFile";
			this.btnSelectServiceKeyFile.Size = new System.Drawing.Size(45, 23);
			this.btnSelectServiceKeyFile.TabIndex = 3;
			this.btnSelectServiceKeyFile.Text = "...";
			this.btnSelectServiceKeyFile.UseVisualStyleBackColor = true;
			this.btnSelectServiceKeyFile.Click += new System.EventHandler(this.btnSelectServiceKeyFile_Click);
			// 
			// labApiKeyFileInfo
			// 
			this.labApiKeyFileInfo.Location = new System.Drawing.Point(92, 47);
			this.labApiKeyFileInfo.Name = "labApiKeyFileInfo";
			this.labApiKeyFileInfo.Size = new System.Drawing.Size(128, 23);
			this.labApiKeyFileInfo.TabIndex = 2;
			this.labApiKeyFileInfo.Text = "label3";
			this.labApiKeyFileInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtApiKey
			// 
			this.txtApiKey.Location = new System.Drawing.Point(92, 20);
			this.txtApiKey.Name = "txtApiKey";
			this.txtApiKey.Size = new System.Drawing.Size(180, 21);
			this.txtApiKey.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "API 키 파일";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "API 키";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnLang1_Save
			// 
			this.btnLang1_Save.Location = new System.Drawing.Point(209, 15);
			this.btnLang1_Save.Name = "btnLang1_Save";
			this.btnLang1_Save.Size = new System.Drawing.Size(51, 67);
			this.btnLang1_Save.TabIndex = 13;
			this.btnLang1_Save.Text = "저장";
			this.btnLang1_Save.UseVisualStyleBackColor = true;
			this.btnLang1_Save.Click += new System.EventHandler(this.btnLang1_Save_Click);
			// 
			// frmRemote
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 325);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmRemote";
			this.Text = "리모콘";
			this.Load += new System.EventHandler(this.frmRemote_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCaptureRange;
		private System.Windows.Forms.Button btnCaptureOCR;
		private System.Windows.Forms.Button btnCaptureRangeShow;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtApiKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labApiKeyFileInfo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelectServiceKeyFile;
		private System.Windows.Forms.CheckBox chkOCRView;
		private System.Windows.Forms.TextBox txtHotKey_CaptureRange;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtHotKey_CaptureOCR;
		private System.Windows.Forms.TextBox txtHotKey_CaptureRangeShow;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkLang1_Step2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbLang1_Step2;
		private System.Windows.Forms.ComboBox cbLang1_Step1;
		private System.Windows.Forms.ComboBox cbLang1_OCR;
		private System.Windows.Forms.Button btnLang1_Save;
	}
}

