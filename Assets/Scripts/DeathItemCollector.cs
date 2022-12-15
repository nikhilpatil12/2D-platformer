using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathItemCollector : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI scoreTextOver;
    [SerializeField] public TextMeshProUGUI scoreTextFinal;
    private int score = 0;
    private int lives = 5;

    public Animator enemyAnimator;
    public Rigidbody2D player;
    public GameObject RestartMenuPanel;
    public GameObject LevelCompletePanel;

    public Image[] liveImages;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score++;
            Destroy(collision.gameObject);
            scoreText.text = " " + score;
            SFXManager.sfxManager.audioSource.PlayOneShot(SFXManager.sfxManager.collectClip);

        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            LevelCompletePanel.SetActive(true);
            scoreTextFinal.text = "Score: " + score;
            SFXManager.sfxManager.audioSource.PlayOneShot(SFXManager.sfxManager.finishClip);

            Debug.Log("Level Complete" + score);
            //player.transform.position = new Vector2(-2.7f, -0.55f);

        }

        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            collision.GetComponentInParent<CircleCollider2D>().enabled = false;

            BoxCollider2D[] liB2D = collision.transform.parent.GetComponentsInChildren<BoxCollider2D>();
            foreach(BoxCollider2D b2d in liB2D)
            {
                if (b2d.CompareTag("EnemyPoison"))
                    b2d.enabled = false;
            }

            score = score + 10;
            scoreText.text = " " + score;
            //Destroy(collision.gameObject);
            SFXManager.sfxManager.audioSource.PlayOneShot(SFXManager.sfxManager.killMonsterClip);

            enemyAnimator.SetBool("die", true);
        }

        if (collision.gameObject.CompareTag("EnemyPoison"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            Die();
        }
    }

    void Die()
    {
        lives--;
        liveImages[5 - lives - 1].enabled = false;
        SFXManager.sfxManager.audioSource.PlayOneShot(SFXManager.sfxManager.dieClip);
        if (lives == 0)
        {
            RestartMenuPanel.SetActive(true);
            scoreTextOver.text = "Score: " + score;

            Debug.Log("Game Over" + score);
            player.transform.position = new Vector2(-2.7f, -0.55f);
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
                player.transform.position = new Vector2(-2.7f, -0.55f);
            if (SceneManager.GetActiveScene().buildIndex == 3)
                player.transform.position = new Vector2(-9.68f, 8.23f);
            if (SceneManager.GetActiveScene().buildIndex == 4)
                player.transform.position = new Vector2(-2.7f, -0.55f);

            //playerAnimator.SetBool("IsRespawning", true);
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
