using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace iTuner
{
  public class iTunerSettings
  {
    int notifyWindowHideDelay = 10;
    bool notifyWindowUseFading = true;
    bool notifyWindowShowArtworkThumbnail = true;
    bool notifyWindowShowArtworkBackground = true;
    string notifyWindowFormatHeaderLeftText = "{index}/{total} ({playlist})";
    string notifyWindowFormatHeaderCenterText = "{index}/{total} ({playlist})";
    string notifyWindowFormatHeaderRightText = "{status}";
    string notifyWindowFormatFooterLeftText = "{index}/{total} ({playlist})";
    string notifyWindowFormatFooterCenterText = "{index}/{total} ({playlist})";
    string notifyWindowFormatFooterRightText = "{status}";
    string notifyWindowFormatBodyText = "{title} ({time})\n{artist}\n{author}";
    string quickFormatText = "{author} - {title}";
    Color backgroundColor = Color.AliceBlue;
    Color borderColor = Color.Black;

    public iTunerSettings()
    {
    }

    #region Public Properties

    public int NotifyWindowHideDelay
    {
      get { return notifyWindowHideDelay; }
      set { notifyWindowHideDelay = value; }
    }

    public bool NotifyWindowUseFading
    {
      get { return notifyWindowUseFading; }
      set { notifyWindowUseFading = value; }
    }

    public bool NotifyWindowShowArtworkThumbnail
    {
      get { return notifyWindowShowArtworkThumbnail; }
      set { notifyWindowShowArtworkThumbnail = value; }
    }

    public bool NotifyWindowShowArtworkBackground
    {
      get { return notifyWindowShowArtworkBackground; }
      set { notifyWindowShowArtworkBackground = value; }
    }

    public string NotifyWindowFormatHeaderLeftText
    {
      get { return notifyWindowFormatHeaderLeftText; }
      set { notifyWindowFormatHeaderLeftText = value; }
    }

    public string NotifyWindowFormatHeaderCenterText
    {
      get { return notifyWindowFormatHeaderCenterText; }
      set { notifyWindowFormatHeaderCenterText = value; }
    }

    public string NotifyWindowFormatHeaderRightText
    {
      get { return notifyWindowFormatHeaderRightText; }
      set { notifyWindowFormatHeaderRightText = value; }
    }

    public string NotifyWindowFormatFooterLeftText
    {
      get { return notifyWindowFormatFooterLeftText; }
      set { notifyWindowFormatFooterLeftText = value; }
    }

    public string NotifyWindowFormatFooterCenterText
    {
      get { return notifyWindowFormatFooterCenterText; }
      set { notifyWindowFormatFooterCenterText = value; }
    }

    public string NotifyWindowFormatFooterRightText
    {
      get { return notifyWindowFormatFooterRightText; }
      set { notifyWindowFormatFooterRightText = value; }
    }

    public string NotifyWindowFormatBodyText
    {
      get { return notifyWindowFormatBodyText; }
      set { notifyWindowFormatBodyText = value; }
    }

    public string QuickFormatText
    {
      get { return quickFormatText; }
      set { quickFormatText = value; }
    }

    public Color BackgroundColor
    {
      get { return backgroundColor; }
      set { backgroundColor = value; }
    }

    public Color BorderColor
    {
      get { return borderColor; }
      set { borderColor = value; }
    }

    #endregion

  }
}
