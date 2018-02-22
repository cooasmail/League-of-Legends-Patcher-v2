namespace Patcher2.Forms
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
            this.components = new System.ComponentModel.Container();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.zoomOutCbox = new System.Windows.Forms.CheckBox();
            this.zoomInCbox = new System.Windows.Forms.CheckBox();
            this.oomCbox = new System.Windows.Forms.CheckBox();
            this.fovCbox = new System.Windows.Forms.CheckBox();
            this.backupBtn = new System.Windows.Forms.Button();
            this.patchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.animationPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // animationPanel
            // 
            this.animationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.animationPanel.Controls.Add(this.groupBox1);
            this.animationPanel.Controls.Add(this.backupBtn);
            this.animationPanel.Controls.Add(this.patchBtn);
            this.animationPanel.Controls.Add(this.label2);
            this.animationPanel.Controls.Add(this.label1);
            this.animationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.animationPanel.ForeColor = System.Drawing.Color.White;
            this.animationPanel.Location = new System.Drawing.Point(0, 0);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(487, 203);
            this.animationPanel.TabIndex = 0;
            this.animationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.animationPanel_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zoomOutCbox);
            this.groupBox1.Controls.Add(this.zoomInCbox);
            this.groupBox1.Controls.Add(this.oomCbox);
            this.groupBox1.Controls.Add(this.fovCbox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(253, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features";
            // 
            // zoomOutCbox
            // 
            this.zoomOutCbox.AutoSize = true;
            this.zoomOutCbox.Checked = true;
            this.zoomOutCbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomOutCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoomOutCbox.Location = new System.Drawing.Point(15, 21);
            this.zoomOutCbox.Name = "zoomOutCbox";
            this.zoomOutCbox.Size = new System.Drawing.Size(118, 19);
            this.zoomOutCbox.TabIndex = 3;
            this.zoomOutCbox.Text = "ZoomHack (max)";
            this.zoomOutCbox.UseVisualStyleBackColor = true;
            // 
            // zoomInCbox
            // 
            this.zoomInCbox.AutoSize = true;
            this.zoomInCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zoomInCbox.Location = new System.Drawing.Point(15, 46);
            this.zoomInCbox.Name = "zoomInCbox";
            this.zoomInCbox.Size = new System.Drawing.Size(117, 19);
            this.zoomInCbox.TabIndex = 4;
            this.zoomInCbox.Text = "ZoomHack (min)";
            this.zoomInCbox.UseVisualStyleBackColor = true;
            // 
            // oomCbox
            // 
            this.oomCbox.AutoSize = true;
            this.oomCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oomCbox.Location = new System.Drawing.Point(15, 71);
            this.oomCbox.Name = "oomCbox";
            this.oomCbox.Size = new System.Drawing.Size(55, 19);
            this.oomCbox.TabIndex = 5;
            this.oomCbox.Text = "OOM";
            this.oomCbox.UseVisualStyleBackColor = true;
            // 
            // fovCbox
            // 
            this.fovCbox.AutoSize = true;
            this.fovCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fovCbox.Location = new System.Drawing.Point(15, 96);
            this.fovCbox.Name = "fovCbox";
            this.fovCbox.Size = new System.Drawing.Size(96, 19);
            this.fovCbox.TabIndex = 6;
            this.fovCbox.Text = "FOV Changer";
            this.fovCbox.UseVisualStyleBackColor = true;
            // 
            // backupBtn
            // 
            this.backupBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.backupBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backupBtn.Location = new System.Drawing.Point(30, 143);
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.Size = new System.Drawing.Size(194, 26);
            this.backupBtn.TabIndex = 9;
            this.backupBtn.Text = "RESTORE BACKUP";
            this.backupBtn.UseVisualStyleBackColor = false;
            this.backupBtn.Click += new System.EventHandler(this.backupBtn_Click);
            // 
            // patchBtn
            // 
            this.patchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.patchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patchBtn.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.patchBtn.Location = new System.Drawing.Point(30, 97);
            this.patchBtn.Name = "patchBtn";
            this.patchBtn.Size = new System.Drawing.Size(194, 40);
            this.patchBtn.TabIndex = 8;
            this.patchBtn.Text = "PATCH";
            this.patchBtn.UseVisualStyleBackColor = false;
            this.patchBtn.Click += new System.EventHandler(this.patchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Created by Zaczero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(65, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patcher v2";
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 20;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 203);
            this.Controls.Add(this.animationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.animationPanel.ResumeLayout(false);
            this.animationPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel animationPanel;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox zoomOutCbox;
        private System.Windows.Forms.CheckBox fovCbox;
        private System.Windows.Forms.CheckBox oomCbox;
        private System.Windows.Forms.CheckBox zoomInCbox;
        private System.Windows.Forms.Button patchBtn;
        private System.Windows.Forms.Button backupBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}