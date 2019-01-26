using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
	private Transform _transform;

	public Vector3 Direction;

	public float Speed;

	// Start is called before the first frame update
	private void Awake()
	{
		_transform = transform;
	}

	// Update is called once per frame
	private void Update()
	{
		_transform.Translate(Direction * Speed * Time.deltaTime);
	}
}