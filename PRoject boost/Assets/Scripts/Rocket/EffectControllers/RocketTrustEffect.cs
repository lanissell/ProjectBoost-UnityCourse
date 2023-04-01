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
            RocketTrustState.OnTrustEnter += PlayTrustEnterEffect;
            RocketIdleState.OnIdleEnter += PauseTrustEffect;
            _trustAudioSource = GetComponent<AudioSource>();
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
