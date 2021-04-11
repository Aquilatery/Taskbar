#region Imports

using System;
using System.Runtime.InteropServices;
using Taskbar.Enum;

#endregion

namespace Taskbar.Struct
{
    /// <summary>
    /// 
    /// </summary>
    public class Structs
    {
        #region Structs
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Data
        {
            public uint cbSize;
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public Enums.EdgeType uEdge;
            public Rectangle rect;
            public int lParam;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Rectangle
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion
    }
}