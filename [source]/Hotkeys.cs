using System;
using System.Windows.Forms;

namespace iTuner
{
  public enum HotkeyAction : int
  {
    ShowBrowser,
    Play,
    PlayPause,
    Stop,
    NextSong,
    PreviousSong,
    ToggleStopAfterCurrent,
  }
  
  [Serializable()]
  public class HotkeyItem
	{
    public HotkeyItem () : this(HotkeyAction.Play, 0)
    {}
    public HotkeyItem (HotkeyAction action, int keyValue) : this(action, keyValue, 0)
    {}
    public HotkeyItem (HotkeyAction action, int keyValue, int modifiers)
    {
      Action = action;
      KeyValue = keyValue;
      Modifiers = modifiers;
    }
    public HotkeyAction Action;
    public int KeyValue;
    public int Modifiers;
    
    public override string ToString ()
    {
      string s = "";
      if ((KeyValue != (int)Keys.ControlKey) && (KeyValue != (int)Keys.ShiftKey) && (KeyValue != (int)Keys.Menu) && (KeyValue != 0)) s = ((Keys)KeyValue).ToString();
      if ((Modifiers & Win32.MOD_ALT) != 0) s = "Alt + " + s;
      if ((Modifiers & Win32.MOD_SHIFT) != 0) s = "Shift + " + s;
      if ((Modifiers & Win32.MOD_CONTROL) != 0) s = "Control + " + s;
      return Action.ToString() + ": " + s;
    }
  }
}
