using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;


namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketIdleState: BaseRocketState
    {
        public static event Action IdleEntering; 

        public RocketIdleState(RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            IdleEntering?.Invoke();
        }

        public override void Exit()
        {
            StateMachine.PreviousState = this;
        }

        public override void Update()
        {
            base.Update();
            ActivateRotateState();
            if (TrustAxis == 0) return;
            StateMachine.ChangeCurrentState(StateMachine.TrustState);
        }

    }
}