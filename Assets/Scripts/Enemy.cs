using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    public float starthealth = 50;
    public float health;
    public int value = 50;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthbar;

    public bool die = false;

    // Start is called before the first frame update
    private void Start()
    {
        target = WayPoints.points[0];

        health = starthealth;
    }

    public void TakeDamage(int amount)
    {
        //Debug.Log("DAmage  data enter update  ............................!");
        health -= amount;

        healthbar.fillAmount = health / starthealth;

        Debug.Log(" Health.........................===" + health + "................................................." + healthbar.fillAmount);
        if (health <= 0 && die == false)
        {
            die = true;
            Die();
        }
    }

    private void Die()
    {
        if (die)
        {
            PlayerStats.Money += value;
        }
        // Debug.Log("Calling Destory Enemy.............");

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnenyAlive--;

        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length)
        {
            EndPath();

            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex - 1];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;

        WaveSpawner.EnenyAlive--;
        Destroy(gameObject);
    }
}
