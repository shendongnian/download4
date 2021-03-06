	<System.Runtime.CompilerServices.Extension()> _
	Public Sub Zero(ByRef S As String)
		Dim gch As GCHandle = GCHandle.Alloc(S, GCHandleType.Pinned)
		ZeroMemory(gch.AddrOfPinnedObject, S.Length * 2)
		gch.Free()
        S = Nothing
	End Sub
	Public Sub ZeroMemory(ByVal location As IntPtr, ByVal size As Integer)
		For i As Integer = 0 To size
			Marshal.WriteByte(IntPtr.Add(location, i), 0)
		Next
	End Sub
