using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderFromMaterialName : MonoBehaviour {
	public GameObject[] targetGameObjects;
	public string ShaderNameA_to ;
	public string ShaderNameB_to;
	public string ShaderNameC_to;
	public string MaterialNameA_from;
	public string MaterialNameB_from;
	public string MaterialNameC_from;
	public Texture textureA;
	public Texture textureB;
	public Texture textureC;
	public float mainTextureScaleX;
	public float mainTextureScaleY;
	
	[ContextMenu("ChangeStart")]
	void ChangeStart() {
		MaterialNameA_from += " (Instance)";
		MaterialNameB_from += " (Instance)";
		Debug.Log(MaterialNameA_from + "s");
		Debug.Log(MaterialNameB_from + "s");
        for (int i = 0; i < targetGameObjects.Length; i++) {
		GameObject targetGameObject = targetGameObjects[i];
		changeShader(targetGameObject, textureA, textureB, textureC, mainTextureScaleX, mainTextureScaleY, ShaderNameA_to, ShaderNameB_to, ShaderNameC_to, MaterialNameA_from, MaterialNameB_from, MaterialNameC_from);
		}
	}

/// <summary>
    /// targetGameObject以下の子オブジェクト群のシェーダーをShaderName_toに変更する。ShaderName_fromが指定されていない場合はすべてのShaderを変更
    /// </summary>
    /// <param name="targetGameObject">対象GameObject。子要素も変更されます。</param>
    /// <param name="ShaderName_from">変更後のShader名</param>
    /// <param name="ShaderName_to">対象Shader名。未設定時は全てのShaderを変更</param>
    public static void changeShader(GameObject targetGameObject, Texture textureA, Texture textureB, Texture textureC, float mainTextureScaleX, float mainTextureScaleY, string ShaderNameA_to, 
	string ShaderNameB_to = "", string ShaderNameC_to = "", string MaterialNameA_from = "", string MaterialNameB_from = "", string MaterialNameC_from = "")
    {
        //List<GameObject> ret = new List<GameObject>();
		// Transform t にターゲットゲームオブジェクトの子オブジェクト郡のTransform入れる 
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
	                Debug.Log(material.name);
					// ShaderName_from が "" のとき
                    if (MaterialNameA_from == null)
                    {
	                    Debug.Log("null");
						// materialのshader に 引数に指定した名前からシェーダーを検索して代入
                        material.shader = Shader.Find(ShaderNameA_to);
						material.SetTexture("_MainTex", textureA);
	                    material.mainTextureScale = new Vector2(mainTextureScaleX, mainTextureScaleY);
                    }
                    else
                    {	
						// ShaderName_from が "" でなく、かつ material の shader の名前が ShaderName_fromのとき
	                    Debug.Log(material.name);
	                    Debug.Log(MaterialNameA_from);
                        if (material.name == MaterialNameA_from)
                        {
							// materialのshader に 引数に指定した名前からシェーダーを検索して代入
	                        Debug.Log(material + "A");
                           material.shader = Shader.Find(ShaderNameA_to);
							material.SetTexture("_MainTex", textureA);
	                       material.mainTextureScale = new Vector2(mainTextureScaleX, mainTextureScaleY);
                        }                        
	                    else if  (material.name == MaterialNameB_from)
                        {
							// materialのshader に 引数に指定した名前からシェーダーを検索して代入
	                        Debug.Log(textureB);
                           material.shader = Shader.Find(ShaderNameB_to);
							material.SetTexture("_MainTex", textureB);
	                       material.mainTextureScale = new Vector2(mainTextureScaleX, mainTextureScaleY);
                        }
	                    else if  (material.name == MaterialNameC_from)
                        {
							// materialのshader に 引数に指定した名前からシェーダーを検索して代入
                           material.shader = Shader.Find(ShaderNameC_to);
							material.SetTexture("_MainTex", textureC);
	                       material.mainTextureScale = new Vector2(mainTextureScaleX, mainTextureScaleY);
                        }
                    }
                }
            }
        }
    }
}
