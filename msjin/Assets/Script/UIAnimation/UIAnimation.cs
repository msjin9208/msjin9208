using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UIAnimation : MonoBehaviour
{
    public static UIAnimation Instance;
    public GameObject _fadePanel;

    [SerializeField] GameObject _failUI;
    [SerializeField] GameObject _yesOrNoPopUp;

    private bool _fading = false;
    private bool _failAnimation = false;
    private bool _yesOrNoPOPUPOn = false;

    public bool YESORNOPOPUP
    {
        get { return _yesOrNoPOPUPOn; }
    }

    public bool FAILANIMAITION
    {
        get { return _failAnimation; }
    }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("UI 애니메이션 인스턴스 생성 완료!");
        }

        //메세지 등록
        Messenger.AddListener(Definition.FadeIn, FadeIn);
        Messenger.AddListener(Definition.FadeOut, FadeOut);
        Messenger.AddListener<string, InventorySlot>(Definition.YesOrNoPOPUP, YesOrNoPopUp);

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
            if (colorAlpha.a >= 1)
            {
                _fading = false;
                Debug.Log("페이드 아웃 완료!");

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

                Debug.Log("페이드 인 완료!");
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

            if (alphaColor <= 1 && fade == false)
                alphaColor += Time.deltaTime;
            else if (alphaColor >= 0)
            {
                if (fade == false)
                    yield return new WaitForSeconds(0.5f);

                fade = true;
                alphaColor -= Time.deltaTime;
                if (alphaColor <= 0)
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

    private void YesOrNoPopUp(string text,InventorySlot slot)
    {
        _yesOrNoPOPUPOn = true;

        _yesOrNoPopUp.SetActive(true);

        var _text = _yesOrNoPopUp.GetComponentInChildren<Text>();
        var _buttons = _yesOrNoPopUp.GetComponentsInChildren<Button>();

        for(int i = 0; i < _buttons.Length; i++)
            _buttons[i].onClick.RemoveAllListeners();

        _text.text = text;
        _buttons[0].onClick.AddListener(() =>
        {
            slot.RemoveItem();
            _yesOrNoPOPUPOn = false;

            GameManager.Instance.PLAYERBASE.PlayerInfo._info._playerGold += slot.ITEMINFO.GETITEMPRICE;
            _yesOrNoPopUp.SetActive(false);
        });
        _buttons[1].onClick.AddListener(() => 
        {
            _yesOrNoPOPUPOn = false;
            _yesOrNoPopUp.SetActive(false);
         });
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.FadeIn, FadeIn);
        Messenger.RemoveListener(Definition.FadeOut, FadeOut);
        Messenger.RemoveListener<string, InventorySlot>(Definition.YesOrNoPOPUP, YesOrNoPopUp);
    }
}
