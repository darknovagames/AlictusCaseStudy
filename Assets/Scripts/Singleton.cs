using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : class
{
    public static T Instance;

    public static T _instance
    {
        get { return Instance; }
    }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Instance = null;
        }
    }
}

public abstract class SingletonPersistent<T> : Singleton<T> where T : class
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}