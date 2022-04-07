using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D gameBounds; // Gets the game boundaries

    private float xMin, xMax, yMin, yMax; // For the boundaries
    private float camY, camX; // Control camera movement
    private float camOrthsize; // Vertical camera FOV
    private float cameraRatio; // Horizontal 
    private Camera mainCam;

    private Vector3 smoothPos; // Allows for smoother camera movement
    public float smoothSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // The following sets the boundaries
        xMin = gameBounds.bounds.min.x;
        xMax = gameBounds.bounds.max.x;
        yMin = gameBounds.bounds.min.y;
        yMax = gameBounds.bounds.max.y;
        
        mainCam = GetComponent<Camera>();
        
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f; // Calculates horizontal size 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        camY = Mathf.Clamp(player.position.y, yMin + camOrthsize, yMax - camOrthsize); // Restricts the camera bounds betwen min and max
        camX = Mathf.Clamp(player.position.x, xMin + cameraRatio, xMax - cameraRatio);
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        transform.position = temp;
    }
}
