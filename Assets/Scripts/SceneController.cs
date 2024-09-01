using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGameLevelScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL);
    }
    
    public void LoadLobbyScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.LOBBY);
    }
}
