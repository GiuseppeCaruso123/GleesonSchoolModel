using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeThings : MonoBehaviour
{
    public GameObject Player;
    public GameObject Drone;

    void Start()
    {
        Player.SetActive(enabled);
        ChangeToDrone();
    }
    void ChangeToDrone()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Player.SetActive(!Player.activeInHierarchy);
            Drone.SetActive(Drone.activeInHierarchy);
        }
    }

}
