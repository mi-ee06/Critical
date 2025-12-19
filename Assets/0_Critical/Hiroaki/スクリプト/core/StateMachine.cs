using System.Collections.Generic;

namespace core
{
    public class StateMachine<T> where T : IStateData<T>
    {
        private readonly T StateData;
        private readonly Dictionary<StateId, IState<T>> _states = new();
        private readonly Dictionary<(StateId, TriggerId), StateId> _transitions = new();
        private StateId _currentStateId;
        private IState<T> _currentState;

        private bool _entered = false;
        public StateMachine(T stateData)
        {
            StateData = stateData;
            addStates(StateData.GetStates());
            addTransitions(StateData.GetTransitions());
            SetInitialize(StateData.GetInitStateId());
        }
        public void Enter()
        {
            _entered = true;
            _currentState.Enter();
        }
        public void Tick()
        {
            if (!_entered) return;
            TriggerId? trigger = _currentState.Tick(StateData);
            if (trigger.HasValue)
            {
                ChangeState(trigger.Value);
            }
        }
        public void Exit()
        {
            _entered = false;
            _currentState.Exit();
        }

        private void addStates(params (StateId id, IState<T> state)[] states)
        {
            foreach (var i in states)
            {
                _states[i.id] = i.state;
            }
        }
        private void addTransitions(params (StateId from, TriggerId trigger, StateId to)[] transitions)
        {
            foreach (var i in transitions)
            {
                _transitions[(i.from, i.trigger)] = i.to;
            }
        }
        private void SetInitialize(StateId id)
        {
            _currentStateId = id;
            _currentState = _states[_currentStateId];
        }
        private void ChangeState(TriggerId id)
        {
            var key = (_currentStateId, id);
            if (!_transitions.TryGetValue(key, out var next))
            {
                return;
            }
            _currentState.Exit();
            _currentStateId = next;
            _currentState = _states[_currentStateId];
            _currentState.Enter();
        }
    }
}
