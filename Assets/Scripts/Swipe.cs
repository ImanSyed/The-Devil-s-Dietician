using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector2 destination;


    private void Update()
    {
        if (destination != Vector2.zero)
        {
            if ((Vector2)transform.position == destination)
            {
                destination = Vector2.zero;
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, 0.25f);
            }
        }
    }

    public void S(bool left)
    {
        if (left)
        {
            destination = Vector2.left * 4.5f;
        }
        else
        {
            destination = Vector2.right * 4.5f;
        }
    }
}
