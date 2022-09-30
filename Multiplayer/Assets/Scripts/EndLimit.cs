using UnityEngine;

public class EndLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Vector2 lastPos = other.GetComponent<PlayerController>().lastPos;
            ResetPosition(other.gameObject,lastPos);
        }    
    }

    private void ResetPosition(GameObject player, Vector2 lastPos)
    {
        player.transform.position = lastPos;
    }
}
