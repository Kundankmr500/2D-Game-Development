using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    WALK,
    RUN,
    ATTACK,
    JUMP
}


public class AnimationName
{
    public const string WALK = "Walk";
    public const string IDLE = "Idle";
    public const string RUN = "Run";
    public const string ATTACK = "Attack";
    public const string JUMP = "Jump";
}
