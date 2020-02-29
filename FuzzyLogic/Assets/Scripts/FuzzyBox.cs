using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FLS;
using FLS.Rules;
using FLS.MembershipFunctions;
public class FuzzyBox : MonoBehaviour {

	bool selected = false;
    IFuzzyEngine engine;
    public GameObject Center;
    Rigidbody rigidbody;
    public float Speedmult = 0.3f;
    LinguisticVariable distance, direction;

    void Start()
	{
        rigidbody = GetComponent<Rigidbody>();
        // Here we need to setup the Fuzzy Inference System
        distance = new LinguisticVariable("distance");
        var farRight = distance.MembershipFunctions.AddTrapezoid("farRight", -100, -100, -60, -45);
        var right = distance.MembershipFunctions.AddTrapezoid("right", -50, -50, -7, -0.05f);
        var none = distance.MembershipFunctions.AddTrapezoid("none", -7, -0.5, 0.5, 7);
        var left = distance.MembershipFunctions.AddTrapezoid("left", 0.05f, 7, 50, 50);
        var farLeft = distance.MembershipFunctions.AddTrapezoid("farLeft", 45, 60, 100, 100);

        direction = new LinguisticVariable("direction");
        var farRightD = direction.MembershipFunctions.AddTrapezoid("farRight", -100, -100, -60, -45);
        var rightD = direction.MembershipFunctions.AddTrapezoid("right", -50, -50, -7, -0.05f);
        var noneD = direction.MembershipFunctions.AddTrapezoid("none", -7, -0.5, 0.5, 7);
        var leftD = direction.MembershipFunctions.AddTrapezoid("left", 0.05f, 7, 50, 50);
        var farLeftD = direction.MembershipFunctions.AddTrapezoid("farLeft", 45, 60, 100, 100);

        engine = new FuzzyEngineFactory().Default();
        var rule0 = Rule.If(distance.Is(farRight)).Then(direction.Is(farLeftD));
        var rule1 = Rule.If(distance.Is(right)).Then(direction.Is(leftD));
        var rule2 = Rule.If(distance.Is(left)).Then(direction.Is(rightD));
        var rule3 = Rule.If(distance.Is(none)).Then(distance.Is(noneD));
        var rule4 = Rule.If(distance.Is(farLeft)).Then(direction.Is(farRightD));

        engine.Rules.Add(rule0, rule1, rule2, rule3, rule4);
    }

	void FixedUpdate()
	{
		if(!selected && this.transform.position.y < 0.6f)
		{
            // Convert position of box to value between 0 and 100
            double result = engine.Defuzzify(new { distance = ((double)this.transform.position.x /*+ (rigidbody.velocity.x * Speedmult)*/ - Center.transform.position.x) });

            rigidbody.AddForce(new Vector3((float)(result), 0f, (float)0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			var hit = new RaycastHit();
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)){
				if (hit.transform.name == "FuzzyBox" )Debug.Log( "You have clicked the FuzzyBox");
				selected = true;
			}
		}

		if(Input.GetMouseButton(0) && selected)
		{
			float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
			transform.position = new Vector3(curPosition.x, Mathf.Max(0.5f, curPosition.y), transform.position.z);
		}

		if(Input.GetMouseButtonUp(0))
		{
			selected = false;
		}
	}
}
