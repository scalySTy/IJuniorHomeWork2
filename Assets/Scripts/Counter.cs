using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private CounterButton _button;

    private int _count = 0;
    private Coroutine _coroutine;
    
    public event Action<int> Changed;
    
    private void OnEnable()
    {
        _button.Clicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnButtonClicked;
    }
    
    private IEnumerator IncreaseCounter()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _count++;
            Changed?.Invoke(_count);
            
            yield return wait;
        }
    }

    private void OnButtonClicked()
    {
        if (_coroutine == null)
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
