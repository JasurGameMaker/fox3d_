using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public GameObject Charecter;

    public float speedCam;
    public float speedCamBack;

    [SerializeField]
    private GameObject clicText;

    public Camera cam;

    [SerializeField]
    private float speed, ySpeed;

    Vector3 posEnd, posSmooth, _jump;

    public bool isGo = false;

    void Update()
    {
        //camera kuzatuvi
        posEnd = new Vector3(Charecter.transform.position.x + 5, transform.position.y, transform.position.z);

        posSmooth = Vector3.Lerp(transform.position, posEnd, 0.05f);

        transform.position = posSmooth;

        //


        if (isGo)
        {

            CancelInvoke("forTime"); //<- camerani uzoqlashishini bekor qiluvchi cod

 
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speedCam);
            clicText.SetActive(false);
            isGo = false;
        }
        else
        {
            Invoke("forTime", 0.5f);
        }
    }

    // camerani uzoqlashishi
    void forTime()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speedCamBack);
        clicText.SetActive(true);
    }
    //

    public void Go()
    {
        //charecterni harakatlantiruchi
        Vector3 charecter_vec = new Vector3(Charecter.transform.position.x + speed * Time.deltaTime, Charecter.transform.position.y);
        Charecter.transform.position = charecter_vec;

        isGo = true;
    }

    public void Jump()
    {
        Vector3 charector_vecJump = new Vector3(Charecter.transform.position.x, Charecter.transform.position.y + ySpeed * Time.deltaTime);

        Charecter.transform.position = charector_vecJump;
    }
}
