using Rocket.StateMachine.RocketStateMachine.States;
using StateMachine;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine
{
    public class RocketStateMachine: BaseStateMachine
    {
        public Rigidbody RocketRigidbody { get;}
        public RocketIdleState IdleState { get; }
        public RocketTrustState TrustState { get; }
        public RocketRotateState RotateState { get; }

        public IState PreviousState;

        public RocketStateMachine(Rigidbody rigidbody)
        {
            RocketRigidbody = rigidbody;
            IdleState = new RocketIdleState(this);
            TrustState = new RocketTrustState(this);
            RotateState = new RocketRotateState(this);
        }
    }
}