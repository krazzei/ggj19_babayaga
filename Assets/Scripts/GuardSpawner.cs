using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{
	public GameObject guardGO;

	private Camera _camera;

	private Player _player;

	private int _lastScoreSpawn;

	// Start is called before the first frame update
	private void Start()
	{
		_camera = Camera.main;
		_player = FindObjectOfType<Player>();

		if (_camera == null || _player == null)
		{
			Debug.LogError("Guard Spawner could not find the camera or player");
			enabled = false;
		}
	}

	// Update is called once per frame
	private void Update()
	{
		if (_player.Score >= _lastScoreSpawn + 10)
		{
			_lastScoreSpawn = _player.Score;
			var horExtend = _camera.orthographicSize * Screen.width / Screen.height;
			Instantiate(guardGO, new Vector3(horExtend + 1 + _camera.transform.position.x, Random.Range(-4, 4), 0),
				Quaternion.identity);
		}
	}
}