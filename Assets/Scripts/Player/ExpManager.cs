using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    [SerializeField]
    private int currentLevel = 1;

    [SerializeField]
    private int exp = 0;

    [SerializeField]
    private Image expBar;

    [SerializeField]
    private int[] levels;

    [SerializeField]
    private TextMeshProUGUI lvlText;

    [SerializeField]
    private GameObject enemyPrefab;

    public void GainExp(int amountExp)
    {
        exp += amountExp;
        if(exp >= levels[currentLevel - 1] && currentLevel < levels.Length)
        {
            exp = 0;
            currentLevel++;
            buffPlayer();
            if(currentLevel > levels.Length)
                lvlText.text = "Level : Max";
            else
                lvlText.text = "Level : " + currentLevel.ToString();
        }
        expBar.fillAmount = (float)exp / (float)levels[currentLevel - 1];

        if(currentLevel > levels.Length && exp % 30 == 0)
        {
            enemyPrefab.GetComponent<EnemyController>().getBuff();
        }
    }

    private void buffPlayer()
    {
        gameObject.GetComponent<CharacterController>().setCooldown(0.75f);
    }
}
