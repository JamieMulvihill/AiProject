using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftState : State {
  
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x + (15 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }

    public override void TransitionCheck(GameObject box, GameObject target)
    {
        if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x > -nearDistance){

            Debug.Log("Changing to nl from left");
            FiniteStateMachine.ChangeState(new NearLeftState());
        }
       
        else if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x < -farDistance){

            Debug.Log("Changing to FarL from left");
            FiniteStateMachine.ChangeState(new FarLeftState());
        }
        else
        {
            Debug.Log("I am Left");
        }
    }
}
