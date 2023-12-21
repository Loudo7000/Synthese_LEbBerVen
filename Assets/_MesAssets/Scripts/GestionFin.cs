using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class GestionFin : MonoBehaviour
{

    private GearPuzzle gearPuzzle;
    private ColorPuzzle colorPuzzle;

    private void Start()
    {
        gearPuzzle = FindObjectOfType<GearPuzzle>();
        colorPuzzle = FindObjectOfType<ColorPuzzle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (colorPuzzle.PuzzleColorEnable && gearPuzzle.PuzzleGearEnable)
        {
            Lobby currentLobby = LobbyManager.Instance.CurrentLobby;
            if (currentLobby == null)
            {

                return;
            }

            // Comme un veux seulement que ce soit le host du lobby qui call le 
            // début de la partie on s'assure que seulement celui-ci call le changement
            if (currentLobby.HostId == AuthenticationService.Instance.PlayerId)
            {
                //On verrouille le Lobby pour les autres joueurs
                LobbyManager.Instance.LockLobby();
                // Si oui on call la méthode pour changer de scène
                NetworkSceneTransition.Instance.ChargerScenePourTous("LobbyFin");
            }
        }
    }

    private void Update()
    {


    }

    public void SetReady(bool isReady)
    {
        Lobby currentLobby = LobbyManager.Instance.CurrentLobby;

        // Vérifier s'il existe un Lobby courant
        if (currentLobby != null)
        {
            // Si oui on récupère le PlayerId du joueur dans ce lobby
            string playerId = AuthenticationService.Instance.PlayerId;
            //À l'aide de la fonction Find ici on cherche dans les joueurs qui sont dans le lobby
            //Une valeur x où le Id de x est identique au playerId on place le joueur trouvé dans la variable myPLayer
            Player myPlayer = currentLobby.Players.Find(x => x.Id == playerId);

            // Si on a trouver un joueur avec ce Id
            if (myPlayer != null)
            {
                // Si le joueur n'a pas de Data on crée un nouveau dictionnaire
                // contenant l'information sur le joueur
                if (myPlayer.Data == null)
                {
                    myPlayer.Data = new Dictionary<string, PlayerDataObject>();
                }

                // On crée un DataObject qui va indiquer que le joueur est prêt
                // ici on doit l'indiquer par un string dans le dictionnaire donc on retourne yes si
                // isReady est vrai ou no s'il est faux
                PlayerDataObject isReadyData = new PlayerDataObject(PlayerDataObject.VisibilityOptions.Public,
                    isReady ? "yes" : "no");

                // On vérifie si les Data du joueur on bien une key dans le dictionnaire
                // qui se nomme isReady
                if (myPlayer.Data.ContainsKey("isReady"))
                {
                    // Si c'est le cas on assigne la data crée plus haut dans le dictionnaire
                    myPlayer.Data["isReady"] = isReadyData;
                }
                else
                {
                    // Si la clé n'existe pas on en crée une et assigne la valeur
                    myPlayer.Data.Add("isReady", isReadyData);
                }

                // Finalement on update l'information sur le joueur dans le lobby
                // LobbyManager.Instance.UpdatePlayer(myPlayer.Data);

                //Pour éviter le bug on ne change pas durectement les données du joueur
                // On appelle plutot la méthode avec un délai
                LobbyManager.Instance.UpdatePlayerData(myPlayer.Data);

            }
        }
    }
}
