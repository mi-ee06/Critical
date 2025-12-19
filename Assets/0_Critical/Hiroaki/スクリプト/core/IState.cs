
namespace core
{
    public interface IState<T> where T : IStateData<T>
    {
        void Enter();
        TriggerId? Tick(T data);
        void Exit();
    }
}
