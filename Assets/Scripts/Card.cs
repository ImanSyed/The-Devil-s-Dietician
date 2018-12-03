using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
[System.Serializable]
public class Card: ScriptableObject {

    public string cardName, bio;
    public Sprite sprite;
    public int stat;

    public ScriptableObject Init(string n, string b, Sprite s, int st)
    {
        cardName = n;
        bio = b;
        sprite = s;
        stat = st;

        return this;
    }
    
}
