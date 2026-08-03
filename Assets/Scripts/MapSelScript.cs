using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public void LoadMap1()
    {
        SceneManager.LoadScene("map1");
    }

    public void LoadMap2()
    {
        SceneManager.LoadScene("map2");
    }

    public void LoadMap3()
    {
        SceneManager.LoadScene("map3");
    }
}