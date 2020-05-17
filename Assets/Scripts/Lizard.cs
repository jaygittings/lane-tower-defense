using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Attacker
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public override void Attack()
    {
        if (defender == null)
            return;

        base.Attack();

        var defenderHealth = defender.GetComponent<Health>();
        defenderHealth.DoDamage(damage);

        if (defenderHealth.IsDead())
        {
            defenderHealth.Die();
            animator.SetTrigger("Walk");
        }

        //animator.SetTrigger("Attack");
        //var defenderHealth = defender.GetComponent<Health>();

        //while(!defenderHealth.IsDead())
        //{
        //    defenderHealth.DoDamage(damage);
        //    yield return new WaitForSeconds(attackRate);
        //}

        //if(defenderHealth != null)
        //    defenderHealth.Die();
        //animator.SetTrigger("Walk");

    }
}
