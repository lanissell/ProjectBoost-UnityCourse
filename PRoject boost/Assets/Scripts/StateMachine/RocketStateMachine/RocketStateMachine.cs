using StateMachine.RocketStateMachine.States;
using UnityEngine;

namespace StateMachine.RocketStateMachine
{
    public class RocketStateMachine: BaseStateMachine
    {
        public Rigidbody RocketRigidbody { get;}

        public RocketIdleState IdleState;
        public RocketMovementState MovementState;

        public RocketStateMachine(Rigidbody rigidbody)
        {
            RocketRigidbody = rigidbody;
            IdleState = new RocketIdleState(this);
            MovementState = new RocketMovementState(this);
        }
    }
}