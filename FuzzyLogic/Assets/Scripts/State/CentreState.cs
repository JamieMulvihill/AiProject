using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreState : State
{
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x + 0, box.transform.position.y, box.transform.position.z);
    }

    public override void TransitionCheck(GameObject box, GameObject target)
    {
        if (Mathf.Abs(box.transform.position.x - target.transform.position.x) < .5)
        {
            Debug.Log("Im in the centre");
        }

        else if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x > -nearDistance)
        {

            FiniteStateMachine.ChangeState(new NearLeftState());
        }

        else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < nearDistance)
        {

            FiniteStateMachine.ChangeState(new NearRightState());
        }
    }
}
