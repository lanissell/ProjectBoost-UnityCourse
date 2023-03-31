using Rocket.StateMachine.RocketStateMachine.States;
using UnityEngine;

namespace Rocket.EffectControllers
{
    public class RocketTrustEffect : MonoBehaviour
    {
        [SerializeField] private AudioSource _trustAudioSource;
        [SerializeField] private ParticleSystem _trustEffect;

        private void Start()
        {
            RocketTrustState.OnTrustEnter += PlayTrustEnterEffect;
            RocketIdleState.OnIdleEnter += PauseTrustEffect;
        }

        private void PlayTrustEnterEffect()
        {
            _trustAudioSource.Play();
            _trustEffect.Play();
        }
    
        private void PauseTrustEffect()
        {
            _trustAudioSource.Pause();
            _trustEffect.Stop();
        }

        private void OnDestroy()
        {
            RocketTrustState.OnTrustEnter -= PlayTrustEnterEffect;
            RocketIdleState.OnIdleEnter -= PauseTrustEffect;
        }
    }
}
