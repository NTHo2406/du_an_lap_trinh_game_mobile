using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public float speed = 5f;
    public float width = 17.78f;

    public Text scoreText;
    private int score = 0;

    private bool isGameOver = false;

    void Start()
    {
        InvokeRepeating(nameof(AddScore), 1f, 1f);
    }

    void Update()
    {
        if (isGameOver) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }

    void AddScore()
    {
        if (isGameOver) return;

        score++;
        scoreText.text = "Score: " + score;
    }

    public void StopGame()
    {
        isGameOver = true;
        CancelInvoke();
    }
}