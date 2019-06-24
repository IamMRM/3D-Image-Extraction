using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
    }
    int count = 0;
    double rotationsPerMinute = 15.0;
    public int resWidth = 640;
    public int resHeight = 640;
    public Camera camera;
    // Update is called once per aframe
    
    void Update () {
        if (count <= 150) { 
            var y = Random.Range(-9, +9) + 4;
            var z = Random.Range(-1, 10);
            var x = Random.Range(-10, -1) - 2;
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.ARGB32, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            //screenShot.Apply();
            camera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = "Batman" + count+".png";
            System.IO.File.WriteAllBytes(filename, bytes);
            //Debug.Log(string.Format("Took screenshot to: {0}", filename));
            //Application.OpenURL(filename);
            transform.Rotate((float)((double)x * rotationsPerMinute * Time.deltaTime), (float)((double)x * rotationsPerMinute * Time.deltaTime), (float)((double)x * rotationsPerMinute * Time.deltaTime));
            count++;
        }
    }
}
