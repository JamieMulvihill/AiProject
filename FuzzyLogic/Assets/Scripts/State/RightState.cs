using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightState : State
{
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x - (15 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }

    public override void TransitionCheck(GameObject box, GameObject target)
    {
        if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < nearDistance) {
            Debug.Log("Changing to nr from r");
            FiniteStateMachine.ChangeState(new NearRightState());
        }
        else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x > farDistance)
        {
            Debug.Log("Changing to fr from r");
            FiniteStateMachine.ChangeState(new FarRightState());
        }
        else
        {
            Debug.Log("I am right");
        }
    }
}
