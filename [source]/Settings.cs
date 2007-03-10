using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace iTuner
{
  [Serializable()]
  public class iTunerSettings
  {
    // Notifications
    public bool ShowNotificationWindowOnStartup;
    public bool ShowNotificationWindowOnSongChange;
    public bool ShowNotificationWindowOnPlay;
    public bool ShowNotificationWindowOnStop;
    public int HideNotificationWindowAfter;
    
    // Hotkeys
    public HotkeyItem [] Hotkeys = new HotkeyItem [0];
    
    public iTunerSettings ()
    {
      // Properties
      foreach (FieldInfo field in GetType().GetFields())
      {
        if ((!field.IsPublic) || (field.IsSpecialName)) continue;
        object [] attr = field.GetCustomAttributes(typeof(DefaultValueAttribute), true);
        if (attr.Length == 0) continue;
        field.SetValue(this, ((DefaultValueAttribute)attr[0]).Value);
      }
      // Notifications
      ShowNotificationWindowOnStartup = true;
      ShowNotificationWindowOnSongChange = true;
      ShowNotificationWindowOnPlay = true;
      ShowNotificationWindowOnStop = true;
      HideNotificationWindowAfter = 10;
      
      // Hotkeys
      Hotkeys = new HotkeyItem [6];
      Hotkeys[0] = new HotkeyItem(HotkeyAction.ShowBrowser, (int)Keys.W, Win32.MOD_CONTROL + Win32.MOD_SHIFT);
      Hotkeys[1] = new HotkeyItem(HotkeyAction.PlayPause, (int)Keys.MediaPlayPause);
      Hotkeys[2] = new HotkeyItem(HotkeyAction.Stop, (int)Keys.MediaStop);
      Hotkeys[3] = new HotkeyItem(HotkeyAction.NextSong, (int)Keys.MediaNextTrack);
      Hotkeys[4] = new HotkeyItem(HotkeyAction.PreviousSong, (int)Keys.MediaPreviousTrack);
      Hotkeys[5] = new HotkeyItem(HotkeyAction.ToggleStopAfterCurrent, (int)Keys.MediaStop, Win32.MOD_CONTROL);
    }
    
    
    public void Save ()
    { Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\iTuner.ini"); }
    public void Save (string fileName)
    {
      FileStream fs = File.OpenWrite(fileName);
      try
      { (new BinaryFormatter()).Serialize(fs, this); }
      catch (SerializationException e)
      { MessageBox.Show("Could not save settings:\n" + e.Message, "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
      fs.Close();
    }
    public static iTunerSettings Load ()
    { return FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\iTuner.ini"); }
    public static iTunerSettings FromFile (string fileName)
    {
      iTunerSettings settings = null;
      if (File.Exists(fileName))
      {
        FileStream fs = File.OpenRead(fileName);
        try
        { settings = (iTunerSettings)(new BinaryFormatter()).Deserialize(fs); }
        catch (SerializationException e)
        { MessageBox.Show("Could not load settings:\n" + e.Message + "\n\nUsing default settings.", "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        fs.Close();
      }
      if ((settings != null) && (settings.Hotkeys == null))
      {
        MessageBox.Show("Settings are corrupt.\n\nUsing default settings.", "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        settings = null;
      }
      if (settings == null)
      { settings = new iTunerSettings(); settings.Save(); }
      return settings;
    }
  }
}
