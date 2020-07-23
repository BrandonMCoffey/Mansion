using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour {
    public string level;
    public float roomSize = 10f;
    public float offX = 0f;
    public float offY = 0f;
    public float offZ = 0f;
    public GameObject otherFloor1;
    public GameObject otherFloor2;
    ImageController imageController;
    public List<GameObject> startingRooms;
    public List<GameObject> availableRooms;
    public List<Room> activeRooms = new List<Room> ();

    private void Awake () {
        int displacement = 0;
        while (startingRooms.Count > 0) {
            GenerateRoom (displacement++, 0, startingRooms[0], "Ignore");
            startingRooms.RemoveAt (0);
        }
        imageController = GameObject.Find ("ImageControl").GetComponent<ImageController> ();
    }
    bool DoesRoomExist (int x, int z) {
        return !(activeRooms.Find (item => item.X == x && item.Z == z) == null);
    }
    public int AttemptRoomGeneration (Room room, int dir) {
        if (availableRooms.Count == 0) {
            Debug.Log ("No available rooms left!");
            return 0;
        }
        int newRoomIndex;
        switch (dir) {
            //Dir rotates incrementally clockwise
            //Dir: 0 = PosZ, 1 = PosX, 2 = NegZ, 3 = NegX
            case 0:
                if (DoesRoomExist (room.X, room.Z + 1)) {
                    Debug.Log ("Attempted Room Generation where Room Exists");
                    return 2;
                }
                newRoomIndex = Mathf.FloorToInt (Random.Range (0, availableRooms.Count - 0.1f));
                GenerateRoom (room.X, room.Z + 1, availableRooms[newRoomIndex], "PosZ");
                availableRooms.RemoveAt (newRoomIndex);
                return 1;
            case 1:
                if (DoesRoomExist (room.X + 1, room.Z)) {
                    Debug.Log ("Attempted Room Generation where Room Exists");
                    return 2;
                }
                newRoomIndex = Mathf.FloorToInt (Random.Range (0, availableRooms.Count - 0.1f));
                GenerateRoom (room.X + 1, room.Z, availableRooms[newRoomIndex], "PosX");
                availableRooms.RemoveAt (newRoomIndex);
                return 1;
            case 2:
                if (DoesRoomExist (room.X, room.Z - 1)) {
                    Debug.Log ("Attempted Room Generation where Room Exists");
                    return 2;
                }
                newRoomIndex = Mathf.FloorToInt (Random.Range (0, availableRooms.Count - 0.1f));
                GenerateRoom (room.X, room.Z - 1, availableRooms[newRoomIndex], "NegZ");
                availableRooms.RemoveAt (newRoomIndex);
                return 1;
            case 3:
                if (DoesRoomExist (room.X - 1, room.Z)) {
                    Debug.Log ("Attempted Room Generation where Room Exists");
                    return 2;
                }
                newRoomIndex = Mathf.FloorToInt (Random.Range (0, availableRooms.Count - 0.1f));
                GenerateRoom (room.X - 1, room.Z, availableRooms[newRoomIndex], "NegX");
                availableRooms.RemoveAt (newRoomIndex);
                return 1;
            default:
                Debug.Log ("Invalid Direction for Room Generation");
                return 0;
        }
    }
    int RoomRotateTest (string dir, Room newRoom) {
        if (newRoom.doors.Count == 0) {
            return 0;
        }
        List<Door> doorScripts = new List<Door> ();
        foreach (GameObject door in newRoom.doors) {
            doorScripts.Add (door.GetComponent<Door> ());
        }
        int incoming;
        switch (dir) {
            case "PosZ":
                incoming = 2;
                break;
            case "PosX":
                incoming = 3;
                break;
            case "NegZ":
                incoming = 0;
                break;
            case "NegX":
                incoming = 1;
                break;
            case "Ignore":
                return 0;
            default:
                Debug.Log ("Invalid Direction for Room Rotation Test");
                return 0;
        }
        int rotation = 0;
        while (true) {
            foreach (Door door in doorScripts) {
                int newRotation = door.facing + rotation;
                while (newRotation > 3) {
                    newRotation -= 4;
                }
                if (newRotation == incoming) {
                    Destroy (door.gameObject);
                    return rotation;
                }
            }
            rotation++;
            if (rotation > 3) {
                Debug.Log ("Invalid Rotation for Room Rotation Test");
                return 0;
            }
        }
    }
    void GenerateDoor (Room room, string doorDir) {
        Transform doorGroup = room.model.transform.Find ("Door");
        if (doorGroup.Find ("Door" + doorDir)) {
            GameObject door = doorGroup.Find ("Door" + doorDir).gameObject;
            MeshCollider bad = door.GetComponent<MeshCollider> ();
            bad.enabled = false;
            BoxCollider doorActivation = door.AddComponent<BoxCollider> ();
            doorActivation.isTrigger = true;
            Door doorScript = door.AddComponent<Door> ();
            switch (doorDir) {
                //Dir rotates incrementally clockwise
                //Dir: 0 = PosZ, 1 = PosX, 2 = NegZ, 3 = NegX
                case "PosZ":
                    doorScript.facing = 0;
                    break;
                case "PosX":
                    doorScript.facing = 1;
                    break;
                case "NegZ":
                    doorScript.facing = 2;
                    break;
                case "NegX":
                    doorScript.facing = 3;
                    break;
                default:
                    Debug.Log ("Invalid  Direction for Door Generation");
                    break;
            }
            doorScript.room = room;
            doorScript.controlScript = this;
            room.doors.Add (door);
        }
    }
    void GenerateCard (Room room) {
        GameObject newCard;
        CardInRoom cardScript;
        Light cardHalo;
        if (room.model.transform.Find ("Event")) {
            newCard = room.model.transform.Find ("Event").gameObject;
            cardScript = newCard.AddComponent<CardInRoom> ();
            if (imageController.Events.Count > 0) {
                int index = Random.Range (0, imageController.Events.Count);
                cardScript.cardImage = imageController.Events[index];
                cardScript.cardType = "Event";
                imageController.Events.RemoveAt (index);
            } else {
                Debug.Log ("No Event Cards Left!");
            }
            cardHalo = newCard.AddComponent<Light> ();
            cardHalo.color = Color.blue;
        } else if (room.model.transform.Find ("Item")) {
            newCard = room.model.transform.Find ("Item").gameObject;
            cardScript = newCard.AddComponent<CardInRoom> ();
            if (imageController.Items.Count > 0) {
                int index = Random.Range (0, imageController.Items.Count);
                cardScript.cardImage = imageController.Items[index];
                cardScript.cardType = "Item";
                imageController.Items.RemoveAt (index);
            } else {
                Debug.Log ("No Item Cards Left!");
            }
            cardHalo = newCard.AddComponent<Light> ();
            cardHalo.color = Color.yellow;
        } else if (room.model.transform.Find ("Omen")) {
            newCard = room.model.transform.Find ("Omen").gameObject;
            cardScript = newCard.AddComponent<CardInRoom> ();
            if (imageController.Omens.Count > 0) {
                int index = Random.Range (0, imageController.Omens.Count);
                cardScript.cardImage = imageController.Omens[index];
                cardScript.cardType = "Omen";
                imageController.Omens.RemoveAt (index);
            } else {
                Debug.Log ("No Omen Cards Left!");
            }
            cardHalo = newCard.AddComponent<Light> ();
            cardHalo.color = Color.green;
        } else {
            return;
        }
        cardHalo.type = LightType.Point;
        cardHalo.intensity = 4;
        cardHalo.range = 4;
        MeshCollider badCollider = newCard.GetComponent<MeshCollider> ();
        badCollider.enabled = false;
        SphereCollider newCollider = newCard.AddComponent<SphereCollider> ();
        newCollider.isTrigger = true;
    }
    void GenerateRoom (int x, int z, GameObject referenceRoom, string dir) {
        string one = referenceRoom.name.Substring (4, 1);
        string two = referenceRoom.name.Substring (5, 1);
        if (one == "0") {
            one = "";
        }
        //Sprite mapTile;
        //Debug.Log(imageController.Map.Count);
        //foreach (Sprite tile in imageController.Map)
        //Debug.Log(imageController.Map.Count);
        //for (int i = 0; i < imageController.Map.Count; i++)
        {
            //Debug.Log(imageController.Map[i]);
            //if (tile.name == "Room_" + string.Concat(one, two))
        }
        Room newRoom = new Room {
            name = referenceRoom.name,
            modelPrefab = referenceRoom,
            model = Instantiate (referenceRoom),
            X = x,
            Z = z,
            rotation = 0,
            doors = new List<GameObject> (),
            //tile = mapTile
        };
        activeRooms.Add (newRoom);
        GenerateDoor (newRoom, "PosX");
        GenerateDoor (newRoom, "NegX");
        GenerateDoor (newRoom, "PosZ");
        GenerateDoor (newRoom, "NegZ");
        GenerateCard (newRoom);
        int rotations = RoomRotateTest (dir, newRoom);
        newRoom.rotation = rotations;
        newRoom.model.transform.parent = this.transform;
        newRoom.model.transform.position = new Vector3 (x * roomSize + offX, offY, z * roomSize + offZ);
        newRoom.model.transform.rotation = Quaternion.Euler (0f, 90f * rotations, 0f);
        while (rotations > 0) {
            foreach (GameObject door in newRoom.doors) {
                door.GetComponent<Door> ().RotateClockwise ();
            }
            rotations--;
        }
        GameObject lightGameObject = new GameObject (newRoom.name + " Light");
        Light lightComp = lightGameObject.AddComponent<Light> ();
        lightComp.color = Color.Lerp (Color.red, Color.green, 0.4f);
        lightComp.intensity = 20f;
        lightGameObject.transform.position = new Vector3 (x * roomSize + offX, 2 * roomSize / 5 + offY, z * roomSize + offZ);

        RoomController otherControl1 = otherFloor1.GetComponent<RoomController> ();
        for (int i = 0; i < otherControl1.availableRooms.Count; i++) {
            if (otherControl1.availableRooms[i].name == referenceRoom.name) {
                otherControl1.availableRooms.RemoveAt (i);
            }
        }
        RoomController otherControl2 = otherFloor1.GetComponent<RoomController> ();
        for (int i = 0; i < otherControl2.availableRooms.Count; i++) {
            if (otherControl2.availableRooms[i].name == referenceRoom.name) {
                otherControl2.availableRooms.RemoveAt (i);
            }
        }
    }
}