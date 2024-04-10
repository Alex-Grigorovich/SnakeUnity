using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initalSize = 4;
    public int score; 
    [SerializeField] private Text scoreText;
    private bool GameIsPaused;
    public GameObject pauseMenuUI;

    
    
    private void Start()
    {
        
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _direction = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S))
            _direction = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A))
            _direction = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D))
            _direction = Vector2.right;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }
    
    
    public void IncreaseScore()
    {
        score = score + 100;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0 ;
        scoreText.text = "Score: " + score.ToString();
    }
    
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
        
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
            
        }
        
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initalSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Food")
        {
            Grow();
            IncreaseScore();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
            ResetScore();
        }
    }
    
}
