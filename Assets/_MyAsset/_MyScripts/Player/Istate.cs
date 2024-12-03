public interface Istate<T>
{
    public void OnEnter(T state);
    public void OnExcute(T state);
    public void OnExit(T state);
}