using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text score;
    public Text speed;
    public Image fade;
    public Text fadeT;

    public GameObject pause;

    private float timer = 0f;

    private void Awake()
    {
        pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.GM.enabled = false;
            pause.SetActive(true);
            Time.timeScale = 0;
        }

        timer += Time.deltaTime;
        speed.text = (Math.Round((GameManager.GM.level - 1f), 2) * 100).ToString();
        score.text = GameManager.GM.score.ToString();

        if (fade)
        {
            fade.color = new Color(0, 0, 0, 1 - timer / 4);
        }

        if (timer >= 5f)
        {
            Destroy(fadeT);
            Destroy(fade);
        }
    }

    public void OnResume()
    {
        GameManager.GM.enabled = true;
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnExit()
    {
        SceneManager.LoadScene(1);
    }
}
