using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class kom : MonoBehaviour {
	private Vector3 startingPosition;
	private Vector3 handLast;
	private Vector3 handDelta;
	private bool Inspected = false;
	private bool Vignetted = false;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;
	public GameObject hand;
	public float flingForce = 5.0f;
	public bool inspectItem;
	public float grabSpeed = 20.0f;
	public float grabBuffer = 0.1f;
	public bool vignette;
	public GameObject scrim;

	void Start() {
		startingPosition = transform.localPosition;
		SetGazedAt(false);
		handLast = hand.transform.position;
		Inspected = false;
	}

	void Update() {
		handDelta = hand.transform.position - handLast;
		handLast = hand.transform.position;

		if (Inspected == true && Vector3.Distance(hand.transform.position,gameObject.transform.position) > grabBuffer) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hand.transform.position, grabSpeed*Time.deltaTime); 
		}
		if (Inspected == true && Vector3.Distance(hand.transform.position,gameObject.transform.position) <= grabBuffer) {
			Inspected = false;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.AddComponent<ConfigurableJoint> ();
			gameObject.GetComponent<ConfigurableJoint> ().connectedBody = hand.GetComponent<Rigidbody> ();
			gameObject.GetComponent<ConfigurableJoint> ().breakForce = 1000;
			gameObject.GetComponent<ConfigurableJoint> ().xMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().zMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularXMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularYMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularZMotion = ConfigurableJointMotion.Locked;		
		}
		if (Vignetted == false && vignette == true && Inspected == true && Vector3.Distance(hand.transform.position,gameObject.transform.position) <= grabBuffer) {
			Vignetted = true;
			Inspected = false;
			gameObject.transform.parent = scrim.transform;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.AddComponent<ConfigurableJoint> ();
			gameObject.GetComponent<ConfigurableJoint> ().connectedBody = hand.GetComponent<Rigidbody> ();
			gameObject.GetComponent<ConfigurableJoint> ().breakForce = 1000;
			gameObject.GetComponent<ConfigurableJoint> ().xMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().zMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularXMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularYMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularZMotion = ConfigurableJointMotion.Locked;		
		}
	}

	void lateUpdate() {
        

	}

	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
	}

	public void Reset() {
		transform.localPosition = startingPosition;
	}

	public void Grabbed() {

		if (inspectItem == true && Vector3.Distance(hand.transform.position,gameObject.transform.position) > grabBuffer) {
			Inspected = true;
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

		if (inspectItem == false || Vector3.Distance(hand.transform.position,gameObject.transform.position) <= grabBuffer) {
			Inspected = false;
			gameObject.AddComponent<ConfigurableJoint> ();
			gameObject.GetComponent<ConfigurableJoint> ().connectedBody = hand.GetComponent<Rigidbody> ();
			gameObject.GetComponent<ConfigurableJoint> ().breakForce = 1000;
			gameObject.GetComponent<ConfigurableJoint> ().xMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().zMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularXMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularYMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularZMotion = ConfigurableJointMotion.Locked;
		}
		if (Vignetted == false && vignette == true && inspectItem == false && Vector3.Distance(hand.transform.position,gameObject.transform.position) <= grabBuffer) {
			Vignetted = true;
			Inspected = false;
			gameObject.transform.parent = scrim.transform;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			gameObject.AddComponent<ConfigurableJoint> ();
			gameObject.GetComponent<ConfigurableJoint> ().connectedBody = hand.GetComponent<Rigidbody> ();
			gameObject.GetComponent<ConfigurableJoint> ().breakForce = 1000;
			gameObject.GetComponent<ConfigurableJoint> ().xMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().zMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularXMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularYMotion = ConfigurableJointMotion.Locked;
			gameObject.GetComponent<ConfigurableJoint> ().angularZMotion = ConfigurableJointMotion.Locked;		
		}

	}

	public void LetGo() {
		if (Inspected == true) {
			Inspected = false;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		} else {
			Vignetted = false;
			gameObject.transform.parent = null;
			Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
			Destroy (gameObject.GetComponent<ConfigurableJoint>());
			rb.velocity = Vector3.Distance(hand.transform.position,gameObject.transform.position)*(handDelta / Time.deltaTime)*flingForce;
		}
	}


}