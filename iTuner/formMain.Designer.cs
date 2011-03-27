namespace iTuner
{
  partial class formMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.showITunesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToITunesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.disconnectFromITunesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nextTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.previousTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.stopAfterCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.radioLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuNotifyIcon.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.BalloonTipText = "Hi";
      this.notifyIcon.ContextMenuStrip = this.menuNotifyIcon;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "iTuner";
      this.notifyIcon.Visible = true;
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
      // 
      // menuNotifyIcon
      // 
      this.menuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showITunesToolStripMenuItem,
            this.connectToITunesToolStripMenuItem,
            this.disconnectFromITunesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextTrackToolStripMenuItem,
            this.previousTrackToolStripMenuItem,
            this.toolStripMenuItem2,
            this.stopAfterCurrentToolStripMenuItem,
            this.toolStripMenuItem3,
            this.preferencesToolStripMenuItem,
            this.radioLogToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
      this.menuNotifyIcon.Name = "menuNotifyIcon";
      this.menuNotifyIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.menuNotifyIcon.Size = new System.Drawing.Size(197, 314);
      this.menuNotifyIcon.Opening += new System.ComponentModel.CancelEventHandler(this.menuNotifyIcon_Opening);
      // 
      // showITunesToolStripMenuItem
      // 
      this.showITunesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.showITunesToolStripMenuItem.Name = "showITunesToolStripMenuItem";
      this.showITunesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.showITunesToolStripMenuItem.Text = "&Show iTunes";
      this.showITunesToolStripMenuItem.Click += new System.EventHandler(this.showITunesToolStripMenuItem_Click);
      // 
      // connectToITunesToolStripMenuItem
      // 
      this.connectToITunesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.connectToITunesToolStripMenuItem.Name = "connectToITunesToolStripMenuItem";
      this.connectToITunesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.connectToITunesToolStripMenuItem.Text = "&Connect to iTunes";
      this.connectToITunesToolStripMenuItem.Click += new System.EventHandler(this.connectToITunesToolStripMenuItem_Click);
      // 
      // disconnectFromITunesToolStripMenuItem
      // 
      this.disconnectFromITunesToolStripMenuItem.Name = "disconnectFromITunesToolStripMenuItem";
      this.disconnectFromITunesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.disconnectFromITunesToolStripMenuItem.Text = "Dis&connect from iTunes";
      this.disconnectFromITunesToolStripMenuItem.Click += new System.EventHandler(this.disconnectFromITunesToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
      // 
      // playToolStripMenuItem
      // 
      this.playToolStripMenuItem.Name = "playToolStripMenuItem";
      this.playToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.playToolStripMenuItem.Text = "&Play";
      this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
      // 
      // pauseToolStripMenuItem
      // 
      this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
      this.pauseToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.pauseToolStripMenuItem.Text = "Paus&e";
      this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
      // 
      // stopToolStripMenuItem
      // 
      this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
      this.stopToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.stopToolStripMenuItem.Text = "&Stop";
      this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
      // 
      // nextTrackToolStripMenuItem
      // 
      this.nextTrackToolStripMenuItem.Name = "nextTrackToolStripMenuItem";
      this.nextTrackToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.nextTrackToolStripMenuItem.Text = "&Next Track";
      this.nextTrackToolStripMenuItem.Click += new System.EventHandler(this.nextTrackToolStripMenuItem_Click);
      // 
      // previousTrackToolStripMenuItem
      // 
      this.previousTrackToolStripMenuItem.Name = "previousTrackToolStripMenuItem";
      this.previousTrackToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.previousTrackToolStripMenuItem.Text = "P&revious Track";
      this.previousTrackToolStripMenuItem.Click += new System.EventHandler(this.previousTrackToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
      // 
      // stopAfterCurrentToolStripMenuItem
      // 
      this.stopAfterCurrentToolStripMenuItem.Name = "stopAfterCurrentToolStripMenuItem";
      this.stopAfterCurrentToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.stopAfterCurrentToolStripMenuItem.Text = "Stop After Curren&t";
      this.stopAfterCurrentToolStripMenuItem.Click += new System.EventHandler(this.stopAfterCurrentToolStripMenuItem_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
      // 
      // preferencesToolStripMenuItem
      // 
      this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
      this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.preferencesToolStripMenuItem.Text = "Pre&ferences...";
      this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
      // 
      // radioLogToolStripMenuItem
      // 
      this.radioLogToolStripMenuItem.Name = "radioLogToolStripMenuItem";
      this.radioLogToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.radioLogToolStripMenuItem.Text = "&Radio Log...";
      this.radioLogToolStripMenuItem.Click += new System.EventHandler(this.radioLogToolStripMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(193, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // formMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(162, 128);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "formMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "iTuner";
      this.menuNotifyIcon.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip menuNotifyIcon;
    private System.Windows.Forms.ToolStripMenuItem showITunesToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nextTrackToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem previousTrackToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem stopAfterCurrentToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem radioLogToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem connectToITunesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem disconnectFromITunesToolStripMenuItem;
  }
}

