using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iTuner
{
  /// <summary>
  /// Summary description for formShowRadioLog.
  /// </summary>
  public class formShowRadioLog : System.Windows.Forms.Form
  {
    #region Class Variables

    private System.Windows.Forms.ColumnHeader columnArtist;
    private System.Windows.Forms.ColumnHeader columnOwns;
    private System.Windows.Forms.ColumnHeader columnName;
    private System.Windows.Forms.ListView listViewLog;
    private System.Windows.Forms.ColumnHeader columnOrder;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    
    #endregion
    
    #region Class Construction
    
    public formShowRadioLog ()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
    }
    
    #region Windows Form Designer generated code
    
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose (bool disposing)
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(formShowRadioLog));
      this.listViewLog = new System.Windows.Forms.ListView();
      this.columnOwns = new System.Windows.Forms.ColumnHeader();
      this.columnName = new System.Windows.Forms.ColumnHeader();
      this.columnArtist = new System.Windows.Forms.ColumnHeader();
      this.columnOrder = new System.Windows.Forms.ColumnHeader();
      this.SuspendLayout();
      // 
      // listViewLog
      // 
      this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                  this.columnOrder,
                                                                                  this.columnOwns,
                                                                                  this.columnName,
                                                                                  this.columnArtist});
      this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewLog.FullRowSelect = true;
      this.listViewLog.HideSelection = false;
      this.listViewLog.Name = "listViewLog";
      this.listViewLog.Size = new System.Drawing.Size(596, 378);
      this.listViewLog.TabIndex = 1;
      this.listViewLog.View = System.Windows.Forms.View.Details;
      this.listViewLog.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewLog_ColumnClick);
      // 
      // columnOwns
      // 
      this.columnOwns.Text = "*";
      this.columnOwns.Width = 16;
      // 
      // columnName
      // 
      this.columnName.Text = "Name";
      this.columnName.Width = 200;
      // 
      // columnArtist
      // 
      this.columnArtist.Text = "Artist";
      this.columnArtist.Width = 200;
      // 
      // columnOrder
      // 
      this.columnOrder.Text = "#";
      this.columnOrder.Width = 32;
      // 
      // formShowRadioLog
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(596, 378);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.listViewLog});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "formShowRadioLog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Radio Log";
      this.Load += new System.EventHandler(this.formShowRadioLog_Load);
      this.ResumeLayout(false);

    }
    
    #endregion
    
    #endregion
    
    public void LoadRadioLog(string radioLogFile)
    {
      listViewLog.Items.Clear();
      
      StreamReader file = null;
      try
      {
        file = new StreamReader(radioLogFile);
        listViewLog.BeginUpdate();
        int number = 1;
        while (file.Peek() != -1)
        {
          string track = file.ReadLine();
          if (track == null) break;
          track = track.Trim();
          if (track == "") continue;
          
          // Parse track
          bool ownsTrack = false;
          if (track.StartsWith("* "))
          {
            track = track.Substring(2);
            ownsTrack = true;
          }
          int sepIndex = track.IndexOf("-");
          if (sepIndex == -1) sepIndex = track.Length;
          string trackArtist = track.Substring(0, sepIndex).Trim();
          string trackName = track.Substring(sepIndex + 1).Trim();
          
          string ownsString = ( ownsTrack ) ? ( "*" ) : ( "" );
          listViewLog.Items.Add(new ListViewItem(new string [] { number.ToString(), ownsString, trackName, trackArtist }));
          number++;
        }
        try
        {
          listViewLog.EndUpdate();
        }
        catch
        {}
      }
      catch (IOException ex)
      {
        MessageBox.Show(String.Format("Could not read radio log.\n\nError Message:\n{0}", ex.Message), "iTuner", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      finally
      {
        try
        {
          if (file != null)
            file.Close();
        }
        catch
        {}
      }
    }
    
    private void formShowRadioLog_Load(object sender, System.EventArgs e)
    {
      if (listViewLog.Items.Count > 0)
      {
        ListViewItem item = listViewLog.Items[listViewLog.Items.Count - 1];
        item.Selected = true;
        item.Focused = true;
        item.EnsureVisible();
      }
    }

    private void listViewLog_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
      // TODO: Sorting
    }
  }
}
