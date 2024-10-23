using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private const float Cooldown = 3.0f;
    private const float RangeChecker = 17.0f;
    public GameObject bulletPrefab;
    public GameObject spawner;
    private Stack<GameObject> stack;
    [SerializeField] private bool isPlayerNearby;

    void Start()
    {
        stack = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            stack.Push(bullet); 
        }
        StartCoroutine(Shoot());
    }

    void Update()
    {
        CheckPlayerProximity();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (isPlayerNearby && stack.Count > 0)
            {
                GameObject bullet = Pop();
                bullet.transform.position = spawner.transform.position;
                bullet.SetActive(true);
            }
            yield return new WaitForSeconds(Cooldown);
        }
    }

    public void Push(GameObject bullet)
    {
        bullet.SetActive(false);
        stack.Push(bullet);
    }

    public GameObject Pop()
    {
        return stack.Pop();
    }

    public void CheckPlayerProximity()
    {
        float distance = Vector2.Distance(transform.position, GameObject.Find("Player").transform.position);
        isPlayerNearby = distance < RangeChecker;
    }
}
