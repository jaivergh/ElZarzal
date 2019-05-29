namespace ReportesElZarzal
{
	partial class OrdenDeProduccionForm
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
			this.OrdenProduccionReport1 = new ReportesElZarzal.OrdenProduccionReport();
			this.RecuperarButton = new System.Windows.Forms.Button();
			this.NumOPTxtBox = new System.Windows.Forms.TextBox();
			this.OrdenLabel = new System.Windows.Forms.Label();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// RecuperarButton
			// 
			this.RecuperarButton.Location = new System.Drawing.Point(195, 25);
			this.RecuperarButton.Name = "RecuperarButton";
			this.RecuperarButton.Size = new System.Drawing.Size(75, 23);
			this.RecuperarButton.TabIndex = 1;
			this.RecuperarButton.Text = "Recuperar";
			this.RecuperarButton.UseVisualStyleBackColor = true;
			this.RecuperarButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// NumOPTxtBox
			// 
			this.NumOPTxtBox.Location = new System.Drawing.Point(89, 25);
			this.NumOPTxtBox.Name = "NumOPTxtBox";
			this.NumOPTxtBox.Size = new System.Drawing.Size(100, 20);
			this.NumOPTxtBox.TabIndex = 2;
			// 
			// OrdenLabel
			// 
			this.OrdenLabel.AutoSize = true;
			this.OrdenLabel.Location = new System.Drawing.Point(32, 25);
			this.OrdenLabel.Name = "OrdenLabel";
			this.OrdenLabel.Size = new System.Drawing.Size(39, 13);
			this.OrdenLabel.TabIndex = 3;
			this.OrdenLabel.Text = "Orden:";
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.AutoSize = true;
			this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.crystalReportViewer1.Location = new System.Drawing.Point(12, 64);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.Size = new System.Drawing.Size(893, 623);
			this.crystalReportViewer1.TabIndex = 4;
			this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			// 
			// OrdenDeProduccionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(917, 699);
			this.Controls.Add(this.crystalReportViewer1);
			this.Controls.Add(this.OrdenLabel);
			this.Controls.Add(this.NumOPTxtBox);
			this.Controls.Add(this.RecuperarButton);
			this.Name = "OrdenDeProduccionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OrdenDeProduccionForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private OrdenProduccionReport OrdenProduccionReport1;
		private System.Windows.Forms.Button RecuperarButton;
		private System.Windows.Forms.TextBox NumOPTxtBox;
		private System.Windows.Forms.Label OrdenLabel;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
	}
}