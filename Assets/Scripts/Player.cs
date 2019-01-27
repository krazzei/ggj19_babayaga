using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
	[Tooltip("The amount of weight that slows you down by 1 unit.")]
	public float weightFactor;
	
	/// <summary>
	/// For the Hud
	/// </summary>
	/// <returns></returns>
	public float SprintCooldownPercent => Mathf.Max(1, (Time.time - _lastSprintTime) / sprintCooldown);

	[HideInInspector]
	public int Score;
	
	private float _speed;
	private bool _didSprint;
	private float _lastSprintTime;
	private float _sprintStartTime;
	private Vector3 _sprintDir;
	private Camera _camera;
	private float _vertExtent;
	private float _horzExtent;
	private int _weight = 0;

	private float WeightSpeedReduction => _weight / weightFactor;

	private float GetCalculatedFrameSpeed =>
		_didSprint
			? _speed + sprintIncrease - WeightSpeedReduction
			: _speed - WeightSpeedReduction;
	
	private void Awake()
	{
		_transform = transform;
		_speed = startSpeed;
		_lastSprintTime = -sprintCooldown;
		_camera = Camera.main;
		_vertExtent = _camera.orthographicSize;
		_horzExtent = _vertExtent * Screen.width / Screen.height;
	}

	private void Update()
	{
		var dir = new Vector3(Input.GetAxis("Horizontal") *  GetCalculatedFrameSpeed * Time.deltaTime,
			Input.GetAxis("Vertical") * GetCalculatedFrameSpeed * Time.deltaTime, 0);
		
		if (_didSprint && _sprintStartTime + sprintDuration < Time.time)
		{
			_didSprint = false;
			_lastSprintTime = Time.time;
		}
		
		if (!_didSprint && Input.GetButtonDown("Sprint") && _lastSprintTime + sprintCooldown < Time.time)
		{
			_didSprint = true;
			_sprintStartTime = Time.time;
		}

		if (dir.y + _transform.position.y > _camera.transform.position.y + _vertExtent)
		{
			dir.y = 0;
		}
		else if (dir.y + _transform.position.y < _camera.transform.position.y - _vertExtent)
		{
			dir.y = 0;
		}

		if (dir.x + _transform.position.x > _camera.transform.position.x + _horzExtent)
		{
			dir.x = 0;
		}
		else if (dir.x + _transform.position.x < _camera.transform.position.x - _horzExtent)
		{
			dir.x = 0;
		}
		
		_transform.Translate(dir);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// TODO: animation

		if (other.gameObject.layer == 9)
		{
			var child = other.gameObject.GetComponent<Child>();
			if (child != null)
			{
				_weight += child.Weight;
				Score += child.Points;
				Destroy(child.gameObject);
			}
		}

		if (other.gameObject.layer == 10)
		{
			// TODO: Guard stuff.
		}
	}
}