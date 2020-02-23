using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearRightState : State
{
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x - (5 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }
}
