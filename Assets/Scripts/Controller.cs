using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Keyboard.current;
        if (gamepad == null) return;

        // Check each key and activate/deactivate arrows accordingly
        leftArrow.GetComponent<ControlArrowBehavior>().SetActive(gamepad.leftArrowKey.isPressed);
        rightArrow.GetComponent<ControlArrowBehavior>().SetActive(gamepad.rightArrowKey.isPressed);
        upArrow.GetComponent<ControlArrowBehavior>().SetActive(gamepad.upArrowKey.isPressed);
        downArrow.GetComponent<ControlArrowBehavior>().SetActive(gamepad.downArrowKey.isPressed);
    }
}
