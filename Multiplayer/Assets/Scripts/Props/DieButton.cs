using UnityEngine;

public class DieButton : MonoBehaviour
{
    public delegate void RestartScene();
    public static event RestartScene RestartSceneCallback;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RestartSceneCallback.Invoke();
        }
    }
}
