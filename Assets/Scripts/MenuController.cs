using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject deathPanel;

    [SerializeField]
    private GameObject mainMenuPanel;

    private void Start()
    {
        if (GameManager.instance.isDead)
        {
            showDeathPanel();
        }
            
        GameManager.instance.onDeath += showDeathPanel;
    }

    private void Update()
    {
    }

    public void changeScene(string sceneName)
    {
        GameManager.instance.isDead = false;
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showDeathPanel()
    {
        Debug.Log("showDeathPanel()" + gameObject.name);
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
            deathPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Score : " + GameManager.instance.score;
        }

    }

    private void OnDestroy()
    {
        GameManager.instance.onDeath -= showDeathPanel;
    }
}
