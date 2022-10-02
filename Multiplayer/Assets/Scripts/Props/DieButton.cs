using UnityEngine;

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
                RestartSceneCallback.Invoke();
            }
        }
    }
}
