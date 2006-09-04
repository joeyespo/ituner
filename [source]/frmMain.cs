using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
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
    readonly Size DefaultNotifySize = new Size(324, 98);
    HotkeyItem [] hotkeys = new HotkeyItem [0];
    iTunesApp iTunesControl;
    bool stopAfterCurrent = false;
    Image currentArtwork = null;
    Bitmap backbuffer = null;
    Font fontStatus = new Font("Arial", 8, FontStyle.Regular);
    Font fontTitle = new Font("Arial", 10, FontStyle.Bold);
    Font fontAuthor = new Font("Arial", 10, FontStyle.Regular);
    Thread artworkThread = null;
    IITTrack artworkTrack = null;
    
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
    private System.Windows.Forms.MenuItem menuTrayMenuPreferences;
    private System.Windows.Forms.MenuItem menuTrayMenuShow;
    private System.Windows.Forms.MenuItem menuTrayMenuSep03;
    private System.Windows.Forms.MenuItem menuTrayMenuStopAfterCurrent;
    private System.Windows.Forms.MenuItem menuTrayMenuSep04;
    private System.Windows.Forms.MenuItem menuTrayMenuAbout;
    private System.Windows.Forms.Timer timerClose;
    
    #endregion
    
    #region Class Construction
    
    public frmMain ()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
      this.Size = DefaultNotifySize;
      
      try
      {
        iTunesControl = new iTunesAppClass();
        iTunesControl.OnPlayerPlayingTrackChangedEvent += new _IiTunesEvents_OnPlayerPlayingTrackChangedEventEventHandler(iTunesControl_OnTrackChangedEvent);
        iTunesControl.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(iTunesControl_OnPlayEvent);
        iTunesControl.OnPlayerStopEvent += new _IiTunesEvents_OnPlayerStopEventEventHandler(iTunesControl_OnStopEvent);
        iTunesControl.BrowserWindow.Visible = true;
      }
      catch (COMException)
      {
        MessageBox.Show(this, "Could not interface with iTunes. Exiting.", "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        Application.Exit();
        return;
      }
      
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.Opaque, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      backbuffer = new Bitmap(DefaultNotifySize.Width, DefaultNotifySize.Height, PixelFormat.Format32bppRgb);
      renderClear();
      
      int desktopWidth = Screen.PrimaryScreen.WorkingArea.Width;
      int desktopHeight = Screen.PrimaryScreen.WorkingArea.Height;
      int x = desktopWidth - this.Width;
      int y = desktopHeight - this.Height;
      this.SetDesktopLocation(x,y);
      
      hotkeys = new HotkeyItem [5];
      hotkeys[0] = new HotkeyItem(HotkeyAction.PlayPause, (int)Keys.MediaPlayPause);
      hotkeys[1] = new HotkeyItem(HotkeyAction.Stop, (int)Keys.MediaStop);
      hotkeys[2] = new HotkeyItem(HotkeyAction.NextSong, (int)Keys.MediaNextTrack);
      hotkeys[3] = new HotkeyItem(HotkeyAction.PreviousSong, (int)Keys.MediaPreviousTrack);
      hotkeys[4] = new HotkeyItem(HotkeyAction.ToggleStopAfterCurrent, (int)Keys.MediaStop, Win32.MOD_CONTROL);
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
      this.menuTrayMenuStopAfterCurrent = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuSep03 = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuPreferences = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuAbout = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuSep04 = new System.Windows.Forms.MenuItem();
      this.menuTrayMenuExit = new System.Windows.Forms.MenuItem();
      this.timerClose = new System.Windows.Forms.Timer(this.components);
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
                                                                                 this.menuTrayMenuStopAfterCurrent,
                                                                                 this.menuTrayMenuSep03,
                                                                                 this.menuTrayMenuPreferences,
                                                                                 this.menuTrayMenuAbout,
                                                                                 this.menuTrayMenuSep04,
                                                                                 this.menuTrayMenuExit});
      this.menuTrayMenu.Popup += new System.EventHandler(this.menuTrayMenu_Popup);
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
      // menuTrayMenuStopAfterCurrent
      // 
      this.menuTrayMenuStopAfterCurrent.Index = 8;
      this.menuTrayMenuStopAfterCurrent.Text = "Stop After &Current";
      this.menuTrayMenuStopAfterCurrent.Click += new System.EventHandler(this.menuTrayMenuStopAfterCurrent_Click);
      // 
      // menuTrayMenuSep03
      // 
      this.menuTrayMenuSep03.Index = 9;
      this.menuTrayMenuSep03.Text = "-";
      // 
      // menuTrayMenuPreferences
      // 
      this.menuTrayMenuPreferences.Index = 10;
      this.menuTrayMenuPreferences.Text = "Pre&ferences...";
      this.menuTrayMenuPreferences.Click += new System.EventHandler(this.menuTrayMenuPreferences_Click);
      // 
      // menuTrayMenuAbout
      // 
      this.menuTrayMenuAbout.Index = 11;
      this.menuTrayMenuAbout.Text = "&About...";
      this.menuTrayMenuAbout.Click += new System.EventHandler(this.menuTrayMenuAbout_Click);
      // 
      // menuTrayMenuSep04
      // 
      this.menuTrayMenuSep04.Index = 12;
      this.menuTrayMenuSep04.Text = "-";
      // 
      // menuTrayMenuExit
      // 
      this.menuTrayMenuExit.Index = 13;
      this.menuTrayMenuExit.Text = "E&xit";
      this.menuTrayMenuExit.Click += new System.EventHandler(this.menuTrayMenuExit_Click);
      // 
      // timerClose
      // 
      this.timerClose.Interval = 10000;
      this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
      // 
      // frmMain
      // 
      this.AutoScale = false;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.BackColor = System.Drawing.Color.AliceBlue;
      this.ClientSize = new System.Drawing.Size(316, 64);
      this.ControlBox = false;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMain";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "iTunes Control";
      this.TopMost = true;
      this.Click += new System.EventHandler(this.frmMain_Click);
      this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);

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
    
    private void menuTrayMenu_Popup (object sender, System.EventArgs e)
    {
      menuTrayMenuStopAfterCurrent.Checked = stopAfterCurrent;
    }
    
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
      doNextTrack();
    }
    
    private void menuTrayMenuPrev_Click (object sender, System.EventArgs e)
    {
      doPreviousTrack();
    }
    
    private void menuTrayMenuStopAfterCurrent_Click(object sender, System.EventArgs e)
    {
      stopAfterCurrent = !stopAfterCurrent;
    }
    
    private void menuTrayMenuPreferences_Click (object sender, System.EventArgs e)
    {
      doPreferences();
    }
    private void menuTrayMenuAbout_Click (object sender, System.EventArgs e)
    { doAbout(); }
    
    private void menuTrayMenuExit_Click (object sender, System.EventArgs e)
    {
      clearHotkeys();
      notifyNotifyIcon.Visible = false;
      this.Close();
      Application.Exit();
    }
    
    #endregion
    
    #region Control Events
    
    private void frmMain_Click(object sender, System.EventArgs e)
    { doHide(); }
    private void m_TitleLabel_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void m_ArtistLabel_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void panPopup_Click (object sender, System.EventArgs e)
    { doHide(); }
    private void picArtwork_Click(object sender, System.EventArgs e)
    { doHide(); }
    
    private void iTunesControl_OnTrackChangedEvent (object iTrack)
    {
      IITTrack track = (IITTrack)iTrack;
      notify(track);
    }
    private void iTunesControl_OnStopEvent (object iTrack)
    {
      IITTrack track = (IITTrack)iTrack;
      if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStatePlaying)
      {
        if (stopAfterCurrent)
        {
          iTunesControl.Stop();
          iTunesControl.BackTrack();
          stopAfterCurrent = false;
          return;
        }
        return;
      }
      if (iTunesControl.PlayerPosition != 0) return;
      renderStopped();
      doShow();
    }
    private void iTunesControl_OnPlayEvent (object iTrack)
    {
      IITTrack track = (IITTrack)iTrack;
      notify(track);
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
    
    #endregion
    
    void notify (IITTrack track)
    {
      currentArtwork = null;
      artworkTrack = null;
      if (artworkThread != null)
      {
        if (artworkThread.ThreadState == ThreadState.Running)
          artworkThread.Abort();
      }
      if ((track.Artwork != null) && (track.Artwork.Count >= 1))
      {
        artworkThread = new Thread(new ThreadStart(ArtworkThread));
        artworkTrack = track;
        artworkThread.Start();
        // Small wait for thread to finish
        artworkThread.Join(500);
      }
      
      notifyNotifyIcon.Text = String.Format("{0} - {1}", track.Artist, track.Name);
      render(track);
      doShow();
    }
    
    void ArtworkThread ()
    {
      IITTrack track = artworkTrack;
      if ((track.Artwork != null) && (track.Artwork.Count >= 1))
      {
        // Fetch artwork belonging to currently playing track
        // Extract artwork and save to folder.jpg file
        // Note: SaveArtworkToFile needs fully qualified path
        // Note: Track.Artwork is 1-indexed.
        bool b = true;
        string path = Path.GetTempFileName();
        IITArtwork art = track.Artwork[1];
        try
        {
          art.SaveArtworkToFile(path);
        }
        catch (COMException)
        { b = false; }
        Image artwork = null;
        if (b)
        {
          try
          {
            using (Stream stream = File.OpenRead(path))
            {
              stream.Seek(0, SeekOrigin.Begin);
              using (StreamView view = new StreamView(stream, 0, stream.Length))
              {
                artwork = Image.FromStream(view);
              }
            }
          }
          catch (IOException)
          { b = false; }
        }
        try
        {
          File.Delete(path);
        }
        catch (IOException)
        {}
        Bitmap bitmap = new Bitmap(artwork.Width, artwork.Height, PixelFormat.Format32bppRgb);
        using (Graphics g = Graphics.FromImage(bitmap))
        { g.DrawImage(artwork, new Rectangle(new Point(0, 0), bitmap.Size), 0, 0, artwork.Width, artwork.Height, GraphicsUnit.Pixel); }
        currentArtwork = bitmap;
      }
      render(track);
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
        if (hotkeys[i].Atom == 0) continue;
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
    
    void doAbout ()
    {
      (new frmAbout()).ShowDialog(this);
    }
    
    protected override void WndProc (ref Message m)
    {
      switch (m.Msg)
      {
        case Win32.WM_HOTKEY:
        {
          int key = ((int)m.LParam) >> 16;
          int mod = ((int)m.LParam) << 16 >> 16;
          for (int i = 0; i < hotkeys.Length; i++)
          {
            if ((key != hotkeys[i].KeyValue) || (mod != hotkeys[i].Modifiers)) continue;
            switch (hotkeys[i].Action)
            {
              case HotkeyAction.ShowBrowser: iTunesControl.BrowserWindow.Visible = true; break;
              case HotkeyAction.Play: iTunesControl.Play(); break;
              case HotkeyAction.PlayPause: iTunesControl.PlayPause(); break;
              case HotkeyAction.Stop: iTunesControl.Stop(); break;
              case HotkeyAction.NextSong: doNextTrack(); break;
              case HotkeyAction.PreviousSong: doPreviousTrack(); break;
              case HotkeyAction.ToggleStopAfterCurrent: stopAfterCurrent = !stopAfterCurrent; break;
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
    
    void doPreviousTrack ()
    {
      try
      {
        stopAfterCurrent = false;
        iTunesControl.PreviousTrack();
      }
      catch (COMException)
      {
      }
    }
    
    void doNextTrack ()
    {
      try
      {
        stopAfterCurrent = false;
        iTunesControl.NextTrack();
      }
      catch (COMException)
      {
      }
    }
    
    private void frmMain_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
    {
      e.Graphics.DrawImage(backbuffer, new Rectangle(new Point(0, 0), this.Size), 0, 0, backbuffer.Width, backbuffer.Height, GraphicsUnit.Pixel);
    }
    
    void renderClear ()
    {
      using (Graphics g = Graphics.FromImage(backbuffer))
      { render(g); }
      this.Invalidate();
    }
    void render (Graphics g)
    {
      g.Clear(Color.AliceBlue);
      g.DrawRectangle(Pens.Black, 0, 0, this.Width-1, this.Height-1);
    }
    
    void renderStopped ()
    {
      using (Graphics g = Graphics.FromImage(backbuffer))
      { renderStopped(g); }
      this.Invalidate();
    }
    void renderStopped (Graphics g)
    {
      string text = "Playback Stopped";
      
      render(g);
      
      SizeF size = g.MeasureString(text, fontTitle);
      g.DrawString(text, fontTitle, Brushes.Black, (this.Width - size.Width) / 2, 44);
    }
    
    void render (IITTrack track)
    {
      using (Graphics g = Graphics.FromImage(backbuffer))
      { render(track, g); }
      this.Invalidate();
    }
    void render (IITTrack track, Graphics g)
    {
      string tracknum = String.Format("{0}/{1}", track.PlayOrderIndex, track.Playlist.Tracks.Count);
      string playlist = track.Playlist.Name;
      string title = String.Format("{0} ({1})", track.Name, track.Time);
      string author = track.Artist;
      SizeF size;
      
      render(g);
      
      if (currentArtwork != null)
      {
        ImageAttributes attr = new ImageAttributes();
        ColorMatrix cm = new ColorMatrix();
        cm.Matrix33 = 0.20f;
        attr.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        g.DrawImage(currentArtwork, new Rectangle(0, (this.Height-this.Width+14+8)/2, this.Width, this.Width), 0, 0, currentArtwork.Width, currentArtwork.Height, GraphicsUnit.Pixel, attr);
      }
      g.DrawString(tracknum, fontStatus, Brushes.Black, 4, 4);
      size = g.MeasureString(playlist, fontStatus);
      g.DrawString(playlist, fontStatus, Brushes.Black, this.Width - size.Width, 4);
      size = g.MeasureString(title, fontTitle);
      g.DrawString(title, fontTitle, Brushes.Black, (this.Width - size.Width) / 2, 34);
      size = g.MeasureString(author, fontAuthor);
      g.DrawString(author, fontAuthor, Brushes.Black, (this.Width - size.Width) / 2, 54);
    }
  }
}
