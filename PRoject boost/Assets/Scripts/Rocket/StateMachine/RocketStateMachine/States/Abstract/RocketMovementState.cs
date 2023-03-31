using StateMachine.RocketStateMachine.StatesData;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States.Abstract
{
    public abstract class RocketMovementState: BaseRocketState
    {
        protected MovementData MovementData;

        protected RocketMovementState(RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
            MovementData = Resources.Load<MovementData>("Rocket/MovementData");
        }
    }
}