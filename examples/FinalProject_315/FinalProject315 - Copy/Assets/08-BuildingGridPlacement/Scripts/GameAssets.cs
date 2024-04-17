using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("salam");
                _instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _instance;
        }
    }

    // Add your game assets here
    public Sprite Chair;
    public Sprite Table;
    public Sprite Bed;
}