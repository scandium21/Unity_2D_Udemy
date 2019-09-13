using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] CoinPickup[] coinsNotCollected;
    [SerializeField] Scene dontDestroyOnLoad;
    int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene!=2) { return; }
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            Object.DontDestroyOnLoad(temp);
            dontDestroyOnLoad = temp.scene;
            Object.DestroyImmediate(temp);
            temp = null;

            GameObject[] items = dontDestroyOnLoad.GetRootGameObjects();

            bool deleted = false;
            for (int i = 0; i<items.Length; i++)
            {
                if (items[i].transform.name == "ScenePersist" && !deleted && items.Length > 2)
                {
                    Destroy(items[i]);
                    deleted = !deleted;
                }
                else if (items[i].transform.name == "ScenePersist")
                {
                    coinsNotCollected = items[i].GetComponentsInChildren<CoinPickup>();
                }
            }
        }
        finally
        {
            if (temp != null)
                Object.DestroyImmediate(temp);
        }

        coins = coinsNotCollected.Length;
    }

    private void Update()
    {
        if (currentScene != 2) { return; }
        if (dontDestroyOnLoad.GetRootGameObjects()[0].name == "ScenePersist")
            coinsNotCollected = dontDestroyOnLoad.GetRootGameObjects()[0].GetComponentsInChildren<CoinPickup>();
        else
            coinsNotCollected = dontDestroyOnLoad.GetRootGameObjects()[1].GetComponentsInChildren<CoinPickup>();

        coins = coinsNotCollected.Length;
        /*if (coins <= 0 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } */
    }

    public void CountCoins()
    {
        coins += 1;
    }

    public void CoinCollected()
    {
        //GameObject temp = null;
        //try
        //{
        //    temp = new GameObject();
        //    Object.DontDestroyOnLoad(temp);
        //    Scene dontDestroyOnLoad = temp.scene;
        //    Object.DestroyImmediate(temp);
        //    temp = null;

        //    coinsNotCollected = dontDestroyOnLoad.GetRootGameObjects()[0].GetComponentsInChildren<CoinPickup>();
        //}
        //finally
        //{
        //    if (temp != null)
        //        Object.DestroyImmediate(temp);
        //}

        
        coins -= 1;
        Debug.Log("Coins value: " + coins);
        Debug.Log("coinsNotCollected.Length: " + coinsNotCollected.Length);
        if ((coins <= 0 || coinsNotCollected.Length <=0 ) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(FindObjectOfType<ScenePersist>());
            //Destroy(FindObjectOfType<GameSession>());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
