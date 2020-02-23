using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

   public enum positionState
    {
        FarLeft,
        Left,
        NearLeft,
        NearRight,
        Right,
        FarRight
    }

    public virtual void Init(bool direction, bool distance) { }
    public virtual void Move(GameObject box) { }
    public positionState location;
}
