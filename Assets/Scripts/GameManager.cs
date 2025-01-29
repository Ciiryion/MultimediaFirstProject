using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float score;
    public bool isDead = false;

    public event Action onDeath;



    private void Awake()
    {
        if (GameManager.instance != null && GameManager.instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void updScore(float addScore)
    {
        score += addScore;
    }

    public void death()
    {
        Debug.Log("death()");
        isDead = true;
        SceneManager.LoadScene("MainMenu");
        onDeath?.Invoke();
    }
}
