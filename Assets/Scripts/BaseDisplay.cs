using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseDisplay : MonoBehaviour
{
    [SerializeField] int startLife = 100;

    Text displayText;
    int currentLife;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        currentLife = startLife;
        UpdateDisplay();
    }

    // Update is called once per frame

    private void UpdateDisplay()
    {
        displayText.text = currentLife.ToString();
    }

    public void RemoveLife(int amt)
    {
        if (amt > currentLife)
            currentLife = 0;
        else
            currentLife -= amt;

        UpdateDisplay();

        if(currentLife == 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        FindObjectOfType<LevelController>().Lose();
    }
}
