using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereClicker : MonoBehaviour
{
    [SerializeField]
    Animator cubeAnimeCon;
    Renderer sphereRend;
    [SerializeField]
    Material[] matLists;
    // red BE3030
    // green 55E561
    // blue 30C6F8
    // violet 8D40FF

    Ray _ray;
    RaycastHit _hit;

    int colorVal = 0, animVal = 0;

    void Start()
    {
        sphereRend = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                if (_hit.transform == this.transform)
                {
                    colorVal = RandRangeExcl(0, 4, colorVal);
                    sphereRend.material = matLists[colorVal];

                    animVal = RandRangeExcl(1, 5, animVal);
                    cubeAnimeCon.SetTrigger("anim" + animVal.ToString());

                }
            }
        }
    }

    int RandRangeExcl(int x, int y, int z)
    {
        int k = Random.Range(x, y);
        while(k == z)
        {
            k = Random.Range(x, y);
        }
        return k;
    }

    public void BackButt()
    {
        SceneManager.LoadScene("Tasks");
    }
}
