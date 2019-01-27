using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IntroLooper : MonoBehaviour
{
	public AudioClip intro;

	public AudioClip loop;

	private AudioSource _source;

	private bool _isLooping;

	private void Awake()
	{
		_source = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		_source.clip = intro;
		_source.Play();
		_isLooping = false;
	}

	private void Update()
	{
		if (!_isLooping && _source.timeSamples >= intro.samples * 0.99f)
		{
			_source.clip = loop;
			_source.loop = _isLooping = true;
			_source.Play();
		}
	}
}