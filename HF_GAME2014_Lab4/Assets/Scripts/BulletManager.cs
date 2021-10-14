using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;

    private BulletFactory factory;
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>(); // creates empty enemy queue
        playerBulletPool = new Queue<GameObject>(); // creates empty player queue
        factory = GetComponent<BulletFactory>();
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < enemyBulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var tempBullet = factory.CreateBullet(type);

        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(tempBullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(tempBullet);
                playerBulletNumber++;
                break;
        }
    }

    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject tempBullet = null;

        switch (type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)
                {
                    AddBullet(BulletType.ENEMY);
                }

                tempBullet = enemyBulletPool.Dequeue();
                tempBullet.transform.position = spawnPosition;
                tempBullet.SetActive(true);
                break;
            
            case BulletType.PLAYER:
                if (playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                }

                tempBullet = playerBulletPool.Dequeue();
                tempBullet.transform.position = spawnPosition;
                tempBullet.SetActive(true);
                break;
        }
        return tempBullet;
    }

    public void ReturnBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);

        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(returnedBullet);
                break;

            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returnedBullet);
                break;
        }
    }
}
