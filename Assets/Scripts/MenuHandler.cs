using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        DataPersistManager.Instance.LoadBestScore();
        bestScoreText.text = "Best Score : " + DataPersistManager.Instance.GetBestScoreText();

    }

    public void StartGame()
    {
        DataPersistManager.Instance.SaveName(nameInput.text);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    

}
