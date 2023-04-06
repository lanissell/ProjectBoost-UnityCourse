using UnityEngine;

namespace Rocket.EffectControllers
{
    public class RocketDestroyEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosion;

        private void OnEnable()
        {
            RocketDestroyer.Destroying += PlayDestroyEffect;
        }

        private void PlayDestroyEffect()
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
        
        private void OnDisable()
        {
            RocketDestroyer.Destroying -= PlayDestroyEffect;
        }
    }
}
