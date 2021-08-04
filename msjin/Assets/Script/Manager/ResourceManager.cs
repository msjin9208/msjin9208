using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    static public ResourceManager Instance;


    [SerializeField] public GameObject Player;
    [SerializeField] GameObject Monster;
    [SerializeField] GameObject MonsterPosition;
    [SerializeField] public Button ItemBase;

    [SerializeField] public Sprite weaponSprite;
    [SerializeField] public Sprite armorSprite;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
