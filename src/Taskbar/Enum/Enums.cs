namespace Taskbar.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public class Enums
    {
        #region Enums
        /// <summary>
        /// 
        /// </summary>
        public enum LocationType
        {
            /// <summary>
            /// 
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// 
            /// </summary>
            Left,
            /// <summary>
            /// 
            /// </summary>
            Top,
            /// <summary>
            /// 
            /// </summary>
            Right,
            /// <summary>
            /// 
            /// </summary>
            Bot
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EdgeType : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Left = 0,
            /// <summary>
            /// 
            /// </summary>
            Top = 1,
            /// <summary>
            /// 
            /// </summary>
            Right = 2,
            /// <summary>
            /// 
            /// </summary>
            Bot = 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MessageType : uint
        {
            /// <summary>
            /// 
            /// </summary>
            New = 0x00000000,
            /// <summary>
            /// 
            /// </summary>
            Remove = 0x00000001,
            /// <summary>
            /// 
            /// </summary>
            QueryPos = 0x00000002,
            /// <summary>
            /// 
            /// </summary>
            SetPos = 0x00000003,
            /// <summary>
            /// 
            /// </summary>
            GetState = 0x00000004,
            /// <summary>
            /// 
            /// </summary>
            GetTaskbarPos = 0x00000005,
            /// <summary>
            /// 
            /// </summary>
            Activate = 0x00000006,
            /// <summary>
            /// 
            /// </summary>
            GetAutoHideBar = 0x00000007,
            /// <summary>
            /// 
            /// </summary>
            SetAutoHideBar = 0x00000008,
            /// <summary>
            /// 
            /// </summary>
            WindowPosChanged = 0x00000009,
            /// <summary>
            /// 
            /// </summary>
            SetState = 0x0000000A,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ShowStateType : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Hide = 0x00,
            /// <summary>
            /// 
            /// </summary>
            Show = 0x01
        }

        /// <summary>
        /// 
        /// </summary>
        public enum HideStateType : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Hide = 0x01,
            /// <summary>
            /// 
            /// </summary>
            Show = 0x02
        }
        #endregion
    }
}