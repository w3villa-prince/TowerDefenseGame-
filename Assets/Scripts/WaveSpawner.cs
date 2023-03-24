using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefabs;

    public Transform spawnWavePsition;
    public float timeBetweeenWaves = 5f;
    private float countdown = 5f;
    private int waveIndex = 0;

    public TextMeshProUGUI timer;

    public Wave[] waves;

    public GameManager gameManager;

    public static int EnenyAlive = 0;

    // Start is called before the first frame update
    private void Start()
    {
        countdown = timeBetweeenWaves;
    }

    // Update is called once per frame
    private void Update()
    {
        if (EnenyAlive > 0)
        {
            // Debug.Log("Enemy Alive here not wave Spawner ........................................................... " + EnenyAlive);
            return;
        }

        if (waveIndex == waves.Length)
        {
            // EnenyAlive--;
            // Debug.Log("Win The game -----------------------------------------------" + EnenyAlive + "_________________________" + waveIndex);
            gameManager.WinLevel();
            //Debug.Log("Level Up ");
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            // Debug.Log(" CounttDown  zero so  here  wave Spawner ...........................................................");
            StartCoroutine(SpawnWave());
            countdown = timeBetweeenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        timer.text = string.Format("{0:00.00}", countdown);//  Mathf.Floor(countdown).ToString();
    }

    private IEnumerator SpawnWave()
    {
        // Debug.Log("Wave Come-------------");

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnenyAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        //Debug.Log("Index Nuber ------------------" + waveIndex);
        waveIndex++;
        // Debug.Log("Index Nuber ------------------" + waveIndex);

        /*if (waveIndex == waves.Length)
        {
            // EnenyAlive--;
            // Debug.Log("Win The game -----------------------------------------------" + EnenyAlive + "_________________________" + waveIndex);
            gameManager.WinLevel();
            //Debug.Log("Level Up ");
            this.enabled = false;
        }*/
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnWavePsition.position, spawnWavePsition.rotation);

        // EnenyAlive++;
    }
}
