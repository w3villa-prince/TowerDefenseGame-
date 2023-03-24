using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve animationCurve;

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    private IEnumerator FadeIN()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;

            float a = animationCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;

            float a = animationCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
            SceneManager.LoadScene(scene);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(FadeIN());
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
