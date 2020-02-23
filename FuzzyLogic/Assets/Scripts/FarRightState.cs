using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarRightState : State
{
    public override void Move(GameObject box)
    {
        box.transform.position = new Vector3(box.transform.position.x - (25 * Time.deltaTime), box.transform.position.y, box.transform.position.z);
    }
}
