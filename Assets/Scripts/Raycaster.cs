using Unity.VisualScripting;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    GameObject _click;

    void moveChip()
    {
        Vector3 clickPosition = _click.transform.position;
        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
        CurrentPlayer.MovementChip.Move(lastClick);
    }

    void buyObject()
    {
        Vector3 clickPosition = _click.transform.position;
        clickPosition.y = 1;

        Point p = new Point((int)clickPosition.x, (int)clickPosition.z);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];

        if (!player.CanBuyObject(CurrentPlayer.TypePurchasedObject, p))
            return;
        //
        Field.DeleteCoin(p);

        ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, clickPosition, Quaternion.identity);

        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.NextPlayer();
    }

    void rocketAttack()
    {
        print(_click.tag);
        if (_click.tag == "Chip" || _click.tag == "Cell" || _click.tag == "coins")
            return;

        Vector3 clickPosition = _click.transform.position;
        Point p = new Point((int)clickPosition.x, (int)clickPosition.z);

        MapObject.DeleteObject(p);
        MonoBehaviour.Destroy(_click);

        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.NextPlayer();
    }

    void OnClick()
    {
        switch (CurrentPlayer.OperatingMode)
        {
            case "movement_chip":
                moveChip();
                break;

            case "buy_object":
                buyObject();
                break;

            case "rocket_attack":
                rocketAttack();
                break;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                _click = hit.collider.gameObject;
                OnClick();
            }
        }
    }
}
