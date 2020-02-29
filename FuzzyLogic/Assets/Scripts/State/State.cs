using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
   protected FiniteStateMachine finiteStateMachine;
   public enum positionState
    {
        FarLeft,
        Left,
        NearLeft,
        NearRight,
        Right,
        FarRight
    }
    public virtual void Move(GameObject box) { }
    public virtual void TransitionCheck(GameObject box, GameObject target) { }
    public positionState location;
    protected float farDistance = 24f;
    protected float nearDistance = 8f;
}
