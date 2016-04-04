using UnityEngine;
using System.Collections;

/// <summary>
/// Simple music player, with some fade stuff. 
/// It starts with 0 volume and then fade music in
/// You can also use fade out music when you need
/// </summary>
public class MusicPlayer : MonoBehaviour
{
	public AudioClip[] Music;
	private AudioSource _audioSrc;

	private void Start()
	{
		_audioSrc = GetComponent<AudioSource>();
		_audioSrc.volume = 0;
		PlayMusic();
		FadeInMusic();
	}

	public void PlayMusic()
	{
		if (_audioSrc)
		{
			_audioSrc.loop = true;
			_audioSrc.PlayOneShot(Music[0]);
		}
	}

	public void FadeInMusic()
	{
		StartCoroutine("FadeSoundIn");
	}

	public void FadeOutMusic()
	{
		StartCoroutine("FadeSoundOut");
	}

	private IEnumerator FadeSoundOut()
	{
		for (var i = 4; i > 0; i--)
		{
			_audioSrc.volume = i*0.25f;
			yield return new WaitForSeconds(.2f);
		}
	}

	private IEnumerator FadeSoundIn()
	{
		for (var i = 0; i < 4; i++)
		{
			_audioSrc.volume = i*.25f;
			yield return new WaitForSeconds(.2f);
		}
	}
}