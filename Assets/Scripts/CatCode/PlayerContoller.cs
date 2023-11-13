using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerContoller : MonoBehaviour
{
    private float _speed = 5.0f;

    private bool _isMoving = false;

    [SerializeField] Transform _movePoint;
    [SerializeField] Tilemap _groindTileMap;
    [SerializeField] GameObject _playerObj;

    private List<Vector3> actionList = new List<Vector3>();

    private void Start()
    {
        _movePoint.parent = null;
    }

    private void Update()
    {
        _playerObj.transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _speed * Time.deltaTime);
    }

    public void MoveHorizontal(int axisInput)
    {
        var moveDirX = new Vector3(axisInput, 0f, 0f);
        if (Vector3.Distance(_playerObj.transform.position, _movePoint.position) <= 0.05f)
        {
            AddAction(moveDirX);
        }
    }

    public void MoveVertical(int axisInput)
    {
        var moveDirY = new Vector3(0f, axisInput, 0f);
        if (Vector3.Distance(_playerObj.transform.position, _movePoint.position) <= 0.05f)
        {
            AddAction(moveDirY);
        }
    }

    private void AddAction(Vector3 action)
    {
        if(!_isMoving) actionList.Add(action);
    }

    public void ExecuteActions()
    {
        if(!_isMoving) StartCoroutine(ExecuteActionsCoroutine());
        _isMoving = true;
    }

    private IEnumerator ExecuteActionsCoroutine()
    {
        foreach (Vector3 action in actionList)
        {
            if (CanMove(action))
            {
                while (Vector3.Distance(_playerObj.transform.position, _movePoint.position) > 0.05f)
                {
                    yield return null;
                }

                _movePoint.position += action;

                yield return new WaitForSeconds(0.5f);
            }
            else print('b');
        }

        actionList.Clear();
        _isMoving = false;
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = _groindTileMap.WorldToCell(transform.position + (Vector3)direction);
        return !_groindTileMap.HasTile(gridPosition);
    }
}
