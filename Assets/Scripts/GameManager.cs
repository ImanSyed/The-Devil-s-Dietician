using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField] Card[] cards;
    [SerializeField] Vector2 pos;
    [SerializeField] GameObject template;
    [SerializeField] Animator anim;
    GameObject[] obs; 

    int counter;

    GameObject activeCard;

	void Start () {
        obs = new GameObject[cards.Length];
        for(int i = 0; i < obs.Length; i++)
        {
            obs[i] = Instantiate(template, pos, Quaternion.identity);
            obs[i].GetComponent<CardApplier>().spriteRenderer.sprite = cards[counter].sprite;
            obs[i].GetComponent<CardApplier>().name.text = cards[counter].name;
            obs[i].GetComponent<CardApplier>().bio.text = cards[counter].bio;
            obs[i].GetComponent<CardApplier>().stat = cards[counter].stat;
            obs[i].transform.SetParent(GameObject.FindGameObjectWithTag("GameController").transform);
            activeCard = obs[i];
            counter++;
        }
        counter--;
	}
	
	
	void Update () {
        if (Input.GetButtonDown("Left"))
        {
            StartCoroutine(SwiperNoSwiping(true)); 
            anim.Play("Left");
        }
        if (Input.GetButtonDown("Right"))
        {
            StartCoroutine(SwiperNoSwiping(false));
            anim.Play("Right");
        }
    }

    IEnumerator SwiperNoSwiping(bool dir)
    {
        yield return new WaitForSeconds(0.2f);
        if (activeCard)
        {
            activeCard.GetComponent<Swipe>().S(dir);
            if (counter > 0)
            {
                activeCard = obs[--counter];
            }
        }
    }
}
