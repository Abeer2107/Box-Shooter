using UnityEngine;

public class BGMaterialController : MonoBehaviour
{
    float value;
    [SerializeField] float minValue = 0.5f;
    [SerializeField] float maxValue = 1.5f;
    bool reachedLimit;
    private float time = 0.0f;
    [SerializeField] float interpolationPeriod = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        value = minValue;
        reachedLimit = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;

            if (!reachedLimit)
            {
                value += 0.1f;
            }
            if (value >= maxValue)
            {
                reachedLimit = true;
            }
            if (reachedLimit)
            {
                value -= 0.1f;
            }
            if (value <= minValue)
            {
                reachedLimit = false;
            }
            gameObject.GetComponent<Skybox>().material.SetFloat("_Exposure", value);
        }
        
    }
    private void OnDestroy()
    {
        gameObject.GetComponent<Skybox>().material.SetFloat("_Exposure", minValue);
    }
}
