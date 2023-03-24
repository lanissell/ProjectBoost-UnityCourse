using UnityEngine;

namespace StateMachine.RocketStateMachine.StatesData
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "Rocket/New MovementData")]
    public class MovementData:ScriptableObject
    {
        [field: SerializeField] public float Force { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
    }
}