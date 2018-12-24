using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {


    

    public void Shield()
    {
        GameObject shield = transform.GetChild(1).gameObject;
        if (shield.activeSelf)
            shield.SetActive(false);
        else
            shield.SetActive(true);
    }

    public void Invisible()
    {
        //change mesh
        //stop navmesh of enemy ships
    }

    
}
