using System;
using SocketIO;
using UnityEngine;

public class KDNetwork {

	private static bool __DEV__ = false;

	public delegate void OnOpenHandler();
	public event OnOpenHandler OnOpen;

	public delegate void BeAttackedHandler(float coordX);
	public event BeAttackedHandler BeAttacked;

	private enum Actions
	{
		Attack
	}

	private KDSocketIO kdSocket;

	public KDNetwork(SocketIOComponent socket)
	{
		kdSocket = new KDSocketIO(socket, () => OnOpen(), OnReceive);
	}

	public void Login(string username)
	{
		// TODO
	}

	public void Attack(float coordX)
	{
		JSONObject data = new JSONObject();
		data.AddField("coordX", coordX);

		kdSocket.Send(Actions.Attack.ToString(), data);
	}

	private void OnReceive(string name, string userId, JSONObject data)
	{
		switch ((Actions) Enum.Parse(typeof(Actions), name))
		{
			case Actions.Attack:
				OnSomeoneAttacked(name, userId, data);
				break;
		}
	}

	// NOTE: Someone attacked (It doesn't necessa necessarily mean that this user is attacked. It depends on the game rule.)
	private void OnSomeoneAttacked(string name, string userId, JSONObject data)
	{
		if (!__DEV__)
		{
			if (userId == kdSocket.UserId)
			{
				return;
			}
		}

		float coordX = data.GetField("coordX").f;
		BeAttacked(coordX);
	}
}
