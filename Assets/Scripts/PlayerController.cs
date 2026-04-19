using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject postGameTextObj;
    
    private Rigidbody _rb;
    private int _totalPickups;
    private int _count;
    private float _movementX;
    private float _movementY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        _totalPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
        SetCountText();
        postGameTextObj.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = $"Count: {_count.ToString()} / {_totalPickups}";

        if (_count < _totalPickups) return;
        
        postGameTextObj.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        
        Destroy(gameObject);
            
        postGameTextObj.GetComponent<TextMeshProUGUI>().text = "You lose!";
        postGameTextObj.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
