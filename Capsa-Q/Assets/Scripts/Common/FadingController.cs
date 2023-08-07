using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingController : MonoBehaviour
{
    [SerializeField] private Image fadingImage;
    [SerializeField] private Animator fadingImageAnimator;

    public delegate void OnFinishFadingIntoScene();
    public event OnFinishFadingIntoScene onFinishFadingIntoScene;

    public delegate void OnFinishFadingOutOfScene();
    public event OnFinishFadingOutOfScene onFinishFadingOutOfScene;

    public void FadeIntoScene() {
        fadingImage.color = Color.black;
        fadingImage.gameObject.SetActive(true);
        fadingImageAnimator.Play("FadingIntoScene");
        StartCoroutine(FadeIntoSceneFinished());
    }

    public void FadeOutOfScene() {
        fadingImage.color = Color.clear;
        fadingImage.gameObject.SetActive(true);
        fadingImageAnimator.Play("FadingOutOfScene");
        StartCoroutine(FadeOutOfSceneFinished());
    }

    private IEnumerator FadeIntoSceneFinished() {
        yield return new WaitForSeconds(1.2f);
        fadingImageAnimator.gameObject.SetActive(false);
        if (onFinishFadingIntoScene != null) onFinishFadingIntoScene();
    }

    private IEnumerator FadeOutOfSceneFinished() {
        yield return new WaitForSeconds(1.2f);
        if (onFinishFadingOutOfScene != null) onFinishFadingOutOfScene();
    }
}
