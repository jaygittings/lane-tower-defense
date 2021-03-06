﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;

    bool selected;

    // Start is called before the first frame update
    void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {

        Text costText = GetComponentInChildren<Text>();
        if(costText)
            costText.text = defenderPrefab.GetCost().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseExit()
    {
        if (!selected)
            GetComponent<SpriteRenderer>().color = new Color(0.236f, 0.235f, 0.235f, 1.000f);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<GameArea>().SetSelectedDefender(defenderPrefab);
        foreach(DefenderButton b in FindObjectsOfType<DefenderButton>())
        {
            b.IsSelected(false);
            b.GetComponent<SpriteRenderer>().color = new Color32(60, 60, 60, 255);
        }
        selected = true;
    }

    public void IsSelected(bool b)
    {
        selected = b;
    }
}
