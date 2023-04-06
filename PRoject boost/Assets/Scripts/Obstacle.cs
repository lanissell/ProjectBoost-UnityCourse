using System.Collections;
using System.Collections.Generic;
using Rocket;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var collisionGameObject = collision.gameObject;
        if (collisionGameObject.TryGetComponent(out RocketDestroyer rocket))
            rocket.DestroyRocket();
    }
}
