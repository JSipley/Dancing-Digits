using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public float speed = 2.5f;
    private bool _noteMissed = false;
    void Start()
    {
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Y postion 6 is out of bounds for camera FOV
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    // If a control was pressed before a collison between the note and control was
    // triggered, consider the event a miss. 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Control_Arrow"))
        {
            return;
        }
        if (collision.gameObject.GetComponent<ControlArrowBehavior>().IsActive)
        {
            Debug.Log("MISSED Note: Control held down prematurely");
            _noteMissed = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Control_Arrow") || _noteMissed)
        {
            return;
        }
        if (collision.gameObject.GetComponent<ControlArrowBehavior>().IsActive)
        {
            Destroy(gameObject);
            Debug.Log("HIT Note");
        }
    }
}
