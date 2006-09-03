using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iTuner
{
	/// <summary>
	/// Summary description for frmPreferences.
	/// </summary>
	public class frmPreferences : System.Windows.Forms.Form
	{
    int key = 0;
    int mod = 0;
    
    #region Class Variables
    
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.ListBox listHotkeys;
    private System.Windows.Forms.Label lblHotkeys;
    private System.Windows.Forms.TextBox txtHotkey;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnSet;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.ComboBox comboHotkeyActions;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
    
    #endregion
    
    #region Class Construction
    
    public frmPreferences()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
      comboHotkeyActions.SelectedIndex = 0;
		}
		
    #region Windows Form Designer generated code
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if(components != null)
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPreferences));
      this.btnOK = new System.Windows.Forms.Button();
      this.listHotkeys = new System.Windows.Forms.ListBox();
      this.lblHotkeys = new System.Windows.Forms.Label();
      this.txtHotkey = new System.Windows.Forms.TextBox();
      this.comboHotkeyActions = new System.Windows.Forms.ComboBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnSet = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(8, 274);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(120, 40);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "Close";
      // 
      // listHotkeys
      // 
      this.listHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.listHotkeys.IntegralHeight = false;
      this.listHotkeys.Location = new System.Drawing.Point(8, 24);
      this.listHotkeys.Name = "listHotkeys";
      this.listHotkeys.Size = new System.Drawing.Size(412, 196);
      this.listHotkeys.TabIndex = 1;
      this.listHotkeys.SelectedIndexChanged += new System.EventHandler(this.listHotkeys_SelectedIndexChanged);
      // 
      // lblHotkeys
      // 
      this.lblHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblHotkeys.Location = new System.Drawing.Point(8, 8);
      this.lblHotkeys.Name = "lblHotkeys";
      this.lblHotkeys.Size = new System.Drawing.Size(412, 16);
      this.lblHotkeys.TabIndex = 2;
      this.lblHotkeys.Text = "Hotkeys:";
      // 
      // txtHotkey
      // 
      this.txtHotkey.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtHotkey.BackColor = System.Drawing.SystemColors.Window;
      this.txtHotkey.Location = new System.Drawing.Point(8, 248);
      this.txtHotkey.Name = "txtHotkey";
      this.txtHotkey.ReadOnly = true;
      this.txtHotkey.Size = new System.Drawing.Size(272, 20);
      this.txtHotkey.TabIndex = 3;
      this.txtHotkey.Text = "";
      this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
      this.txtHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyUp);
      // 
      // comboHotkeyActions
      // 
      this.comboHotkeyActions.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.comboHotkeyActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboHotkeyActions.Items.AddRange(new object[] {
                                                            "Browser: Show",
                                                            "Playback: Play",
                                                            "Playback: Play/Pause",
                                                            "Playback: Stop",
                                                            "Playback: Next Song",
                                                            "Playback: Previous Song",
                                                            "Playback: Toggle Stop After Current"});
      this.comboHotkeyActions.Location = new System.Drawing.Point(8, 224);
      this.comboHotkeyActions.Name = "comboHotkeyActions";
      this.comboHotkeyActions.Size = new System.Drawing.Size(412, 21);
      this.comboHotkeyActions.TabIndex = 4;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnAdd.Location = new System.Drawing.Point(284, 248);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(40, 20);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "&Add";
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnSet
      // 
      this.btnSet.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnSet.Enabled = false;
      this.btnSet.Location = new System.Drawing.Point(328, 248);
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new System.Drawing.Size(40, 20);
      this.btnSet.TabIndex = 5;
      this.btnSet.Text = "&Set";
      this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnDelete.Enabled = false;
      this.btnDelete.Location = new System.Drawing.Point(372, 248);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(48, 20);
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "&Delete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // frmPreferences
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(426, 320);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.btnAdd,
                                                                  this.comboHotkeyActions,
                                                                  this.txtHotkey,
                                                                  this.lblHotkeys,
                                                                  this.listHotkeys,
                                                                  this.btnOK,
                                                                  this.btnSet,
                                                                  this.btnDelete});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmPreferences";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "iTuner Preferences";
      this.ResumeLayout(false);

    }
		#endregion
    
    #endregion
    
    public HotkeyItem [] Hotkeys
    {
      get
      {
        HotkeyItem [] hotkeys = new HotkeyItem [listHotkeys.Items.Count];
        for (int i = 0; i < listHotkeys.Items.Count; i++)
          hotkeys[i] = (HotkeyItem)listHotkeys.Items[i];
        return hotkeys;
      }
      set
      {
        listHotkeys.Items.Clear();
        foreach (HotkeyItem item in value)
          listHotkeys.Items.Add(item);
      }
    }
    
    private void txtHotkey_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
    {
      key = e.KeyValue;
      mod = (int)e.Modifiers;
      showHotkeyText();
      e.Handled = true;
    }
    
    private void txtHotkey_KeyUp (object sender, System.Windows.Forms.KeyEventArgs e)
    {
      if ((key == (int)Keys.ControlKey) || (key == (int)Keys.ShiftKey) || (key == (int)Keys.Menu) || (key == 0))
      {
        key = 0;
        mod = 0;
      }
      showHotkeyText();
    }
    
    private void listHotkeys_SelectedIndexChanged (object sender, System.EventArgs e)
    {
      bool b = listHotkeys.SelectedIndex != -1;
      btnSet.Enabled = b;
      btnDelete.Enabled = b;
      if (!b) return;
      HotkeyItem item = (HotkeyItem)(listHotkeys.SelectedItem);
      key = item.KeyValue;
      mod = item.Modifiers;
      setHotkeyAction(item.Action);
      showHotkeyText();
    }
    
    private void btnAdd_Click (object sender, System.EventArgs e)
    {
      if (key == 0) return;
      int real_mod = 0;
      if ((mod & (int)Keys.Alt) != 0) real_mod |= Win32.MOD_ALT;
      if ((mod & (int)Keys.Shift) != 0) real_mod |= Win32.MOD_SHIFT;
      if ((mod & (int)Keys.Control) != 0) real_mod |= Win32.MOD_CONTROL;
      listHotkeys.Items.Add(new HotkeyItem(getHotkeyAction(), key, real_mod));
    }
    private void btnSet_Click (object sender, System.EventArgs e)
    {
      if (listHotkeys.SelectedIndex == -1) return;
      listHotkeys.Items[listHotkeys.SelectedIndex] = new HotkeyItem(getHotkeyAction(), key, mod);
    }
    private void btnDelete_Click (object sender, System.EventArgs e)
    {
      if (listHotkeys.SelectedIndex == -1) return;
      int index = listHotkeys.SelectedIndex;
      listHotkeys.Items.RemoveAt(listHotkeys.SelectedIndex);
      if (index >= listHotkeys.Items.Count) index--;
      listHotkeys.SelectedIndex = index;
    }
    
    void showHotkeyText ()
    {
      string s = "";
      if ((key != (int)Keys.ControlKey) && (key != (int)Keys.ShiftKey) && (key != (int)Keys.Menu) && (key != 0)) s = ((Keys)key).ToString();
      if ((mod & (int)Keys.Alt) != 0) s = "Alt + " + s;
      if ((mod & (int)Keys.Shift) != 0) s = "Shift + " + s;
      if ((mod & (int)Keys.Control) != 0) s = "Control + " + s;
      txtHotkey.Text = s;
    }
    
    HotkeyAction getHotkeyAction ()
    {
      switch (comboHotkeyActions.SelectedIndex)
      {
        case 0: return HotkeyAction.ShowBrowser;
        case 1: return HotkeyAction.Play;
        case 2: return HotkeyAction.PlayPause;
        case 3: return HotkeyAction.Stop;
        case 4: return HotkeyAction.NextSong;
        case 5: return HotkeyAction.PreviousSong;
        case 6: return HotkeyAction.ToggleStopAfterCurrent;
        default:return HotkeyAction.PlayPause;
      }
    }
    void setHotkeyAction (HotkeyAction action)
    {
      switch (action)
      {
        case HotkeyAction.ShowBrowser: comboHotkeyActions.SelectedIndex = 0; break;
        case HotkeyAction.Play: comboHotkeyActions.SelectedIndex = 1; break;
        case HotkeyAction.PlayPause: comboHotkeyActions.SelectedIndex = 2; break;
        case HotkeyAction.Stop: comboHotkeyActions.SelectedIndex = 3; break;
        case HotkeyAction.NextSong: comboHotkeyActions.SelectedIndex = 4; break;
        case HotkeyAction.PreviousSong: comboHotkeyActions.SelectedIndex = 5; break;
        case HotkeyAction.ToggleStopAfterCurrent: comboHotkeyActions.SelectedIndex = 6; break;
        default: comboHotkeyActions.SelectedIndex = -1; break;
      }
    }
	}
}
