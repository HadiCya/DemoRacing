using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject canvas;
    public TMPro.TMP_InputField nameInput;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public void spawnPlayer()
    {
        canvas.SetActive(false);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        player.GetComponent<PhotonView>().Owner.NickName = nameInput.text;
    }
}