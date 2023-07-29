using Photon.Pun;
using UnityEngine.SceneManagement;

namespace CollectAndKill
{
    public class ServerConnection : MonoBehaviourPunCallbacks
    {
        private readonly int _buildIndexLobby = 1;

        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene(_buildIndexLobby);
        }
    }
}
