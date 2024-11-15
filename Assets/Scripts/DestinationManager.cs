using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    public Transform player;
    public Transform[] destinations;  // Array of destination points
    public float reachDistance = 2f; // Distance at which destination is considered reached

    private int currentDestinationIndex = 0;

    // Event that navigation scripts can subscribe to
    public System.Action onDestinationChanged;

    public Transform GetCurrentDestination()
    {
        if (currentDestinationIndex < destinations.Length)
        {
            return destinations[currentDestinationIndex];
        }
        return null;
    }

    void Update()
    {
        if (currentDestinationIndex >= destinations.Length) return;

        // Check if player reached current destination
        float distance = Vector3.Distance(
            player.position,
            destinations[currentDestinationIndex].position
        );

        if (distance <= reachDistance)
        {
            // Deactivate current destination
            destinations[currentDestinationIndex].gameObject.SetActive(false);

            // Move to next destination
            currentDestinationIndex++;

            // Activate next destination if available
            if (currentDestinationIndex < destinations.Length)
            {
                destinations[currentDestinationIndex].gameObject.SetActive(true);
                // Notify navigation indicators of destination change
                onDestinationChanged?.Invoke();
            }
        }
    }
}
