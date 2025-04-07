using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public int dungeonSize = 10;
    private List<Rect> occupiedAreas = new List<Rect>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        Vector2 currentPosition = Vector2.zero; // Startpositie
        GameObject startRoom = Instantiate(roomPrefabs[0], currentPosition, Quaternion.identity);
        Vector2 startSize = GetRoomSize(startRoom);

        occupiedAreas.Add(new Rect(currentPosition, startSize)); // Voeg startkamer toe

        for (int i = 1; i < dungeonSize; i++)
        {
            GameObject roomPrefab = GetRandomRoom();
            Vector2 roomSize = GetRoomSize(roomPrefab);
            Vector2 newPos = FindValidPosition(roomSize);

            if (newPos != Vector2.zero)
            {
                Instantiate(roomPrefab, newPos, Quaternion.identity);
                occupiedAreas.Add(new Rect(newPos, roomSize));
            }
        }
    }
    Vector2 FindValidPosition(Vector2 roomSize)
    {
        int maxTries = 100;
        while (maxTries > 0)
        {
            // Richtingen uitbreiden met diagonalen
            Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right,
                                  new Vector2(1, 1), new Vector2(-1, 1), new Vector2(1, -1), new Vector2(-1, -1) };

            Vector2 randomDirection = directions[Random.Range(0, directions.Length)];

            // Kies een willekeurige bestaande kamer om vanaf te starten
            Rect randomRoom = occupiedAreas[Random.Range(0, occupiedAreas.Count)];
            // Beweeg in de gekozen richting, zonder ruimte toe te voegen
            Vector2 newPos = (Vector2)randomRoom.position + (randomDirection * randomRoom.size);

            if (!IsOverlapping(newPos, roomSize))
                return newPos;

            maxTries--;
        }
        return Vector2.zero; // Geen geldige positie gevonden
    }

    bool IsOverlapping(Vector2 pos, Vector2 size)
    {
        Rect newRoom = new Rect(pos, size);
        foreach (Rect occupied in occupiedAreas)
        {
            if (newRoom.Overlaps(occupied))
                return true;
        }
        return false;
    }

    GameObject GetRandomRoom()
    {
        return roomPrefabs[Random.Range(1, roomPrefabs.Length)];
    }

    Vector2 GetRoomSize(GameObject roomPrefab)
    {
        string name = roomPrefab.name; // Bijvoorbeeld: "Room_12x8"
        string[] parts = name.Split('_');

        if (parts.Length >= 2 && parts[1].Contains("x"))
        {
            string[] dimensions = parts[1].Split('x');
            if (int.TryParse(dimensions[0], out int width) && int.TryParse(dimensions[1], out int height))
            {
                return new Vector2(width, height);
            }
        }

        return new Vector2(10, 10); // Default grootte als het niet uit de naam gelezen kan worden
    }
}