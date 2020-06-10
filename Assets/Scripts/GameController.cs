using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameController : MonoBehaviour
{

    [SerializeField] PlayerController player;
    [SerializeField] CarController car;
    [SerializeField] Text keyText;
    [SerializeField] CinemachineClearShot cinemachineClearShot;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = player.keys.ToString();
    }

    public void UseCar()
    {
        player.controlPlayer = false;
        car.controlCar = true;

        cinemachineClearShot.LookAt = car.transform;
        player.gameObject.SetActive(false);
        car.playerSkin.SetActive(true);
    }
}
