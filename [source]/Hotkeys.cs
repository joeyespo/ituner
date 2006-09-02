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
  }
  
	public struct HotkeyItem
	{
    public HotkeyItem (HotkeyAction action, int keyValue) : this(action, keyValue, 0)
    {}
    public HotkeyItem (HotkeyAction action, int keyValue, int modifiers)
    {
      Atom = 0;
      Action = action;
      KeyValue = keyValue;
      Modifiers = modifiers;
    }
    public HotkeyAction Action;
    public int KeyValue;
    public int Modifiers;
    public int Atom;
    
    public override string ToString ()
    {
      string s = "";
      if ((KeyValue != (int)Keys.ControlKey) && (KeyValue != (int)Keys.ShiftKey) && (KeyValue != (int)Keys.Menu) && (KeyValue != 0)) s = ((Keys)KeyValue).ToString();
      if ((Modifiers & (int)Keys.Alt) != 0) s = "Alt + " + s;
      if ((Modifiers & (int)Keys.Shift) != 0) s = "Shift + " + s;
      if ((Modifiers & (int)Keys.Control) != 0) s = "Control + " + s;
      return Action.ToString() + ": " + s;
    }
  }
}
