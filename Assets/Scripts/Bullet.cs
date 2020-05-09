using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float shotSpeed = 10f;
    [SerializeField] float rotationSpeed = 6f;
    [SerializeField] int damage = 10;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * shotSpeed * Time.deltaTime);
    }

    public int DoDamage()
    {
        return damage;
    }

    public void DestoryBullet()
    {
        Destroy(this.gameObject);
    }
}
