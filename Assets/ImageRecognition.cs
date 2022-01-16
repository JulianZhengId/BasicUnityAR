using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
/*    [SerializeField] private GameObject[] prefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();*/

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
/*        foreach (GameObject prefab in prefabs)
        {
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            obj.name = prefab.name;
            spawnedPrefabs.Add(obj.name, obj);
        }*/
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var e in eventArgs.added)
        {
            e.gameObject.transform.localScale = new Vector3(e.size.x, 0.005f, e.size.y);
            if (e.referenceImage.name == "Touhou")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (e.referenceImage.name == "Water Dragon")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
            else if (e.referenceImage.name == "Forest")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (e.referenceImage.name == "Cherry Blossom")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            else if (e.referenceImage.name == "Summer Girl")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (e.referenceImage.name == "Kimono Flower")
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                e.gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
            //SetText(e);
            //UpdateImage(e);

        }
        foreach (var e in eventArgs.updated)
        {
            if (e.trackingState == TrackingState.Limited)
            {
                e.gameObject.SetActive(false);

            }
            else
            {
                e.gameObject.SetActive(true);
            }
            //SetText(e);
            //UpdateImage(e);
        }
    }

/*    private void SetText(ARTrackedImage trackedImage)
    {
        text.text += "Name : " + trackedImage.referenceImage.name + '\n';
        text.text += "Size X : " + trackedImage.size.x + '\n';
        text.text += "Size Y : " + trackedImage.size.y + '\n';
        text.text += "State : " + trackedImage.trackingState.ToString() ;
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 pos = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = pos;
        prefab.transform.localScale = new Vector3(trackedImage.size.x, trackedImage.size.y, 0.3f);
        prefab.SetActive(true);

        if (trackedImage.trackingState == TrackingState.Limited)
        {
            text.text = "Removed";
            prefab.SetActive(false);
        }

        foreach (GameObject obj in spawnedPrefabs.Values)
        {
            if (obj.name != name)
            {
                obj.SetActive(false);
            }
        }
    }*/
}
