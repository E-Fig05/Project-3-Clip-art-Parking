using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject YouCrashed;
    [SerializeField] private GameObject YouWin;
    [SerializeField] private string NextLevel = "Level 2";


    private void Start()
    {
        YouWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(car.GetComponent<CarController>() != null)
        {
            if (!car.GetComponent<CarController>().alive)
            {
                YouCrashed.SetActive(true);
            }

            if (car.GetComponent<CarController>().LevelWin == true && car.GetComponent<CarController>().alive == true)
            {
                YouWin.SetActive(true);
            }

            if(car.GetComponent<CarController>().LevelWin == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(NextLevel);
                }
            }
        }
    }


}
