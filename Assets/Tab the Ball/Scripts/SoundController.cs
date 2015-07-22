using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip    ClickSound,ballUp,ScoreIncrease,GameOver,BulbBrokenSound,ElecricalShocksound,powersound;
	
	public static SoundController Static ;
	public AudioSource[]  audioSources;
	public AudioSource bgAudio;
	
	//public AudioSource scoreCount,bgSound ;
	
	void Start () {
		
		Static = this;
	}
	
	// Update is called once per frame
	
	public void PlayScoreIncrease()
	{
		
		swithAudioSources (ScoreIncrease);
		
	}
	public void PlayBallUp()
	{
		
		swithAudioSources (ballUp);
		
	}
	public void Playpowersound()
	{
		
		swithAudioSources (powersound);
		
	}



	public void PlayGameOver()
	{
		bgAudio.volume=0;
		swithAudioSources (GameOver);
		
	}
	public void PlayBulbBrokenSound()
	{
		
		swithAudioSources (BulbBrokenSound);
		
	}
	
	public void PlayClickSound()
	{
		
		swithAudioSources (ClickSound);
		
	}
	public void PlayElecricalShocksound()
	{
		
		swithAudioSources (ElecricalShocksound);
		
	}
	//public void StopSounds ()
	//{
	//	audio.Stop ();
	//}
	
	void swithAudioSources( AudioClip clip)
	{
		if(audioSources[0].isPlaying) 
		{
			audioSources[1].PlayOneShot(clip);
		}
		else audioSources[0].PlayOneShot(clip);
		
	}
}
