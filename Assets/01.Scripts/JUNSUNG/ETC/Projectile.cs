using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public int damage;
    public LayerMask targetLayer;
    public float speed;
    public Vector2 movedir;

    private void Update()
    {
        transform.Translate(movedir * speed * Time.deltaTime);
    }
}
