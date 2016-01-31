using UnityEngine;
using System.Collections;

public class RitualController : MonoBehaviour
{
    public int numRitualItems;
    private int itemsPlaced = 0;

    public GameObject WinScreen;

    public void ItemComplete()
    {
        itemsPlaced++;

        if(itemsPlaced >= numRitualItems)
        {
            EndGame();
        }
    }

    public void ItemRemoved()
    {
        itemsPlaced--;
    }

    void EndGame()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

}
