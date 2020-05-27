using UnityEngine;
using System.Collections;

public class  Agro : MonoBehaviour {

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;
	Rigidbody theRigidbody;
	Renderer myRender;


	void Start () {
		myRender = GetComponent<Renderer>();
		theRigidbody = GetComponent<Rigidbody>();
	
	}
	
	void FixedUpdate () {
		fpsTargetDistance = Vector3.Distance(fpsTarget.position,transform.position);
		if (fpsTargetDistance<enemyLookDistance){
			lookAtPlayer ();
			print ("Посмотри пожалуйста на игрока");
		}
        if (fpsTargetDistance < attackDistance)
        {
            attackPlease();
            print("АТАКА!");
        }
	}
	
	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		
	}

	void attackPlease(){
		theRigidbody.AddForce(transform.forward*enemyMovementSpeed);
	}

}
