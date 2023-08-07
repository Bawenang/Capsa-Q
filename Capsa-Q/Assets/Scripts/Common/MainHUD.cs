using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHUD : MonoBehaviour
{
    [SerializeField] private Image fadingImage;
    [SerializeField] private Animator fadingImageAnimator;

    public delegate void OnFinishFadingIntoScene();
    public delegate void OnFinishFadingOutOfScene();

    private event OnFinishFadingIntoScene onFinishFadingIntoScene;
    private event OnFinishFadingOutOfScene onFinishFadingOutOfScene;

    public void FadeIntoScene(OnFinishFadingIntoScene completion = null) {
        onFinishFadingIntoScene = completion;
        fadingImage.color = Color.black;
        fadingImage.gameObject.SetActive(true);
        fadingImageAnimator.Play("FadingIntoScene");
        StartCoroutine(FadeIntoSceneFinished());
    }

    public void FadeOutOfScene(OnFinishFadingOutOfScene completion = null) {
        onFinishFadingOutOfScene = completion;
        fadingImage.color = Color.clear;
        fadingImage.gameObject.SetActive(true);
        fadingImageAnimator.Play("FadingOutOfScene");
        StartCoroutine(FadeOutOfSceneFinished());
    }

    private IEnumerator FadeIntoSceneFinished() {
        yield return new WaitForSeconds(1.2f);
        fadingImageAnimator.gameObject.SetActive(false);
        if (onFinishFadingIntoScene != null) {
            onFinishFadingIntoScene();
            onFinishFadingIntoScene = null;
        }
    }

    private IEnumerator FadeOutOfSceneFinished() {
        yield return new WaitForSeconds(1.2f);
        if (onFinishFadingOutOfScene != null) {
            onFinishFadingOutOfScene();
            onFinishFadingOutOfScene = null;
        }
    }
}
