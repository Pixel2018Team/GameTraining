using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Singleton Structure
    #region Singleton
    public static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                if (GameObject.Find("ScoreManager"))
                {
                    GameObject g = GameObject.Find("ScoreManager");
                    if (g.GetComponent<ScoreManager>())
                    {
                        _instance = g.GetComponent<ScoreManager>();
                    }
                    else
                    {
                        _instance = g.AddComponent<ScoreManager>();
                    }
                }
                else
                {
                    GameObject g = new GameObject { name = "ScoreManager" };
                    _instance = g.AddComponent<ScoreManager>();
                }
            }

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    #endregion Singleton

    private int _score;

    [SerializeField]
    private Text _scoreText;

    // Use this for initialization
    private void Start()
    {
        // TODO: Score should be initialized with a value significant to the number of NPCs in the game
        _score = 10;

        UpdateUI();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    /// <summary>
    /// This method will update the score text shown in the game's UI
    /// </summary>
    private void UpdateUI()
    {
        _scoreText.text = _score.ToString();
    }

    /// <summary>
    /// Method used to increment the human players' score
    /// </summary>
    /// <param name="amount">The amount by which to increment the score</param>
    public void Increment(int amount)
    {
        _score += amount;

        UpdateUI();
    }

    /// <summary>
    /// Method used to decrement the human players' score
    /// </summary>
    /// <param name="amount">The amount by which to decrement the score</param>
    public void Decrement(int amount)
    {
        _score -= amount;

        UpdateUI();

        if (_score <= 0) return; // TODO: Trigger the GameManager's gameover state
    }
}
