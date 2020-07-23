using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int facing;
    public Room room;
    public RoomController controlScript;

    //Dir rotates incrementally clockwise
    //Dir: 0 = PosZ, 1 = PosX, 2 = NegZ, 3 = NegX

    public void RotateClockwise()
    {
        facing++;
        if (facing > 3)
        {
            facing = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        int roomGenerationSuccess;
        /*if (other.GetComponent<Player>().turn == PlayerTurn.Move) {
            roomGenerationSuccess = controlScript.AttemptRoomGeneration(room, facing);
        }
        else
        {
            Debug.Log("Player attempting to move when it is not his/her turn to do so");
            return;
        }*/
        roomGenerationSuccess = controlScript.AttemptRoomGeneration(room, facing);

        if (roomGenerationSuccess == 0)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else if (roomGenerationSuccess == 1)
        {
            Destroy(gameObject);
            other.GetComponent<Player>().turn = PlayerTurn.NewRoom;
        }
        else if (roomGenerationSuccess == 2)
        {
            Destroy(gameObject);
        }
    }
}
