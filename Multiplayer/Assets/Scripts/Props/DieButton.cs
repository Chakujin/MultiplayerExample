using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class DieButton : MonoBehaviour
{
    public delegate void RestartScene();
    public static event RestartScene RestartSceneCallback;

    [SerializeField] private Animator m_anim;
    private bool b_press = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (b_press == false)
            {
                m_anim.SetBool("Press", true);
                b_press = true;
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandomPitch("Click");
                StartCoroutine(RestartCurrentScene());
            }
        }
    }

    public static IEnumerator RestartCurrentScene()
    {
        RestartSceneCallback.Invoke();
        yield return new WaitForSeconds(3f);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
