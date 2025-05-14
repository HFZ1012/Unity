using UnityEngine;

public class Test : MonoBehaviour
{
    public int val1;
    [Range(0, 5)]
    public int val2;

    void Awake()
    {
        Debug.Log("Awake called");
        GameObject mainCamera = GameObject.Find("Main Camera");
        Transform child1 = transform.Find("Sphere");
    }

    void Start()
    {
        bool active = gameObject.activeSelf;
        Transform trans = gameObject.transform;
        Transform trans2 = transform;
        string name = gameObject.name;
        string tag = gameObject.tag;
        bool isStatic = gameObject.isStatic;
        bool enabled = this.enabled;
        this.enabled = true;
        Debug.Log($"Start{Time.frameCount}");

    }

     void OnEnable()
    {
        Debug.Log($"OnEnable {Time.frameCount}");
    }
    void OnDisable()
    {
        Debug.Log($"OnDisable {Time.frameCount}");
    }
    void OnDestroy()
    {
        Debug.Log($"OnDestroy  {Time.frameCount}");
    }
    void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log($"OnApplicationPause {Time.frameCount}");
    }
    void OnApplicationQuit()
    {
        Debug.Log($"OnApplicationQuit  {Time.frameCount}");
    }
}