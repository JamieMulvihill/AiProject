using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearRightState : State
{
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x - (5 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }

    public override void TransitionCheck(GameObject box, GameObject target)
    {
        if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < .5)
        {
            Debug.Log("Changing to centre from nr");
            FiniteStateMachine.ChangeState(new CentreState());
        }

        else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < farDistance && box.transform.position.x - target.transform.position.x > nearDistance)
        {
            Debug.Log("Changing to right from nr");
            FiniteStateMachine.ChangeState(new RightState());
        }
        else
        {
            Debug.Log("I am near right");
        }
    }
}
