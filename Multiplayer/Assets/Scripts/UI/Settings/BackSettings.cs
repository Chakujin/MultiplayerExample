using UnityEngine;

public class BackSettings : MonoBehaviour
{
    [SerializeField] private GameObject m_settingsCanvas;
    [SerializeField] private GameObject m_mainCanvas;

    public void OnClickBackSettings()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandomPitch("Button");
        m_settingsCanvas.SetActive(false);
        m_mainCanvas.SetActive(true);
    }
}
