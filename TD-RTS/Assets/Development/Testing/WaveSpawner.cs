using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour {
    
    public static int enemiesAlive = 0;
    public WaveInfo[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveCountDownText;
    private GameManager gameManager;

    //countdown number will determine time until first wave
    private float countdown = 2.5f;
    private int waveIndex = 0;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    //Resets enemiesAlive to 0 when restarting level
    private void OnEnable()
    {
        enemiesAlive = 0;
    }

    private void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (waveIndex == waves.Length && !GameManager.GameIsOver)
        {
            gameManager.WinLevel();
            enabled = false;
        }

        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{00:00.00}", countdown);

        //Mathf.Floor will keep it from displaying decimals
        //waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Waves++;

        WaveInfo waveInfo = waves[waveIndex];
        enemiesAlive = waveInfo.count;

        for (int i = 0; i < waveInfo.count; i++)
        {
            SpawnEnemy(waveInfo.enemyPrefab);
            yield return new WaitForSeconds(1/waveInfo.rate);
        }

        waveIndex++;
        
    }

    void SpawnEnemy(GameObject _enemyPrefab)
    {
        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
