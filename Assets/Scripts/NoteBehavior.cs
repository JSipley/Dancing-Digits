using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    private bool _noteMissed = false;

    private const float OutOfBoundsY = 6f;
    private const float FullHitCeiling = 0.2f;
    private const float PartialHitCeiling = 0.5f;

    void Update()
    {
        MoveNote();
        CheckOutOfBounds();
    }

    private void MoveNote()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y > OutOfBoundsY)
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
            float noteHitAccuracy = (collision.transform.position - transform.position).magnitude;
            Debug.Log("Note Hit, Score: " + CalculateScore(noteHitAccuracy));

            Destroy(gameObject);
        }
    }

    int CalculateScore(float accuracy)
    {
        if (accuracy <= FullHitCeiling)
        {
            return 100;
        }
        else if (accuracy <= PartialHitCeiling)
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }
}
