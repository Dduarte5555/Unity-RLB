using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int Respawn;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public TextMeshProUGUI timerText;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int timer;
    private int contador_timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 60;
        contador_timer = 0;


        SetCountText();
        SetTimerText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            // winTextObject.SetActive(true);
            SceneManager.LoadScene(3);
        }
    }

    void SetTimerText()
    {
        timerText.text = "Timer: " + timer.ToString();
        contador_timer++;
        if(contador_timer == 60){
            timer--;
            contador_timer = 0;
        }

        if(timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        SetTimerText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }
}
