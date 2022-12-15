using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    private int score = 0;
    private int lives = 5;

    public Rigidbody2D player;
    public GameObject RestartMenuPanel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score++;
            Destroy(collision.gameObject);
            scoreText.text = "Score: " + score;
        }
    }
}
