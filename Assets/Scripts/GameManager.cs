using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    #region Unity_functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions
    public void BookShelf()
    {
        SceneManager.LoadScene("Bookshelf");
    }

    public void MainRoom()
    {
        SceneManager.LoadScene("Main Room");
    }

    public void BookShelfDown(GameObject[] bookShelfItems)
    {
        foreach (GameObject items in bookShelfItems)
        {
            Vector3 newPos = new Vector3(items.GetComponent<Transform>().position.x, items.GetComponent<Transform>().position.y + 10, 0);
            items.GetComponent<Transform>().position = newPos;
        }
    }

    #endregion
}
