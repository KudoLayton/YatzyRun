using UnityEngine;
using UnityEngine.UI;

public class TestScoreBoard : MonoBehaviour
{
    [SerializeField]
    private string prefix = "";
    private Button button;
    private Text text;
    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    public void updateScore(int score, bool enable)
    {
        text.text = $"{prefix}: {score}";
        button.interactable = enable;
    }
}
