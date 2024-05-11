using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    public float horizontal = 1f;
    public float speed = 8f;
    private GameObject enemyObj = null;
    private GameObject projectile = null;
    public Animator animatior;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        projectile= GameObject.Find("projectile");
        rb = GetComponent<Rigidbody2D>();
        enemyObj = GameObject.Find("RangedEnemy");
        horizontal = enemyObj.GetComponent<Ranged_Attack>().horizontal;
        
        this.transform.position = new Vector3(enemyObj.transform.position.x + 2* horizontal, 
        enemyObj.transform.position.y, enemyObj.transform.position.z);
        Debug.Log(enemyObj.transform.position.z);
        this.transform.localScale = new Vector3(-1*horizontal, 1,1);
        Debug.Log("projectile spawned");
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
        projectile.SetActive(false);
    }
}