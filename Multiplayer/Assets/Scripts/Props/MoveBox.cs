using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private Rigidbody2D m_myRb;
    [SerializeField] private int i_totalPlayersToPush;
    private int i_currentPlayersPush;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
           i_currentPlayersPush++;

           if(i_currentPlayersPush >= i_totalPlayersToPush) //If are total player required or more can push
           {
                m_myRb.bodyType = RigidbodyType2D.Dynamic;
           }  
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            i_currentPlayersPush--; 
                       
            if(i_currentPlayersPush < i_totalPlayersToPush) //Dont have total player requiried pushing
            {
                m_myRb.bodyType = RigidbodyType2D.Static; //Static rigidbody
            } 
        }
    }
}
