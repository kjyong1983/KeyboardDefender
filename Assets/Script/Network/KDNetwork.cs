using System;
using System.Collections.Generic;
using SocketIO;
using UnityEngine;

public class KDNetwork {

	private static bool __DEV__ = false;

	public delegate void OnOpenHandler();
	public event OnOpenHandler OnOpen;

	public delegate void BeAttackedHandler(float coordX, string byUser);
	public event BeAttackedHandler BeAttacked;

	private Dictionary<string, string> usernameMap = new Dictionary<string, string>();

	private enum Actions
	{
		Login,
		Attack,
		Score,

		ShareUserInfo
	}

	private KDSocketIO kdSocket;

	public KDNetwork(SocketIOComponent socket)
	{
		kdSocket = new KDSocketIO(socket, () => OnOpen(), OnReceive);
	}

	public void Login(string username)
	{
		usernameMap.Add(kdSocket.UserId, username);

		JSONObject data = new JSONObject();
		data.AddField("username", username);

		kdSocket.Send(Actions.Login.ToString(), data);
	}

	public void Attack(float coordX)
	{
		JSONObject data = new JSONObject();
		data.AddField("coordX", coordX);

		kdSocket.Send(Actions.Attack.ToString(), data);
	}

	public void Score(int score)
	{
		JSONObject data = new JSONObject();
		data.AddField("score", score);

		kdSocket.Send(Actions.Attack.ToString(), data);
	}

	private void ShareUserInfo(string username)
	{
		JSONObject data = new JSONObject();
		data.AddField("username", username);

		kdSocket.Send(Actions.ShareUserInfo.ToString(), data);
	}

	private void OnReceive(string name, string userId, JSONObject data)
	{
		switch ((Actions) Enum.Parse(typeof(Actions), name))
		{
			case Actions.Login:
				OnSomeoneLogined(userId, data);
				break;
			case Actions.Attack:
				OnSomeoneAttacked(userId, data);
				break;
			case Actions.Score:
				OnSomeoneSendScore(userId, data);
				break;
			case Actions.ShareUserInfo:
				OnSomeoneSharedUserInfo(userId, data);
				break;
		}
	}

	private void OnSomeoneLogined(string userId, JSONObject data)
	{
		if (!__DEV__)
		{
			if (userId == kdSocket.UserId)
			{
				return;
			}
		}

		string username = data.GetField("username").str;
		usernameMap.Add(userId, username);

		string myName = usernameMap[kdSocket.UserId];
		ShareUserInfo(myName);
	}

	// NOTE: Someone attacked (It doesn't necessa necessarily mean that this user is attacked. It depends on the game rule.)
	private void OnSomeoneAttacked(string userId, JSONObject data)
	{
		if (!__DEV__)
		{
			if (userId == kdSocket.UserId)
			{
				return;
			}
		}

		float coordX = data.GetField("coordX").f;
		string byUser = usernameMap[userId];
		BeAttacked(coordX, byUser);
	}

	private void OnSomeoneSendScore(string userId, JSONObject data)
	{
		
	}

	private void OnSomeoneSharedUserInfo(string userId, JSONObject data)
	{
		string username = data.GetField("username").str;
		usernameMap.Add(userId, username);
	}
}
