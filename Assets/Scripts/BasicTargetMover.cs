using UnityEngine;

public class BasicTargetMover : MonoBehaviour
{
    [SerializeField] bool doSpin = true;
    [SerializeField] float spinSpeed = 180.0f;

    [SerializeField] bool doMotion = true;
    [SerializeField] float motionMagnitude = 0.1f;   
    
    // Update is called once per frame
    void Update()
    {
        if (doSpin)
        {
            //Rotate around the up axis
            gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        if (doMotion)
        {
            //Move up and down over time
            gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
        }
    }
}
