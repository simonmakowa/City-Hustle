using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class TargetIndicator : MonoBehaviour
{

    /*public Transform target;
     public float rotationSpeed;
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.position - transform.position),rotationSpeed * Time.deltaTime);
     }*/

    /* public Transform player;         // Reference to the player
    public Transform destination;    // Reference to the destination
    public float heightOffset = 1f;  // Height of the line above the ground
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    public float maxWidth = 0.5f;
    public float minWidth = 0.1f;

    private LineRenderer lineRenderer;
    private float initialDistance;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Store initial distance for scaling purposes
        if (player && destination)
        {
            initialDistance = Vector3.Distance(player.position, destination.position);
        }

        // Set up line renderer properties
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }

    void Update()
    {
        if (player == null || destination == null) return;

        // Update line positions
        Vector3 startPos = player.position + Vector3.up * heightOffset;
        Vector3 endPos = destination.position + Vector3.up * heightOffset;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // Calculate current distance and scale line width accordingly
        float currentDistance = Vector3.Distance(player.position, destination.position);
        float distanceRatio = currentDistance / initialDistance;
        float width = Mathf.Lerp(minWidth, maxWidth, distanceRatio);

        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }*/
    public Transform player;
    public DestinationManager destinationManager;  // Reference to destination manager
    public float heightOffset = 1f;
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    public float maxWidth = 0.5f;
    public float minWidth = 0.1f;

    private LineRenderer lineRenderer;
    private float initialDistance;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Subscribe to destination change events
        if (destinationManager != null)
        {
            destinationManager.onDestinationChanged += OnDestinationChanged;
        }

        // Set up line renderer properties
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }

    void OnDestroy()
    {
        if (destinationManager != null)
        {
            destinationManager.onDestinationChanged -= OnDestinationChanged;
        }
    }

    void OnDestinationChanged()
    {
        // Update initial distance for the new destination
        Transform currentDestination = destinationManager.GetCurrentDestination();
        if (player && currentDestination)
        {
            initialDistance = Vector3.Distance(player.position, currentDestination.position);
        }
    }

    void Update()
    {
        Transform currentDestination = destinationManager.GetCurrentDestination();
        if (player == null || currentDestination == null)
        {
            // Hide line if no destination is active
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.enabled = true;

        // Update line positions
        Vector3 startPos = player.position + Vector3.up * heightOffset;
        Vector3 endPos = currentDestination.position + Vector3.up * heightOffset;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // Calculate current distance and scale line width accordingly
        float currentDistance = Vector3.Distance(player.position, currentDestination.position);
        float distanceRatio = currentDistance / initialDistance;
        float width = Mathf.Lerp(minWidth, maxWidth, distanceRatio);

        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
