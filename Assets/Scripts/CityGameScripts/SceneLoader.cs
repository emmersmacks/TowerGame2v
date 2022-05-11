using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerGame.UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] int sceneIndex;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    var p = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(p, Vector2.zero);
                    if (hit.collider.name == GetComponent<BoxCollider2D>().name)
                    {
                        LoadScene();
                    }
                }

            }
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var raycast = Physics2D.Raycast(ray, Vector2.zero);
                if (raycast.collider.name == GetComponent<BoxCollider2D>().name)
                {
                    LoadScene();
                }
            }
        }

        public void LoadScene()
        {
            Debug.Log("1");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

