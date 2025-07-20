using UnityEngine;

public class PhotoTourManager : MonoBehaviour
{
    // Drag your 6 sphere GameObjects here
    public GameObject[] viewpoints;
    private int currentViewpointIndex = 0;

    void Start()
    {
        // When the scene starts, make sure only the first viewpoint is visible.
        ChangeViewpoint(0);
    }

    // This function is called every single frame
    void Update()
    {
        // Check if the 'A' button on the right controller is pressed down
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            GoToNextViewpoint();
        }
    }

    void GoToNextViewpoint()
    {
        // Add 1 to the current index
        currentViewpointIndex++;

        // If the index goes past the last viewpoint, loop back to the start (0)
        if (currentViewpointIndex >= viewpoints.Length)
        {
            currentViewpointIndex = 0;
        }

        // Call the function to switch the sphere
        ChangeViewpoint(currentViewpointIndex);
    }

    public void ChangeViewpoint(int index)
    {
        // First, turn all spheres off
        for (int i = 0; i < viewpoints.Length; i++)
        {
            viewpoints[i].SetActive(false);
        }

        // Then, turn on only the one we want
        if (index >= 0 && index < viewpoints.Length)
        {
            viewpoints[index].SetActive(true);
        }
    }
}