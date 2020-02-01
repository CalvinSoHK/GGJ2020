using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that forces a UI script to be able to send messages
/// </summary>
public interface IMessagable
{
    /// <summary>
    /// Sends message to gameStateManager, implemented especially for you.
    /// <summary>
    void SendMessage(GameStateSystem gameStateSystem);
}
