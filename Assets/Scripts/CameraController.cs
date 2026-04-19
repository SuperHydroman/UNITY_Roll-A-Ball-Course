using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        // Calculate the initial offset between the camera's position and the player's position.
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;
        
        transform.position = player.transform.position + _offset;
    }
}
