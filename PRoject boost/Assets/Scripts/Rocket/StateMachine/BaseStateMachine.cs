namespace StateMachine
{
    public abstract class BaseStateMachine
    {
        private IState _currentState;
        private IState _additionalState;

        public void ChangeCurrentState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        
        public void ChangeAdditionalState(IState newState)
        {
            _additionalState?.Exit();
            _additionalState = newState;
            _additionalState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
            _additionalState?.Update();
        }

        public void FixedUpdate()
        {
            _currentState?.FixedUpdate();
            _additionalState?.FixedUpdate();
        }
    }
}