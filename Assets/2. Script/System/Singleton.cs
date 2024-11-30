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
        // �ߺ� ����: �̹� �ν��Ͻ��� �����ϸ� ���� ������ ������Ʈ�� �ı�
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