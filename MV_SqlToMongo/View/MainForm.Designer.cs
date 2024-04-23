namespace MV_SqlToMongo.View
{
    partial class MainForm
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
            btnChuyenDuLieu = new Button();
            SuspendLayout();
            // 
            // btnChuyenDuLieu
            // 
            btnChuyenDuLieu.Location = new Point(150, 100);
            btnChuyenDuLieu.Name = "btnChuyenDuLieu";
            btnChuyenDuLieu.Size = new Size(284, 64);
            btnChuyenDuLieu.TabIndex = 0;
            btnChuyenDuLieu.Text = "Chuyển dữ liệu";
            btnChuyenDuLieu.UseMnemonic = false;
            btnChuyenDuLieu.UseVisualStyleBackColor = true;
            btnChuyenDuLieu.Click += btnChuyenDuLieu_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 287);
            Controls.Add(btnChuyenDuLieu);
            Name = "MainForm";
            Text = "Minv SQL To Mongo";
            ResumeLayout(false);
        }

        #endregion

        private Button btnChuyenDuLieu;
    }
}