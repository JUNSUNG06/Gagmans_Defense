using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public int damage;
    public LayerMask targetLayer;
    public float speed = 5f;
    public Vector2 movedir;

    private void Update()
    {
        transform.Translate(movedir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == targetLayer && collision.transform.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.GetDamaged(damage, out bool isKill);
            Destroy(gameObject);
        }
    }
}
