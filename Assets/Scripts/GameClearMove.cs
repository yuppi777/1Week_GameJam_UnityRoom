using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearMove : MonoBehaviour
{
    [SerializeField]
    [Header("シーン内にあるTextAnimationManager")]
    private DOTextAnimation textAnimation;

    [SerializeField]
    private Text ClearText;

    [SerializeField]
    private float fadespeed;

    [SerializeField]
    [Header("タイトルボタンのイメージ")]
    private Image TitolButton;
    private void Awake()
    {
        textAnimation.DOFadeTextInitialize(ClearText);
        //textAnimation.DOFadeImageInitialize(TitolButton);
    }
    void Start()
    {
        textAnimation.DOFadeInText(ClearText, fadespeed);
        textAnimation.DOFadeLoop(TitolButton, fadespeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
