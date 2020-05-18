using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] public float currentSpeed = 0f;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public GameObject deathVFX;
    [SerializeField] public Animator animator;
    [SerializeField] public int damage;
    [SerializeField] public float attackRate;
    [SerializeField] public int baseDamage;

    int currentHealth;
    public Defender defender;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();    
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        maxHealth *= (int)PlayerPrefsController.GetDifficulty();
        damage *= (int)PlayerPrefsController.GetDifficulty();
        baseDamage *= (int)PlayerPrefsController.GetDifficulty();

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

            if(currentHealth <= 0)
            {
                Die();
            }
        }

        defender = collision.GetComponent<Defender>();
        if(defender != null)
        {
            animator.SetTrigger("Attack");
        }
    }

    public virtual void Attack()
    {

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

    public int GetBaseDamage()
    {
        return baseDamage;
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
            levelController.AttackerKilled();
    }
}
