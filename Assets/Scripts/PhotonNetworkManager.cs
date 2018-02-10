using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PhotonNetworkManager : PunBehaviour
{
    public static PhotonNetworkManager instance;

    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            PhotonNetwork.autoJoinLobby = true;
            PhotonNetwork.automaticallySyncScene = true;
        }
    }

    void Start()
    {
        PhotonNetwork.playerName = PlayDataManager.Instance.nickName;

        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("dev");
        }
    }

    public override void OnJoinedRoom()
    {
        print("is join" + PhotonNetwork.isMasterClient + " / " + PhotonNetwork.room.PlayerCount);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        CoinManager.Instance.SendCoinPriceList(newPlayer.NickName);
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {

    }

    public int GetPlayerCount()
    {
        if (PhotonNetwork.connected)
            return PhotonNetwork.countOfPlayers;
        else
            return 0;
    }


}
