using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Child : MonoBehaviour
{
	public int Points;
	public int Weight;
	public bool ShouldRun;
	public float RunSpeed;
	public float AlertRange = 1.75f;

	private Transform _playerTrans;
	private Transform _transform;
	private Camera _camera;
	private float vertExtent;

	private void Start()
	{
		// LOL game jam!
		_playerTrans = FindObjectOfType<Player>().transform;
		_transform = transform;
		_camera = Camera.main;
		vertExtent = _camera.orthographicSize;
	}

	private void Update()
	{
		if (Vector3.Distance(_playerTrans.position, _transform.position) < AlertRange)
		{
			if (ShouldRun)
			{
				RunAway();
			}
			else
			{
				RunToward();
			}
		}
	}

	private void RunAway()
	{
		var dir = (_transform.position - _playerTrans.position).normalized * RunSpeed * Time.deltaTime;
		dir.z = 0;

		if (dir.y + _transform.position.y > _camera.transform.position.y + vertExtent)
		{
			dir.x *= 1.25f;
			dir.y = 0;
		}
		else if (dir.y + _transform.position.y < _camera.transform.position.y - vertExtent)
		{
			dir.x *= 1.25f;
			dir.y = 0;
		}
		
		_transform.Translate(dir);
	}

	private void RunToward()
	{
		var dir = (_playerTrans.position - _transform.position).normalized;
		dir.z = 0;
		_transform.Translate(dir * RunSpeed * Time.deltaTime);
	}
}