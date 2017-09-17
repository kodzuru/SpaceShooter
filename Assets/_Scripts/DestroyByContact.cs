using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        //вызов объектов из другого скрипта
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    void OnTriggerEnter(Collider other)
    {
        //если касается с внешним кубом
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        //если не с кубом то взрыв астеройда путём замены на взрыв 
        //если в инспекторе не добавлен взрыв
        if(explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        //если касается игрока то взрыв игрока
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //вызов функции класса гейм контроллер
        gameController.AddScore(scoreValue);

        //удаление выстрела и объекта
        Destroy(other.gameObject);
        Destroy(gameObject);


    }
}
