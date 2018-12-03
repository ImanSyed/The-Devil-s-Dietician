using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Helper {

    [MenuItem("Tools/GenerateCards")]
    public static void GenerateCards()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");
        foreach(Sprite sprite in sprites)
        {
            ScriptableObject so = ScriptableObject.CreateInstance<Card>().Init(sprite.name, " ", sprite, 0);

            AssetDatabase.CreateAsset(so, "Assets/Cards/" + sprite.name + ".asset");
        }
    }
}
