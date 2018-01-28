using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	[SerializeField] private AudioSource[] efxSource;
	[SerializeField] private AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float highPitchRange = 1.05f;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Start ()
	{
		if (musicSource != null) 
		{
			StartCoroutine (PlayMusic (0.5f));
		}
	}


	public void PlayMusic(AudioClip clip)
	{
		musicSource.clip = clip;
		musicSource.Play ();
	}

	public void StopMusic(){
		musicSource.Stop ();
	}

	public void PlaySingle (AudioClip clip, int channel) {
		efxSource[channel].clip = clip;
		efxSource[channel].Play();
	}

	public void RandomizeSfx (int channel, params AudioClip [] clips) {
		int randomIndex = Random.Range(0, clips.Length - 1);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource[channel].pitch = randomPitch;
		efxSource[channel].clip = clips[randomIndex];
		efxSource[channel].Play();
	}

	public bool IsChannelPlaying(int channel){
		if (channel < efxSource.Length) {
			return efxSource [channel].isPlaying;

		} else {
			return false;
		}
	}

	public void StopPlay(int channel){
		if (channel < efxSource.Length) {
			efxSource [channel].Stop();

		} 
	}


	IEnumerator PlayMusic(float time)
	{
		yield return new WaitForSeconds (time);
		PlayMusic (musicSource.clip);
	}
}