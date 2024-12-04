using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private int _count = 0;
    private Coroutine _coroutine;
    
    public event Action<int> Changed;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_coroutine == null)
            {
                _coroutine = StartCoroutine(IncreaseCounter());               
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
    
    private IEnumerator IncreaseCounter()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _count++;
            Changed?.Invoke(_count);
            
            yield return wait;
        }
    }
}
