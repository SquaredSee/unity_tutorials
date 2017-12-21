using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        updateCountText();
    }

    // FixedUpdate is called before physics calculations
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count++;
            updateCountText();
        }
    }

    void updateCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 8) {
            winText.text = "You Win!";
        }
    }
}
