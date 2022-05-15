using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLaunch : MonoBehaviour
{
    public GameObject bomb;
    //Time before the player can fire again
    public float cooldownTime;
    //Time tracked since last firing
    private float trackedTime;
    // Start is called before the first frame update
    void Start()
    {
        trackedTime = cooldownTime;   
    }

    // Update is called once per frame
    void Update()
    {
                 if (Input.GetMouseButtonUp(1) && trackedTime >= cooldownTime)
        {
            Instantiate(bomb, this.transform);
            trackedTime = 0;
        }
        trackedTime += Time.deltaTime;
    }
       void FixedUpdate() {
        /**
         if (Input.GetMouseButtonUp(1))
        {
            Instantiate(bomb, this.transform);
        }
        **/
    }

}
