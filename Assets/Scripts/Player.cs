using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Transform _transform;

	public float startSpeed;

	public float sprintIncrease;
	[Tooltip("In Seconds")]
	public float sprintCooldown;
	[Tooltip("In Seconds")]
	public float sprintDuration;

	private float _speed;
	private bool _didSprint;
	private float _lastSprintTime;
	private float _sprintStartTime;
	private Vector3 _sprintDir;
	private Camera _camera;
	private float vertExtent;
	private float horzExtent;

	/// <summary>
	/// For the Hud
	/// </summary>
	/// <returns></returns>
	public float SprintCooldownPercent => Mathf.Max(1, (Time.time - _lastSprintTime) / sprintCooldown);

	private void Awake()
	{
		_transform = transform;
		_speed = startSpeed;
		_lastSprintTime = -sprintCooldown;
		_camera = Camera.main;
		vertExtent = _camera.orthographicSize;
		horzExtent = vertExtent * (float)Screen.width / (float)Screen.height;
		Debug.Log(horzExtent);
	}

	private void Update()
	{
		var dir = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
			Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);
		if (_didSprint)
		{
			if (_sprintStartTime + sprintDuration > Time.time)
			{
				 dir = new Vector3(Input.GetAxis("Horizontal") * (_speed + sprintIncrease) * Time.deltaTime,
					Input.GetAxis("Vertical") * (_speed + sprintIncrease) * Time.deltaTime, 0);
			}
			else
			{
				_didSprint = false;
				_lastSprintTime = Time.time;
			}
		}
		
		if (!_didSprint && Input.GetButtonDown("Sprint") && _lastSprintTime + sprintCooldown < Time.time)
		{
			_didSprint = true;
			_sprintStartTime = Time.time;
		}

		if (dir.y + _transform.position.y > _camera.transform.position.y + vertExtent)
		{
			dir.y = 0;
		}
		else if (dir.y + _transform.position.y < _camera.transform.position.y - vertExtent)
		{
			dir.y = 0;
		}

		if (dir.x + _transform.position.x > _camera.transform.position.x + horzExtent)
		{
			dir.x = 0;
		}
		else if (dir.x + _transform.position.x < _camera.transform.position.x - horzExtent)
		{
			dir.x = 0;
		}
		
		_transform.Translate(dir);
	}
}