using UnityEngine;
using System.Collections;
using System;
public class barController : MonoBehaviour {


	public Transform leftBar,rightBar;

	public float speed ;
	public float distanceDivider ;
	float Right_originalXPosition,Left_originalXPosition;
	void OnEnable(){
		
		playerController.PlayerDead += OnPlayerDead;

		Right_originalXPosition  = rightBar.localPosition.x ;

		Left_originalXPosition= leftBar.localPosition.x;

		//To increase bars sliding speed at random 

		if( UnityEngine.Random.Range(-5,5) > 3 )
		{

			speed  = UnityEngine.Random.Range(3.0f,5.0f);
		}

	}

	void OnDisable(){
		
		playerController.PlayerDead -= OnPlayerDead;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//translation two bars using Sine wave .

		leftBar.localPosition  = new Vector3( Left_originalXPosition +  (Mathf.Sin ( Time.timeSinceLevelLoad * speed ) )/ distanceDivider ,leftBar.localPosition.y,0  );

		rightBar.localPosition = new Vector3(Right_originalXPosition -  (Mathf.Sin(  Time.timeSinceLevelLoad * speed))/distanceDivider ,rightBar.localPosition.y,0);

	
	}

	void OnPlayerDead(System.Object obj,EventArgs args)
	{
		//when player is dead ,we put collider as trigger ,to move ball freely to ground.
		leftBar.GetComponent<Collider2D>().isTrigger = true;
		rightBar.GetComponent<Collider2D>().isTrigger = true;
	}
}
