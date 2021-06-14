using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField PlayerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        PlayerNameInput.text = SaveDataManager.Instance.CurrentScore.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (PlayerNameInput.text.Length > 0)
        {
            SaveDataManager.Instance.CurrentScore.PlayerName = PlayerNameInput.text;
            SaveDataManager.Instance.Save();
        }
        SceneManager.LoadScene(1);
    }
}
