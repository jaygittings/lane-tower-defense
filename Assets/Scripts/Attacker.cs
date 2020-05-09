using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float currentSpeed = 0f;
    [SerializeField] int maxHealth = 100;
    [SerializeField] GameObject deathVFX;

    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            currentHealth -= bullet.DoDamage();
            bullet.DestoryBullet();
            //Debug.Log("currentHealth = " + currentHealth);

            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if(deathVFX != null)
        {
            var obj = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(obj, 1f);
        }
        Destroy(this.gameObject);
    }

}
