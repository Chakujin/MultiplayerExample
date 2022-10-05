using UnityEngine;

public class Key : MonoBehaviour
{
    private bool b_start = false;
    private GameObject m_lastPlayer;
    private Vector2 m_speed = Vector2.zero;
    private const float f_delayTime = 0.4f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player") 
        {
            b_start = true;
            m_lastPlayer = other.gameObject;
        }    
    }

    private void Update() 
    {
        if (b_start == true)
        {
            if (m_lastPlayer == null) //Player dissconect
            {
                b_start = false;
            }
            else
            {
                //Smooth path player
                Vector2 playerPos = new Vector2(m_lastPlayer.transform.position.x, m_lastPlayer.transform.position.y + 1);
                transform.position = Vector2.SmoothDamp(transform.position, playerPos, ref m_speed, f_delayTime);
            }
        }
    }
}
