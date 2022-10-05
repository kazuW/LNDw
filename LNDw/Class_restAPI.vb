Imports System
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Serialization
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows

Public Class lnd_restApi

    Public Shared macaroon_metadata As String

    Public Function getInfo() As node_info

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "GET"
        Dim path As String = "v1/getinfo"

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(1)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     node_info.AliasName = CType(JsonObject("alias"), String)
                                     node_info.PubKey = CType(JsonObject("identity_pubkey"), String)
                                     node_info.LndVersion = CType(JsonObject("version"), String)
                                     node_info.Chain = CType(JsonObject("chains")(0)("chain"), String)
                                     node_info.Network = CType(JsonObject("chains")(0)("network"), String)
                                     node_info.NumPendingChannel = CType(JsonObject("num_pending_channels"), Integer)
                                     node_info.NumActiveChannel = CType(JsonObject("num_active_channels"), Integer)
                                     node_info.NumInactiveChannel = CType(JsonObject("num_inactive_channels"), Integer)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.TextBox_log.Text += Form1.dt + ": Error convert json(nodeinfo update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.TextBox_log.Text += Form1.dt + ": Error connect LND(nodeinfo update)" + vbCrLf
            Form1.TextBox_log.Text += vbTab + "Please check config setting!!" + vbCrLf
            MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return node_info

    End Function

    Public Function walletBalance() As UInt64

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim wallet_balance As UInt64
        Dim method As String = "GET"
        Dim path As String = "/v1/balance/blockchain"

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     wallet_balance = CType(JsonObject("total_balance"), UInt64)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.TextBox_log.Text += Form1.dt + ": Error convert json(wallet balance update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.TextBox_log.Text += Form1.dt + ": Error connect LND(wallet balance update)" + vbCrLf
            Form1.TextBox_log.Text += vbTab + "Please check config setting!!" + vbCrLf
            MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return wallet_balance

    End Function

    Public Function lightningBalance() As UInt64

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim lightning_balance As UInt64
        Dim method As String = "GET"
        Dim path As String = "/v1/balance/channels"

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     lightning_balance = CType(JsonObject("balance"), UInt64)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.TextBox_log.Text += Form1.dt + ": Error convert json(lightning balance update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.TextBox_log.Text += Form1.dt + ": Error connect LND(lightning balance update)" + vbCrLf
            Form1.TextBox_log.Text += vbTab + "Please check config setting!!" + vbCrLf
            MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return lightning_balance

    End Function

    Public Function getAllCannels() As ArrayList

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "GET"
        Dim path As String = "v1/channels"
        Dim ChannelLists As ArrayList = New ArrayList

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     Dim JsonObject1 As Object = JsonObject("channels")
                                     Dim jTokens As JEnumerable(Of JToken) = JsonObject1.children

                                     For Each jT As JToken In jTokens

                                         Dim tmpChannel As channel = New channel

                                         tmpChannel.PubKey = CType(jT("remote_pubkey"), String)
                                         tmpChannel.ChanID = CType(jT("chan_id"), String)
                                         tmpChannel.ChanPointID = CType(jT("channel_point"), String)
                                         tmpChannel.Capacity = CType(jT("capacity"), String)
                                         tmpChannel.LocalBalance = CType(jT("local_balance"), String)
                                         tmpChannel.RemoteBalance = CType(jT("remote_balance"), String)
                                         tmpChannel.Active = CType(jT("active"), Boolean)

                                         ChannelLists.Add(tmpChannel)

                                     Next

                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult = Form1.dt + ": Error convert json(get all channels update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(get all channels update)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return ChannelLists

    End Function

    Public Function getNodeInfo(ByVal pub_key As String) As String

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "GET"
        Dim path As String = "v1/graph/node/" + pub_key
        Dim NodeAliasName As String = ""

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     NodeAliasName = JsonObject("node")("alias")
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult = Form1.dt + ": Error convert json(nodeinfo update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(nodeinfo update)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return NodeAliasName

    End Function

    Public Function getChannelInfo(ByVal pub_key As String, ByVal chainID As String) As String()

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "GET"
        Dim path As String = "v1/graph/edge/" + chainID
        Dim chainFeeData(5) As String

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)

        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     Dim NodePubKey As String = CType(JsonObject("node1_pub"), String)

                                     If pub_key = NodePubKey Then
                                         chainFeeData(0) = CType(JsonObject("node1_policy")("fee_base_msat"), String)
                                         chainFeeData(1) = CType(JsonObject("node1_policy")("fee_rate_milli_msat"), String)
                                         chainFeeData(2) = CType(JsonObject("node1_policy")("time_lock_delta"), String)
                                         chainFeeData(3) = CType(JsonObject("node2_policy")("fee_base_msat"), String)
                                         chainFeeData(4) = CType(JsonObject("node2_policy")("fee_rate_milli_msat"), String)
                                         chainFeeData(5) = CType(JsonObject("node2_policy")("time_lock_delta"), String)
                                     Else
                                         chainFeeData(0) = CType(JsonObject("node2_policy")("fee_base_msat"), String)
                                         chainFeeData(1) = CType(JsonObject("node2_policy")("fee_rate_milli_msat"), String)
                                         chainFeeData(2) = CType(JsonObject("node2_policy")("time_lock_delta"), String)
                                         chainFeeData(3) = CType(JsonObject("node1_policy")("fee_base_msat"), String)
                                         chainFeeData(4) = CType(JsonObject("node1_policy")("fee_rate_milli_msat"), String)
                                         chainFeeData(5) = CType(JsonObject("node1_policy")("time_lock_delta"), String)
                                     End If

                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult = Form1.dt + ": Error convert json(getChannelInfo update)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(getChannelInfo update)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return chainFeeData

    End Function


    Private Sub generateMacaroon()

        Dim fs As New FileStream(Form1.macaroon_path + "admin.macaroon", FileMode.Open, FileAccess.Read)
        Dim fileSize As Integer = CInt(fs.Length)
        Dim buf(fileSize - 1) As Byte

        Dim readSize As Integer = fs.Read(buf, 0, fs.Length)

        macaroon_metadata = ""

        For i = 0 To buf.Count - 1
            macaroon_metadata += buf(i).ToString("x2")
        Next

    End Sub

End Class
