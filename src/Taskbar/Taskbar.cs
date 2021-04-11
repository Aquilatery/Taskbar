#region Imports

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taskbar.Enum;
using Taskbar.Struct;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Taiizor.com
//     Created: 11.Apr.2021
//     Changed: 11.Apr.2021
//     Version: 1.0.0.2
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
        #region Values
        /// <summary>
        /// 
        /// </summary>
        private const string Exception = "An unexpected error occurred.";

        /// <summary>
        /// 
        /// </summary>
        private const string ClassName = "Shell_TrayWnd";

        /// <summary>
        /// 
        /// </summary>
        private static Structs.Data BarData;
        #endregion

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
                    throw new Exception(Exception);
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
                        throw new Exception(Exception);
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
                        throw new Exception(Exception);
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
                        throw new Exception(Exception);
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

            [DllImport("user32.dll", SetLastError = true)]
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
                    BarData = new Structs.Data
                    {
                        cbSize = (uint)Marshal.SizeOf(typeof(Structs.Data)),
                        hWnd = FindWindow(ClassName, null)
                    };
                }
                catch
                {
                    throw new Exception(Exception);
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
                        int state = SHAppBarMessage(Enums.MessageType.GetState, ref BarData).ToInt32();
                        return !((Enums.ShowStateType)state).HasFlag(Enums.ShowStateType.Show);
                    }
                    catch
                    {
                        throw new Exception(Exception);
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
                        int state = SHAppBarMessage(Enums.MessageType.GetState, ref BarData).ToInt32();
                        return ((Enums.HideStateType)state).HasFlag(Enums.HideStateType.Hide);
                    }
                    catch
                    {
                        throw new Exception(Exception);
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
                        Structs.Rectangle rect = new();
                        if (GetWindowRect(Handle, ref rect))
                        {
                            return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
                        }

                        return Rectangle.Empty;
                    }
                    catch
                    {
                        throw new Exception(Exception);
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
                            return Rectangle.FromLTRB(BarData.rect.Left, BarData.rect.Top, BarData.rect.Right, BarData.rect.Bottom);
                        }

                        return CurrentBounds;
                    }
                    catch
                    {
                        throw new Exception(Exception);
                    }
                }
            }

            /// <summary>
            /// Gets the taskbar's window handle.
            /// </summary>
            private static IntPtr Handle
            {
                get
                {
                    try
                    {
                        return BarData.hWnd;
                    }
                    catch
                    {
                        throw new Exception(Exception);
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
                            return (Enums.LocationType)BarData.uEdge;
                        }

                        return Enums.LocationType.Unknown;
                    }
                    catch
                    {
                        throw new Exception(Exception);
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
                    ShowWindow(Handle, SW_HIDE);
                }
                catch
                {
                    throw new Exception(Exception);
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
                    ShowWindow(Handle, SW_SHOW);
                }
                catch
                {
                    throw new Exception(Exception);
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
                    return SHAppBarMessage(Enums.MessageType.GetTaskbarPos, ref BarData) != IntPtr.Zero;
                }
                catch
                {
                    throw new Exception(Exception);
                }
            }
        }
        #endregion
    }

    #endregion
}