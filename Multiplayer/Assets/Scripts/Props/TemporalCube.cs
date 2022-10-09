using System.Collections;
using UnityEngine;

public class TemporalCube : MonoBehaviour
{
    private Rigidbody2D myRb;

    private void Start() 
    {
        myRb = GetComponent<Rigidbody2D>();    
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(StartFall());
        }    
    }

    private IEnumerator StartFall()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("RedBox");
        myRb.bodyType = RigidbodyType2D.Dynamic;
    }
}
