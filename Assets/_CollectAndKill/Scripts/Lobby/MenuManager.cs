using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace CollectAndKill
{
    public class MenuManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createInput;
        [SerializeField] private TMP_InputField _joinInput;
        [SerializeField] private TMP_InputField _nickname;

        private readonly int _maxPlayers = 3;
        private readonly int _buildIndexGame = 2;

        public void CreateRoom()
        {
            SaveName();

            RoomOptions roomOptions = new();
            roomOptions.MaxPlayers = _maxPlayers;
            PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            SaveName();

            PhotonNetwork.JoinRoom(_joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(_buildIndexGame);
        }

        private void SaveName()
        {
            PhotonNetwork.NickName = _nickname.text;
        }
    }
}
