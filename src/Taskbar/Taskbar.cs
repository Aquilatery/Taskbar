#region Imports

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taskbar.Enum;
using Taskbar.Struct;
using Taskbar.Value;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 11.Apr.2021
//     Changed: 12.Apr.2021
//     Version: 1.0.0.4
//
// |---------DO-NOT-REMOVE---------|

namespace Taskbar
{
    #region Core

    /// <summary>
    /// 
    /// </summary>
    public class Taskbar
    {
        #region Shared

        /// <summary>
        /// 
        /// </summary>
        private class Shared
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Screen"></param>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <param name="Type"></param>
            /// <returns></returns>
            public static Point Location(Screen Screen, Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32, Enums.Type Type = Enums.Type.Simple)
            {
                try
                {
                    Enums.LocationType LocationType = Type switch
                    {
                        Enums.Type.Advanced => Advanced.Position,
                        _ => Simple.Detect(Screen),
                    };

                    return Edge switch
                    {
                        Enums.EdgeLocationType.TopLeft => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Pixel, Pixel),
                            Enums.LocationType.Top => new Point(Pixel, Screen.Bounds.Height - Screen.WorkingArea.Height + Pixel),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + Pixel, Pixel),
                            _ => new Point(Pixel, Pixel),
                        },
                        Enums.EdgeLocationType.TopCenter => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point((Screen.Bounds.Width / 2) - (Width / 2), Pixel),
                            Enums.LocationType.Top => new Point((Screen.Bounds.Width / 2) - (Width / 2), Screen.Bounds.Height - Screen.WorkingArea.Height + Pixel),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + (Screen.WorkingArea.Width / 2) - (Width / 2), Pixel),
                            _ => new Point((Screen.WorkingArea.Width / 2) - (Width / 2), Pixel),
                        },
                        Enums.EdgeLocationType.TopRight => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Pixel),
                            Enums.LocationType.Top => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Screen.Bounds.Height - Screen.WorkingArea.Height + Pixel),
                            Enums.LocationType.Left => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Pixel),
                            _ => new Point(Screen.WorkingArea.Width - (Width + Pixel), Pixel),
                        },
                        Enums.EdgeLocationType.BotLeft => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Pixel, Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Top => new Point(Pixel, Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + Pixel, Screen.WorkingArea.Height - (Height + Pixel)),
                            _ => new Point(Pixel, Screen.WorkingArea.Height - (Height + Pixel)),
                        },
                        Enums.EdgeLocationType.BotCenter => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point((Screen.Bounds.Width / 2) - (Width / 2), Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Top => new Point((Screen.Bounds.Width / 2) - (Width / 2), Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + (Screen.WorkingArea.Width / 2) - (Width / 2), Screen.WorkingArea.Height - (Height + Pixel)),
                            _ => new Point((Screen.WorkingArea.Width / 2) - (Width / 2), Screen.WorkingArea.Height - (Height + Pixel)),
                        },
                        Enums.EdgeLocationType.BotRight => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Top => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Screen.WorkingArea.Height - (Height - (Screen.Bounds.Height - Screen.WorkingArea.Height) + Pixel)),
                            Enums.LocationType.Left => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Screen.WorkingArea.Height - (Height + Pixel)),
                            _ => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), Screen.WorkingArea.Height - (Height + Pixel)),
                        },
                        Enums.EdgeLocationType.LeftCenter => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Pixel, (Screen.Bounds.Height / 2) - (Height / 2) - (Screen.Bounds.Height - Screen.WorkingArea.Height) / 2),
                            Enums.LocationType.Top => new Point(Pixel, Screen.Bounds.Height - Screen.WorkingArea.Height + (Screen.WorkingArea.Height / 2) - (Height / 2)),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + Pixel, (Screen.Bounds.Height / 2) - (Height / 2)),
                            _ => new Point(Pixel, (Screen.Bounds.Height / 2) - (Height / 2)),
                        },
                        Enums.EdgeLocationType.RightCenter => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point(Screen.WorkingArea.Width - (Width + Pixel), (Screen.Bounds.Height / 2) - (Height / 2) - (Screen.Bounds.Height - Screen.WorkingArea.Height) / 2),
                            Enums.LocationType.Top => new Point(Screen.WorkingArea.Width - (Width + Pixel), Screen.Bounds.Height - Screen.WorkingArea.Height + (Screen.WorkingArea.Height / 2) - (Height / 2)),
                            Enums.LocationType.Left => new Point(Screen.WorkingArea.Width - (Width - (Screen.Bounds.Width - Screen.WorkingArea.Width) + Pixel), (Screen.Bounds.Height / 2) - (Height / 2)),
                            _ => new Point(Screen.WorkingArea.Width - (Width + Pixel), (Screen.Bounds.Height / 2) - (Height / 2)),
                        },
                        Enums.EdgeLocationType.CalcCenter => LocationType switch
                        {
                            Enums.LocationType.Bot => new Point((Screen.Bounds.Width / 2) - (Width / 2), (Screen.Bounds.Height / 2) - (Height / 2) - (Screen.Bounds.Height - Screen.WorkingArea.Height) / 2),
                            Enums.LocationType.Top => new Point((Screen.Bounds.Width / 2) - (Width / 2), Screen.Bounds.Height - Screen.WorkingArea.Height + (Screen.WorkingArea.Height / 2) - (Height / 2)),
                            Enums.LocationType.Left => new Point(Screen.Bounds.Width - Screen.WorkingArea.Width + (Screen.WorkingArea.Width / 2) - (Width / 2), (Screen.Bounds.Height / 2) - (Height / 2)),
                            _ => new Point((Screen.Bounds.Width / 2) - (Width / 2) - (Screen.Bounds.Width - Screen.WorkingArea.Width) / 2, (Screen.Bounds.Height / 2) - (Height / 2)),
                        },
                        _ => new Point((Screen.Bounds.Width / 2) - (Width / 2), (Screen.Bounds.Height / 2) - (Height / 2)),
                    };
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }
        }

        #endregion

        #region Simple Taskbar
        /// <summary>
        /// 
        /// </summary>
        public class Simple
        {
            /// <summary>
            /// Gets detect screen taskbar location.
            /// </summary>
            /// <param name="Screen"></param>
            /// <returns></returns>
            public static Enums.LocationType Detect(Screen Screen)
            {
                try
                {
                    if (Screen.WorkingArea.Width == Screen.Bounds.Width)
                    {
                        if (Screen.WorkingArea.Top > 0)
                        {
                            return Enums.LocationType.Top;
                        }
                        else
                        {
                            return Enums.LocationType.Bot;
                        }
                    }
                    else
                    {
                        if (Screen.WorkingArea.Left > 0)
                        {
                            return Enums.LocationType.Left;
                        }
                        else
                        {
                            return Enums.LocationType.Right;
                        }
                    }
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// Gets detect primary screen taskbar location.
            /// </summary>
            public static Enums.LocationType SingleDetect
            {
                get
                {
                    try
                    {
                        return Detect(Screen.PrimaryScreen);
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets detect multiple screen taskbar location list value.
            /// </summary>
            public static List<Enums.LocationType> MultiDetectList
            {
                get
                {
                    try
                    {
                        List<Enums.LocationType> Result = new();

                        foreach (Screen Screen in Screen.AllScreens)
                        {
                            Result.Add(Detect(Screen));
                        }

                        return Result;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets detect multiple screen taskbar location dictionary value.
            /// </summary>
            public static Dictionary<int, Enums.LocationType> MultiDetectDictionary
            {
                get
                {
                    try
                    {
                        Dictionary<int, Enums.LocationType> Result = new();
                        int Count = 0;

                        foreach (Screen Screen in Screen.AllScreens)
                        {
                            Result.Add(Count++, Detect(Screen));
                        }

                        return Result;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Screen"></param>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static Point Location(Screen Screen, Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    return Shared.Location(Screen, Edge, Width, Height, Pixel, Enums.Type.Simple);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static Point SingleLocation(Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    return Location(Screen.PrimaryScreen, Edge, Width, Height, Pixel);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static List<Point> MultiLocationList(Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    List<Point> Result = new();

                    foreach (Screen Screen in Screen.AllScreens)
                    {
                        Result.Add(Location(Screen, Edge, Width, Height, Pixel));
                    }

                    return Result;
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static Dictionary<int, Point> MultiLocationDictionary(Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    Dictionary<int, Point> Result = new();
                    int Count = 0;

                    foreach (Screen Screen in Screen.AllScreens)
                    {
                        Result.Add(Count++, Location(Screen, Edge, Width, Height, Pixel));
                    }

                    return Result;
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }
        }
        #endregion

        #region Advanced Taskbar
        /// <summary>
        /// 
        /// </summary>
        public class Advanced
        {
            #region DLL Imports

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetWindowRect(IntPtr hWnd, ref Structs.Rectangle lpRect);

            [DllImport("shell32.dll", SetLastError = true)]
            private static extern IntPtr SHAppBarMessage(Enums.MessageType dwMessage, [In] ref Structs.Data pData);

            [DllImport("user32.dll")]
            private static extern int ShowWindow(IntPtr hwnd, int command);

            #endregion

            /// <summary>
            /// Static initializer of the <see cref="Advanced" /> class.
            /// </summary>
            static Advanced()
            {
                try
                {
                    Values.BarData = new Structs.Data
                    {
                        cbSize = (uint)Marshal.SizeOf(typeof(Structs.Data)),
                        hWnd = FindWindow(Values.ClassName, null)
                    };

                    //Get the taskbar window rect in screen coordinates
                    _ = GetWindowRect(Handle, ref Values.BarData.Rect);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// Gets a data value.
            /// </summary>
            public static Structs.Data Data
            {
                get
                {
                    try
                    {
                        return Values.BarData;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets a value indicating whether the taskbar is always on top of other windows.
            /// </summary>
            /// <value><c>true</c> if the taskbar is always on top of other windows; otherwise, <c>false</c>.</value>
            /// <remarks>This property always returns <c>false</c> on Windows 7 and newer.</remarks>
            /// <returns></returns>
            public static bool AlwaysOnTop
            {
                get
                {
                    try
                    {
                        int State = SHAppBarMessage(Enums.MessageType.GetState, ref Values.BarData).ToInt32();
                        return !((Enums.ShowStateType)State).HasFlag(Enums.ShowStateType.Show);
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets a value indicating whether the taskbar is automatically hidden when inactive.
            /// </summary>
            /// <value><c>true</c> if the taskbar is set to auto-hide is enabled; otherwise, <c>false</c>.</value>
            /// <returns></returns>
            public static bool AutoHide
            {
                get
                {
                    try
                    {
                        int State = SHAppBarMessage(Enums.MessageType.GetState, ref Values.BarData).ToInt32();
                        return ((Enums.HideStateType)State).HasFlag(Enums.HideStateType.Hide);
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets the current display bounds of the taskbar.
            /// </summary>
            public static Rectangle CurrentBounds
            {
                get
                {
                    try
                    {
                        Structs.Rectangle Rect = new();
                        if (GetWindowRect(Handle, ref Rect))
                        {
                            return Rectangle.FromLTRB(Rect.Left, Rect.Top, Rect.Right, Rect.Bot);
                        }

                        return Rectangle.Empty;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets the display bounds when the taskbar is fully visible.
            /// </summary>
            public static Rectangle DisplayBounds
            {
                get
                {
                    try
                    {
                        if (RefreshAll())
                        {
                            return Rectangle.FromLTRB(Values.BarData.Rect.Left, Values.BarData.Rect.Top, Values.BarData.Rect.Right, Values.BarData.Rect.Bot);
                        }

                        return CurrentBounds;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets the taskbar's window handle.
            /// </summary>
            public static IntPtr Handle
            {
                get
                {
                    try
                    {
                        return Values.BarData.hWnd;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Gets the taskbar's position on the screen.
            /// </summary>
            public static Enums.LocationType Position
            {
                get
                {
                    try
                    {
                        if (RefreshAll())
                        {
                            return (Enums.LocationType)Values.BarData.uEdge;
                        }

                        return Enums.LocationType.Unknown;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Hides the taskbar.
            /// </summary>
            public static void Hide()
            {
                try
                {
                    const int SW_HIDE = 0;
                    _ = ShowWindow(Handle, SW_HIDE);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// Shows the taskbar.
            /// </summary>
            public static void Show()
            {
                try
                {
                    const int SW_SHOW = 1;
                    _ = ShowWindow(Handle, SW_SHOW);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// Gets taskbar size.
            /// </summary>
            /// <returns></returns>
            public static Size Size
            {
                get
                {
                    try
                    {
                        //Detecting position
                        //width - height
                        return new(0, 0);
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Screen"></param>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static Point Location(Screen Screen, Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    return Shared.Location(Screen, Edge, Width, Height, Pixel, Enums.Type.Advanced);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Edge"></param>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            /// <param name="Pixel"></param>
            /// <returns></returns>
            public static Point SingleLocation(Enums.EdgeLocationType Edge, int Width, int Height, int Pixel = 32)
            {
                try
                {
                    return Location(Screen.PrimaryScreen, Edge, Width, Height, Pixel);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Screen"></param>
            /// <returns></returns>
            public static Rectangle FindDockedTaskbar(Screen Screen)
            {
                try
                {
                    Rectangle Rect = new();

                    int LeftDockedWidth = Math.Abs(Math.Abs(Screen.Bounds.Left) - Math.Abs(Screen.WorkingArea.Left));
                    int TopDockedHeight = Math.Abs(Math.Abs(Screen.Bounds.Top) - Math.Abs(Screen.WorkingArea.Top));
                    int RightDockedWidth = Screen.Bounds.Width - LeftDockedWidth - Screen.WorkingArea.Width;
                    int BotDockedHeight = Screen.Bounds.Height - TopDockedHeight - Screen.WorkingArea.Height;

                    if (LeftDockedWidth > 0)
                    {
                        Rect.X = Screen.Bounds.Left;
                        Rect.Y = Screen.Bounds.Top;
                        Rect.Width = LeftDockedWidth;
                        Rect.Height = Screen.Bounds.Height;
                    }
                    else if (RightDockedWidth > 0)
                    {
                        Rect.X = Screen.WorkingArea.Right;
                        Rect.Y = Screen.Bounds.Top;
                        Rect.Width = RightDockedWidth;
                        Rect.Height = Screen.Bounds.Height;
                    }
                    else if (TopDockedHeight > 0)
                    {
                        Rect.X = Screen.WorkingArea.Left;
                        Rect.Y = Screen.Bounds.Top;
                        Rect.Width = Screen.WorkingArea.Width;
                        Rect.Height = TopDockedHeight;
                    }
                    else if (BotDockedHeight > 0)
                    {
                        Rect.X = Screen.WorkingArea.Left;
                        Rect.Y = Screen.WorkingArea.Bottom;
                        Rect.Width = Screen.WorkingArea.Width;
                        Rect.Height = BotDockedHeight;
                    }
                    else
                    {
                        //throw new Exception(Values.Nothing);

                        Rect.X = Screen.WorkingArea.Left;
                        Rect.Y = Screen.WorkingArea.Top;
                        Rect.Width = Screen.WorkingArea.Width;
                        Rect.Height = Screen.WorkingArea.Height;
                    }

                    return Rect;
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static List<Rectangle> FindDockedTaskbarsList
            {
                get
                {
                    try
                    {
                        List<Rectangle> DockedRects = new();

                        foreach (Screen Screen in Screen.AllScreens)
                        {
                            /*
                            if (!Screen.Bounds.Equals(Screen.WorkingArea))
                            {
                                DockedRects.Add(FindDockedTaskbar(Screen));
                            }
                            */
                            DockedRects.Add(FindDockedTaskbar(Screen));
                        }

                        if (DockedRects.Count == 0)
                        {
                            //throw new Exception(Values.AutoHide);
                        }

                        return DockedRects;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static Dictionary<int, Rectangle> FindDockedTaskbarsDictionary
            {
                get
                {
                    try
                    {
                        Dictionary<int, Rectangle> DockedRects = new();
                        int Count = 0;

                        foreach (Screen Screen in Screen.AllScreens)
                        {
                            /*
                            if (!Screen.Bounds.Equals(Screen.WorkingArea))
                            {
                                DockedRects.Add(Count++, FindDockedTaskbar(Screen));
                            }
                            */
                            DockedRects.Add(Count++, FindDockedTaskbar(Screen));
                        }

                        if (DockedRects.Count == 0)
                        {
                            //throw new Exception(Values.AutoHide);
                        }

                        return DockedRects;
                    }
                    catch
                    {
                        throw new Exception(Values.Exception);
                    }
                }
            }

            /// <summary>
            /// Refresh data value.
            /// </summary>
            /// <returns></returns>
            public static bool RefreshData()
            {
                try
                {
                    Values.BarData = new Structs.Data
                    {
                        cbSize = (uint)Marshal.SizeOf(typeof(Structs.Data)),
                        hWnd = FindWindow(Values.ClassName, null)
                    };

                    //Get the taskbar window rect in screen coordinates
                    return GetWindowRect(Values.BarData.hWnd, ref Values.BarData.Rect);
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }

            /// <summary>
            /// Refresh all value.
            /// </summary>
            /// <returns></returns>
            public static bool RefreshAll()
            {
                try
                {
                    RefreshData();

                    //! SHAppBarMessage returns IntPtr.Zero **if it fails**
                    return SHAppBarMessage(Enums.MessageType.GetTaskbarPos, ref Values.BarData) != IntPtr.Zero;
                }
                catch
                {
                    throw new Exception(Values.Exception);
                }
            }
        }
        #endregion
    }

    #endregion
}