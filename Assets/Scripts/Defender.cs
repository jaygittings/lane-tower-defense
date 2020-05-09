using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Animator animator;
    [SerializeField] GameObject gunpoint;
    [SerializeField] int starCost;
    [SerializeField] bool canAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(shot, gunpoint.transform.position, Quaternion.identity);
        return;
    }

}
