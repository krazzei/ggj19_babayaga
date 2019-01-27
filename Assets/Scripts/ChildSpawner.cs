using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct SpawnInfo
{
	public GameObject thingToSpawn;
	public Vector2 amountToSpawn;
	public Vector2 xStartRange;
	public Vector2 xAdditionRange;
	public Vector2 yVariance;

	public int GetAmount => Random.Range((int) amountToSpawn.x, (int) amountToSpawn.y);
	public float GetXStart => Random.Range(xStartRange.x, xStartRange.y);
	public float GetXAddition => Random.Range(xAdditionRange.x, xAdditionRange.y);
	public float GetYVariance => Random.Range(yVariance.x, yVariance.y);
}

public class ChildSpawner : MonoBehaviour
{
	public SpawnInfo PovertyChild;

	public SpawnInfo RichChild;

	public SpawnInfo GoldenChild;

	public float EndGameDistance = 40;
	
	// Start is called before the first frame update
	private void Awake()
	{
		SpawnTheThings(PovertyChild);
		SpawnTheThings(RichChild);
		SpawnTheThings(GoldenChild);
	}
	
	private void SpawnTheThings(SpawnInfo info)
	{
		var numWindow = info.GetAmount;
		var x = info.GetXStart;
		for (var i = 0; i < numWindow; ++i)
		{
			if (x < EndGameDistance)
			{
				Instantiate(info.thingToSpawn, new Vector3(x, info.GetYVariance, 0), Quaternion.identity);
				x += info.GetXAddition;
			}
		}
	}
}