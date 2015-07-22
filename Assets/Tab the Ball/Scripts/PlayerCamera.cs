using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	Transform playerTransform;
	Transform thisTrans;
	public float targetToReach;
	public float lerpSpeed ;
	void Start () {
		
		thisTrans  = transform;
		playerTransform= GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	float lastPlayerPosition;
	void FixedUpdate () {
		
		
		switch(playerController.currentState)
		{

		case playerController.playerStates.alive:
			if( playerTransform != null && playerTransform.position.y - lastPlayerPosition > 2)
			{
				
				targetToReach = playerTransform.transform.position.y;
				lastPlayerPosition = targetToReach;
			}
			
			thisTrans.position=new Vector3(0,Mathf.Lerp(thisTrans.position.y ,targetToReach,lerpSpeed),-10); 
			break;
		case playerController.playerStates.dead:
			targetToReach = playerTransform.transform.position.y;
			
			targetToReach = Mathf.Clamp(targetToReach,1,playerTransform.transform.position.y);
			thisTrans.position=new Vector3(0,targetToReach,-10); 
			break;

		case playerController.playerStates.idle:
		 
			
			 
			thisTrans.position=new Vector3(0,Mathf.Lerp(thisTrans.position.y ,targetToReach,lerpSpeed),-10); 
			break;
	}
	}
}
