using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int hitsToKill;
    public int points;
    private int numberOfHits;
    public AudioClip hitSound;
    private AudioSource audioSource;
    // используйте этот метод для инициализации
    void Start () {
        numberOfHits = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update вызывается при отрисовке каждого кадра игры
    void Update () {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.tag == "Ball"){
            
            numberOfHits++;
            //audioSource.PlayOneShot(hitSound);
            if (numberOfHits == hitsToKill){
                // получаем ссылку на платформу
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

                // выполняем метод из другого скрипта
                player.SendMessage("addPoints", points);
                // уничтожаем объект
                Destroy(this.gameObject);
            }
        }
        
    }
    
    
}
