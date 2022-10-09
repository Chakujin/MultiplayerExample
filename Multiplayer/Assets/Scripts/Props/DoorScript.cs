using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Vector2 f_sizeDetector;
    [SerializeField] private LayerMask m_keyLayer;
    
    private  int i_currentPlayers = 0;
    private int i_enterPlayers = 0;

    private bool b_open = false;

    private void Start() 
    {
        AddPlayer();
    }

    private void FixedUpdate()
    {
        //DetectKey 
        Collider2D[] detectKey = Physics2D.OverlapBoxAll(transform.position, f_sizeDetector, 0, m_keyLayer);

        foreach (Collider2D key in detectKey)
        {
            TakeKey();
            Destroy(key.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && b_open == true)
        {
            other.GetComponent<PlayerController>().DoorEnter();
            i_enterPlayers++; // Add player total enter on the door
            
            if(i_currentPlayers == i_enterPlayers) //If all players enter
            {
                PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }   
    }

    private void AddPlayer()
    {
        i_currentPlayers = PhotonNetwork.PlayerList.Length;
    }

    private void TakeKey()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Door");
        b_open = true;
        m_animator.SetBool("Open", true); // Animation
        AddPlayer(); //Take total players current ingame
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, f_sizeDetector);
    }
}
