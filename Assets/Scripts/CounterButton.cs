using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CounterButton : MonoBehaviour
{
    private Button _selfButton;
    
    public event Action Clicked;
    
    private void Awake()
    {
        _selfButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _selfButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _selfButton.onClick.RemoveListener(OnButtonClicked);
    }
    
    private void OnButtonClicked()
    {
        Clicked?.Invoke();
    }
}
