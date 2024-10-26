using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private const float Cooldown = 3.0f;
    private const float RangeChecker = 15.0f;
    public GameObject bulletPrefab;
    public GameObject spawner;
    private Stack<GameObject> stack;
    [SerializeField] private bool isPlayerNearby;
    public GameObject spawnpoint;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        stack = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,spawnpoint.transform.position, Quaternion.identity);
            bullet.GetComponent<BulletBehavior>().cannon = this;
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
        if (isPlayerNearby && stack.Count > 0)
        {
            GameObject bullet = Pop();
            audioManager.PlaySFX(audioManager.cannonShot);
            bullet.transform.position = spawner.transform.position;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(Cooldown);
        yield return Shoot();
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
