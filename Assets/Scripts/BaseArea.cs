﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArea : MonoBehaviour
{
    [SerializeField] BaseDisplay baseDisplay = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Attacker>();
        if (enemy != null)
        {
            baseDisplay.RemoveLife(enemy.GetBaseDamage());
            Destroy(enemy);
        }
    }
}

