using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject player;
    public Camera cam;

    public int score = 0;
    public float level = 1.01f;

    private float timer = 0f;
    private float timer2 = 0f;

    private void Awake()
    {
        GM = this;
    }

    private void Update()
    {
        if (player == null)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene(1);
        }
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer >= 10f)
        {
            if (level <= 1.20f) level += 0.01f;
            timer = 0f;
        }

        if (timer2 >= 0.01f)
        {
            score += 1;
            timer2 = 0f;
        }
    }
}
