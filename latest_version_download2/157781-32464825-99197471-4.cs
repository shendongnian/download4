    public class MyPacketHandler
    {
    	Dictionary<Type, Action<Packet>> _packetHandlers = new Dictionary<Type, Action<Packet>>();
    	public MyPacketHandler()
    	{
    		_packetHandlers.Add(typeof(MessagePacket), HandleMessagePacket);
    		_packetHandlers.Add(typeof(PingPacket), HandlePingPacket);
    	}
    	
    	public void HandlePacket(Packet packet)
    	{
    		var type = packet.GetType();
    		if(!_packetHandlers.Contains(type))
    			throw new NotSupportedException(type.Name + " is not supported");
   			_packetHandlers[type].Invoke(packet);
    	}
    	
    	public void HandleMessagePacket(Packet packet)
    	{
    		var messagePacket = packet as MessagePacket;
    		if(packet == null)
    			throw new Exception("oops");
    	}
    }
