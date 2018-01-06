using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int points;
    public Text pointCounter;
    public Text gameState;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetPointsText();
        gameState.text = "";
       
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            points += 1;
            SetPointsText();
        }
    }

    void SetPointsText()
    {
        pointCounter.text = "Your point's : " + points.ToString();
        if (points >= 12)
        {
            gameState.text = "Wygrałeś !";
        }
    }
}
