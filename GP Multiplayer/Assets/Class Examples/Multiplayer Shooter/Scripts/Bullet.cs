using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Bullet : MonoBehaviourPun {

    public bool MovingDirection;
    public float MoveSpeed = 8;

    public float DestroyTime=  2f;
    public float bulletDamage = 0.3f;

    public string killerName;
    public GameObject localPlayerObj;

    void Start()
    {
        if(photonView.IsMine)
        killerName = localPlayerObj.GetComponent<CowBoy>().MyName;
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(DestroyTime);
        // Destroy bullet on the other clients
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
    }

    void Update()
    {
        if (!MovingDirection)
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }


    [PunRPC]
    public void ChangeDirection()
    {
        MovingDirection = true;
    }

    [PunRPC]
    void Destroy()
    {
        Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (!photonView.IsMine)
        {
            return;
        }

        PhotonView target = collision.gameObject.GetComponent<PhotonView>();
       
        if (target != null && (!target.IsMine))
        {
            //If any player is hit, update the health
            if (target.tag == "Player")
            {
                //RPC is called on each client
                target.RPC("HealthUpdate", RpcTarget.AllBuffered, bulletDamage);
                target.GetComponent<HurtEffect>().GotHit();

                if (target.GetComponent<Health>().health <= 0)
                {
                    // Only show on player who got killed
                    Player GotKilled = target.Owner;
                    target.RPC("YouGotKilledBy", GotKilled, killerName);

                    target.RPC("YouKilled", localPlayerObj.GetComponent<PhotonView>().Owner, target.Owner.NickName);
                }

            }
            this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);

        }
    }
}
