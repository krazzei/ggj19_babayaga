using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Child : MonoBehaviour
{
	public float Points;
	public float Weight;
	public bool ShouldRun;
	public float RunSpeed;
	public float AlertRange = 1.75f;

	private Transform _playerTrans;
	private Transform _transform;

	private void Start()
	{
		// LOL game jam!
		_playerTrans = FindObjectOfType<Player>().transform;
		_transform = transform;
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
		var dir = (_transform.position - _playerTrans.position).normalized;
		dir.z = 0;
		_transform.Translate(dir * RunSpeed * Time.deltaTime);
	}

	private void RunToward()
	{
		var dir = (_playerTrans.position - _transform.position).normalized;
		dir.z = 0;
		_transform.Translate(dir * RunSpeed * Time.deltaTime);
	}
}