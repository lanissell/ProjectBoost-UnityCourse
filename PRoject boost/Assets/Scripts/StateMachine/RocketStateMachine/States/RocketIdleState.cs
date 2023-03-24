using StateMachine.RocketStateMachine.States.Abstract;
using UnityEngine;

namespace StateMachine.RocketStateMachine.States
{
    public class RocketIdleState: BaseRocketState
    {
        public RocketIdleState(RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
        }

        public override void Update()
        {
            base.Update();
            if (TrustAxis == 0 && RotateAxis == 0) return;
            StateMachine.ChangeState(StateMachine.MovementState);
        }
    }
}