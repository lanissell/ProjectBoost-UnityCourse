using System;
using Rocket;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   private int _sceneCount;

   private void Awake()
   {
      _sceneCount = SceneManager.sceneCountInBuildSettings;
   }

   private void LoadNextLvl()
   {
      int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
      if (nextSceneIndex >= _sceneCount) nextSceneIndex = 0;
      SceneManager.LoadScene(nextSceneIndex);
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.TryGetComponent(out RocketMovement _))
         LoadNextLvl();
   }
}
