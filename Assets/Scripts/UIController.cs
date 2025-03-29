using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image Sky;
    [SerializeField] private Image Sky2;
    [SerializeField] private Image Sky3;
    [SerializeField] private Image Mountains;
    [SerializeField] private Image Mountains2;
    [SerializeField] private Image Road;
    [SerializeField] private Image Road2;
    [SerializeField] private Image StartWord;
    [SerializeField] private Image StartShadow;
    [SerializeField] private Image QuitWord;
    [SerializeField] private Image QuitShadow;
    [SerializeField] private string Level1 = "Level1";

    public float SkySpeed = 0.1f;
    public float MountainSpeed = 0.2f;
    public float RoadSpeed = 0.3f;
    private float MountainWidth = 957;
    private float RoadWidth = 684;
    private float SkyWidth = 490;

    private void Start()
    {
        //Start the background images at the correct position
        Sky2.rectTransform.position = new Vector3((SkyWidth * 1.825f), Sky2.rectTransform.position.y, Sky2.rectTransform.position.z);
        Sky3.rectTransform.position = new Vector3((2 * SkyWidth * 2.3175f), Sky3.rectTransform.position.y, Sky3.rectTransform.position.z);
        Mountains2.rectTransform.position = new Vector3((2.8f * MountainWidth) + Mountains.rectTransform.position.x, Mountains2.rectTransform.position.y, Mountains2.rectTransform.position.z);
        Road2.rectTransform.position = new Vector3((2.8f * RoadWidth) + Road.rectTransform.position.x, Road2.rectTransform.position.y, Road2.rectTransform.position.z);

        //Deactivate the Start Shadow
        StartShadow.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //Sky Movement
        //Reset the Cloud's Position When at the End of the Screen
        if(Sky.rectTransform.position.x <= -686*2)
        {
            Sky.rectTransform.position = new Vector3(Sky3.rectTransform.position.x + (2 * 686), Sky.rectTransform.position.y, Sky.rectTransform.position.z);
        }
        if(Sky2.rectTransform.position.x <= -686*2)
        {
            Sky2.rectTransform.position = new Vector3(Sky.rectTransform.position.x + (2 * 686), Sky2.rectTransform.position.y, Sky2.rectTransform.position.z);
        }
        if (Sky3.rectTransform.position.x <= -686*2)
        {
            Sky3.rectTransform.position = new Vector3(Sky2.rectTransform.position.x + (2 * 686), Sky3.rectTransform.position.y, Sky3.rectTransform.position.z);
        }
        //Linearly Interpolate the Cloud BG Layer
        Sky.rectTransform.position = new Vector3(Mathf.Lerp(Sky.rectTransform.position.x, Sky.rectTransform.position.x - 492, SkySpeed * Time.deltaTime), Sky.rectTransform.position.y, Sky.rectTransform.position.z);
        Sky2.rectTransform.position = new Vector3(Mathf.Lerp(Sky2.rectTransform.position.x, Sky2.rectTransform.position.x - 492, SkySpeed * Time.deltaTime), Sky2.rectTransform.position.y, Sky2.rectTransform.position.z);
        Sky3.rectTransform.position = new Vector3(Mathf.Lerp(Sky3.rectTransform.position.x, Sky3.rectTransform.position.x - 492, SkySpeed * Time.deltaTime), Sky3.rectTransform.position.y, Sky3.rectTransform.position.z);

        //Mountain Movement
        //Reset the Mountains' Position When at the End of the Screen
        if (Mountains.rectTransform.position.x <= -(2.8f * MountainWidth))
        {
            Mountains.rectTransform.position = new Vector3(Mountains2.rectTransform.position.x + (2.8f * MountainWidth), Mountains.rectTransform.position.y, Mountains.rectTransform.position.z);
        }
        if (Mountains2.rectTransform.position.x <= -(2.8f * MountainWidth))
        {
            Mountains2.rectTransform.position = new Vector3(Mountains.rectTransform.position.x + (2.8f * MountainWidth), Mountains2.rectTransform.position.y, Mountains2.rectTransform.position.z);
        }
        //Linearly Interpolate The Mountains
        Mountains.rectTransform.position = new Vector3(Mathf.Lerp(Mountains.rectTransform.position.x, Mountains.rectTransform.position.x - (MountainWidth * 2), MountainSpeed * Time.deltaTime), Mountains.rectTransform.position.y, Mountains.rectTransform.position.z);
        Mountains2.rectTransform.position = new Vector3(Mathf.Lerp(Mountains2.rectTransform.position.x, Mountains2.rectTransform.position.x - (MountainWidth * 2), MountainSpeed * Time.deltaTime), Mountains2.rectTransform.position.y, Mountains2.rectTransform.position.z);

        //Road Movement
        //Reset the Road's Position When at the End of the Screen
        if (Road.rectTransform.position.x <= -RoadWidth * 2.8f)
        {
            Road.rectTransform.position = new Vector3(Road.rectTransform.position.x + (2* 2.8f * RoadWidth), Road.rectTransform.position.y, Road.rectTransform.position.z);
        }
        if (Road2.rectTransform.position.x <= -RoadWidth * 2.8f)
        {
            Road2.rectTransform.position = new Vector3(Road2.rectTransform.position.x + (2* 2.8f * RoadWidth), Road2.rectTransform.position.y, Road2.rectTransform.position.z);
        }
        //Linearly Interpolate the Cloud BG Layer
        Road.rectTransform.position = new Vector3(Mathf.Lerp(Road.rectTransform.position.x, Road.rectTransform.position.x - 492, RoadSpeed * Time.deltaTime), Road.rectTransform.position.y, Road.rectTransform.position.z);
        Road2.rectTransform.position = new Vector3(Mathf.Lerp(Road2.rectTransform.position.x, Road2.rectTransform.position.x - 492, RoadSpeed * Time.deltaTime), Road2.rectTransform.position.y, Road2.rectTransform.position.z);

        //Activate the Start Shadow when the Mouse is in the proper position
        if (StartWord.rectTransform.rect.Contains(StartWord.rectTransform.InverseTransformPoint(Input.mousePosition)))/*Input.mousePosition*/
        {
            StartShadow.enabled = true;
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(Level1);
            }
        }
        else
        {
            StartShadow.enabled = false;
        }

        if (QuitWord.rectTransform.rect.Contains(QuitWord.rectTransform.InverseTransformPoint(Input.mousePosition)))/*Input.mousePosition*/
        {
            QuitShadow.enabled = true;
            if (Input.GetMouseButton(0))
            {
                Application.Quit();
            }
        }
        else
        {
            QuitShadow.enabled = false;
        }


    }

}
