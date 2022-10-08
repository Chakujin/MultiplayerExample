using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject m_settingsCanvas;
    [SerializeField] private GameObject m_mainCanvas;

    public void OnClickSettings()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandomPitch("Button");
        m_settingsCanvas.SetActive(true);
        m_mainCanvas.SetActive(false);
    }
}
