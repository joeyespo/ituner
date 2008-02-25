using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTunesLib;

// TODO: Notification window
// TODO: Hotkeys
// TODO: Sleep mode
// TODO: Mood mode
// TODO: Radio log
// TODO: Alarm

namespace iTuner
{
  public partial class formMain : Form
  {
    formPreferences preferencesWindow = null;
    formAboutBox aboutBoxWindow = null;

    Icon iconDisconnected = iTuner.Properties.Resources.Notify_Disconnected;
    Icon iconConnected = iTuner.Properties.Resources.Notify_Connected;
    iTunesApp iTunesControl = null;
    iTunerSettings settings = new iTunerSettings();
    
    public formMain()
    {
      InitializeComponent();

      // Show initial notify icon
      updateNotifyIcon();

      // Initial connection to iTunes
      iTunesConnect();
    }

    public void iTunesConnect()
    {
      // Connect to iTunes
      try
      {
        iTunesControl = new iTunesAppClass();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not connect to iTunes.");
      }

      // Set up iTunes
      updateNotifyIcon();
    }

    void iTunesError(Exception ex)
    { iTunesError(ex, ""); }
    void iTunesError(Exception ex, string message)
    {
      // Show error balloon
      string caption = ((message != "") ? (message) : ("Error with iTunes."));
      notifyIcon.ShowBalloonTip(0, "iTuner", caption + "\n\nError Message:\n" + ex.Message, ToolTipIcon.Error);

      // Log error
      // TODO: Log error in error log
    }

    void iTunesDisconnect()
    {
      // Disconnect from iTunes
      iTunesControl = null;
      GC.Collect();
      // Update icon
      updateNotifyIcon();
    }

    void updateNotifyIcon()
    {
      if (iTunesControl == null)
      {
        notifyIcon.Icon = iconDisconnected;
        notifyIcon.Text = "iTuner\nDisconnected";
      }
      else
      {
        notifyIcon.Icon = iconConnected;
        notifyIcon.Text = "iTuner";
      }
    }

    #region Menu Events

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left) return;
      if (iTunesControl == null)
        doConnect();
      else
        doShowITunes();
    }

    private void menuNotifyIcon_Opening(object sender, CancelEventArgs e)
    {
      bool connected = (iTunesControl != null);
      showITunesToolStripMenuItem.Visible = connected;
      connectToITunesToolStripMenuItem.Visible = !connected;
      disconnectFromITunesToolStripMenuItem.Visible = connected;
    }

    private void showITunesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doShowITunes();
    }

    private void connectToITunesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      iTunesConnect();
    }

    private void disconnectFromITunesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      iTunesDisconnect();
    }

    private void playToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doPlay();
    }

    private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doPause();
    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doStop();
    }

    private void nextTrackToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doNextTrack();
    }

    private void previousTrackToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doPreviousTrack();
    }

    private void stopAfterCurrentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doStopAfterCurrent();
    }

    private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doShowPreferences();
    }

    private void radioLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doShowRadioLog();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doShowAbout();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      doExit();
    }

    #endregion

    #region Menu Commands

    void doShowITunes()
    {
      if (iTunesControl == null) return;
      // Show iTunes browser
      try
      {
        iTunesControl.BrowserWindow.Visible = true;
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not show iTunes.");
      }
    }
    void doConnect()
    {
      iTunesConnect();
    }
    void doDisconnect()
    {
      iTunesDisconnect();
    }
    void doPlay()
    {
      if (iTunesControl == null) return;
      // Play track
      try
      {
        iTunesControl.Play();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not play in iTunes.");
      }
    }
    void doPause()
    {
      if (iTunesControl == null) return;
      // Pause track
      try
      {
        iTunesControl.Pause();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not pause in iTunes.");
      }
    }
    void doStop()
    {
      if (iTunesControl == null) return;
      // Stop track
      try
      {
        iTunesControl.Stop();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not stop in iTunes.");
      }
    }
    void doNextTrack()
    {
      if (iTunesControl == null) return;
      // Jump to next track
      try
      {
        iTunesControl.NextTrack();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not jump to next track in iTunes.");
      }
    }
    void doPreviousTrack()
    {
      if (iTunesControl == null) return;
      // Jump to previous track
      try
      {
        iTunesControl.PreviousTrack();
      }
      catch (COMException ex)
      {
        iTunesError(ex, "Could not jump to next track in iTunes.");
      }
    }
    void doStopAfterCurrent()
    {
      if (iTunesControl == null) return;
      // Toggle "Stop After Current" sleep mode flag
      // TODO: Stop after current flag
    }
    void doShowPreferences()
    {
      if (preferencesWindow == null)
      {
        preferencesWindow = new formPreferences();
        preferencesWindow.FormClosed += delegate(object sender, FormClosedEventArgs e)
        { preferencesWindow = null; };
      }
      preferencesWindow.Show();
    }
    void doShowRadioLog()
    {
      // TODO: Show radio log
    }
    void doShowAbout()
    {
      if (aboutBoxWindow == null)
      {
        aboutBoxWindow = new formAboutBox();
        aboutBoxWindow.FormClosed += delegate(object sender, FormClosedEventArgs e)
        { aboutBoxWindow = null; };
      }
      aboutBoxWindow.Show();
    }
    void doExit()
    {
      // Close other forms
      if (preferencesWindow != null)
        preferencesWindow.Close();
      if (aboutBoxWindow != null)
        aboutBoxWindow.Close();
      // Clean up and exit
      iTunesDisconnect();
      this.Close();
      Application.ExitThread();
    }

    #endregion

  }
}
