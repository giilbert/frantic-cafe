using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    private List<Collider2D> colliders = new List<Collider2D>();

    void FixedUpdate()
    {
        foreach (Collider2D c in colliders)
        {
            c.attachedRigidbody.AddRelativeForce(direction * Time.deltaTime * 100);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
    }
}
