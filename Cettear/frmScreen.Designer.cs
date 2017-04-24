namespace Cettear
{
	partial class frmScreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnComplete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnComplete
			// 
			this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnComplete.Location = new System.Drawing.Point(437, 12);
			this.btnComplete.Name = "btnComplete";
			this.btnComplete.Size = new System.Drawing.Size(75, 23);
			this.btnComplete.TabIndex = 0;
			this.btnComplete.Text = "완료";
			this.btnComplete.UseVisualStyleBackColor = true;
			this.btnComplete.Visible = false;
			this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
			// 
			// frmScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(524, 429);
			this.Controls.Add(this.btnComplete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmScreen";
			this.Text = "자막 표시 윈도우";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			this.Load += new System.EventHandler(this.frmScreen_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmScreen_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmScreen_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmScreen_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnComplete;
	}
}