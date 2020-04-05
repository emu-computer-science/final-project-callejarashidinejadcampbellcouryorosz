using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Waypoint Class
    // AI Classes will use this to tranform to predetermined locations
public class Waypoint : MonoBehaviour
{
    // This is an array of the different waypoints for AI to follow
        // Each object will have their own set of wapoints to go to
        // It's a List of Transformations called "waypoints"
    public Transform[] waypoints;
}
