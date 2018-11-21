using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using System;
 using System.IO;
 using System.Runtime.Serialization.Formatters.Binary;
 using UnityEngine.SceneManagement;
 
 public class SaveSystem : MonoBehaviour {
 
     GameObject player;
 
     private Scene scene;
 
     public static float health;
     public static bool firePower;
     public static bool saved;
 
     void Start()
     {
         player = GameObject.FindGameObjectWithTag ("Player");
         //cam = GameObject.Find ("Camera");
 
     }
 
     public void SaveData () 
     {
         BinaryFormatter bf = new BinaryFormatter ();
         FileStream file = File.Create (Application.persistentDataPath + "/Data.dat");
         PlayerData data = new PlayerData ();
 
         data.posx = player.transform.position.x;
         data.posy = player.transform.position.y;
         data.posz = player.transform.position.z;
 
         data.rotx = player.transform.rotation.x;
         data.roty = player.transform.rotation.y;
         data.rotz = player.transform.rotation.z;
         data.rotw = player.transform.rotation.w;
         
         data.health = health;
         data.firePower = firePower;

         //scene = SceneManager.GetSceneByName("UnityChanAnim");
         //data.sceneName = scene.name;

         bf.Serialize (file, data);
         file.Close ();
     }
 
     public void LoadData()
     {
         if(File.Exists (Application.persistentDataPath + "/Data.dat"))
         {
             BinaryFormatter bf = new BinaryFormatter ();
             FileStream file = File.Open (Application.persistentDataPath + "/Data.dat", FileMode.Open);
             PlayerData data = (PlayerData)bf.Deserialize (file);
 
             file.Close ();
 
 
             //SceneManager.LoadScene (data.sceneName, LoadSceneMode.Single);
 
             Vector3 newPlayerPos = new Vector3 (data.posx, data.posy, data.posz);
             Quaternion newPlayerRot = new Quaternion (data.rotx, data.roty, data.rotz, data.rotw);
 
			player.transform.position = newPlayerPos;
			player.transform.rotation = newPlayerRot;
            health = data.health;
            firePower = data.firePower;
			
             //startScript.LoadDataState (newPlayerPos, newPlayerRot);
         }
     }
 }
 
 [Serializable]
 class PlayerData
 {
     public string sceneName;
 
     public float posx;
     public float posy;
     public float posz;
 
     public float rotx;
     public float roty;
     public float rotz;
     public float rotw;

     public float health;
     public bool firePower;
 }