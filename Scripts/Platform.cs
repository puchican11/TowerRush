using UnityEngine;

[CreateAssetMenu(fileName = "Platform", menuName = "GamePlay/ NewPlatform")]
public class Platform : ScriptableObject
{
    public GameObject _prefab;
    public string _name;

    public Difficulty _difficulty;
    public float weight;
}

[System.Serializable]
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Extreme,
    YoureDead
}
