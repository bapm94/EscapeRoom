using UnityEngine;
using System.Linq;

[RequireComponent(typeof(RectTransform))]  // Require a RectTransform component on this object
public class Aim_Controller_V2 : MonoBehaviour
{
    [SerializeField] private float maxOpacityDistance = 200.0f;  // The maximum distance from the crosshair that an object can be to be fully opaque
    [SerializeField] private float minOpacity = 0.0f;  // The minimum opacity of the crosshair
    [SerializeField] private float maxDistanceFromPlayer = 7.0f;  // The maximum distance an object can be from the player to be considered
    [SerializeField] private string tagToCheck = "000";  // The tag of objects to change opacity for


    private Collider[] colliders;  // The colliders of all objects in the scene that meet certain conditions
    private RectTransform rectTransform;  // The RectTransform of this object
    private Camera mainCamera;  // The main camera in the scene
    private Transform playerTransform;  // The transform of the player object

    private void Start()
    {
        // Find all objects in the scene that meet certain conditions, get their colliders, and store them in an array
        colliders = FindObjectsOfType<Prop>()
            .Where(prop => prop.GetComponent<Collider>() != null && prop.GetComponent<Collider>().enabled && prop.gameObject.activeSelf)
            .Select(prop => prop.GetComponent<Collider>())
            .ToArray();

        rectTransform = GetComponent<RectTransform>();  // Get the RectTransform component of this object
        mainCamera = Camera.main;  // Get the main camera in the scene
        playerTransform = GameObject.FindGameObjectWithTag("PlayerTag").transform;  // Find the player object in the scene using its tag
    }

    private void Update()
    {
        Collider closestCollider = null;  // The closest collider to the crosshair
        float closestDistance = Mathf.Infinity;  // The distance to the closest collider

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag(tagToCheck))
            {
                // Calculate direction from player to collider
                Vector3 directionToCollider = collider.transform.position - playerTransform.position;
                directionToCollider.Normalize();

                // Check if the object is within the maximum distance from the player and within the camera's view frustum and in front of the player
                if (Vector3.Distance(collider.transform.position, playerTransform.position) <= maxDistanceFromPlayer &&
                    GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(mainCamera), collider.bounds) &&
                    Vector3.Dot(directionToCollider, playerTransform.forward) > 0)
                {
                    // Calculate distance to crosshair
                    Vector3 screenPosition = mainCamera.WorldToScreenPoint(collider.transform.position);
                    Vector3 crosshairPosition = rectTransform.position;
                    float distance = Vector3.Distance(screenPosition, crosshairPosition);

                    // If this object is closer to the crosshair than any previous objects, make it the closest
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestCollider = collider;
                    }
                }
            }
        }


        Debug.Log(closestCollider + " " + closestDistance);

        // Calculate the opacity of the crosshair based on the distance to the closest object
        float opacity = 1.0f - (closestDistance / maxOpacityDistance);
        opacity = Mathf.Clamp(opacity, minOpacity, 1.0f);

        // Set the alpha value of the crosshair's color to the calculated opacity
        Color color = GetComponent<UnityEngine.UI.Image>().color;
        color.a = opacity;
        GetComponent<UnityEngine.UI.Image>().color = color;
    }
}
