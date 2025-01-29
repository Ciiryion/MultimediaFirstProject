using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject deathPanel;

    [SerializeField]
    private GameObject inGamePanel;

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showDeathPanel()
    {
        inGamePanel.SetActive(false);
        deathPanel.SetActive(true);
    }
}
