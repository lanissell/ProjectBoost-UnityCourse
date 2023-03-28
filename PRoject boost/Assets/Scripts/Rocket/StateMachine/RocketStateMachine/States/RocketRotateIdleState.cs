using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketRotateIdleState: BaseRocketState
    {
        public static event Action<float> OnRotate;
        public RocketRotateIdleState(global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
        }

        public override void Update()
        {
            base.Update();
            if (RotateAxis == 0) return;
            Debug.Log(RotateAxis);
            OnRotate?.Invoke(RotateAxis);
            StateMachine.ChangeAdditionalState(StateMachine.RocketRotateState);
        }
        
    }
}