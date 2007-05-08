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
  public class frmMain : System.Windows.Forms.Form
  {
    class ExitException : Exception
    {}
    
    public readonly Size DefaultNotifySize = new Size(324, 98);
    int currentHideTime = 0;
    bool hideTiming = false;
    iTunerSettings settings = new iTunerSettings();
    int [] hotkeyAtoms = new int [0];
    iTunesApp iTunesControl;
    bool stopAfterCurrent = false;
    Image currentArtwork = null;
    Image nullArtwork = null;
    Bitmap backbuffer = null;
    Font fontStatus = new Font("Arial", 8, FontStyle.Regular);
    Font fontPlaylist = new Font("Arial", 8, FontStyle.Regular);
    Font fontTitle = new Font("Arial", 10, FontStyle.Bold);
    Font fontAuthor = new Font("Arial", 10, FontStyle.Regular);
    Font fontAlbum = new Font("Arial", 10, FontStyle.Regular);
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
    private System.Windows.Forms.Timer timerClose;
    private System.Windows.Forms.MenuItem menuTrayMenuAbout;
    
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
        throw new ExitException();
      }
      
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.Opaque, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      
      backbuffer = new Bitmap(DefaultNotifySize.Width, DefaultNotifySize.Height, PixelFormat.Format32bppRgb);
      aquireNullArtwork();
      
      int desktopWidth = Screen.PrimaryScreen.WorkingArea.Width;
      int desktopHeight = Screen.PrimaryScreen.WorkingArea.Height;
      int x = desktopWidth - this.Width;
      int y = desktopHeight - this.Height;
      this.SetDesktopLocation(x,y);
      
      settings = iTunerSettings.Load();
      hotkeyAtoms = new int [settings.Hotkeys.Length];
      setHotkeys();
      
      // Show notification window (since starting up), if settings permits
      if (settings.ShowNotificationWindowOnStartup)
        notify();
      
      // Start the close timer, even if not closing, to keep it going
      timerClose.Start();
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
      this.timerClose.Enabled = true;
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
      try
      { frmMain form = new frmMain(); }
      catch (ExitException)
      { return; }
      Application.Run();
    }
    
    private void frmMain_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
    {
      e.Graphics.DrawImage(backbuffer, new Rectangle(new Point(0, 0), this.Size), 0, 0, backbuffer.Width, backbuffer.Height, GraphicsUnit.Pixel);
    }
    
    #region Menu Events
    
    private void menuTrayMenu_Popup(object sender, System.EventArgs e)
    {
      menuTrayMenuStopAfterCurrent.Checked = stopAfterCurrent;
    }
    
    private void menuTrayMenuShow_Click(object sender, System.EventArgs e)
    { doShowBrowser(); }
    
    private void menuTrayMenuPlay_Click(object sender, System.EventArgs e)
    { doPlay(); }
    
    private void menuTrayMenuPause_Click(object sender, System.EventArgs e)
    { doPause(); }
    
    private void menuTrayMenuStop_Click(object sender, System.EventArgs e)
    { doStop(); }
    
    private void menuTrayMenuNext_Click(object sender, System.EventArgs e)
    { doNextTrack(); }
    
    private void menuTrayMenuPrev_Click(object sender, System.EventArgs e)
    { doPreviousTrack(); }
    
    private void menuTrayMenuStopAfterCurrent_Click(object sender, System.EventArgs e)
    { doToggleStopAfterCurrent(); }
    
    private void menuTrayMenuPreferences_Click(object sender, System.EventArgs e)
    { doPreferences(); }
    private void menuTrayMenuAbout_Click(object sender, System.EventArgs e)
    { doAbout(); }
    
    private void menuTrayMenuExit_Click(object sender, System.EventArgs e)
    { doExit(); }
    
    #endregion
    
    #region Control Events
    
    private void frmMain_Click(object sender, System.EventArgs e)
    { doHideWindow(); }
    
    private void iTunesControl_OnTrackChangedEvent (object iTrack)
    {
      if (iTunesControl == null) return;
      if (settings.ShowNotificationWindowOnSongChange)
        notify();
    }
    private void iTunesControl_OnStopEvent (object iTrack)
    {
      if (iTunesControl == null) return;
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
      if (settings.ShowNotificationWindowOnStop)
        notify();
    }
    private void iTunesControl_OnPlayEvent (object iTrack)
    {
      if (iTunesControl == null) return;
      if (settings.ShowNotificationWindowOnPlay)
        notify();
    }
    
    private void timerClose_Tick (object sender, System.EventArgs e)
    {
      if (hideTiming)
      {
        currentHideTime += 1;
        if (currentHideTime >= settings.HideNotificationWindowAfter*10)
        {
          currentHideTime = 0;
          doHideWindow();
        }
      }
    }
    
    private void notifyNotifyIcon_DoubleClick (object sender, System.EventArgs e)
    {
      if (iTunesControl == null) return;
      iTunesControl.BrowserWindow.Visible = true;
    }
    
    #endregion
    
    #region Do Commands
    
    void doShowBrowser ()
    {
      if (iTunesControl == null) return;
      iTunesControl.BrowserWindow.Visible = true;
    }
    
    void doPlay ()
    {
      if (iTunesControl == null) return;
      try
      {
        iTunesControl.Play();
      }
      catch (COMException)
      {
      }
    }
    
    void doPause ()
    {
      if (iTunesControl == null) return;
      try
      {
        iTunesControl.Pause();
      }
      catch (COMException)
      {
      }
    }
    
    void doPlayPause ()
    {
      if (iTunesControl == null) return;
      try
      {
        iTunesControl.PlayPause();
      }
      catch (COMException)
      {
      }
    }
    
    void doStop()
    {
      if (iTunesControl == null) return;
      try
      {
        stopAfterCurrent = false;
        iTunesControl.Stop();
      }
      catch (COMException)
      {
      }
    }
    
    void doPreviousTrack()
    {
      if (iTunesControl == null) return;
      try
      {
        stopAfterCurrent = false;
        iTunesControl.PreviousTrack();
      }
      catch (COMException)
      {
      }
    }
    
    void doNextTrack()
    {
      if (iTunesControl == null) return;
      try
      {
        stopAfterCurrent = false;
        iTunesControl.NextTrack();
      }
      catch (COMException)
      {
      }
    }
    
    void doToggleStopAfterCurrent()
    {
      stopAfterCurrent = !stopAfterCurrent;
    }
    
    void doStartTimer()
    {
      if (this.IsDisposed) return;
      currentHideTime = 0;
      hideTiming = true;
    }
    
    void doStopTimer()
    {
      currentHideTime = 0;
      hideTiming = false;
    }
    
    void doShowWindow()
    {
      if (this.IsDisposed) return;
      if (!this.Visible)
      {
        Win32.ShowWindow(this.Handle, Win32.ShowWindowCommands.ShowNoActivate);
        this.Visible = true;
      }
      else
      {
        this.Refresh();
      }
      doStartTimer();
    }
    void doHideWindow()
    {
      if (this.IsDisposed) return;
      if (this.Visible)
      {
        Win32.AnimateWindow(this.Handle, 1000, Win32.AnimateStyles.Hide | Win32.AnimateStyles.Blend);
        this.Visible = false;
      }
      doStopTimer();
    }
    
    void doPreferences()
    {
      if (this.IsDisposed) return;
      clearHotkeys();
      frmPreferences form = new frmPreferences();
      form.ShowNotificationWindowOnStartup = settings.ShowNotificationWindowOnStartup;
      form.ShowNotificationWindowOnSongChange = settings.ShowNotificationWindowOnSongChange;
      form.ShowNotificationWindowOnPlay = settings.ShowNotificationWindowOnPlay;
      form.ShowNotificationWindowOnStop = settings.ShowNotificationWindowOnStop;
      form.HideNotificationWindowAfter = settings.HideNotificationWindowAfter;
      form.Hotkeys = settings.Hotkeys;
      form.LogRadioTracks = settings.LogRadioTracks;
      form.LogRadioMarkOwnedTracks = settings.LogRadioMarkOwnedTracks;
      form.RadioLogFile = settings.RadioLogFile;
      if (form.ShowDialog() == DialogResult.OK)
      {
        // Set results
        settings.ShowNotificationWindowOnStartup = form.ShowNotificationWindowOnStartup;
        settings.ShowNotificationWindowOnSongChange = form.ShowNotificationWindowOnSongChange;
        settings.ShowNotificationWindowOnPlay = form.ShowNotificationWindowOnPlay;
        settings.ShowNotificationWindowOnStop = form.ShowNotificationWindowOnStop;
        settings.HideNotificationWindowAfter = form.HideNotificationWindowAfter;
        settings.Hotkeys = form.Hotkeys;
        settings.LogRadioTracks = form.LogRadioTracks;
        settings.LogRadioMarkOwnedTracks = form.LogRadioMarkOwnedTracks;
        settings.RadioLogFile = form.RadioLogFile;
        hotkeyAtoms = new int [settings.Hotkeys.Length];
        // Save results
        settings.Save();
      }
      setHotkeys();
    }
    
    void doAbout()
    {
      if (this.IsDisposed) return;
      (new frmAbout()).ShowDialog(this);
    }

    void doExit()
    {
      if (!this.IsDisposed)
      {
        clearHotkeys();
        notifyNotifyIcon.Visible = false;
        this.Close();
      }
      Application.Exit();
    }
    
    #endregion
    
    void ArtworkThread()
    {
      if (iTunesControl == null) return;
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
            { artwork = Image.FromStream(stream); }
          }
          catch (IOException)
          { b = false; }
        }
        try
        { File.Delete(path); }
        catch (IOException)
        {}
        Bitmap bitmap = new Bitmap(artwork.Width, artwork.Height, PixelFormat.Format32bppRgb);
        using (Graphics g = Graphics.FromImage(bitmap))
        { g.DrawImage(artwork, new Rectangle(new Point(0, 0), bitmap.Size), 0, 0, artwork.Width, artwork.Height, GraphicsUnit.Pixel); }
        currentArtwork = bitmap;
      }
      renderWindow();
    }
    
    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case Win32.WM_HOTKEY:
        {
          int key = ((int)m.LParam) >> 16;
          int mod = ((int)m.LParam) << 16 >> 16;
          for (int i = 0; i < settings.Hotkeys.Length; i++)
          {
            if ((key != settings.Hotkeys[i].KeyValue) || (mod != settings.Hotkeys[i].Modifiers)) continue;
            switch (settings.Hotkeys[i].Action)
            {
              case HotkeyAction.ShowBrowser: doShowBrowser(); break;
              case HotkeyAction.Play: doPlay(); break;
              case HotkeyAction.PlayPause: doPlayPause(); break;
              case HotkeyAction.Stop: doStop(); break;
              case HotkeyAction.NextSong: doNextTrack(); break;
              case HotkeyAction.PreviousSong: doPreviousTrack(); break;
              case HotkeyAction.ToggleStopAfterCurrent: doToggleStopAfterCurrent(); break;
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
    
    void setHotkeys()
    {
      clearHotkeys();
      for (int i = 0; i < settings.Hotkeys.Length; i++)
      {
        if (settings.Hotkeys[i].KeyValue == 0) continue;
        string atomName = "iTuner.Hotkey." + settings.Hotkeys[i].Action.ToString() + ":" + i.ToString();
        int result = 0;
        hotkeyAtoms[i] = Win32.GlobalAddAtom(atomName);
        if (hotkeyAtoms[i] != 0) result = Win32.RegisterHotKey(this.Handle, hotkeyAtoms[i], settings.Hotkeys[i].Modifiers, settings.Hotkeys[i].KeyValue);
        if (result == 0) MessageBox.Show(this, "Could not register hotkey: " + settings.Hotkeys[i].Action.ToString(), "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    void clearHotkeys()
    {
      for (int i = 0; i < hotkeyAtoms.Length; i++)
      {
        if (hotkeyAtoms[i] == 0) continue;
        Win32.UnregisterHotKey(this.Handle, hotkeyAtoms[i]);
        Win32.GlobalDeleteAtom(hotkeyAtoms[i]);
        hotkeyAtoms[i] = 0;
      }
    }
    
    void aquireNullArtwork()
    {
      Bitmap bitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
      using (Graphics g = Graphics.FromImage(bitmap))
      {
        g.Clear(Color.AliceBlue);
        g.DrawRectangle(Pens.Black, 0, 0, this.Width-1, this.Height-1);
      }
      nullArtwork = bitmap;
    }
    void aquireArtwork()
    {
      if (iTunesControl == null) return;
      IITTrack track = iTunesControl.CurrentTrack;
      currentArtwork = null;
      if (track == null) return;
      // Show artwork (in separate thread)
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
    }
    
    void notify()
    {
      if (iTunesControl == null) return;
      logRadioTrack();
      renderTrayText();
      aquireArtwork();
      renderWindow();
      doShowWindow();
    }
    
    void logRadioTrack()
    {
      if (iTunesControl == null) return;
      IITTrack track = iTunesControl.CurrentTrack;
      
      // Check for logging conditions
      if (!settings.LogRadioTracks) return;
      if (iTunesControl.PlayerState != ITPlayerState.ITPlayerStatePlaying) return;
      if (track == null) return;
      if (track.Kind != ITTrackKind.ITTrackKindURL) return;
      IITURLTrack urlTrack = (IITURLTrack)track;
      if (track.Playlist.Kind != ITPlaylistKind.ITPlaylistKindRadioTuner) return;
      
      // FUTURE: Show category, if available
      //string playlist = ( isRadio )?( String.Format("Radio ({0})", urlTrack.Category) ):( "URL" );
      string title = iTunesControl.CurrentStreamTitle;
      
      // Untitled tracks are not logged
      if ((title == null) || (title == "")) return;
      
      // Parse title
      int sepIndex = title.IndexOf("-");
      if (sepIndex == -1) sepIndex = title.Length;
      string trackArtist = title.Substring(0, sepIndex).Trim();
      string trackName = title.Substring(sepIndex + 1).Trim();
      
      // Check for ownership
      bool ownsTrack = false;
      IITLibraryPlaylist library = iTunesControl.LibraryPlaylist;
      if (library != null)
      {
        IITTrackCollection matches = library.Search(trackArtist, ITPlaylistSearchField.ITPlaylistSearchFieldArtists);
        if ((matches != null) && (matches.Count > 0))
        {
          for (int i = 1; i <= matches.Count; i++)
          {
            IITTrack match = matches[i];
            if (match == null) continue;
            if ((match.Artist == trackArtist) && (match.Name == trackName))
              ownsTrack = true;
          }
        }
      }
      
      string logText = String.Format("{0}{1}", ((ownsTrack) ? ("* ") : ("")), title);
      
      // Check for duplicate entry
      if (File.Exists(settings.RadioLogFile))
      {
        try
        {
          StreamReader sr = new StreamReader(File.OpenRead(settings.RadioLogFile));
          string line = "";
          while (sr.Peek() != -1) line = sr.ReadLine();
          if (line != null)
          {
            line = line.Trim();
            if (line == logText) return;
          }
          sr.Close();
        }
        catch (IOException)
        {}
      }
      
      // Log track information
      try
      {
        StreamWriter file = File.AppendText(settings.RadioLogFile);
        file.WriteLine(logText);
        file.Close();
      }
      catch (IOException ex)
      {
        MessageBox.Show(String.Format("Could not log radio track.\n\nTrack:\n{0}\n\nError Message:\n{1}", logText, ex.Message), "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
    
    void renderTrayText()
    {
      if (iTunesControl == null) return;
      IITTrack track = iTunesControl.CurrentTrack;
      
      // Show track info
      string trackText = "";
      if (track != null)
      {
        if (track.Kind == ITTrackKind.ITTrackKindURL)
        {
          IITURLTrack urlTrack = (IITURLTrack)track;
          trackText = String.Format("{0}\n{1}", urlTrack.Name, iTunesControl.CurrentStreamTitle);
        }
        else if (track.Kind == ITTrackKind.ITTrackKindCD)
        {
          IITFileOrCDTrack fileTrack = (IITFileOrCDTrack)track;
          trackText = String.Format("{0} {1} - {2}", fileTrack.TrackNumber, fileTrack.Artist, fileTrack.Name);
        }
        else
        {
          IITFileOrCDTrack fileTrack = (IITFileOrCDTrack)track;
          trackText = String.Format("{0} - {1}", track.Artist, track.Name);
        }
      }
      else
      {
        trackText = "No track";
      }
      
      // Show info
      string text = String.Format("iTuner\n{0}", trackText);
      if (text.Length >= 64)
        text = text.Substring(0, 63-"...".Length) + "...";
      notifyNotifyIcon.Text = text;
    }
    
    void renderWindow(Graphics g)
    {
      if (this.IsDisposed) return;
      if (iTunesControl == null) return;
      IITTrack track = iTunesControl.CurrentTrack;
      
      // Show status
      /*
      string text = "Playback Stopped";
      SizeF size = g.MeasureString(text, fontTitle);
      g.DrawString(text, fontTitle, Brushes.Black, (this.Width - size.Width) / 2, 44);
      */
      
      // Draw background
      g.DrawImage(nullArtwork, 0, 0, new Rectangle(0, 0, this.Width, this.Height), GraphicsUnit.Pixel);
      if (currentArtwork != null)
      {
        ImageAttributes attr = new ImageAttributes();
        ColorMatrix cm = new ColorMatrix();
        cm.Matrix33 = 0.20f;
        attr.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        g.DrawImage(currentArtwork, new Rectangle(0, (this.Height-this.Width+14+8)/2, this.Width, this.Width), 0, 0, currentArtwork.Width, currentArtwork.Height, GraphicsUnit.Pixel, attr);
      }
      
      // Draw track info
      if (track != null)
      {
        if (track.Kind == ITTrackKind.ITTrackKindURL)
        {
          IITURLTrack urlTrack = (IITURLTrack)track;
          bool isRadio = track.Playlist.Kind == ITPlaylistKind.ITPlaylistKindRadioTuner;
          // FUTURE: Show category, if available
          //string playlist = ( isRadio )?( String.Format("Radio ({0})", urlTrack.Category) ):( "URL" );
          string playlist = ( isRadio )?( "Radio" ):( "URL" );
          string title = iTunesControl.CurrentStreamTitle;
          string name = track.Name;
          if (title == "") title = "Untitled Track";
          g.DrawString(playlist, fontPlaylist, Brushes.Black, 4, 4);
          g.DrawString(title, fontTitle, Brushes.Black, (this.Width - g.MeasureString(title, fontTitle).Width) / 2, 34);
          g.DrawString(name, fontAuthor, Brushes.Black, (this.Width - g.MeasureString(name, fontAuthor).Width) / 2, 54);
        }
        else if (track.Kind == ITTrackKind.ITTrackKindCD)
        {
          string playlist = String.Format("CD {0}/{1}", track.TrackNumber, track.TrackCount);
          string title = String.Format("{0} ({1})", track.Name, track.Time);
          string author = track.Artist;
          string album = track.Album;
          g.DrawString(playlist, fontPlaylist, Brushes.Black, 4, 4);
          g.DrawString(title, fontTitle, Brushes.Black, (this.Width - g.MeasureString(title, fontTitle).Width) / 2, 28);
          g.DrawString(author, fontAuthor, Brushes.Black, (this.Width - g.MeasureString(author, fontAuthor).Width) / 2, 48);
          g.DrawString(album, fontAlbum, Brushes.Black, (this.Width - g.MeasureString(album, fontAlbum).Width) / 2, 68);
        }
        else
        {
          string playlist = String.Format("{0}/{1} ({2})", track.PlayOrderIndex, track.Playlist.Tracks.Count, track.Playlist.Name);
          string title = String.Format("{0} ({1})", track.Name, track.Time);
          string author = track.Artist;
          string album = track.Album;
          g.DrawString(playlist, fontPlaylist, Brushes.Black, 4, 4);
          g.DrawString(title, fontTitle, Brushes.Black, (this.Width - g.MeasureString(title, fontTitle).Width) / 2, 28);
          g.DrawString(author, fontAuthor, Brushes.Black, (this.Width - g.MeasureString(author, fontAuthor).Width) / 2, 48);
          g.DrawString(album, fontAlbum, Brushes.Black, (this.Width - g.MeasureString(album, fontAlbum).Width) / 2, 68);
        }
      }
      else
      {
        string text = "No Track";
        SizeF size = g.MeasureString(text, fontTitle);
        g.DrawString(text, fontTitle, Brushes.Black, (this.Width - size.Width) / 2, 48);
      }
      
      // Draw status
      string status = "";
      if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStatePlaying)
        status = "Playing";
      else if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStateStopped)
        status = "Stopped";
      else if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStateFastForward)
        status = "Fast Forward";
      else if (iTunesControl.PlayerState == ITPlayerState.ITPlayerStateRewind)
        status = "Rewind";
      g.DrawString(status, fontStatus, Brushes.Black, this.Width - g.MeasureString(status, fontStatus).Width, 4);
    }
    void renderWindow ()
    {
      if (this.IsDisposed) return;
      using (Graphics g = Graphics.FromImage(backbuffer))
      { renderWindow(g); }
      this.Invalidate();
    }
  }
}
