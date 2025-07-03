using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Knight_PortalController : MonoBehaviour
{
    public enum SceneType {Town , Adventure}
    public SceneType scene;
    public Cat_UIFade fade;
    public GameObject portalEffect;
    public GameObject loadingImage;
    public Image progressBar;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());

        }
    }

    IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade_Image(3f, Color.white, true));
        
        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade_Image(3f, Color.white, false));

        while (progressBar.fillAmount <1f)
        {
            var ranValue = Random.Range(0.0001f, 0.001f);
            progressBar.fillAmount += ranValue;
            yield return null;
        }

        if (scene == SceneType.Town)
        {
            SceneManager.LoadScene(0);
        }
        else if (scene == SceneType.Adventure)
        {
            SceneManager.LoadScene(1);
        }
    }
}
