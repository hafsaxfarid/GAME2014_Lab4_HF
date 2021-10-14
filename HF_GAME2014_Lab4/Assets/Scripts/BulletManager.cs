using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;

    private BulletFactory factory;
    void Start()
    {
        bulletPool = new Queue<GameObject>(); // creates empty queue
        factory = GetComponent<BulletFactory>();
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet()
    {
        var tempBullet = factory.enemyBullet;
        bulletPool.Enqueue(tempBullet);
    }

    public GameObject GetBullet(Vector2 spawn_position)
    {
        if(bulletPool.Count < 1)
        {
            AddBullet();
            bulletNumber++;
        }

        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = spawn_position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject returned_bullet)
    {
        returned_bullet.SetActive(false);
        bulletPool.Enqueue(returned_bullet);
    }
}
