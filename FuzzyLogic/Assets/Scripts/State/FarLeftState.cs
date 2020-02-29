using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarLeftState : State
{
    public override void Move(GameObject box) {
        box.transform.position = new Vector3(box.transform.position.x + (25 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }

    public override void TransitionCheck(GameObject box, GameObject target)
    {
       if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x > -farDistance)
        {

            FiniteStateMachine.ChangeState(new LeftState());
        }
    }

}

