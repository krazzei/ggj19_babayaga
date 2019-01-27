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
	}

	private void Update()
	{
		// too lazy to clean this up, I feel like I could have one dir and Translate call...
		if (_didSprint)
		{
			if (_sprintStartTime + sprintDuration > Time.time)
			{
				var sprintDir = new Vector3(Input.GetAxis("Horizontal") * (_speed + sprintIncrease) * Time.deltaTime,
					Input.GetAxis("Vertical") * (_speed + sprintIncrease) * Time.deltaTime, 0);
				_transform.Translate(sprintDir);
			}
			else
			{
				_didSprint = false;
				_lastSprintTime = Time.time;
			}
			
			return;
		}
		
		if (Input.GetButtonDown("Sprint") && _lastSprintTime + sprintCooldown < Time.time)
		{
			_didSprint = true;
			_sprintStartTime = Time.time;
		}
		
		var dir = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
			Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);
		_transform.Translate(dir);
	}
}