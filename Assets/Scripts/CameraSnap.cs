using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSnap : MonoBehaviour
{
    [Serializable]
    public class MinMax <T>
    {
        public T min, max;
    }

	public Transform camera;
	public bool canFall;
    public float scrollOffset = 2;

	public Vector2Int snap;
    public MinMax<int>[] levelWidths;
    public bool[] levelSnapX;

    private Transform _player;
	private PlayerLife _playerlife;

    public void SetCanFall(bool _canFall) => canFall = _canFall;

	private bool _isFalling = false;

    private void Start()
    {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_playerlife = _player.GetComponent<PlayerLife>();
    }

	int NearestY(Vector3 v)
    {        
		return Mathf.RoundToInt(v.y / snap.y);
    }

    void Update()
    {
        int sy = NearestY(_playerlife.spawnpoint);
		int y = NearestY(_player.position);

		bool _wasFalling = _isFalling;
		_isFalling = y < sy;

		if(_isFalling && !canFall)
        {
            y = sy;
            if (!_wasFalling)
            {
                _playerlife.Fall();
            }
        }

        bool snapX = (y < levelSnapX.Length && y < levelWidths.Length) ? levelSnapX[y] : true;

        Vector3 v = camera.position;

        if (!snapX)
        {
            MinMax<int> level = levelWidths[y];

            float xOff = camera.position.x - _player.position.x;

            v.x = Mathf.Clamp((_player.position.x + Mathf.Clamp(xOff, -scrollOffset, +scrollOffset)) / snap.x, level.min, level.max) * snap.x;
        } else
        {
            v.x = Mathf.RoundToInt(_player.position.x / snap.x) * snap.x;
        }

        v.y = y * snap.y;

        camera.position = v;
	}
}
