using System;
using SocketIO;
using UnityEngine;

public class KDNetwork {

	public delegate void BeAttackedHandler(float coordX);
	public event BeAttackedHandler BeAttacked;

	private enum Names
	{
		Attack
	}

	private KDSocketIO kdSocket;

	public KDNetwork(SocketIOComponent socket)
	{
		kdSocket = new KDSocketIO(socket, OnReceive);
	}

	public void Attack(float coordX)
	{
		JSONObject data = new JSONObject();
		data.AddField("coordX", coordX);

		kdSocket.Send(Names.Attack.ToString(), data);
	}

	private void OnReceive(string name, JSONObject data)
	{
		Debug.Log("Open received: " + name + " " + data);

		switch ((Names) Enum.Parse(typeof(Names), name))
		{
			case Names.Attack:
				// NOTE: Someone attacked (It doesn't necessa necessarily mean that this user is attacked. It depends on the game rule.)
				float f = data.GetField("coordX").f;
				BeAttacked(f);
				break;
		}
	}
}
