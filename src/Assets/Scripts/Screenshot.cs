using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public RenderTexture texture;
    public Camera camera;
    public int scale = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            camera.enabled = true;
            camera.Render();

            RenderTexture.active = texture;
            Texture2D tex = new Texture2D(texture.width, texture.height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
            RenderTexture.active = null;

            byte[] bytes;
            bytes = tex.EncodeToPNG();

            string folder = Path.GetFullPath("../img");
            string filename = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + "--R.png";
            string path = Path.Combine(folder, filename);

            System.IO.Directory.CreateDirectory(folder);
            System.IO.File.WriteAllBytes(path, bytes);
            Debug.Log("Saved to " + path);

            camera.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            string folder = Path.GetFullPath("../img");
            string filename = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + "--T.png";
            string path = Path.Combine(folder, filename);
            
            ScreenCapture.CaptureScreenshot(path, scale);
        }
    }   
}
