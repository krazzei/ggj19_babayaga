using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Transform _transform;

	public float StartSpeed;

	private float _speed;

	private void Awake()
	{
		_transform = transform;
		_speed = StartSpeed;
	}

	private void Update()
	{
		var dir = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
			Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);
		_transform.Translate(dir);
	}
}