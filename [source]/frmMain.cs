using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using iTunesLib;

namespace iTuner
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class frmMain : System.Windows.Forms.Form
  {
    HotkeyItem [] hotkeys = new HotkeyItem [0];
    iTunesApp iTunesControl;
    
    #region Class Variables
    
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.NotifyIcon notifyNotifyIcon;
    private System.Windows.Forms.ContextMenu menuTrayMenu;
    private System.Windows.Forms.MenuItem menuTrayMenuPlay;
    private System.Windows.Forms.MenuItem menuTrayMenuPause;
    private System.Windows.Forms.MenuItem menuTrayMenuStop;
    private System.Windows.Forms.MenuItem menuTrayMenuNext;
    private System.Windows.Forms.MenuItem menuTrayMenuPrev;
    private System.Windows.Forms.MenuItem menuTrayMenuSep01;
    private System.Windows.Forms.MenuItem menuTrayMenuExit;
    private System.Windows.Forms.MenuItem menuTrayMenuSep02;
    private System.Windows.Forms.Panel panPopup;
    private System.Windows.Forms.MenuItem menuTrayMenuPreferences;
    private System.Windows.Forms.MenuItem menuTrayMenuShow;
    private System.Windows.Forms.MenuItem menuTrayMenuSep03;
    private System.Windows.Forms.Label lblTrack;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblPlaylist;
    private System.Windows.Forms.PictureBox picArtwork;
    private System.Windows.Forms.Timer timerClose;
    
    #endregion
    
    #region Class Construction
    
    public frmMain ()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      try
      {
        iTunesControl = new iTunesAppClass();
        iTunesControl.OnPlayerPlayingTrackChangedEvent += new _IiTunesEvents_OnPlayerPlayingTrackChangedEventEventHandler(iTunesControl_OnPlayerEvent);
        iTunesControl.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(iTunesControl_OnPlayerEvent);
        iTunesControl.OnPlayerStopEvent += new _IiTunesEvents_OnPlayerStopEventEventHandler(iTunesControl_OnPlayerEvent);
      }
      catch (COMException)
      {
        MessageBox.Show(this, "Could not interface with iTunes. Exiting.", "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        Application.Exit();
        return;
      }
      
      int desktopWidth = Screen.PrimaryScreen.WorkingArea.Width;
      int desktopHeight = Screen.PrimaryScreen.WorkingArea.Height;
      int x = desktopWidth - this.Width;
      int y = desktopHeight - this.Height;
      this.SetDesktopLocation(x,y);
      
      hotkeys = new HotkeyItem [4];
      hotkeys[0] = new HotkeyItem(HotkeyAction.PlayPause, (int)Keys.MediaPlayPause);
      hotkeys[3] = new HotkeyItem(HotkeyAction.Stop, (int)Keys.MediaStop);
      hotkeys[1] = new HotkeyItem(HotkeyAction.NextSong, (int)Keys.MediaNextTrack);
      hotkeys[2] = new HotkeyItem(HotkeyAction.PreviousSong, (int)Keys.MediaPreviousTrack);
      setHotkeys();
    }
    
		#region Windows Form Designer generated code
    
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose (bool disposing)
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
      this.notifyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuTrayMenu = new System.Windows.Forms.ContextMenu();
      this.menuTrayMenuShow = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuSep01 = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuPlay = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuPause = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuStop = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuNext = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuPrev = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuSep02 = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuPreferences = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuSep03 = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuExit = new System.Windows.Forms.MenuItem();
      this.lblAuthor = new System.Windows.Forms.Label();
      this.lblTitle = new System.Windows.Forms.Label();
      this.timerClose = new System.Windows.Forms.Timer(this.components);
      this.panPopup = new System.Windows.Forms.Panel();
      this.picArtwork = new System.Windows.Forms.PictureBox();
      this.lblPlaylist = new System.Windows.Forms.Label();
      this.lblTrack = new System.Windows.Forms.Label();
      this.panPopup.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyNotifyIcon
      // 
      this.notifyNotifyIcon.ContextMenu = this.menuTrayMenu;
      this.notifyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyNotifyIcon.Icon")));
      this.notifyNotifyIcon.Text = "iTuner";
      this.notifyNotifyIcon.Visible = true;
      this.notifyNotifyIcon.DoubleClick += new System.EventHandler(this.notifyNotifyIcon_DoubleClick);
      // 
      // menuTrayMenu
      // 
      this.menuTrayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.menuTrayMenuShow,
                                                                                 this.menuTrayMenuSep01,
                                                                                 this.menuTrayMenuPlay,
                                                                                 this.menuTrayMenuPause,
                                                                                 this.menuTrayMenuStop,
                                                                                 this.menuTrayMenuNext,
                                                                                 this.menuTrayMenuPrev,
                                                                                 this.menuTrayMenuSep02,
                                                                                 this.menuTrayMenuPreferences,
                                                                                 this.menuTrayMenuSep03,
                                                                                 this.menuTrayMenuExit});
      // 
      // menuTrayMenuShow
      // 
      this.menuTrayMenuShow.DefaultItem = true;
      this.menuTrayMenuShow.Index = 0;
      this.menuTrayMenuShow.Text = "Show &iTunes";
      this.menuTrayMenuShow.Click += new System.EventHandler(this.menuTrayMenuShow_Click);
      // 
      // menuTrayMenuSep01
      // 
      this.menuTrayMenuSep01.Index = 1;
      this.menuTrayMenuSep01.Text = "-";
      // 
      // menuTrayMenuPlay
      // 
      this.menuTrayMenuPlay.Index = 2;
      this.menuTrayMenuPlay.Text = "&Play";
      this.menuTrayMenuPlay.Click += new System.EventHandler(this.menuTrayMenuPlay_Click);
      // 
      // menuTrayMenuPause
      // 
      this.menuTrayMenuPause.Index = 3;
      this.menuTrayMenuPause.Text = "P&ause";
      this.menuTrayMenuPause.Click += new System.EventHandler(this.menuTrayMenuPause_Click);
      // 
      // menuTrayMenuStop
      // 
      this.menuTrayMenuStop.Index = 4;
      this.menuTrayMenuStop.Text = "&Stop";
      this.menuTrayMenuStop.Click += new System.EventHandler(this.menuTrayMenuStop_Click);
      // 
      // menuTrayMenuNext
      // 
      this.menuTrayMenuNext.Index = 5;
      this.menuTrayMenuNext.Text = "&Next Song";
      this.menuTrayMenuNext.Click += new System.EventHandler(this.menuTrayMenuNext_Click);
      // 
      // menuTrayMenuPrev
      // 
      this.menuTrayMenuPrev.Index = 6;
      this.menuTrayMenuPrev.Text = "P&revious Song";
      this.menuTrayMenuPrev.Click += new System.EventHandler(this.menuTrayMenuPrev_Click);
      // 
      // menuTrayMenuSep02
      // 
      this.menuTrayMenuSep02.Index = 7;
      this.menuTrayMenuSep02.Text = "-";
      // 
      // menuTrayMenuPreferences
      // 
      this.menuTrayMenuPreferences.Index = 8;
      this.menuTrayMenuPreferences.Text = "Pre&ferences...";
      this.menuTrayMenuPreferences.Click += new System.EventHandler(this.menuTrayMenuPreferences_Click);
      // 
      // menuTrayMenuSep03
      // 
      this.menuTrayMenuSep03.Index = 9;
      this.menuTrayMenuSep03.Text = "-";
      // 
      // menuTrayMenuExit
      // 
      this.menuTrayMenuExit.Index = 10;
      this.menuTrayMenuExit.Text = "E&xit";
      this.menuTrayMenuExit.Click += new System.EventHandler(this.menuTrayMenuExit_Click);
      // 
      // lblAuthor
      // 
      this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblAuthor.Location = new System.Drawing.Point(0, 44);
      this.lblAuthor.Name = "lblAuthor";
      this.lblAuthor.Size = new System.Drawing.Size(314, 15);
      this.lblAuthor.TabIndex = 0;
      this.lblAuthor.Text = "Artist";
      this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblAuthor.Click += new System.EventHandler(this.m_ArtistLabel_Click);
      // 
      // lblTitle
      // 
      this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTitle.Location = new System.Drawing.Point(0, 24);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(314, 15);
      this.lblTitle.TabIndex = 1;
      this.lblTitle.Text = "Title (Time)";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblTitle.Click += new System.EventHandler(this.m_TitleLabel_Click);
      // 
      // timerClose
      // 
      this.timerClose.Interval = 10000;
      this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
      // 
      // panPopup
      // 
      this.panPopup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panPopup.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.picArtwork,
                                                                           this.lblPlaylist,
                                                                           this.lblTrack,
                                                                           this.lblTitle,
                                                                           this.lblAuthor});
      this.panPopup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panPopup.Name = "panPopup";
      this.panPopup.Size = new System.Drawing.Size(316, 64);
      this.panPopup.TabIndex = 2;
      this.panPopup.Click += new System.EventHandler(this.panPopup_Click);
      // 
      // picArtwork
      // 
      this.picArtwork.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left);
      this.picArtwork.BackColor = System.Drawing.Color.White;
      this.picArtwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picArtwork.Location = new System.Drawing.Point(4, 20);
      this.picArtwork.Name = "picArtwork";
      this.picArtwork.Size = new System.Drawing.Size(38, 38);
      this.picArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picArtwork.TabIndex = 3;
      this.picArtwork.TabStop = false;
      this.picArtwork.Click += new System.EventHandler(this.picArtwork_Click);
      this.picArtwork.SizeChanged += new System.EventHandler(this.picArtwork_SizeChanged);
      // 
      // lblPlaylist
      // 
      this.lblPlaylist.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.lblPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblPlaylist.Location = new System.Drawing.Point(160, 4);
      this.lblPlaylist.Name = "lblPlaylist";
      this.lblPlaylist.Size = new System.Drawing.Size(152, 13);
      this.lblPlaylist.TabIndex = 2;
      this.lblPlaylist.Text = "Status";
      this.lblPlaylist.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lblTrack
      // 
      this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTrack.Location = new System.Drawing.Point(4, 4);
      this.lblTrack.Name = "lblTrack";
      this.lblTrack.Size = new System.Drawing.Size(148, 15);
      this.lblTrack.TabIndex = 0;
      this.lblTrack.Text = "Track/Total";
      // 
      // frmMain
      // 
      this.AutoScale = false;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(316, 64);
      this.ControlBox = false;
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.panPopup});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMain";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "iTunes Control";
      this.TopMost = true;
      this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
      this.panPopup.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		
    #endregion
    
    #endregion
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main () 
    {
      frmMain form = new frmMain();
      Application.Run();
    }
    
    #region Menu Events
    
    private void menuTrayMenuShow_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.BrowserWindow.Visible = true;
      }
      catch (COMException)
      {
      }
    }
    
    private void menuTrayMenuPlay_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.Play();
      }
      catch (COMException)
      {
      }
    }
    
    private void menuTrayMenuPause_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.Pause();
      }
      catch(COMException)
      {
      }
    }
    
    private void menuTrayMenuStop_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.Stop();
      }
      catch(COMException)
      {
      }
    }
    
    private void menuTrayMenuNext_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.NextTrack();
      }
      catch(COMException)
      {
      }
    }
    
    private void menuTrayMenuPrev_Click (object sender, System.EventArgs e)
    {
      try
      {
        iTunesControl.PreviousTrack();
				
      }
      catch (COMException)
      {
      }
    }

    private void menuTrayMenuPreferences_Click (object sender, System.EventArgs e)
    {
      doPreferences();
    }
    
    private void menuTrayMenuExit_Click (object sender, System.EventArgs e)
    {
      clearHotkeys();
      notifyNotifyIcon.Visible = false;
      this.Close();
      Application.Exit();
    }
    
    #endregion
    
    private void picArtwork_SizeChanged (object sender, System.EventArgs e)
    { if (picArtwork.Width != picArtwork.Height) picArtwork.Width = picArtwork.Height; }
    
    private void m_TitleLabel_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void m_ArtistLabel_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void panPopup_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void picArtwork_Click(object sender, System.EventArgs e)
    { doHide(); }
    
    private void iTunesControl_OnPlayerEvent (object iTrack)
    {
      IITTrack track = (IITTrack)iTrack;
      
      if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStateStopped)
      {
        picArtwork.Visible = false;
        lblTitle.Left = 0;
        lblAuthor.Left = 0;
        lblTitle.Width = panPopup.ClientSize.Width-lblTitle.Left;
        lblAuthor.Width = panPopup.ClientSize.Width-lblAuthor.Left;
        if (iTunesControl.PlayerPosition != 0) return;
        lblTrack.Text = "";
        lblPlaylist.Text = "";
        lblTitle.Text = "";
        lblAuthor.Text = "Playback Stopped";
      }
      else
      {
        if ((track.Artwork != null) && (track.Artwork.Count >= 1))
        {
          picArtwork.Visible = true;
          // Fetch artwork belonging to currently playing track
          // Extract artwork and save to folder.jpg file
          // Note: SaveArtworkToFile needs fully qualified path
          // Note: Track.Artwork is 1-indexed.
          string path = Path.GetTempFileName();
          IITArtwork art = track.Artwork[1];
          art.SaveArtworkToFile(path);
          // Read file to memory
          MemoryStream ms = new MemoryStream();
          FileStream fs = new FileStream(path, FileMode.Open);
          byte[] buffer = new byte[fs.Length];
          fs.Read(buffer, 0, (int)fs.Length);
          ms.Write(buffer, 0, buffer.Length);
          ms.Seek(0, SeekOrigin.Begin);
          fs.Close();
          File.Delete(path);
          picArtwork.Image = Image.FromStream(ms);
          lblTitle.Left = picArtwork.Right + 4;
          lblAuthor.Left = picArtwork.Right + 4;
          lblTitle.Width = panPopup.ClientSize.Width-lblTitle.Left;
          lblAuthor.Width = panPopup.ClientSize.Width-lblAuthor.Left;
        }
        else
        {
          picArtwork.Visible = false;
          lblTitle.Left = 0;
          lblAuthor.Left = 0;
          lblTitle.Width = panPopup.ClientSize.Width-lblTitle.Left;
          lblAuthor.Width = panPopup.ClientSize.Width-lblAuthor.Left;
        }
        
        lblTrack.Text = String.Format("{0}/{1}", track.PlayOrderIndex, track.Playlist.Tracks.Count);
        lblPlaylist.Text = track.Playlist.Name;
        lblTitle.Text = String.Format("{0} ({1})", track.Name, track.Time);
        lblAuthor.Text = track.Artist;
        notifyNotifyIcon.Text = String.Format("{0} - {1}", track.Artist, track.Name);
      }
      
      doShow();
    }
    
    private void timerClose_Tick (object sender, System.EventArgs e)
    { doHide(); }
    
    private void notifyNotifyIcon_DoubleClick (object sender, System.EventArgs e)
    {
      iTunesControl.BrowserWindow.Visible = true;
    }
    
    private void frmMain_VisibleChanged (object sender, System.EventArgs e)
    {
      if (this.Visible)
        timerClose.Start();
      else
        timerClose.Stop();
    }
    
    void setHotkeys ()
    {
      clearHotkeys();
      for (int i = 0; i < hotkeys.Length; i++)
      {
        if (hotkeys[i].KeyValue == 0) continue;
        string atomName = "iTuner.Hotkey." + hotkeys[i].Action.ToString() + ":" + i.ToString();
        int result = 0;
        hotkeys[i].Atom = Win32.GlobalAddAtom(atomName);
        if (hotkeys[i].Atom != 0) result = Win32.RegisterHotKey(this.Handle, hotkeys[i].Atom, hotkeys[i].Modifiers, hotkeys[i].KeyValue);
        if (result == 0) MessageBox.Show(this, "Could not register hotkey: " + hotkeys[i].Action.ToString(), "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    void clearHotkeys ()
    {
      for (int i = 0; i < hotkeys.Length; i++)
      {
        Win32.UnregisterHotKey(this.Handle, hotkeys[i].Atom);
        Win32.GlobalDeleteAtom(hotkeys[i].Atom);
        hotkeys[i].Atom = 0;
      }
    }
    
    void doShow ()
    {
      if (!this.Visible)
      {
        Win32.ShowWindow(this.Handle, Win32.ShowWindowCommands.ShowNoActivate);
        this.Visible = true;
      }
      else
      {
        this.Refresh();
      }
    }
    void doHide ()
    {
      if (this.Visible)
      {
        Win32.AnimateWindow(this.Handle, 1000, Win32.AnimateStyles.Hide | Win32.AnimateStyles.Blend);
        this.Visible = false;
      }
    }
    
    void doPreferences ()
    {
      clearHotkeys();
      frmPreferences form = new frmPreferences();
      form.Hotkeys = hotkeys;
      if (form.ShowDialog() == DialogResult.OK)
      {
        // Set results
        hotkeys = form.Hotkeys;
      }
      setHotkeys();
    }
    
    protected override void WndProc (ref Message m)
    {
      switch (m.Msg)
      {
        case Win32.WM_HOTKEY:
        {
          int key = ((int)m.LParam) >> 16;
          for (int i = 0; i < hotkeys.Length; i++)
          {
            if (key != hotkeys[i].KeyValue) continue;
            switch (hotkeys[i].Action)
            {
              case HotkeyAction.ShowBrowser: iTunesControl.BrowserWindow.Visible = true; break;
              case HotkeyAction.Play: iTunesControl.Play(); break;
              case HotkeyAction.PlayPause: iTunesControl.PlayPause(); break;
              case HotkeyAction.Stop: iTunesControl.Stop(); break;
              case HotkeyAction.NextSong: iTunesControl.NextTrack(); break;
              case HotkeyAction.PreviousSong: iTunesControl.PreviousTrack(); break;
            }
          }
          break;
        }
        default:
        {
          base.WndProc(ref m);
          break;
        }
      }
    }
  }
}
