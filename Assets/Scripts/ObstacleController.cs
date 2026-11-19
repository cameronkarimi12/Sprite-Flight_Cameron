using UnityEngine;
/**************************************************************
- COMPONENT OF: Obstacle GameObjects
- REQUIRED DEPENDENCIES: Rigidbody2D Component
- DESCRIPTION: Controls initial obstacle setup by assigning a randomized scale and applying an initial randomized movement force.
- AUTHOR: Cameron K.
- VERSION: 1.2
- VERSION 1.2: Fix CS1513 compiler error by ensuring all opening and closing curly braces in the class and methods are properly balanced.
**************************************************************/ 

public class ObstacleController : MonoBehaviour
{ 
    [Header("Initial Value Options")]
    [Tooltip("The minimum size of an obstacle")]
    [Range(0.4f, 0.6f)]
    [SerializeField] private float minSize = 0.5f;

    [Tooltip("The maximum size of an obstacle")]
    [Range(1.5f, 2.5f)]
    [SerializeField] private float maxSize = 2.0f;

    [Tooltip("The minimum speed of an obstacle")]
    [Range(40f, 60f)]
    [SerializeField] private float minSpeed = 50f;

    [Tooltip("The maximum speed of an obstacle")]
    [Range(100f, 200f)]
    [SerializeField] private float maxSpeed = 150f;
     
    private Rigidbody2D obstacleRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Cache the Rigidbody2D component attached to this GameObject
        CacheRigidbody();

        // Apply randomized size and initial directional force
        RandomizeFields(); 
    }

    // Caches the attached Rigidbody2D reference safely
    private void CacheRigidbody()
    {
        obstacleRB = GetComponent<Rigidbody2D>();
    }

    // Randomizes the scale and initial velocity vector of the obstacle
    private void RandomizeFields()
    {
        // Set randomized size
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1f);

        // Set randomized movement vector
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Add Force in selected direction with selected speed if Rigidbody2D exists
        if (obstacleRB != null)
        {
            obstacleRB.AddForce(randomDirection * randomSpeed);
        }
    }
}