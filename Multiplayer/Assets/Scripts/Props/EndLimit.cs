using UnityEngine;

public class EndLimit : MonoBehaviour
{
    [SerializeField] private bool b_restartGame = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Fall");
            if (b_restartGame == false)
            {
            Vector2 lastPos = other.GetComponent<PlayerController>().lastPos;
            PlayerEvents.ResetPlayerPosition(other.gameObject,lastPos); //Reset Pos
            }
            else
            {
                StartCoroutine(DieButton.RestartCurrentScene());
            }
        }    
    }
}
