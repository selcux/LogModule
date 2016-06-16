﻿using System;

namespace LogModule
{
    [Flags]
    public enum LogType : byte
    {
        None = 0,
        Error = 0x1,
        Debug = Error << 1,
        Info = Debug << 1
    }
}