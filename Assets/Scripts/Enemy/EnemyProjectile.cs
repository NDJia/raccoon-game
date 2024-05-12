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
        projectile.SetActive(false);

    }
    public void Launch()
    {
        projectile.SetActive(true);
        horizontal = enemyObj.GetComponent<Ranged_Attack>().horizontal;
        this.transform.position = new Vector3(enemyObj.transform.position.x + 2 * horizontal,
        enemyObj.transform.position.y-0.5f, 0);
        Debug.Log("projectile horizontal " + horizontal);
        this.transform.localScale = new Vector3(horizontal, 1, 1);
        Debug.Log("projectile spawned");
    }


    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Debug.Log("projectile flying " + projectile.transform.position.x + projectile.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            Debug.Log("projectile hit");
            projectile.SetActive(false);
        }

    }
}