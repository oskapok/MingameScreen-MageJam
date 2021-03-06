using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static Dictionary<string, int> sfxDictionary = new Dictionary<string, int>();
	static Dictionary<string, int> musicDictionary = new Dictionary<string, int>();

	AudioSource SFXSource;
	AudioSource musicSource;
	
	public List<AudioClip> sfxList = new List<AudioClip>();
	public List<AudioClip> musicList = new List<AudioClip>();
	public static SoundManager Instance = null;

	private void Awake()
	{
		//Assign Instance
		if (Instance == null)
		{
			Instance = this;

			//Fetch SFX
			if (sfxDictionary.Count != sfxList.Count)
			{
				for (int i = 0; i < sfxList.Count; i++)
				{
					sfxDictionary.Add(sfxList[i].name, i);
				}
			}

			//Create SFX Audio Source
			var sfxSrc = Instantiate(new GameObject("SFX"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			sfxSrc.AddComponent<AudioSource>();
			sfxSrc.transform.parent = gameObject.transform;
			SFXSource = sfxSrc.GetComponent<AudioSource>();


			//Fetch Music
			if (musicDictionary.Count != musicList.Count)
			{
				for (int i = 0; i < musicList.Count; i++)
				{
					musicDictionary.Add(musicList[i].name, i);
				}
			}

			//Create Music Audio Source
			var musicSrc = Instantiate(new GameObject("Music"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			musicSrc.AddComponent<AudioSource>();
			musicSrc.transform.parent = gameObject.transform;
			musicSource = musicSrc.GetComponent<AudioSource>();
		}

		//If duplicate abort
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Mark as permament
		DontDestroyOnLoad(gameObject);
	}


	public void PlaySFX(string sfxName)
	{
		//Play only if exists
		if(sfxDictionary.TryGetValue(sfxName, out int index))
			SFXSource.PlayOneShot(sfxList[index]);
	}

	public void PlayMusic(string musicName)
	{
		//Play only if exists
		if (musicDictionary.TryGetValue(musicName, out int index))
		{
			musicSource.volume = 0.3f;
			musicSource.clip = musicList[index];
			musicSource.Play();
		}

		
	}
}
