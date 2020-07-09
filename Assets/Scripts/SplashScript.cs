using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SplashScript : MonoBehaviour
{
    public VideoPlayer player;
    private bool play = false;
    private bool play2 = true;
    public Image fade;
    public GameObject fade2;

    private float timer = 0f;

    private void Awake()
    {
        fade.enabled = false;
        fade2.SetActive(false);
    }

    private void Update()
    {
        if (player.isPlaying) play = true;
        if (!player.isPlaying && play)
        {
            play2 = false;
            fade.enabled = true;
            fade2.SetActive(true);
        }
        if (play2 == false)
        {
            timer += Time.deltaTime;
            fade.color = new Color(0, 0, 0, 1 - timer / 4);
            if (timer >= 3f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}