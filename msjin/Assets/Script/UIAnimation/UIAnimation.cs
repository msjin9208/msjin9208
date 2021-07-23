using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation Instance;
    public GameObject _fadePanel;

    private bool _fading = false;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("UI 애니메이션 인스턴스 생성 완료!");
        }

        FadeSetting();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FadeIn", 1f);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }


    private void FadeSetting()
    {
        var image = _fadePanel.GetComponent<Image>().color;
        image = Color.black;
        image.a = 1f;
        _fadePanel.GetComponent<Image>().color = image;
    }
    
    private IEnumerator FadeOutCoroutine()
    {
        _fading = true;
        
        _fadePanel.SetActive(true);
        _fadePanel.layer = 1;
        while (_fading)
        {
            var colorAlpha = _fadePanel.GetComponent<Image>().color;
            if(colorAlpha.a >= 1)
            {
                _fading = false;
                Debug.Log("페이드 아웃 완료!");

                SceneMgr.Instance._readyToLoad = true;
                yield break;
            }

            colorAlpha.a += Time.deltaTime;
            _fadePanel.GetComponent<Image>().color = colorAlpha;
            yield return null;
        }
    }

    public IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(1f);

        _fading = true;
        _fadePanel.layer = 1;
        while (_fading)
        {
            var colorAlpha = _fadePanel.GetComponent<Image>().color;
            if (colorAlpha.a <= 0)
            {
                _fading = false;
                _fadePanel.SetActive(false);

                Debug.Log("페이드 인 완료!");
                yield break;
            }

            colorAlpha.a -= Time.deltaTime;
            _fadePanel.GetComponent<Image>().color = colorAlpha;
            yield return null;
        }
    }

}
