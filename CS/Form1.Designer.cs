namespace Q135913 {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl2)).BeginInit();
			this.SuspendLayout();
			// 
			// pivotGridControl1
			// 
			this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
			this.pivotGridControl1.Location = new System.Drawing.Point(13, 13);
			this.pivotGridControl1.Name = "pivotGridControl1";
			this.pivotGridControl1.Size = new System.Drawing.Size(400, 200);
			this.pivotGridControl1.TabIndex = 0;
			// 
			// pivotGridControl2
			// 
			this.pivotGridControl2.Cursor = System.Windows.Forms.Cursors.Default;
			this.pivotGridControl2.Location = new System.Drawing.Point(13, 219);
			this.pivotGridControl2.Name = "pivotGridControl2";
			this.pivotGridControl2.Size = new System.Drawing.Size(400, 200);
			this.pivotGridControl2.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 432);
			this.Controls.Add(this.pivotGridControl2);
			this.Controls.Add(this.pivotGridControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
		private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl2;
	}
}

