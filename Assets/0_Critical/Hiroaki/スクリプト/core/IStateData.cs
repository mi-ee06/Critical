
namespace core
{
    public interface IStateData<T> where T : IStateData<T>
    {
        (StateId, IState<T>)[] GetStates();
        /// <summary>
        /// from,trigger,to
        /// </summary>
        /// <returns></returns>
        (StateId, TriggerId, StateId)[] GetTransitions();
        StateId GetInitStateId();
    }
}

