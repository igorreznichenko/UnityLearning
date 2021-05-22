using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class SaveScript : MonoBehaviour
{
    string HttpAddress = "https://localhost:44359/api/PlayerTransform";

    [SerializeField] Transform _player;
    [SerializeField] Text _message;
    void Start()
    {
        _message.text = "";
    }

    public void OnSave()
    {
        _message.text = "Please wait";
        StartCoroutine("WebSave");
      
    }
    IEnumerator WebSave()
    {
        WWWForm data = new WWWForm();
        data.AddField("obj", JsonUtility.ToJson(_player.transform.position));
        UnityWebRequest unityWebRequest = UnityWebRequest.Post(HttpAddress, data);
        
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.isNetworkError)
        {
            Debug.LogError(unityWebRequest.error);
        }
        _message.text = "";
    }
    public void OnLoad() 
    {
        _message.text = "Please wait";
        StartCoroutine("WebLoad");
     


    }
    IEnumerator WebLoad()
    {
        UnityWebRequest Request = UnityWebRequest.Get(HttpAddress);
        yield return Request.SendWebRequest();
        if (Request.isHttpError)
        {
            Debug.LogError(Request.error);
        }
        Vector3 position = JsonUtility.FromJson<Vector3>(Request.downloadHandler.text);
        _player.transform.position = position;
        _message.text = "";
    }
    private void Save()
    {
        //Serialization using streamingAssetsPath
        //string path = Path.Combine(Application.streamingAssetsPath, "Save.txt");
        //StreamWriter sr = new StreamWriter(path);
        //Vector3 position = player.transform.position;
        //sr.Write(JsonUtility.ToJson(position));
        //sr.Close();

        //Serialization using playerPrefs
        Vector3 position = _player.transform.position;
        PlayerPrefs.SetString("Saving", JsonUtility.ToJson(position));
    }

    private void Load()
    {
        //Deserialization using streamingAssetsPath
        //string path = Path.Combine(Application.streamingAssetsPath, "Save.txt");
        //StreamReader sr = new StreamReader(path);
        //string JSON = sr.ReadToEnd();
        //Vector3 position = JsonUtility.FromJson<Vector3>(JSON);
        //transform.position = position;
        //sr.Close();

        //Deserialization using playerPrefs
        if (PlayerPrefs.HasKey("Saving"))
        {
            Vector3 position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Saving"));
            _player.transform.position = position;

        }

    }

}
