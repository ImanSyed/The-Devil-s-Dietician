using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
[System.Serializable]
public class Card: ScriptableObject {

    public string name, bio;
    public Sprite sprite;
    public int stat;

    public ScriptableObject Init(string n, string b, Sprite s, int st)
    {
        name = n;
        bio = b;
        sprite = s;
        stat = st;

        return this;
    }
    
}
