namespace Core.Interfaces
{
    public interface IPooledObject
    {
        bool ActivateOnSpawn { get;}
        void OnObjectSpawn();
    }
}