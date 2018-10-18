using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialFromInspector : MonoBehaviour {
	public GameObject[] targetGameObjects;
	public Material newMaterial;
	public float amount;
	public float point;
	public string MaterialName_from;
	
	[ContextMenu("ChangeStart")]
	void Start(){
        for (int i = 0; i < targetGameObjects.Length; i++) {
		GameObject targetGameObject = targetGameObjects[i];
		changeMaterial(targetGameObject, newMaterial, amount, point, MaterialName_from);
		}
	}

/// <summary>
    /// </summary>
    /// <param name="targetGameObject">対象GameObject。子要素も変更されます。</param>
    /// <param name="newMaterial">変更後のMaterial名</param>
    /// <param name="MaterialName_from">対象Shader名。未設定時は全てのMaterialを変更</param>
    public static void changeMaterial(GameObject targetGameObject, Material newMaterial, float amount, float point, string MaterialName_from = "")
    {
        //List<GameObject> ret = new List<GameObject>();
		// Transform t にターゲットゲームオブジェクトの子オブジェクト郡のTransform入れる 
        foreach (Transform t in targetGameObject.GetComponentsInChildren<Transform>(true)) //include inactive gameobject
        {
            // tのレンダラーが null でないとき
			if (t.GetComponent<Renderer>() != null)
            {
                // tのMaterialを変数materialsに入れる
				var materials = t.GetComponent<Renderer>().materials;
				// materialsの数だけ処理
                for (int i = 0; i< materials.Length; i++) 
                {
                    // 各Materialを新しく作ったMaterial型の変数materialの代入
					Material material = materials[i];
					// ShaderName_from が "" のとき
                    if (MaterialName_from == "")
                    {
                        material = newMaterial;
	                    material.SetFloat("_ExtrusionAmount", amount);
	                    material.SetFloat("ExtruisionPoint", point);
                    }
                    else
                    {	
                        if (material == newMaterial)
                        {
                           material = newMaterial;
	                        material.SetFloat("_ExtrusionAmount", amount);
	                        material.SetFloat("ExtruisionPoint", point);
                        }
                    }
                }
            }
        }
    }
}
