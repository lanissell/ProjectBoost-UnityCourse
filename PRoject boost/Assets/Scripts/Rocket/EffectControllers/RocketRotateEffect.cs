using Rocket.StateMachine.RocketStateMachine.States;
using UnityEngine;

namespace Rocket.EffectControllers
{
    public class RocketRotateEffect : MonoBehaviour
    {
        [SerializeField] private AudioSource _rotateAudioSource;
        [SerializeField] private ParticleSystem _leftSmokeEffect;
        [SerializeField] private ParticleSystem _rightSmokeEffect;

        private void Start()
        {
            RocketRotateState.RotateEntering += PlayRotateEffect;
            RocketRotateState.RotateExiting += PauseRotateEffect;
        }
        
        private void PlayRotateEffect(float direction)
        {
            _rotateAudioSource.Play();
            if (direction > 0)
            {
                _leftSmokeEffect.Play();
                _rightSmokeEffect.Stop();
            }
            else
            {
                _rightSmokeEffect.Play();
                _leftSmokeEffect.Stop();
            }
        }
    
        private void PauseRotateEffect()
        { 
            _rotateAudioSource.Pause();
            _leftSmokeEffect.Stop();
            _rightSmokeEffect.Stop();
        } 
        
        private void OnDestroy()
        {
            RocketRotateState.RotateEntering -= PlayRotateEffect;
            RocketRotateState.RotateExiting -= PauseRotateEffect;
        }
    }
}
