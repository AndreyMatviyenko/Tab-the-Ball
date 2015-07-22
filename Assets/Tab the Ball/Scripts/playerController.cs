using UnityEngine;
using System.Collections;
using System;
public class playerController : MonoBehaviour {

	// Use this for initialization
	public static EventHandler IncreaseScore,PlayerDead ;
	Transform thisTrans;
	public float playerUpwardsForce ;


	//these player states will give us ,current state .wheather game starts or player is dead etc.
	public enum playerStates{

		idle,alive,dead
	}
	public static playerStates currentState ;

	void Start () {
	
		thisTrans  = transform; // always copy transform to local variable ,since we transform component a lot in playercontroller .

		 
	}
	
	// Update is called once per frame
	void Update () {
	
		//if player is not dead and is not idle state we will jump into gameplay . alive state
		if( Input.GetKeyDown(KeyCode.Mouse0) && currentState != playerStates.dead && currentState != playerStates.idle)
		{
			//when user taps ,add force to the ball
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,playerUpwardsForce* 100));
			//to give punch scale effect 
			iTween.PunchScale(gameObject,iTween.Hash("amount",new Vector3(0.06f,0.06f,0),"time",1.7f,"easetype",iTween.EaseType.linear));
			currentState=playerStates.alive; //changing ball/player state to alive 
			SoundController.Static.PlayBallUp(); //to play ball tap sound.
		}

		thisTrans.position  =new Vector2(0,thisTrans.position.y); // ball x position is constant at zero.
	}


	void OnCollisionEnter2D(Collision2D coll) {

		//if player collides with enemy , ie left or right white bar .
		if (coll.gameObject.tag == "Enemy"){
			currentState = playerStates.dead;//changing state to dead, so the camera will also track the ball falldown 
			iTween.PunchPosition(gameObject,iTween.Hash("amount",new Vector3(0.4f,0.0f,0),"time",0.6f,"easetype",iTween.EaseType.easeInOutBounce));
			if(PlayerDead != null) PlayerDead(null,null);//to say every script that player is dead.those who every register to this event will fire their statements ,for ex uicontroller or Admanager
			SoundController.Static.PlayGameOver(); //to play sound
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {

		//if player collides with score trigger we will increment score
		if (coll.name.Contains("Score")){
			if(IncreaseScore != null) IncreaseScore(null,null);//to fire the score increment event,uicontroller will uses this event
			 coll.name ="USED"; //to avoid repeated trigger enter events
		 }
	}
}
