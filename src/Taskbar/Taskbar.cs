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
//     Changed: 11.Apr.2021
//     Version: 1.0.0.3
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
        #region Simple Taskbar
        /// <summary>
        /// 
        /// </summary>
        public class Simple
        {
            /// <summary>
            /// 
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
            /// 
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
            /// 
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
                }
                catch
                {
                    throw new Exception(Values.Exception);
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
                        if (RefreshBoundsAndPosition())
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
                        if (RefreshBoundsAndPosition())
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
            /// 
            /// </summary>
            /// <returns></returns>
            private static bool RefreshBoundsAndPosition()
            {
                try
                {
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