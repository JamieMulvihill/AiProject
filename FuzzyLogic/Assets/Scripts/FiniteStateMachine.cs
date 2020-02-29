using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public GameObject target;
    public GameObject box;
    float farDistance = 24f;
    float nearDistance = 8f; 
    static State currentState;
    private Vector3 position;
    State.positionState state;
    private void Start()
    {
        currentState = new FarRightState();
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Move(box);
        currentState.TransitionCheck(box, target);

        //if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x > -nearDistance) {    
        //    currentState = new NearLeftState();
        //    currentState.Move(box);
        //}
        //else if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x > -farDistance){
        //    currentState = new LeftState();
        //    currentState.Move(box);
        //}
        //else if (box.transform.position.x < target.transform.position.x && box.transform.position.x - target.transform.position.x < -farDistance)
        //{
        //    currentState = new FarLeftState();
        //    currentState.Move(box);
        //}
        //else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < nearDistance)
        //{
        //    currentState = new NearRightState();
        //    currentState.Move(box);
        //}
        //else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x < farDistance)
        //{
        //    currentState = new RightState();
        //    currentState.Move(box);
        //}
        //else if (box.transform.position.x > target.transform.position.x && box.transform.position.x - target.transform.position.x > farDistance)
        //{
        //    currentState = new FarRightState();
        //    currentState.Move(box);
        //}
    }
    static public void ChangeState(State state)
    {
        currentState = state;
    }
}
