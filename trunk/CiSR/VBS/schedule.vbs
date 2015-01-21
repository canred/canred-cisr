On Error Resume Next

 url = Wscript.Arguments.Item(0) 
 
 Set File = WScript.CreateObject("Microsoft.XMLHTTP") 
 File.Open "GET", url, False 
 'This is IE 8 headers
 File.setRequestHeader "User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 1.1.4322; .NET CLR 3.5.30729; .NET CLR 3.0.30618; .NET4.0C; .NET4.0E; BCD2000; BCD2000)"
 File.Send
 If err.number <> 0 then 
    line =""
    Line  = Line &  vbcrlf & "" 
    Line  = Line &  vbcrlf & "Error getting file" 
    Line  = Line &  vbcrlf & "==================" 
    Line  = Line &  vbcrlf & "" 
    Line  = Line &  vbcrlf & "Error " & err.number & "(0x" & hex(err.number) & ") " & err.description 
    Line  = Line &  vbcrlf & "Source " & err.source 
    Line  = Line &  vbcrlf & "" 
    Line  = Line &  vbcrlf & "HTTP Error " & File.Status & " " & File.StatusText
    Line  = Line &  vbcrlf &  File.getAllResponseHeaders
    wscript.echo Line
    Err.clear
    wscript.quit
 End If

 'wscript.echo "Finish"
 
On Error Goto 0

' Set BS = CreateObject("ADODB.Stream")
' BS.type = 1
' BS.open
' BS.Write File.ResponseBody
' BS.SaveToFile "d:\test.txt", 2