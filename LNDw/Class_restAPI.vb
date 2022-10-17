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

    Public Function getMcCfg() As mc_cfg

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim mc_cfg As mc_cfg = New mc_cfg
        Dim method As String = "GET"
        Dim path As String = "v2/router/mccfg"

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
                                     Dim JsonObject1 As Object = JsonObject("config")
                                     mc_cfg.HalfLifeSeconds = CType(JsonObject1("half_life_seconds"), String)
                                     mc_cfg.HopProbability = CType(JsonObject1("hop_probability"), Double)
                                     mc_cfg.Weight = CType(JsonObject1("weight"), Double)
                                     mc_cfg.MaxPaymentResults = CType(JsonObject1("maximum_payment_results"), Int64)
                                     mc_cfg.MinFailRelaxInterval = CType(JsonObject1("minimum_failure_relax_interval"), String)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.TextBox_log.Text += Form1.dt + ": Error convert json(get mc_cfg)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.TextBox_log.Text += Form1.dt + ": Error connect LND(get mc_cfg)" + vbCrLf
            Form1.TextBox_log.Text += vbTab + "Please check config setting!!" + vbCrLf
            MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return mc_cfg

    End Function

    Public Sub postMcCfg(ByVal mcCfg As mc_cfg)

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim method As String = "POST"
        Dim path As String = "v2/router/mccfg"
        Dim timeout As Integer = CType(Form1.timeout, Integer)

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        Dim routerMCC As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

        routerMCC.Add("half_life_seconds", mcCfg.HalfLifeSeconds)
        routerMCC.Add("hop_probability", mcCfg.HopProbability)
        routerMCC.Add("weight", mcCfg.Weight)
        routerMCC.Add("maximum_payment_results", mcCfg.MaxPaymentResults)
        routerMCC.Add("minimum_failure_relax_interval", mcCfg.MinFailRelaxInterval)

        parameters.Add("config", routerMCC)

        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(post mc_cfg)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

    End Sub

    Public Sub resetMcCfg()

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim method As String = "POST"
        Dim path As String = "v2/router/mc/reset"
        Dim timeout As Integer = CType(Form1.timeout, Integer)

        Dim body As String = "{  }"

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(reset mc_cfg)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

    End Sub

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

    Public Function getQueryRoute(ByVal outgoingID As String, ByVal lasthopPubKey As String, ByVal amount As String, ByVal fee_limit As String, ignoreNode As ArrayList) As String

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path

        Dim route As String = ""
        Dim method As String = "GET"
        Dim myPubkey As String = Form1.pubkey
        Dim lasthopPubKey_string As String = convertToBase64string(lasthopPubKey)

        Dim path As String = "v1/graph/routes/" + myPubkey + "/" + amount
        Dim query As String = ""

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        parameters.Add("fee_limit.fixed", fee_limit)
        parameters.Add("source_pub_key", myPubkey)
        parameters.Add("use_mission_control", True)
        parameters.Add("outgoing_chan_id", outgoingID)
        parameters.Add("last_hop_pubkey", lasthopPubKey_string)

        For Each kvp As KeyValuePair(Of String, Object) In parameters
            query += kvp.Key + "=" + kvp.Value.ToString + "&"
        Next

        For i = 0 To ignoreNode.Count - 1
            Dim tmpIgnoredNode As String
            tmpIgnoredNode = ignoreNode(i)
            query += "ignored_nodes=" + convertToBase64string(tmpIgnoredNode) + "&"
            'query += convertToBase64string(tmpIgnoredNode) + ","
        Next

        query = query.Substring(0, query.Length - 1)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path + "?" + query)

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
                                     route = response_json
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult += Form1.dt + ": Error convert json(get QueryRoute)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult += Form1.dt + ": Error connect LND(get QueryRoute)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'Console.Beep()
        End Try

        Return route

    End Function

    Public Function getQueryRoute_v2(ByVal outgoingID As String, ByVal outgoingPubKey As String, ByVal lasthopPubKey As String, ByVal amount As String) As String

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path

        Dim route As String = ""
        Dim method As String = "POST"
        Dim myPubkey As String = Form1.pubkey
        Dim myPubkey_byte(myPubkey.Length / 2 - 1) As Byte
        Dim lasthopPubKey_byte(lasthopPubKey.Length / 2 - 1) As Byte
        Dim myPubkey_string As String = convertToBase64string(myPubkey)
        Dim x As Integer = 0
        Dim path As String = "v2/router/route"

        lasthopPubKey_byte = convertToByte(lasthopPubKey)
        myPubkey_byte = convertToByte(myPubkey)

        Dim arrayString(1) As String

        arrayString(0) = convertToBase64string(outgoingPubKey)
        arrayString(1) = convertToBase64string(lasthopPubKey)

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        parameters.Add("amt_msat", amount + "000")
        parameters.Add("outgoing_chan_id", outgoingID)
        parameters.Add("hop_pubkeys", arrayString)
        parameters.Add("payment_addr", lasthopPubKey_byte)

        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(1)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                 Try
                                     route = response_json
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult += Form1.dt + ": Error convert json(get QueryRoute)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult += Form1.dt + ": Error connect LND(get QueryRoute)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'Console.Beep()
        End Try

        Return route

    End Function

    Public Function getPaymentHash(ByVal pay_req As String) As String

        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim method As String = "GET"
        Dim path As String = "v1/payreq/" + pay_req

        Dim payment_hash As String = ""

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
                                     payment_hash = CType(JsonObject("payment_hash"), String)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult += Form1.dt + ": Error convert json(get payment_hash)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult += Form1.dt + ": Error connect LND(get payment_hash)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'Console.Beep()
        End Try

        Return payment_hash

    End Function

    Public Function postChannelPolicy(ByVal chanPointID As String, ByVal feeBase As String, ByVal feeRate As String, ByVal HTLC_max As String, ByVal LockTime As String) As String

        Dim res As String = ""
        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "POST"
        Dim path As String = "v1/chanpolicy"
        Dim timeout As Integer = CType(Form1.timeout, Integer)

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        Dim lnrpcChanPoint As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        Dim tmpStr As String() = chanPointID.Split(":")
        'Dim tmpBytes As Byte() = Convert.FromBase64String(tmpStr(0))
        Dim index As Int64 = CType(tmpStr(1), Int64)

        'lnrpcChanPoint.Add("funding_txid_bytes", tmpBytes)
        lnrpcChanPoint.Add("funding_txid_str", tmpStr(0))
        lnrpcChanPoint.Add("output_index", index)

        parameters.Add("chan_point", lnrpcChanPoint)
        parameters.Add("base_fee_msat", feeBase)
        parameters.Add("fee_rate_ppm", CType(feeRate, Int64))
        parameters.Add("time_lock_delta", CType(LockTime, Int64))
        parameters.Add("max_htlc_msat", HTLC_max)

        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())
                                 res = response_json

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)

                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult = Form1.dt + ": Error convert json(post ChannelPolicy)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(post ChannelPolicy)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return res

    End Function

    Public Function postInvoice(ByVal amount As String, ByVal memo As String) As String

        Dim res As String = ""
        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "POST"
        Dim path As String = "v1/invoices"
        Dim timeout As Integer = CType(Form1.timeout, Integer)
        Dim expire As String = Form1.timeout
        Dim pay_response As String = ""

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        'Dim tmpBytes As Byte() = Convert.FromBase64String()

        parameters.Add("memo", memo)
        parameters.Add("value", amount)
        parameters.Add("expiry", expire)
        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())
                                 'res = response_json

                                 Try
                                     Dim JsonObject As Object = JsonConvert.DeserializeObject(response_json)
                                     pay_response = CType(JsonObject("payment_request"), String)
                                     'Console.WriteLine("sucssess")
                                 Catch ex As Exception
                                     Form1.tmpResult = Form1.dt + ": Error convert json(post invoice)" + vbCrLf
                                     'Console.WriteLine("error")
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(post invoice)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return pay_response

    End Function

    Public Sub cancelInvoice(ByVal payHash As String)

        Dim res As String = ""
        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim node_info As node_info = New node_info
        Dim method As String = "POST"
        Dim path As String = "v2/invoices/cancel"
        Dim timeout As Integer = CType(Form1.timeout, Integer)
        Dim expire As String = Form1.timeout
        Dim payHash_byte(payHash.Length / 2 - 1) As Byte
        Dim x As Int16 = 0

        payHash_byte = convertToByte(payHash)

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        'Dim tmpBytes As Byte() = Convert.FromBase64String()

        parameters.Add("payment_hash", payHash_byte)
        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromMinutes(5)

                                 Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                 Dim response_json As String = Await (message.Content.ReadAsStringAsync())
                                 'res = response_json

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(cancel invoice)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try


    End Sub


    Public Function sendPayment(ByVal outgoing As String, ByVal lasthop As String, ByVal feelimit As String, ByVal payreq As String) As ArrayList

        Dim res As String = ""
        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim method As String = "POST"
        Dim path As String = "v2/router/send"
        Dim timeout As Integer = CType(Form1.timeout, Int32)
        Dim expire As String = Form1.timeout
        Dim lasthop_byte(lasthop.Length / 2 - 1) As Byte
        Dim x As Int16 = 0
        Dim resArray As ArrayList = New ArrayList

        lasthop_byte = convertToByte(lasthop)

        Dim arrayString(0) As String
        arrayString(0) = outgoing

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        'Dim tmpBytes As Byte() = Convert.FromBase64String()

        parameters.Add("payment_request", payreq)
        parameters.Add("timeout_seconds", timeout) '1hour
        parameters.Add("fee_limit_sat", feelimit)
        parameters.Add("outgoing_chan_ids", arrayString)
        parameters.Add("last_hop_pubkey", lasthop_byte)
        parameters.Add("allow_self_payment", True)
        parameters.Add("no_inflight_updates", True)

        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromSeconds(timeout)
                                 Try
                                     Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                     Dim response_json As String = Await (message.Content.ReadAsStringAsync())
                                     Dim rs As New StringReader(response_json)
                                     Dim tmpData As String = rs.ReadLine

                                     Do While tmpData <> Nothing
                                         resArray.Add(tmpData)
                                         tmpData = rs.ReadLine
                                     Loop
                                 Catch e As TaskCanceledException
                                     Form1.tmpResult = Form1.dt + ": Error timeout LND(send invoice)" + vbCrLf
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(send invoice)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return resArray

    End Function

    Public Function sendRoute(ByVal route As Object, ByVal feelimit As String, ByVal payhash As String) As String

        Dim res As String = "FAILED"
        Dim endpointUri As Uri = New Uri(Form1.uri_path)
        Dim macaroon_path As String = Form1.macaroon_path
        Dim method As String = "POST"
        Dim path As String = "v2/router/route/send"
        Dim timeout As Integer = CType(Form1.timeout, Int32)
        Dim x As Int16 = 0
        Dim payhash_byte(payhash.Length / 2 - 1) As Byte

        payhash_byte = convertToByte(payhash)

        Dim parameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        'Dim tmpBytes As Byte() = Convert.FromBase64String()

        parameters.Add("payment_hash", payhash_byte)
        parameters.Add("route", route)

        Dim body As String = JsonConvert.SerializeObject(parameters, Formatting.Indented)

        generateMacaroon()

        Dim request As HttpRequestMessage = New HttpRequestMessage(New HttpMethod(method), path)
        Dim content As StringContent = New StringContent(body)

        content.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        request.Headers.Add("Grpc-Metadata-macaroon", macaroon_metadata)
        request.Content = content
        'request.Timeout

        Dim task1 = Task.Run(Async Function()
                                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                                 Dim client As HttpClient = New HttpClient()

                                 client.BaseAddress = endpointUri
                                 client.Timeout = TimeSpan.FromSeconds(timeout)
                                 Try
                                     Dim message As HttpResponseMessage = Await (client.SendAsync(request))
                                     Dim response_json As String = Await (message.Content.ReadAsStringAsync())

                                     res = response_json

                                 Catch e As TaskCanceledException
                                     res = "FAILED"
                                     Form1.tmpResult = Form1.dt + ": Error timeout LND(send route)" + vbCrLf
                                 End Try

                             End Function)

        Try
            task1.Wait()
        Catch ex As Exception
            Form1.tmpResult = Form1.dt + ": Error connect LND(send route)" + vbCrLf
            Form1.tmpResult += vbTab + "Please check config setting!!" + vbCrLf
            'MessageBox.Show("Please check config setting!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.Beep()
        End Try

        Return res

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

    Private Function convertToBase64string(ByVal tmpString As String) As String

        Dim tmpString_base64 As String
        Dim tmpString_byte(tmpString.Length / 2 - 1) As Byte
        Dim x As Int16 = 0

        tmpString_byte = convertToByte(tmpString)
        tmpString_base64 = Convert.ToBase64String(tmpString_byte).Replace("/", "_").Replace("+", "-").Replace("=", "")

        Return tmpString_base64

    End Function

    Private Function convertToByte(ByVal tmpString As String) As Byte()

        Dim tmpString_byte(tmpString.Length / 2 - 1) As Byte
        Dim x As Int16 = 0

        For i = 0 To tmpString.Length - 1 Step 2
            Dim w As String = tmpString.Substring(i, 2)
            tmpString_byte(x) = Convert.ToByte(w, 16)
            x += 1
        Next

        Return tmpString_byte

    End Function

End Class