using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    [SerializeField] private Text textCoin;
    [SerializeField] private GameObject menuFinish;
    [SerializeField] private AudioClip clipCoin;
    [SerializeField] private AudioClip clipFinish;
    public UnityAction OnCoinCollect;
    public UnityAction OnFinishLevel;
    public bool finish = false;
    private int coinValue = 0;
    private int coinNominal = 10;
    private float period = 0.5f;
    private AudioSource audio;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        OnCoinCollect += CoinCollect;
        OnFinishLevel += ActivFinishMenu;
    }

    private void OnDestroy()
    {
        OnCoinCollect -= CoinCollect;
        OnFinishLevel -= ActivFinishMenu;
    }

    private void CoinCollect()
    {
        audio.PlayOneShot(clipCoin);
        coinValue += coinNominal;
        textCoin.text = coinValue.ToString();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    private void ActivFinishMenu()
    {
        audio.PlayOneShot(clipFinish);
        StartCoroutine(AnimFinish());
    }

    IEnumerator AnimFinish()
    {
        yield return new WaitForSeconds(period);

        finish = true;
        menuFinish.SetActive(true);
    }
}
