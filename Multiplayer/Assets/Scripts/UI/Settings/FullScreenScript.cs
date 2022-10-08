using UnityEngine;

public class FullScreenScript : MonoBehaviour
{
    [SerializeField]private Animator _Anim;
    // Start is called before the first frame update

    public void SetFullscreen(bool isFullscreen)
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Screen.fullScreen = isFullscreen;
        _Anim.SetBool("Press", isFullscreen);
    }
}
