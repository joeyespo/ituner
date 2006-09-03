/*
 * Package:			iTunes
 * File:			Win32.cs
 * Programmer:		Adam Durity
 * Date:			07/11/2004
 * License:			Copyright © 2004 Adam Durity
 * Description:		Win32 Interop declarations for use in the iTunes Tray app.
 */

using System;
using System.Runtime.InteropServices;

/// <summary>
/// Summary description for Win32.
/// </summary>
public class Win32
{
  
  public const int WM_HOTKEY = unchecked( (int)(0x312) );
  
  public enum AnimateStyles 
	{
		Show =					0x00000000,
		Slide =					0x00040000,
		Activate =				0x00020000,
		Blend =					0x00080000,
		Hide =					0x00010000, 
		Center =				0x00000010,
		HorizontalPositive =	0x00000001,
		HorizontalNegative =	0x00000002,
		VerticalPositive =		0x00000004,
		VerticalNegative =		0x00000008
	}

	public enum ShowWindowCommands
	{
		Hide =				0,
		ShowNormal =		1,
		ShowMinimized =		2,
		ShowMaximized =		3,
		ShowNoActivate =	4,
		Show =				5,
		Minimize =			6,
		ShowMinNoActive =	7,
		ShowNA =			8,
		Restore =			9,
	}

	[DllImport("user32.dll")]
	public static extern bool AnimateWindow(IntPtr hWnd, uint time, AnimateStyles flags);

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
  
  
  public const int MOD_ALT = unchecked( (int)(0x1) );
  public const int MOD_CONTROL = unchecked( (int)(0x2) );
  public const int MOD_SHIFT = unchecked( (int)(0x4) );
  
  [DllImport("user32", EntryPoint="RegisterHotKey", SetLastError=true, CharSet=CharSet.Auto, ExactSpelling=false, CallingConvention=CallingConvention.Winapi)]
  public static extern int RegisterHotKey ( IntPtr hWnd, int id, int fsModifiers, int vk );
  
  [DllImport("user32", EntryPoint="UnregisterHotKey", SetLastError=true, CharSet=CharSet.Auto, ExactSpelling=false, CallingConvention=CallingConvention.Winapi)]
  public static extern int UnregisterHotKey ( IntPtr hWnd, int id );
  
  [DllImport("kernel32", EntryPoint="GlobalAddAtom", SetLastError=true, CharSet=CharSet.Auto, ExactSpelling=false, CallingConvention=CallingConvention.Winapi)]
  public static extern int GlobalAddAtom ( string lpString );
  
  [DllImport("kernel32", EntryPoint="GlobalDeleteAtom", SetLastError=true, CharSet=CharSet.Auto, ExactSpelling=false, CallingConvention=CallingConvention.Winapi)]
  public static extern int GlobalDeleteAtom ( int nAtom );
}
