using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MovingCollectableCollision : CollectableCollision
{
    private List<GameObject> _movingObstaclesList = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            //if (collision.tag == "Moving Obstacle")
            //{
            //    _movingObstaclesList.Add(collision.gameObject);
            //}
            if (collision.tag == "Ball" && _isCollected == false)
            {
                _isCollected = true;
                ScoreManager.Instance.UpdateScore(_scoreReward);
                Destroy(collision.gameObject);
                // Destroy Moving Obstacles within trigger area
                this.gameObject.SetActive(false);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Moving Obstacle")
    //    {
    //        //_movingObstaclesList.Remove(collision.gameObject);
    //        collision.gameObject.GetComponent<MovingObstacle>().DestroySelf();
    //    }
    //}
}
