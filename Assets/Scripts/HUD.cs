using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
	public UnityEngine.UI.Text score;
	public UnityEngine.UI.Text weight;
	public UnityEngine.UI.Slider sprintPercent;
	
	private Player _player;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
		if (_player == null)
		{
			Debug.LogError("Hud could not find player");
			enabled = false;
		}
	}

	// Update is called once per frame
	private void Update()
	{
		score.text = $"Score: {_player.Score}";
		weight.text = $"Weight: {_player.Weight}";
		Debug.Log(_player.SprintCooldownPercent);
		sprintPercent.value = _player.SprintCooldownPercent;
	}
}