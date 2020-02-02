using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that all patients will use
/// </summary>
public interface IPatient
{
    void Init();
    bool isFirstCheckpoint();
    bool isSecondCheckpoint();
    bool isThirdCheckpoint();
    void Complete();
}
