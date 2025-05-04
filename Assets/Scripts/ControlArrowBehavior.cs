using UnityEngine;

public class ControlArrowBehavior : MonoBehaviour
{
    private bool _isActive = false;

    public bool IsActive
    {
        get { return _isActive; }
        set
        {
            _isActive = value;
            SetActive(_isActive);
        }
    }
    
    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            _isActive = true;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
