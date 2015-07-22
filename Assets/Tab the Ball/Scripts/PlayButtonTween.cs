using UnityEngine;
using System.Collections;

public class PlayButtonTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(1.06f,1.06f,0),"time",0.5f,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.pingPong));
	}
	
	 
}
