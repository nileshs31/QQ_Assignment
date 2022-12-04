using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SortMan : MonoBehaviour
{
    [SerializeField]
    GameObject[] cubesGo;
    [SerializeField]
    Rigidbody[] cubes;
    [SerializeField]
    Vector3[] positions;
    [SerializeField]
    TextMeshProUGUI text;
    public float moveSpeed;
    void Start()
    {
        positions = new Vector3[cubesGo.Length];
        cubes = new Rigidbody[cubesGo.Length];
        
        for (int i = 0; i < cubesGo.Length; i++)
        {
            cubes[i] = cubesGo[i].GetComponent<Rigidbody>();
        }

        for (int i = 0; i< cubesGo.Length; i++)
        {
            positions[i] = cubesGo[i].transform.position;
        }
        ResetScene();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < cubesGo.Length; i++)
        {
            cubes[i].transform.position = Vector3.Lerp(cubes[i].transform.position, positions[i], Time.deltaTime * moveSpeed);
        }
    }

    public void Sort()
    {
        for (int i = 0; i < cubes.Length - 1; i++)
            for(int j = 0 ; j < cubes.Length - i - 1; j++)
            {
                if (cubes[j+1].mass < cubes[j].mass)
                {
                    var temp = cubesGo[j];
                    cubesGo[j]= cubesGo[j+1];
                    cubesGo[j+1] = temp;

                    var temp2 = cubes[j];
                    cubes[j] = cubes[j + 1];
                    cubes[j + 1] = temp2;
                }
            }
    }

    public void IsSorted()
    {

        text.text = "Is Sorted: "+ IsSortedChecker();

    }

    bool IsSortedChecker()
    {
        for (int i = 1; i < cubes.Length; i++)
        {
            if (cubes[i - 1].mass > cubes[i].mass) {
                Debug.Log("Sorted: False");
                return false;
            }
                
        }
        Debug.Log("Sorted: True");
        return true;
    }

    public void ResetScene()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].mass = Random.Range(0f, 12f);
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackButt()
    {
        SceneManager.LoadScene("Tasks");
    }
}
