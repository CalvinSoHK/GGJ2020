using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020.Utility
{
    /// <summary>
    /// Contains all enums for our flags.
    /// Add more enums for new flags in the future.
    /// NOTE: MAKE SURE NULL IS THE LAST ENUM
    /// </summary>
    public enum FlagEnum
    {
        IsMean,
        IsNice,
        IsLoving,
        Null
    }

    /// <summary>
    /// Contains all enums for values we need to track.
    /// Add more enums for new values to track
    /// NOTE: MAKE SURE NULL IS THE LAST ENUM
    /// <summary>
    public enum GameEnum
    {
        Temperature,
        Brightness,
        Volume,
        RedX,
        RedY,
        BlueX,
        BlueY,
        YellowX,
        YellowY,
        Null
    }

    /// <summary>
    /// Color enums for the color picker
    /// <summary>
    public enum ColorEnum
    {
        Red,
        Blue,
        Yellow
    }
}
