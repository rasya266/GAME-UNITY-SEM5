using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public double time;
    public GameObject panel;
    public Image panelBg;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        panelBg = panel.GetComponent<Image>();
    }

    private void Update()
    {
        time = videoPlayer.time;
        if(time > 8)
        {
            panelBg.color = new Color(255, 255, 255,  (float)((time - 8)) / 1);
        }
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}
