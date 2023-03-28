using Rocket.StateMachine.RocketStateMachine.States.Abstract;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketTrustIdleState: BaseRocketState
    {
        public RocketTrustIdleState(global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
        }

        public override void Update()
        {
            base.Update();
            if (TrustAxis == 0) return;
            StateMachine.ChangeCurrentState(StateMachine.TrustState);
        }

    }
}