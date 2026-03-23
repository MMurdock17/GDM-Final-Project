using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolManager : MonoBehaviour
{

	public static CoinPoolManager Instance { get; private set; }

	[Header("References")]
	public ObjectPool pool;
	public GameObject coinPrefab;

	private List<Vector3> coinStartPositions = new List<Vector3>();
	private List<GameObject> activeCoins = new List<GameObject>();

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;

		GameObject[] coinsInScene = GameObject.FindGameObjectsWithTag("Coin");

		foreach (GameObject coin in coinsInScene)
		{
			coinStartPositions.Add(coin.transform.position);
			Destroy(coin);
		}
		SpawnAllCoins();
	}

	void SpawnAllCoins()
	{
		foreach (Vector3 pos in coinStartPositions)
		{
			GameObject coin = pool.GetObject();
			coin.transform.position = pos;
			coin.SetActive(true);

			activeCoins.Add(coin);
		}
	}

	public void ReturnCoin(GameObject coin)
	{
		pool.ReturnObject(coin);
		activeCoins.Remove(coin);
	}

	public void ResetAllCoins()
	{
		foreach (GameObject coin in activeCoins)
		{
			pool.ReturnObject(coin);
		}

		activeCoins.Clear();

		SpawnAllCoins();
	}

}
