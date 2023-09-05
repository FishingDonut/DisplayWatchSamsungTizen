using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    public Enemy enemy;
    public Link link;
    public int speed;
    public int totalEnemyMax = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Encontre todos os objetos com a tag especificada
        GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag("enemy");

        // Obtenha o número de objetos com a tag especificada
        int quantidadeDeObjetos = objetosComTag.Length;

        if (totalEnemyMax > quantidadeDeObjetos)
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        System.Random random = new System.Random();
        Vector2 position = new Vector2(random.Next(-11, 12), random.Next(-11, 12));
        Enemy cloneEnemy = Instantiate(enemy, position, transform.rotation);
        cloneEnemy.ConfigEnemy(link, speed);
    }
}
