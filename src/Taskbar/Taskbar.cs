#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Taskbar.Enum;

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

    public class Taskbar
    {
        /// <summary>
        /// 
        /// </summary>
        private const string Exception = "It only works on the Windows platform.";
        /// <summary>
        /// 
        /// </summary>
        private const string OnlyWindows = "It only works on the Windows platform.";

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
            private static Enums.LocationType Detect(Screen Screen)
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

            /// <summary>
            /// 
            /// </summary>
            public static Enums.LocationType SingleDetect
            {
                get
                {
                    try
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            return Detect(Screen.PrimaryScreen);
                        }
                        else
                        {
                            throw new Exception(OnlyWindows);
                        }
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
            public static Dictionary<int, Enums.LocationType> MultiDetect
            {
                get
                {
                    try
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            Dictionary<int, Enums.LocationType> Type = new();
                            int Count = 0;

                            foreach (Screen Screen in Screen.AllScreens)
                            {
                                Type.Add(Count++, Detect(Screen));
                            }

                            return Type;
                        }
                        else
                        {
                            throw new Exception(OnlyWindows);
                        }
                    }
                    catch
                    {
                        throw new Exception(Exception);
                    }
                }
            }
        }
    }

    #endregion
}