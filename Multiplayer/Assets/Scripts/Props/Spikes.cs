using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector2 lastPos = other.GetComponent<PlayerController>().lastPos;
            PlayerEvents.ResetPlayerPosition(other.gameObject,lastPos); //Reset Level
        }
    }
}
