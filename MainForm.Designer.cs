namespace WordCloudMigration
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.FilePathDisplay = new System.Windows.Forms.TextBox();
            this.BroswerButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MigrationProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.TimeConsume = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeConsumeTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库文件：";
            // 
            // FilePathDisplay
            // 
            this.FilePathDisplay.Location = new System.Drawing.Point(141, 38);
            this.FilePathDisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilePathDisplay.Name = "FilePathDisplay";
            this.FilePathDisplay.Size = new System.Drawing.Size(505, 31);
            this.FilePathDisplay.TabIndex = 1;
            // 
            // BroswerButton
            // 
            this.BroswerButton.Location = new System.Drawing.Point(654, 36);
            this.BroswerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BroswerButton.Name = "BroswerButton";
            this.BroswerButton.Size = new System.Drawing.Size(109, 35);
            this.BroswerButton.TabIndex = 2;
            this.BroswerButton.Text = "浏览";
            this.BroswerButton.UseVisualStyleBackColor = true;
            this.BroswerButton.Click += new System.EventHandler(this.BroswerButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(141, 77);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 36);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "开始";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressStatus,
            this.MigrationProgress,
            this.TimeConsume});
            this.statusStrip1.Location = new System.Drawing.Point(0, 153);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(787, 31);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressStatus
            // 
            this.ProgressStatus.Name = "ProgressStatus";
            this.ProgressStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ProgressStatus.Size = new System.Drawing.Size(78, 24);
            this.ProgressStatus.Text = "空闲...";
            // 
            // MigrationProgress
            // 
            this.MigrationProgress.Name = "MigrationProgress";
            this.MigrationProgress.Size = new System.Drawing.Size(122, 23);
            // 
            // TimeConsume
            // 
            this.TimeConsume.Name = "TimeConsume";
            this.TimeConsume.Size = new System.Drawing.Size(0, 24);
            // 
            // TimeConsumeTimer
            // 
            this.TimeConsumeTimer.Tick += new System.EventHandler(this.TimeConsumeTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 184);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BroswerButton);
            this.Controls.Add(this.FilePathDisplay);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库迁移";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilePathDisplay;
        private System.Windows.Forms.Button BroswerButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ProgressStatus;
        private System.Windows.Forms.ToolStripProgressBar MigrationProgress;
        private System.Windows.Forms.ToolStripStatusLabel TimeConsume;
        private System.Windows.Forms.Timer TimeConsumeTimer;
    }
}

