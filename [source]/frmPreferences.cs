using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
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
    private System.Windows.Forms.TextBox txtHotkey;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnSet;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.ComboBox comboHotkeyActions;
    private System.Windows.Forms.GroupBox groupHotkeys;
    private System.Windows.Forms.GroupBox groupRadioLog;
    private System.Windows.Forms.GroupBox groupNotificationWindow;
    private System.Windows.Forms.Label lblNotificationHideAfterSeconds;
    private System.Windows.Forms.Label lblNotificationHideAfter;
    private System.Windows.Forms.TextBox txtNotificationHideAfter;
    private System.Windows.Forms.CheckBox chkShowNotificationOnStartup;
    private System.Windows.Forms.CheckBox chkShowNotificationOnPlay;
    private System.Windows.Forms.CheckBox chkShowNotificationOnStop;
    private System.Windows.Forms.CheckBox chkShowNotificationOnSongChange;
    private System.Windows.Forms.CheckBox checkRadioLog;
    private System.Windows.Forms.TextBox textRadioLogFile;
    private System.Windows.Forms.Button buttonRadioLogFileBrowse;
    private System.Windows.Forms.Button buttonRadioLogShow;
    private System.Windows.Forms.Label labelRadioLogFile;
    private System.Windows.Forms.CheckBox checkLogRadioMarkOwnedTracks;
    private System.Windows.Forms.Button buttonRadioLogClear;
    private System.Windows.Forms.SaveFileDialog dialogRadioLogFile;
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
      this.txtHotkey = new System.Windows.Forms.TextBox();
      this.comboHotkeyActions = new System.Windows.Forms.ComboBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnSet = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.groupHotkeys = new System.Windows.Forms.GroupBox();
      this.groupRadioLog = new System.Windows.Forms.GroupBox();
      this.labelRadioLogFile = new System.Windows.Forms.Label();
      this.checkLogRadioMarkOwnedTracks = new System.Windows.Forms.CheckBox();
      this.buttonRadioLogShow = new System.Windows.Forms.Button();
      this.buttonRadioLogFileBrowse = new System.Windows.Forms.Button();
      this.textRadioLogFile = new System.Windows.Forms.TextBox();
      this.checkRadioLog = new System.Windows.Forms.CheckBox();
      this.buttonRadioLogClear = new System.Windows.Forms.Button();
      this.groupNotificationWindow = new System.Windows.Forms.GroupBox();
      this.lblNotificationHideAfterSeconds = new System.Windows.Forms.Label();
      this.lblNotificationHideAfter = new System.Windows.Forms.Label();
      this.txtNotificationHideAfter = new System.Windows.Forms.TextBox();
      this.chkShowNotificationOnStartup = new System.Windows.Forms.CheckBox();
      this.chkShowNotificationOnPlay = new System.Windows.Forms.CheckBox();
      this.chkShowNotificationOnStop = new System.Windows.Forms.CheckBox();
      this.chkShowNotificationOnSongChange = new System.Windows.Forms.CheckBox();
      this.dialogRadioLogFile = new System.Windows.Forms.SaveFileDialog();
      this.groupHotkeys.SuspendLayout();
      this.groupRadioLog.SuspendLayout();
      this.groupNotificationWindow.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(408, 388);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(120, 40);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "Close";
      // 
      // listHotkeys
      // 
      this.listHotkeys.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.listHotkeys.IntegralHeight = false;
      this.listHotkeys.Location = new System.Drawing.Point(8, 20);
      this.listHotkeys.Name = "listHotkeys";
      this.listHotkeys.Size = new System.Drawing.Size(504, 140);
      this.listHotkeys.TabIndex = 1;
      this.listHotkeys.SelectedIndexChanged += new System.EventHandler(this.listHotkeys_SelectedIndexChanged);
      // 
      // txtHotkey
      // 
      this.txtHotkey.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtHotkey.BackColor = System.Drawing.SystemColors.Window;
      this.txtHotkey.Location = new System.Drawing.Point(8, 188);
      this.txtHotkey.Name = "txtHotkey";
      this.txtHotkey.ReadOnly = true;
      this.txtHotkey.Size = new System.Drawing.Size(364, 20);
      this.txtHotkey.TabIndex = 3;
      this.txtHotkey.Text = "";
      this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
      this.txtHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyUp);
      // 
      // comboHotkeyActions
      // 
      this.comboHotkeyActions.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
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
      this.comboHotkeyActions.Location = new System.Drawing.Point(8, 164);
      this.comboHotkeyActions.Name = "comboHotkeyActions";
      this.comboHotkeyActions.Size = new System.Drawing.Size(504, 21);
      this.comboHotkeyActions.TabIndex = 4;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnAdd.Location = new System.Drawing.Point(376, 188);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(40, 20);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "&Add";
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnSet
      // 
      this.btnSet.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnSet.Enabled = false;
      this.btnSet.Location = new System.Drawing.Point(420, 188);
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new System.Drawing.Size(40, 20);
      this.btnSet.TabIndex = 5;
      this.btnSet.Text = "&Set";
      this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnDelete.Enabled = false;
      this.btnDelete.Location = new System.Drawing.Point(464, 188);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(48, 20);
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "&Delete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // groupHotkeys
      // 
      this.groupHotkeys.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.groupHotkeys.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                               this.btnAdd,
                                                                               this.btnSet,
                                                                               this.txtHotkey,
                                                                               this.comboHotkeyActions,
                                                                               this.listHotkeys,
                                                                               this.btnDelete});
      this.groupHotkeys.Location = new System.Drawing.Point(8, 164);
      this.groupHotkeys.Name = "groupHotkeys";
      this.groupHotkeys.Size = new System.Drawing.Size(520, 216);
      this.groupHotkeys.TabIndex = 11;
      this.groupHotkeys.TabStop = false;
      this.groupHotkeys.Text = "Hotkeys";
      // 
      // groupRadioLog
      // 
      this.groupRadioLog.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.groupRadioLog.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.labelRadioLogFile,
                                                                                this.checkLogRadioMarkOwnedTracks,
                                                                                this.buttonRadioLogShow,
                                                                                this.buttonRadioLogFileBrowse,
                                                                                this.textRadioLogFile,
                                                                                this.checkRadioLog,
                                                                                this.buttonRadioLogClear});
      this.groupRadioLog.Location = new System.Drawing.Point(272, 8);
      this.groupRadioLog.Name = "groupRadioLog";
      this.groupRadioLog.Size = new System.Drawing.Size(256, 144);
      this.groupRadioLog.TabIndex = 12;
      this.groupRadioLog.TabStop = false;
      this.groupRadioLog.Text = "Radio Log";
      // 
      // labelRadioLogFile
      // 
      this.labelRadioLogFile.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.labelRadioLogFile.Location = new System.Drawing.Point(8, 64);
      this.labelRadioLogFile.Name = "labelRadioLogFile";
      this.labelRadioLogFile.Size = new System.Drawing.Size(240, 16);
      this.labelRadioLogFile.TabIndex = 5;
      this.labelRadioLogFile.Text = "Log File:";
      // 
      // checkLogRadioMarkOwnedTracks
      // 
      this.checkLogRadioMarkOwnedTracks.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.checkLogRadioMarkOwnedTracks.Location = new System.Drawing.Point(8, 40);
      this.checkLogRadioMarkOwnedTracks.Name = "checkLogRadioMarkOwnedTracks";
      this.checkLogRadioMarkOwnedTracks.Size = new System.Drawing.Size(240, 16);
      this.checkLogRadioMarkOwnedTracks.TabIndex = 4;
      this.checkLogRadioMarkOwnedTracks.Text = "Mark Tracks in Library with *";
      // 
      // buttonRadioLogShow
      // 
      this.buttonRadioLogShow.Location = new System.Drawing.Point(8, 104);
      this.buttonRadioLogShow.Name = "buttonRadioLogShow";
      this.buttonRadioLogShow.Size = new System.Drawing.Size(72, 32);
      this.buttonRadioLogShow.TabIndex = 3;
      this.buttonRadioLogShow.Text = "Show";
      this.buttonRadioLogShow.Click += new System.EventHandler(this.buttonRadioLogShow_Click);
      // 
      // buttonRadioLogFileBrowse
      // 
      this.buttonRadioLogFileBrowse.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.buttonRadioLogFileBrowse.Location = new System.Drawing.Point(224, 80);
      this.buttonRadioLogFileBrowse.Name = "buttonRadioLogFileBrowse";
      this.buttonRadioLogFileBrowse.Size = new System.Drawing.Size(24, 20);
      this.buttonRadioLogFileBrowse.TabIndex = 2;
      this.buttonRadioLogFileBrowse.Text = "...";
      this.buttonRadioLogFileBrowse.Click += new System.EventHandler(this.buttonRadioLogFileBrowse_Click);
      // 
      // textRadioLogFile
      // 
      this.textRadioLogFile.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.textRadioLogFile.Location = new System.Drawing.Point(8, 80);
      this.textRadioLogFile.Name = "textRadioLogFile";
      this.textRadioLogFile.Size = new System.Drawing.Size(212, 20);
      this.textRadioLogFile.TabIndex = 1;
      this.textRadioLogFile.Text = "";
      // 
      // checkRadioLog
      // 
      this.checkRadioLog.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.checkRadioLog.Location = new System.Drawing.Point(8, 20);
      this.checkRadioLog.Name = "checkRadioLog";
      this.checkRadioLog.Size = new System.Drawing.Size(240, 16);
      this.checkRadioLog.TabIndex = 0;
      this.checkRadioLog.Text = "Log Radio Tracks";
      // 
      // buttonRadioLogClear
      // 
      this.buttonRadioLogClear.Location = new System.Drawing.Point(88, 104);
      this.buttonRadioLogClear.Name = "buttonRadioLogClear";
      this.buttonRadioLogClear.Size = new System.Drawing.Size(72, 32);
      this.buttonRadioLogClear.TabIndex = 3;
      this.buttonRadioLogClear.Text = "Clear";
      this.buttonRadioLogClear.Click += new System.EventHandler(this.buttonRadioLogClear_Click);
      // 
      // groupNotificationWindow
      // 
      this.groupNotificationWindow.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                          this.lblNotificationHideAfterSeconds,
                                                                                          this.lblNotificationHideAfter,
                                                                                          this.txtNotificationHideAfter,
                                                                                          this.chkShowNotificationOnStartup,
                                                                                          this.chkShowNotificationOnPlay,
                                                                                          this.chkShowNotificationOnStop,
                                                                                          this.chkShowNotificationOnSongChange});
      this.groupNotificationWindow.Location = new System.Drawing.Point(8, 8);
      this.groupNotificationWindow.Name = "groupNotificationWindow";
      this.groupNotificationWindow.Size = new System.Drawing.Size(256, 144);
      this.groupNotificationWindow.TabIndex = 13;
      this.groupNotificationWindow.TabStop = false;
      this.groupNotificationWindow.Text = "Notification Window";
      // 
      // lblNotificationHideAfterSeconds
      // 
      this.lblNotificationHideAfterSeconds.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblNotificationHideAfterSeconds.Location = new System.Drawing.Point(180, 104);
      this.lblNotificationHideAfterSeconds.Name = "lblNotificationHideAfterSeconds";
      this.lblNotificationHideAfterSeconds.Size = new System.Drawing.Size(68, 16);
      this.lblNotificationHideAfterSeconds.TabIndex = 17;
      this.lblNotificationHideAfterSeconds.Text = "seconds";
      // 
      // lblNotificationHideAfter
      // 
      this.lblNotificationHideAfter.Location = new System.Drawing.Point(8, 104);
      this.lblNotificationHideAfter.Name = "lblNotificationHideAfter";
      this.lblNotificationHideAfter.Size = new System.Drawing.Size(120, 16);
      this.lblNotificationHideAfter.TabIndex = 16;
      this.lblNotificationHideAfter.Text = "Hide Notification After:";
      // 
      // txtNotificationHideAfter
      // 
      this.txtNotificationHideAfter.Location = new System.Drawing.Point(132, 100);
      this.txtNotificationHideAfter.Name = "txtNotificationHideAfter";
      this.txtNotificationHideAfter.Size = new System.Drawing.Size(44, 20);
      this.txtNotificationHideAfter.TabIndex = 15;
      this.txtNotificationHideAfter.Text = "10";
      // 
      // chkShowNotificationOnStartup
      // 
      this.chkShowNotificationOnStartup.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkShowNotificationOnStartup.Location = new System.Drawing.Point(8, 20);
      this.chkShowNotificationOnStartup.Name = "chkShowNotificationOnStartup";
      this.chkShowNotificationOnStartup.Size = new System.Drawing.Size(240, 16);
      this.chkShowNotificationOnStartup.TabIndex = 14;
      this.chkShowNotificationOnStartup.Text = "Show on Startup";
      // 
      // chkShowNotificationOnPlay
      // 
      this.chkShowNotificationOnPlay.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkShowNotificationOnPlay.Location = new System.Drawing.Point(8, 60);
      this.chkShowNotificationOnPlay.Name = "chkShowNotificationOnPlay";
      this.chkShowNotificationOnPlay.Size = new System.Drawing.Size(240, 16);
      this.chkShowNotificationOnPlay.TabIndex = 11;
      this.chkShowNotificationOnPlay.Text = "Show on Play";
      // 
      // chkShowNotificationOnStop
      // 
      this.chkShowNotificationOnStop.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkShowNotificationOnStop.Location = new System.Drawing.Point(8, 80);
      this.chkShowNotificationOnStop.Name = "chkShowNotificationOnStop";
      this.chkShowNotificationOnStop.Size = new System.Drawing.Size(240, 16);
      this.chkShowNotificationOnStop.TabIndex = 12;
      this.chkShowNotificationOnStop.Text = "Show on Stop";
      // 
      // chkShowNotificationOnSongChange
      // 
      this.chkShowNotificationOnSongChange.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkShowNotificationOnSongChange.Location = new System.Drawing.Point(8, 40);
      this.chkShowNotificationOnSongChange.Name = "chkShowNotificationOnSongChange";
      this.chkShowNotificationOnSongChange.Size = new System.Drawing.Size(240, 16);
      this.chkShowNotificationOnSongChange.TabIndex = 13;
      this.chkShowNotificationOnSongChange.Text = "Show on Song Change";
      // 
      // dialogRadioLogFile
      // 
      this.dialogRadioLogFile.FileName = "Radiolog.txt";
      this.dialogRadioLogFile.Filter = "Log Files (*.txt;*.log)|*.txt;*.log|All Files (*.*)|*.*";
      // 
      // frmPreferences
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(534, 436);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.groupNotificationWindow,
                                                                  this.groupRadioLog,
                                                                  this.groupHotkeys,
                                                                  this.btnOK});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmPreferences";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "iTuner Preferences";
      this.groupHotkeys.ResumeLayout(false);
      this.groupRadioLog.ResumeLayout(false);
      this.groupNotificationWindow.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
    
    #endregion
    
    public bool ShowNotificationWindowOnStartup
    {
      get { return chkShowNotificationOnStartup.Checked; }
      set { chkShowNotificationOnStartup.Checked = value; }
    }
    public bool ShowNotificationWindowOnSongChange
    {
      get { return chkShowNotificationOnSongChange.Checked; }
      set { chkShowNotificationOnSongChange.Checked = value; }
    }
    public bool ShowNotificationWindowOnPlay
    {
      get { return chkShowNotificationOnPlay.Checked; }
      set { chkShowNotificationOnPlay.Checked = value; }
    }
    public bool ShowNotificationWindowOnStop
    {
      get { return chkShowNotificationOnStop.Checked; }
      set { chkShowNotificationOnStop.Checked = value; }
    }
    
    public int HideNotificationWindowAfter
    {
      get
      {
        try
        { return int.Parse(txtNotificationHideAfter.Text); }
        catch (FormatException)
        { return 10; }
      }
      set { txtNotificationHideAfter.Text = value.ToString(); }
    }
    
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
    
    public bool LogRadioTracks
    {
      get { return checkRadioLog.Checked; }
      set { checkRadioLog.Checked = value; }
    }
    
    public bool LogRadioMarkOwnedTracks
    {
      get { return checkLogRadioMarkOwnedTracks.Checked; }
      set { checkLogRadioMarkOwnedTracks.Checked = value; }
    }
    
    public string RadioLogFile
    {
      get { return textRadioLogFile.Text; }
      set { textRadioLogFile.Text = value; }
    }
    
    #region Control Events
    
    private void buttonRadioLogFileBrowse_Click(object sender, System.EventArgs e)
    {
      dialogRadioLogFile.FileName = RadioLogFile;
      if (dialogRadioLogFile.ShowDialog(this) != DialogResult.OK) return;
      RadioLogFile = dialogRadioLogFile.FileName;
    }
    
    private void buttonRadioLogShow_Click(object sender, System.EventArgs e)
    {
      try
      {
        Process.Start(RadioLogFile, "");
      }
      catch (Exception)
      {}
    }
    private void buttonRadioLogClear_Click(object sender, System.EventArgs e)
    {
      if (MessageBox.Show(this, "Clear radio log file?", "iTuner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
      if (File.Exists(RadioLogFile))
      {
        try
        {
          File.Create(RadioLogFile).Close();
        }
        catch (IOException)
        {}
      }
    }
    
    private void txtNotificationHideAfter_Leave(object sender, System.EventArgs e)
    {
      try
      { txtNotificationHideAfter.Text = int.Parse(txtNotificationHideAfter.Text).ToString(); }
      catch (FormatException)
      { txtNotificationHideAfter.Text = "10"; }
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
    
    #endregion
    
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
