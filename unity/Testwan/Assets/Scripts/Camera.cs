using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
    }


}
