using UnityEngine;
using System.Collections;
using System;
public class GameController : MonoBehaviour {

	// Use this for initialization

	public GameObject barGroup; //bargroup,contains 3 bars left and right
	public float distanceBetweenBarGroups; 
	Transform playerTransform;


 
	void Start () {
		
		playerTransform= GameObject.FindGameObjectWithTag("Player").transform;



	}
	
	// Update is called once per frame
	float lastPlayerPosition;
	void Update () {
	

		//if player player somes 6 units distance from its last distance ,then we will create new bar group
		if( playerTransform != null && playerTransform.position.y - lastPlayerPosition > 6)
		{

			createNewGroup();
			lastPlayerPosition = playerTransform.transform.position.y; // to store the present ball position y .
		}

		 


	}

	int groupIndex=1;
	void createNewGroup()
	{

		GameObject barGroupNewInstance = GameObject.Instantiate(barGroup) as GameObject;

		barGroupNewInstance.transform.position= new Vector3(-3,distanceBetweenBarGroups*groupIndex,0 ); //this will create new bars group

		groupIndex++;
	}

}
