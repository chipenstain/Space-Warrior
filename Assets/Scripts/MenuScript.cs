using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text score;

    private void Awake()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
    }

    public void OnStart()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
