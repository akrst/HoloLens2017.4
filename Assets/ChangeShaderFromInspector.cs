using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderFromInspector : MonoBehaviour {
	public GameObject[] targetGameObjects;
	public string ShaderName_to;
	public string ShaderName_from;
	public Texture texture;
	
	[ContextMenu("ChangeStart")]
	void ChangeStart(){
        for (int i = 0; i < targetGameObjects.Length; i++) {
		GameObject targetGameObject = targetGameObjects[i];
		changeShader(targetGameObject, texture, ShaderName_to);
		}
	}

/// <summary>
    /// targetGameObject以下の子オブジェクト群のシェーダーをShaderName_toに変更する。ShaderName_fromが指定されていない場合はすべてのShaderを変更
    /// </summary>
    /// <param name="targetGameObject">対象GameObject。子要素も変更されます。</param>
    /// <param name="ShaderName_from">変更後のShader名</param>
    /// <param name="ShaderName_to">対象Shader名。未設定時は全てのShaderを変更</param>
    public static void changeShader(GameObject targetGameObject, Texture texture, string ShaderName_to, string ShaderName_from = "")
    {
        //List<GameObject> ret = new List<GameObject>();
		// Transform t にターゲットゲームオブジェクトの子オブジェクト軍のTransform入れる 
        foreach (Transform t in targetGameObject.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
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
                    if (ShaderName_from == "")
                    {
						// materialのshader に 引数に指定した名前からシェーダーを検索して代入
                        material.shader = Shader.Find(ShaderName_to);
						material.SetTexture("_MainTex", texture);
                    }
                    else
                    {	
						// ShaderName_from が "" でなく、かつ material の shader の名前が ShaderName_fromのとき	
                        if (material.shader.name == ShaderName_from)
                        {
							// materialのshader に 引数に指定した名前からシェーダーを検索して代入
                            material.shader = Shader.Find(ShaderName_to);
							material.SetTexture("_MainTex", texture);
                        }
                    }
                }
            }
        }
    }
}
