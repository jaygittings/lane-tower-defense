using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject shot = null;
    [SerializeField] Animator animator = null;
    [SerializeField] GameObject gunpoint = null;
    [SerializeField] int starCost = 100;
    [SerializeField] bool canAttack = false;
    [SerializeField] GameObject star = null;


    EnemySpawner myLaneSpawner;

    // Start is called before the first frame update
    void Start()
    {
       SetLaneSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack)
        {
            if(IsAttackerInLane())
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(shot, gunpoint.transform.position, Quaternion.identity);
        return;
    }

    public void AddMoney(int amt)
    {
        FindObjectOfType<MoneyDisplay>().AddMoney(amt);
        var obj = Instantiate(star, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);
    }

    public int GetCost()
    {
        return starCost;
    }

    public bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
            return true;
        return false;
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner e in spawners)
        {
            if (e.transform.position.y == transform.position.y)
                myLaneSpawner = e;
        }

        if (myLaneSpawner == null)
            Debug.Log("prob finding spawner");
    }
}
