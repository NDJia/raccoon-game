using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    public float horizontal = 1f;
    public float speed = 8f;
    public Animator animatior;
    [SerializeField] private Rigidbody2D rb;
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
            Destroy(gameObject);

        }
    }
}