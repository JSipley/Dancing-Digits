using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public float speed = 2.5f; // Speed of note movement in positive Y direction
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
}
