using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 0;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * (rotationSpeed * Time.deltaTime));
    }
}
