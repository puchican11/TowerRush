using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Tech")]
    public Platform[] _platforms;
    public Transform spawnPoint;
    public Transform _parent;
    [Range(1, 10)]
    public int _numberOfPlatformToSpawn;
    int number = 0;
    float maxHeight;
    Transform player;

    [Header("UI")]
    public TextMeshProUGUI _height_Text;
    public TextMeshProUGUI _height_Text_Final;
    public GameObject _gameOver;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        _gameOver.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        float height = Mathf.RoundToInt(player.position.y - 1);
        if (height > maxHeight) maxHeight = height;
        _height_Text.text = "> " + height.ToString() + "m <";
    }

    private void Initialize()
    {
        for (int i = 0; i < _numberOfPlatformToSpawn; i++)
        {
            NewPlatform();
        }
    }

    Platform GetRandomPlatform()
    {
        if (_platforms.Length == 0) return null; // Sécurité si aucune plateforme n’est définie

        float totalProbability = 0f;
        foreach (var platform in _platforms)
        {
            totalProbability += platform.weight; // Somme des probabilités
        }

        float randomValue = Random.Range(0f, totalProbability); // Nombre entre 0 et la somme totale

        float cumulative = 0f;
        foreach (var platform in _platforms)
        {
            cumulative += platform.weight;
            if (randomValue <= cumulative)
            {
                return platform; // Retourne la plateforme sélectionnée
            }
        }

        return null;
    }

    public void NewPlatform()
    {
        SpawnPlatform(GetRandomPlatform());
    }

    void SpawnPlatform(Platform _p)
    {
        Vector3 pos = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        GameObject p = Instantiate(_p._prefab, pos, Quaternion.identity);
        p.transform.SetParent(_parent);
        p.transform.name = new string("Platform_" + number);
        spawnPoint.position = p.GetComponent<Platform_Script>().nextSpawnPoint.position;

        number++;
    }

    public static void KillPlayer()
    {
        PlayerController.isDead = true;
    }

    public void FinishGame()
    {
        _gameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        _height_Text_Final.text = "Max Height : " + maxHeight + "m";
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
