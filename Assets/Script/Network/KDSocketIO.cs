using SocketIO;
using System;
using UnityEngine;

public class KDSocketIO {

	private SocketIOComponent socket;
	private Action<string, JSONObject> onReceive;

	public KDSocketIO(SocketIOComponent socket, Action<string, JSONObject> onReceive)
	{
		this.socket = socket;
		this.onReceive = onReceive;

		socket.On("open", OnOpen);
		socket.On("receive", OnReceive);
		socket.On("error", OnError);
		socket.On("close", OnClose);
	}

	public void Send(string name, JSONObject data)
	{
		JSONObject wholeData = new JSONObject();
		wholeData.AddField("name", name);
		wholeData.AddField("data", data);
		socket.Emit("send", wholeData);
	}

	public void OnOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}

	public void OnReceive(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		onReceive(e.data.GetField("name").str, e.data.GetField("data"));
	}

	public void OnError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}

	public void OnClose(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}
