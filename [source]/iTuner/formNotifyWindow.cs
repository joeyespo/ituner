using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iTuner
{
  public partial class formNotifyWindow : Form
  {
    iTunerSettings settings = new iTunerSettings();

    public formNotifyWindow()
    {
      InitializeComponent();
    }
    public formNotifyWindow(iTunerSettings settings)
      : this()
    {
      this.settings = settings;
    }

    private void formNotifyWindow_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.Clear(settings.BackgroundColor);
      using (Pen pen = new Pen(settings.BorderColor))
        e.Graphics.DrawRectangle(pen, new Rectangle(new Point(0, 0), this.Size));
    }
  }
}
