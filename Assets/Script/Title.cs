using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private string sceneName = "InGame";

    private void Start()
    {
      /*  //�O��̃X�R�A���c��Ȃ��悤�ɂ���
        PlayerPrefs.DeleteKey("Money");
        PlayerPrefs.DeleteKey("ItemCount");
      */

    }
    public void ChangeScene(string targetScene)

    {
        SceneManager.LoadScene(sceneName);
    }

  /*  private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName);
        }

    }
  */
}
