using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Helper {

    static char[] trimChars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

    static Card[] cards;

    [MenuItem("Tools/GenerateCards")]
    public static void GenerateCards()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");
        cards = new Card[sprites.Length];
        int counter = 0;
        foreach(Sprite sprite in sprites)
        {
            string s = sprite.name.Trim(trimChars);
            s = s.Replace("_", " ");
            s = s.Remove(0, 1);
            if(s == "Sex Offendor")
            {
                s = "Sex Offender";
            }
            ScriptableObject so = ScriptableObject.CreateInstance<Card>().Init(s, " ", sprite, 0);
            cards[counter] = (Card)so;
            counter++;
            AssetDatabase.CreateAsset(so, "Assets/Cards/" + s + ".asset");
        }
    }

    [MenuItem("Tools/AddCards")]
    public static void AddCards()
    {
        GameObject.FindObjectOfType<GameManager>().cards = cards;
        
    }
}
