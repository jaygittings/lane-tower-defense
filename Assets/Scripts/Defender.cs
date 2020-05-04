using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Animator animator;


    Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        shotPoint = transform.Find("Shot Point");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(shot, shotPoint.position, Quaternion.identity);
        return;
    }
}
