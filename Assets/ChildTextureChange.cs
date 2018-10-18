using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTextureChange : MonoBehaviour {
	public Texture [] textures;
	Renderer renderer;
	int count = 0;
	public float span;
	float delta = 0;

	// Use this for initialization
	void Start () {
		GameObject child = transform.Find("default").gameObject;
		renderer = child.GetComponent<Renderer>();
		renderer.material.mainTexture = textures[count];
		count++;
		Debug.Log(renderer.material.mainTexture);
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if (this.delta > this.span)
		{
			if (count >= textures.Length)
			{
				count = 0;
			}
			delta = 0;
			renderer.material.mainTexture = textures[count];
			count++;
		}

	}
}