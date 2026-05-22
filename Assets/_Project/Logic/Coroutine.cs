using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private float _time;

    private int _count;
    private bool _isCounting = false;

    public void StartCount()
    {
        if (_isCounting)
        {
            return;
        }

        _isCounting = true;
        StartCoroutine(CoroutineCount());
    }

    public void StopCount()
    {
        _isCounting = false;
    }

    private IEnumerator CoroutineCount()
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(_time);

            _count++;
            Debug.Log($"{_count}");
        }
    }
}
