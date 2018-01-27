using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

	public GameObject[] envBlocks;
	public Transform spawnEnvironmentBlocks;

	private float blockSize = 27f;
	private GameObject blockA;
	private GameObject blockB;
	private GameObject blockC;
	
	// Use this for initialization
	void Start ()
	{
		blockA = CreateBlock(spawnEnvironmentBlocks, -2);
		blockB = CreateBlock(spawnEnvironmentBlocks, -1);
		blockC = CreateBlock(spawnEnvironmentBlocks, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float planeSpeed = Game.Instance.planeSpeed;
		
		blockA.transform.Translate(0, 0, -1 * planeSpeed * Time.deltaTime);
		blockB.transform.Translate(0, 0, -1 * planeSpeed * Time.deltaTime);
		blockC.transform.Translate(0, 0, -1 * planeSpeed * Time.deltaTime);

		if (blockA.transform.position.z <= -blockSize)
		{
			SwapBlocks();
		}
	}

	private void SwapBlocks()
	{
		//Debug.Log("Swapping blocks...");

		var deleteMeBlock = blockA;
		blockA = blockB;
		blockB = blockC;
		blockC = CreateBlock(blockB.transform, 1);
		
		Destroy(deleteMeBlock);
	}

	private GameObject CreateBlock(Transform pSpawnTransform, int offset)
	{
		GameObject original = envBlocks[Random.Range(0, envBlocks.Length)];
		
		Vector3 spawnPosition = pSpawnTransform.position + new Vector3(0, 0, blockSize) * offset;
		Quaternion spawnRotation = pSpawnTransform.rotation;
		
		GameObject clone = Instantiate (original, spawnPosition, spawnRotation);

		return clone;
	}
}
