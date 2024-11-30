using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _inst;
    public static T Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindAnyObjectByType<T>();
            }
            return _inst;
        }
    }

    private void Awake()
    {
        // 중복 방지: 이미 인스턴스가 존재하면 새로 생성된 오브젝트를 파괴
        if (_inst == null)
        {
            _inst = this as T;
        }
        else if (_inst != this)
        {
            Destroy(gameObject);
        }
    }
}