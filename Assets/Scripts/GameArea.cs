using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    // Start is called before the first frame update
    void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;

        AttemptToPlaceDefender(SnapToGrid(point));
    }

    private Vector2 SnapToGrid(Vector2 rawPos)
    {
        int newX = Mathf.RoundToInt(rawPos.x);
        int newY = Mathf.RoundToInt(rawPos.y);

        return new Vector2(newX, newY);
    }

    public void SetSelectedDefender(Defender d)
    {
        defender = d;
    }

    public void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var money = FindObjectOfType<MoneyDisplay>();
        var defenderCost = defender.GetCost();

        if(money.EnoughMoney(defenderCost))
        {
            money.RemoveMoney(defenderCost);
            var obj = Instantiate(defender, gridPos, Quaternion.identity);
            obj.transform.parent = defenderParent.transform;
        }
    }
}
