using Rocket.StateMachine.RocketStateMachine.States;
using UnityEngine;

namespace Rocket.EffectControllers
{
    [RequireComponent(typeof(AudioSource))]
    public class RocketTrustEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _trustEffect;
        private AudioSource _trustAudioSource;


        private void Start()
        {
            RocketTrustState.TrustEntering += PlayTrustEnteringEffect;
            RocketIdleState.IdleEntering += PauseTrustEffect;
            _trustAudioSource = GetComponent<AudioSource>();
        }

        private void PlayTrustEnteringEffect()
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
            RocketTrustState.TrustEntering -= PlayTrustEnteringEffect;
            RocketIdleState.IdleEntering -= PauseTrustEffect;
        }
    }
}
