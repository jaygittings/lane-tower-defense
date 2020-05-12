using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] int startMoney = 100;

    Text displayText;
    int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        currentMoney = startMoney;
        UpdateDisplay();
    }

    // Update is called once per frame

    private void UpdateDisplay()
    {
        displayText.text = currentMoney.ToString();
    }

    public void AddMoney(int amt)
    {
        currentMoney += amt;
        UpdateDisplay();
    }

    public void RemoveMoney(int amt)
    {
        if (amt > currentMoney)
            return;

        currentMoney -= amt;
        UpdateDisplay();
    }

    public bool EnoughMoney(int amt)
    {
        return currentMoney >= amt;
    }
}
