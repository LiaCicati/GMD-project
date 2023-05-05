using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour {

    public float speed;
    public GameObject locationTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private MiniGame miniGame;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        locationTextObject.SetActive(false);
        miniGame = FindObjectOfType<MiniGame>(); // find MiniGame object in the scene
        Debug.Log("Start called.");
    }

    void FixedUpdate ()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Potion"))
        {
            other.gameObject.SetActive (false);
            SetLocationText ();
            miniGame.FoundPotion(); // call public function on MiniGame object
        }
    } 
 
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

    private void SetLocationText()
    {
        locationTextObject.SetActive(true);
    } 
}