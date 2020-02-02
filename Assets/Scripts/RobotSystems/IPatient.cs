using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

/// <summary>
/// Interface that all patients will use
/// </summary>
public interface IPatient
{
    void Init();
    RobotType GetRobotType();
    CheckPointProgress GetCheckpointProgress();
    bool isFirstCheckpoint();
    bool isSecondCheckpoint();
    bool isThirdCheckpoint();
    void Complete();
}
