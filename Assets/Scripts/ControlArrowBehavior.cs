using UnityEngine;

public class ControlArrowBehavior : MonoBehaviour
{
    private bool _isActive = false;

    public bool IsActive
    {
        get => _isActive;
        set => SetActive(value);
    }
    
    public void SetActive(bool isActive)
    {
        _isActive = isActive;
        GetComponent<Renderer>().material.color = isActive ? Color.yellow : Color.white;
    }
}
