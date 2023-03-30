using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerVelocity, boundary;
    private Vector3 playerPosition;
    private int playerLives;
    private int playerPoints;
    public AudioClip pointSound;
    public AudioClip lifeSound;

    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        // get the initial position of the game object
        playerPosition = gameObject.transform.position;
        audioSource = GetComponent<AudioSource>();

        playerLives = 3;
        playerPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal movement
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        // leave the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // update the game object transform
        transform.position = playerPosition;

        // boundaries
        if (playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }
        WinLose();
    }

    void addPoint(int points)
    {
        playerPoints += points;
        audioSource.PlayOneShot(pointSound);
    }
    void TakeLife(){
        playerLives--;
        audioSource.PlayOneShot(lifeSound);
    }
    void WinLose(){
        // перезапускаем уровень
        if (playerLives == 0) {
            Application.LoadLevel("Level1");
        }

        // все блоки уничтожены
        if ((GameObject.FindGameObjectsWithTag ("Block")).Length == 0) {
            // проверяем текущий уровень
            if (Application.loadedLevelName == "Level1") {
                Application.LoadLevel("Level2");
            } else {
                Application.Quit();
            }
        }
    }
    
}