using System.Collections;
using Rocket;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlReLoader : MonoBehaviour
{
    [SerializeField] private float _reloadDelay;

    private void OnEnable()
    {
        RocketDestroyer.Destroying += StartReloadCoroutine;
    }

    private void StartReloadCoroutine() => StartCoroutine(ReLoadLvlWithDelay());

    private IEnumerator ReLoadLvlWithDelay()
    {
        yield return new WaitForSeconds(_reloadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void OnDisable()
    {
        RocketDestroyer.Destroying -= StartReloadCoroutine;
    }
}
