using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Singleton Structure
    #region Singleton
    public static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                if (GameObject.Find("AudioManager"))
                {
                    GameObject g = GameObject.Find("AudioManager");
                    if (g.GetComponent<AudioManager>())
                    {
                        _instance = g.GetComponent<AudioManager>();
                    }
                    else
                    {
                        _instance = g.AddComponent<AudioManager>();
                    }
                }
                else
                {
                    GameObject g = new GameObject { name = "AudioManager" };
                    _instance = g.AddComponent<AudioManager>();
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

    // Variables declarations
    private AudioSource _source;

    // Use this for initialization
    private void Start()
    {
        // The source for the BGM should be on the GameManager object.
        // Use the start method to find the source and map it to the _source variable
    }

    /// <summary>
    /// Method to have the background music playing
    /// </summary>
    /// <param name="_clip">The asset you want to play as the background music</param>
    /// <param name="_volume">The volume must be between 0 and 1</param>
    /// <param name="_delay">Amount of time before the clip starts playing (in seconds)</param>
    public void PlayBGM(AudioClip _clip, float _volume = 1, ulong _delay = 0)
    {
        this._source.clip = _clip;
        this._source.loop = true;
        this._source.volume = _volume;
        this._source.PlayDelayed(_delay);
    }

    /// <summary>
    /// Coroutine to have a sound effect play during the game
    /// </summary>
    /// <param name="_clip">The asset you want to play as sound effect</param>
    /// <param name="_volume">The volume must be between 0 and 1</param>
    /// <param name="_delay">Amount of time before the clip starts playing (in seconds)</param>
    /// <param name="_source">Provide a source to have the sound play at a specific point in the world (3D audio)</param>
    public IEnumerator PlaySound(AudioClip _clip, AudioSource _source = null, float _volume = 1, ulong _delay = 0)
    {
        bool flag = false;
        if (_source == null)
        {
            _source = AudioManager.Instance.gameObject.AddComponent<AudioSource>();
            flag = true;
        }

        _source.clip = _clip;
        _source.loop = false;
        _source.volume = _volume;
        this._source.PlayDelayed(_delay);

        yield return new WaitForSeconds(_clip.length + _delay);

        if(flag) Destroy(_source);
    }
}
