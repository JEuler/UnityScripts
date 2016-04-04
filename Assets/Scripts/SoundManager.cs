using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource EfxSource;
	public AudioSource MusicSource;

	public static SoundManager Instance = null;

	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	void Awake() {
		if ( Instance == null ) {
			Instance = this;
		}
		else if ( Instance != this ) {
			Destroy( gameObject );
		}

		DontDestroyOnLoad( gameObject );
	}

	public void PlaySingle( AudioClip clip ) {
		EfxSource.clip = clip;
		EfxSource.Play();
	}

	public void RandomizeSfx( params AudioClip[] clips ) {
		int randomIndex = Random.Range( 0, clips.Length );
		float randomPitch = Random.Range( LowPitchRange, HighPitchRange );

		EfxSource.pitch = randomPitch;
		EfxSource.clip = clips[ randomIndex ];
		EfxSource.Play();
	}

	public void FadeInMusic() {
		StartCoroutine( "FadeSoundIn", MusicSource );
	}

	public void FadeOutMusic() {
		StartCoroutine( "FadeSoundOut", MusicSource );
	}

	private IEnumerator FadeSoundOut( AudioSource audioSource ) {
		for ( var i = 4; i > 0; i-- ) {
			audioSource.volume = i * 0.25f;
			yield return new WaitForSeconds( .2f );
		}
	}

	private IEnumerator FadeSoundIn( AudioSource audioSource ) {
		for ( var i = 0; i < 4; i++ ) {
			audioSource.volume = i * .25f;
			yield return new WaitForSeconds( .2f );
		}
	}
}
