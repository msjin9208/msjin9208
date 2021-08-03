using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation Instance;
    public GameObject _fadePanel;
    [SerializeField] GameObject _failUI;
    

    private bool _fading = false;
    private bool _failAnimation = false;

    public bool FAILANIMAITION
    {
        get { return _failAnimation; }
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("UI �ִϸ��̼� �ν��Ͻ� ���� �Ϸ�!");
        }

        Messenger.AddListener(Definition.FadeIn, FadeIn);
        Messenger.AddListener(Definition.FadeOut, FadeOut);

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
                Debug.Log("���̵� �ƿ� �Ϸ�!");

                Messenger.Broadcast(Definition.LoadScene);
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

                Debug.Log("���̵� �� �Ϸ�!");
                yield break;
            }

            colorAlpha.a -= Time.deltaTime;
            _fadePanel.GetComponent<Image>().color = colorAlpha;
            yield return null;
        }
    }

    public void FailUI(string _string)
    {
        if (_failUI.active == true)
            return;

        _failUI.SetActive(true);
        var uitext = _failUI.GetComponentInChildren<Text>();
        uitext.text = _string;
        var textcolor = uitext.color;
        textcolor.a = 0;
        uitext.color = textcolor;

        var color = _failUI.GetComponent<Image>().color;
        color.a = 0;
        _failUI.GetComponent<Image>().color = color;
        StartCoroutine(FailUIAnimation(_failUI, uitext));
    }

    private IEnumerator FailUIAnimation(GameObject ui, Text text)
    {
        ui.SetActive(true);

        _failAnimation = true;
        bool animation = true;
        bool fade = false;
        float alphaColor = 0;
        while (animation)
        {
            var color = ui.GetComponent<Image>().color;
            var textcolor = text.color;

            if(alphaColor <= 1 && fade == false)
                alphaColor += Time.deltaTime;
            else if(alphaColor >= 0)
            {
                if (fade == false)
                    yield return new WaitForSeconds(0.5f);

                fade = true;
                alphaColor -= Time.deltaTime;
                if(alphaColor <= 0)
                {
                    _failAnimation = false;
                    animation = false;
                    ui.SetActive(false);
                    yield break;
                }
            }

            textcolor.a = alphaColor;
            text.color = textcolor;
            color.a = alphaColor;
            ui.GetComponent<Image>().color = color;
            
            yield return null;
        }
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.FadeIn, FadeIn);
        Messenger.RemoveListener(Definition.FadeOut, FadeOut);
    }
}
