using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject note; // Use SerializeField for better encapsulation
    [SerializeField] private float spawnRate = 2f;

    private float timeToSpawn;

    private readonly Vector3[] spawnPositions = 
    {
        new Vector3(-3f, 0f, 0f), // LeftControlArrowXPosition
        new Vector3(3f, 0f, 0f),  // RightControlArrowXPosition
        new Vector3(-1f, 0f, 0f), // UpControlArrowXPosition
        new Vector3(1f, 0f, 0f)   // DownControlArrowXPosition
    };

    private readonly Quaternion[] spawnRotations = 
    {
        Quaternion.Euler(0, 0, 90),  // LeftControlArrow
        Quaternion.Euler(0, 0, 270), // RightControlArrow
        Quaternion.Euler(0, 0, 0),   // UpControlArrow
        Quaternion.Euler(0, 0, 180)  // DownControlArrow
    };

    void Start()
    {
        timeToSpawn = Time.time + spawnRate;
    }

    void Update()
    {
        // Notes will eventually spanw at a ceratin time (i.e at the beat to a song)
        if (Time.time > timeToSpawn)
        {
            SpawnNote();
            timeToSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnNote()
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = new Vector3(
            spawnPositions[randomIndex].x, 
            transform.position.y, 
            transform.position.z
        );
        Quaternion spawnRotation = spawnRotations[randomIndex];

        Instantiate(note, spawnPosition, spawnRotation);
    }
}
