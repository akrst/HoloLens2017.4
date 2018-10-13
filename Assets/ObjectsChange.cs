using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsChange : MonoBehaviour {
	public GameObject[] targetGameObjects;
	int count = 0;
	int previousCount;
	public float span;
	float delta = 0;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < targetGameObjects.Length; i++)
		{
			GameObject targetGameObject = targetGameObjects[i];
			targetGameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if (this.delta > this.span)
		{
			if (count >= targetGameObjects.Length)
			{
				count = 0;
			}
			delta = 0;
			
			if (previousCount != null) {
				GameObject previousTargetGameObject = targetGameObjects[previousCount];
				previousTargetGameObject.SetActive(false);
			}  
			GameObject currenTargetGameObject= targetGameObjects[count];
			currenTargetGameObject.SetActive(true);
			previousCount = count;
			count++;
		}

	}
}