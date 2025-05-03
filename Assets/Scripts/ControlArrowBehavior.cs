using UnityEngine;

public class ControlArrowBehavior : MonoBehaviour
{
    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
