using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float strafeDistance = 2.0f; 
    public float strafeSpeed = 1.5f;    
    
    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        // This makes sure all enemies don't move in perfect sync
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // Calculate a side-to-side movement on the X axis
        float xMovement = Mathf.Sin((Time.time + randomOffset) * strafeSpeed) * strafeDistance;
        
        // Update the position relative to the starting point
        transform.position = startPosition + new Vector3(xMovement, 0, 0);
    }
}