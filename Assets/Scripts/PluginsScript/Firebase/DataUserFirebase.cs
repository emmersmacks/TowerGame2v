using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class DataUserFirebase : MonoBehaviour
{
    //This script was created for the Firebase test.
    DatabaseReference dbref;

    public int floorCount;
    public int souls = 5;

    public void Start()
    {
        dbref = FirebaseDatabase.DefaultInstance.RootReference;
        SaveData(souls);
    }

    public void SaveData(int field)
    {
        dbref.Child("Soul").SetValueAsync(field);
    }
}
