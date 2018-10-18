using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrianglesController : MonoBehaviour {
	
	// Use this for initialization
	[ContextMenu("MeshChange")]
	void MeshChange () {
		GameObject child = transform.Find("default").gameObject;
        MeshFilter meshFilter = child.GetComponent<MeshFilter>();
        meshFilter.sharedMesh.SetIndices(meshFilter.sharedMesh.GetIndices(0), MeshTopology.Triangles, 0);
        meshFilter.sharedMesh.SetIndices(meshFilter.sharedMesh.GetIndices(1), MeshTopology.Points, 1);
    }
	
}
