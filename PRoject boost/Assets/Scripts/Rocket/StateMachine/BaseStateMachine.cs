namespace StateMachine
{
    public abstract class BaseStateMachine
    {
        public IState CurrentState { get; private set; }
        private IState _additionalState;

        public void ChangeCurrentState(IState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        
        public void ChangeAdditionalState(IState newState)
        {
            _additionalState?.Exit();
            _additionalState = newState;
            _additionalState.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
            _additionalState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
            _additionalState?.FixedUpdate();
        }
    }
}