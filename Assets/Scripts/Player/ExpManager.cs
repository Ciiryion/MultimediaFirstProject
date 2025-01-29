using System.Linq;
using TMPro;
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

    public void GainExp(int amountExp)
    {
        exp += amountExp;
        if(exp >= levels[currentLevel - 1] && currentLevel < levels.Length)
        {
            exp = 0;
            currentLevel++;
            lvlText.text = "Level : " + currentLevel.ToString();
        }
        expBar.fillAmount = (float)exp / (float)levels[currentLevel - 1];
    }
}
