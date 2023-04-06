using System;
using UnityEngine;

namespace Rocket
{
    public class RocketDestroyer : MonoBehaviour
    {
        public static event Action Destroying;

        public void DestroyRocket()
        {
            Destroy(gameObject);
            Destroying?.Invoke();
        }

    }
}
