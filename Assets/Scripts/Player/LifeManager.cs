using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    private int lifePoints = 5;

    [SerializeField]
    private Canvas canvasGame;

    [SerializeField]
    private Image lifeBar;

    private int initialLifePoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialLifePoints = lifePoints;
    }

    public void takeDamage(int damage)
    {
        Debug.Log(nameof(takeDamage));
        lifePoints -= damage;
        lifeBar.fillAmount -= (float)damage / (float)initialLifePoints;


        if (lifePoints <= 0)
        {
            death();
            return;
        }
        // TODO : Ajouter un son quand le joueur prend des degats
    }

    private void death()
    {
        Debug.Log(nameof(death));
        // TODO : Ajouter un son quand le joueur meurt
        canvasGame.GetComponent<MenuController>().showDeathPanel();
    }
}
