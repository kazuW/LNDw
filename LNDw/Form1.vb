Imports System.ComponentModel
Imports System.Text
Imports System.Text.Json.Nodes
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Public Shared uri_path As String
    Public Shared macaroon_path As String = ""
    Public Shared dt As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
    Public Shared timeout As String
    Public Shared pubkey As String

    Public Shared FeeSetting1(9) As Single
    Public Shared FeeSetting2(9) As Single

    Public Shared AllChannels As ArrayList = New ArrayList
    Public Shared AllChannels_cash As ArrayList = New ArrayList
    Public Shared checkAllChannels As ArrayList = New ArrayList
    Private lnd_restApi As New lnd_restApi

    Public Shared AutoFeeSet_ChannelsCollection As ArrayList = New ArrayList
    Public Shared Outgoing_ChannelsCollection As ArrayList = New ArrayList
    Public Shared Lasthop_ChannelsCollection As ArrayList = New ArrayList
    Public Shared Ignore_ChannelsCollection As ArrayList = New ArrayList

    Public Shared tmpResult As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox_dir.Items.Clear()
        ComboBox_dir.Items.Add("outgoing")
        ComboBox_dir.Items.Add("lasthop")
        ComboBox_dir.Items.Add("both")
        ComboBox_dir.Items.Add("none")

        ComboBox_feeAC.Items.Clear()
        ComboBox_feeAC.Items.Add("0")
        ComboBox_feeAC.Items.Add("1")
        ComboBox_feeAC.Items.Add("2")

        'List_view Main setting

        'setting
        TextBox_uri.Text = "https://localhost:8080"
        TextBox_macaroon.Text = "C:\Users\quick\AppData\Local\Lnd\data\chain\bitcoin\mainnet\"

        uri_path = TextBox_uri.Text
        macaroon_path = TextBox_macaroon.Text

        For i = 0 To 9
            FeeSetting1(i) = 1
            FeeSetting2(i) = 1
            Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString).Text = "1"
            Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString).Text = "1"
        Next

        TextBox_basefee.Text = "1000"
        TextBox_timelock.Text = "40"
        TextBox_amount_reb.Text = "100000"
        TextBox_feelimit_reb.Text = "50"
        TextBox_interval_reb.Text = "10"
        TextBox_repeat_reb.Text = "10"
        TextBox_repeatRoute.Text = "100"
        TextBox_timeout_reb.Text = "3600" '1 hour

        TextBox_log.Text += dt + ": Start LNDw" + vbCrLf

        timeout = TextBox_timeout_reb.Text

        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True

        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True

    End Sub

    Private Sub UpdateNodeInfo()

        Dim MyNode As node_info = lnd_restApi.getInfo()

        ListView_main.Items(0).SubItems.Add(MyNode.AliasName)

        ListView_main.Items(2).SubItems.Add(MyNode.NumActiveChannel.ToString)
        ListView_main.Items(3).SubItems.Add(MyNode.NumInactiveChannel.ToString)
        ListView_main.Items(4).SubItems.Add(MyNode.NumPendingChannel.ToString)

        ListView_main.Items(9).SubItems.Add(MyNode.Chain + "-" + MyNode.Network)

        Label_version.Text = "version ; " + MyNode.LndVersion
        TextBox_pubkey.Text = MyNode.PubKey

        Dim wallet_balance As UInt64 = lnd_restApi.walletBalance()
        Dim lightning_balance As UInt64 = lnd_restApi.lightningBalance()

        ListView_main.Items(6).SubItems.Add(wallet_balance.ToString)
        ListView_main.Items(7).SubItems.Add(lightning_balance.ToString)


        TextBox_log.Text += dt + ": Done nodeinfo updeate!" + vbCrLf


    End Sub

    Private Sub Button_updateChannel_Click(sender As Object, e As EventArgs) Handles Button_updateChannel.Click

        Dim resDialog As DialogResult = MessageBox.Show("Just a minutes...", "Update channels", MessageBoxButtons.OKCancel)

        If resDialog = DialogResult.Cancel Then
            Exit Sub
        End If


        UpdateNodeInfo()
        AllChannels = lnd_restApi.getAllCannels()

        ListView_cannels.Items.Clear()

        For i = 0 To AllChannels.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels(i)
            tmpChannel.AliasName = lnd_restApi.getNodeInfo(tmpChannel.PubKey)
            Dim tmpFeeData() As String = lnd_restApi.getChannelInfo(tmpChannel.PubKey, tmpChannel.ChanID)

            tmpChannel.RemoteFeeBase = tmpFeeData(0)
            tmpChannel.RemoteFeeRate = tmpFeeData(1)
            tmpChannel.RemoteTimelock = tmpFeeData(2)
            tmpChannel.LocalFeeBase = tmpFeeData(3)
            tmpChannel.LocalFeeRate = tmpFeeData(4)
            tmpChannel.LocalTimelock = tmpFeeData(5)

            tmpChannel.LocalCapRate = CType(tmpChannel.LocalBalance, Single) / CType(tmpChannel.Capacity, Single) * 100
            tmpChannel.ChanDirection = ""
            tmpChannel.LocalCapRateTarget = {50, 50}
            tmpChannel.BaseFeeRate = 500
            tmpChannel.AutoFeeCont = 0


            AllChannels(i) = tmpChannel

        Next

        AllChannels.Sort()
        AllChannels_cash = AllChannels

        TextBox_log.Text += dt + ": Initial all channels updeate!" + vbCrLf

        updateAllChannels()

    End Sub

    Private Sub updateAllChannels()

        ListView_cannels.Items.Clear()

        For i = 0 To AllChannels_cash.Count - 1
            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels(i)

            Dim item_channel() As String = {tmpChannel.AliasName, tmpChannel.LocalCapRate.ToString(0) _
                , tmpChannel.LocalFeeRate, tmpChannel.RemoteFeeRate, tmpChannel.ChanDirection _
                , tmpChannel.LocalCapRateTarget(0).ToString(0) + "," + tmpChannel.LocalCapRateTarget(1).ToString(0) _
                , tmpChannel.BaseFeeRate.ToString(0), tmpChannel.AutoFeeCont.ToString}

            ListView_cannels.Items.Add(New ListViewItem(item_channel))
        Next

        TextBox_log.Text += dt + ": Done all channels updeate!" + vbCrLf


    End Sub

    Private Sub updateAllChannels1()

        ListView_cannels.Items.Clear()

        For i = 0 To AllChannels_cash.Count - 1
            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels(i)

            Dim item_channel() As String = {tmpChannel.AliasName, tmpChannel.LocalCapRate.ToString(0) _
                , tmpChannel.LocalFeeRate, tmpChannel.RemoteFeeRate, tmpChannel.ChanDirection _
                , tmpChannel.LocalCapRateTarget(0).ToString(0) + "," + tmpChannel.LocalCapRateTarget(1).ToString(0) _
                , tmpChannel.BaseFeeRate.ToString(0), tmpChannel.AutoFeeCont.ToString}

            ListView_cannels.Items.Add(New ListViewItem(item_channel))
        Next

        'TextBox_log.Text += dt + ": Done all channels updeate!" + vbCrLf


    End Sub

    Private Sub Listview_channels_ItemActivation(ByVal sender As Object, ByVal e As EventArgs) Handles ListView_cannels.ItemActivate

        Dim tmpItem As ListViewItem = ListView_cannels.SelectedItems(0)

        If tmpItem.SubItems(4).Text = "outgoing" Then
            ComboBox_dir.SelectedIndex = 0
        ElseIf tmpItem.SubItems(4).Text = "lasthop" Then
            ComboBox_dir.SelectedIndex = 1
        ElseIf tmpItem.SubItems(4).Text = "both" Then
            ComboBox_dir.SelectedIndex = 2
        Else
            ComboBox_dir.SelectedIndex = 3
        End If

        If tmpItem.SubItems(7).Text = "0" Then
            ComboBox_feeAC.SelectedIndex = 0
        ElseIf tmpItem.SubItems(7).Text = "1" Then
            ComboBox_feeAC.SelectedIndex = 1
        ElseIf tmpItem.SubItems(7).Text = "2" Then
            ComboBox_feeAC.SelectedIndex = 2
        Else
            ComboBox_feeAC.SelectedIndex = 0
        End If

        TextBox_target1.Text = tmpItem.SubItems(5).Text
        TextBox_basefee1.Text = tmpItem.SubItems(6).Text


    End Sub

    Private Sub Button_changePara_Click(sender As Object, e As EventArgs) Handles Button_changePara.Click

        Dim numIndex As Integer = ListView_cannels.SelectedItems(0).Index

        ListView_cannels.Items(numIndex).SubItems(4).Text = ComboBox_dir.SelectedItem.ToString
        ListView_cannels.Items(numIndex).SubItems(5).Text = TextBox_target1.Text
        ListView_cannels.Items(numIndex).SubItems(6).Text = TextBox_basefee1.Text
        ListView_cannels.Items(numIndex).SubItems(7).Text = ComboBox_feeAC.SelectedItem.ToString

        Dim tmpChannel As channel = AllChannels_cash(numIndex)
        tmpChannel.ChanDirection = ComboBox_dir.SelectedItem.ToString
        tmpChannel.BaseFeeRate = CType(TextBox_basefee1.Text, Single)
        tmpChannel.AutoFeeCont = CType(ComboBox_feeAC.SelectedItem.ToString, Integer)

        Dim str As String() = TextBox_target1.Text.Split(",")
        tmpChannel.LocalCapRateTarget(0) = str(0)
        tmpChannel.LocalCapRateTarget(1) = str(1)

        TextBox_log.Text += dt + ": node configration change [" + ListView_cannels.Items(numIndex).SubItems(0).Text + "]" + vbCrLf


    End Sub

    Private Sub NodeConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NodeConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String
        Dim Fs As IO.StreamReader
        Dim tmpData As String
        Dim strData() As String

        Ret = OpenFileDialog1.ShowDialog()

        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = IO.Path.GetFullPath(OpenFileDialog1.FileName)

        Fs = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        tmpData = Fs.ReadLine

        Do While tmpData <> Nothing

            strData = tmpData.Split(",")

            Select Case strData(0)
                Case "uri_path"
                    TextBox_uri.Text = strData(1)
                Case "macaroon_path"
                    TextBox_macaroon.Text = strData(1)
                Case "control_fee1"
                    For i = 0 To 9
                        Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString).Text = strData(i + 1)
                    Next
                Case "control_fee2"
                    For i = 0 To 9
                        Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString).Text = strData(i + 1)
                    Next
            End Select

            tmpData = Fs.ReadLine

        Loop

        TextBox_log.Text += dt + ": read configration file [" + FileName + "]" + vbCrLf

    End Sub

    Private Sub BaseFeeRateConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaseFeeRateConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String
        Dim Fs As IO.StreamReader
        Dim tmpData As String
        Dim strData() As String

        Ret = OpenFileDialog1.ShowDialog()

        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = IO.Path.GetFullPath(OpenFileDialog1.FileName)

        Fs = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        tmpData = Fs.ReadLine

        Do While tmpData <> Nothing

            strData = tmpData.Split(",")
            Dim tmpChanID As String = strData(1).Replace(" ", "")

            For i = 0 To AllChannels_cash.Count - 1

                Dim tmpChannel As channel = New channel
                tmpChannel = AllChannels_cash(i)

                If tmpChannel.ChanID = tmpChanID Then
                    tmpChannel.BaseFeeRate = CType(strData(3), Single)
                    tmpChannel.AutoFeeCont = CType(strData(4), Integer)
                    AllChannels_cash(i) = tmpChannel

                    Continue For
                End If

            Next

            tmpData = Fs.ReadLine

        Loop

        TextBox_log.Text += dt + ": read fee rate setting file [" + FileName + "]" + vbCrLf

        updateAllChannels()

    End Sub

    Private Sub Button_startRebalance_Click(sender As Object, e As EventArgs) Handles Button_startRebalance.Click

        If CheckBox_autoRebalance.Checked = False Then

            startRebalance()

        Else

        End If


    End Sub

    Private Sub LasthopChannelsCollection()

        Lasthop_ChannelsCollection.Clear()

        For i = 0 To AllChannels_cash.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels_cash(i)

            If (tmpChannel.ChanDirection = "lasthop" Or tmpChannel.ChanDirection = "both") And
                (tmpChannel.LocalCapRate < tmpChannel.LocalCapRateTarget(1)) Then
                Lasthop_ChannelsCollection.Add(tmpChannel)
            End If
        Next

    End Sub

    Private Sub OutgoingChannelsCollection()

        Outgoing_ChannelsCollection.Clear()

        For i = 0 To AllChannels_cash.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels_cash(i)

            If (tmpChannel.ChanDirection = "outgoing" Or tmpChannel.ChanDirection = "both") And
                (tmpChannel.LocalCapRate > tmpChannel.LocalCapRateTarget(0)) Then
                Outgoing_ChannelsCollection.Add(tmpChannel)
            End If
        Next

    End Sub

    Private Sub startRebalance()


        If Not CheckBox_useQuery.Checked Then

            pubkey = TextBox_pubkey.Text
            timeout = TextBox_timeout_reb.Text
            freezeButton()
            TextBox_log.Text += dt + ": rebalance start(lncli version)!!" + vbCrLf
            BackgroundWorker1.RunWorkerAsync()

        ElseIf CheckBox_useQuery.Checked Then

            pubkey = TextBox_pubkey.Text
            timeout = TextBox_timeout_reb.Text
            freezeButton()
            TextBox_log.Text += dt + ": rebalance start(query version)!!" + vbCrLf
            BackgroundWorker2.RunWorkerAsync()

        Else

        End If


    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim bgWorker As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim rebalance_amount As String = TextBox_amount_reb.Text
        Dim rebalance_fee_limit As String = TextBox_feelimit_reb.Text
        Dim repeatNum As Integer = CType(TextBox_repeat_reb.Text, Integer)
        Dim repeatRoute As Integer = CType(TextBox_repeatRoute.Text, Integer)
        Dim interval As Integer = CType(TextBox_interval_reb.Text, Integer)
        Dim i As Integer

reStartRebalance_query:
        Dim res As String = "FAILED"
        Dim tmpres As String = ""
        Dim route As String
        Dim route_v2 As String
        Dim route1 As Object
        Dim progressNum As Integer = 0

        OutgoingChannelsCollection()
        LasthopChannelsCollection()

        For lasthop_num = 0 To Lasthop_ChannelsCollection.Count - 1
            For outgoing_num = 0 To Outgoing_ChannelsCollection.Count - 1

                progressNum += 1

                Dim tmpChannel_outgoing As channel = New channel
                Dim tmpChannel_lashop As channel = New channel
                tmpChannel_lashop = Lasthop_ChannelsCollection(lasthop_num)
                tmpChannel_outgoing = Outgoing_ChannelsCollection(outgoing_num)

                If CType(rebalance_fee_limit, Int32) > CType(rebalance_amount, Int32) / 1000000 * CType(tmpChannel_lashop.RemoteFeeRate, Int32) And Not CheckBox_reckless.Checked Then
                    rebalance_fee_limit = (CType(rebalance_amount, Int32) / 1000000 * CType(tmpChannel_lashop.RemoteFeeRate, Int32)).ToString
                End If

                Dim memo As String = "Rebalance(use query) " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName
                Dim Payment_req As String = ""
                Dim Payment_hash As String = ""

                addinvoice(rebalance_amount, memo, Payment_req, Payment_hash)

                Ignore_ChannelsCollection.Clear()

                i = 0

                While i <= repeatRoute

                    route = lnd_restApi.getQueryRoute(tmpChannel_outgoing.ChanID, tmpChannel_lashop.PubKey, rebalance_amount, rebalance_fee_limit, Ignore_ChannelsCollection)

                    Try
                        Dim JsonObject As Object = JsonConvert.DeserializeObject(route)
                        route1 = JsonObject("routes")(0)
                    Catch ex As Exception
                        Exit While
                    End Try

                    For j = 0 To repeatNum
                        res = payRoute(route1, rebalance_fee_limit, Payment_hash)

                        If res = "SUCCEEDED" Then
                            tmpres = res
                            tmpResult = "*** Rebalancing(query) " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName + " " + res + vbCrLf

                            If j = repeatNum Then
                                Exit While
                            Else
                                addinvoice(rebalance_amount, memo, Payment_req, Payment_hash)
                            End If
                        Else
                            If tmpres = "SUCCEEDED" Then
                                tmpResult = "*** Rebalancing(query) " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName + " " + res + vbCrLf
                                Exit While
                            Else
                                Exit For
                            End If
                        End If

                    Next

                    Dim hops As Object = route1("hops")
                    Dim minChanCap As Int64 = 100000000
                    Dim ignorePubkey As String = ""
                    Dim hop0 As Object
                    Dim checkPubkey As Boolean

                    If hops.Count <= 3 Then
                        Exit While
                    End If

                    For k = 1 To hops.Count - 3
                        hop0 = hops(k)
                        If minChanCap > CType(hop0("chan_capacity"), Int64) Then
                            minChanCap = CType(hop0("chan_capacity"), Int64)
                            ignorePubkey = CType(hop0("pub_key"), String)
                        End If
                    Next

                    checkPubkey = IsSamePubkey(ignorePubkey)
                    If Not checkPubkey Then
                        Ignore_ChannelsCollection.Add(ignorePubkey)
                    End If

                    i += 1

                    'If i = 99 Then
                    '    Console.ReadLine()
                    'End If

                End While

                If Not tmpres = "SUCCEEDED" Then
                    tmpResult = "*** Rebalancing(query) " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName + " " + res + vbCrLf
                End If

                tmpres = ""

                If Not res = "SUCCEEDED" Then
                    lnd_restApi.cancelInvoice(Payment_hash)
                End If

                bgWorker.ReportProgress(progressNum)

                If bgWorker.CancellationPending = True Then
                    e.Cancel = True
                    Exit Sub
                End If

            Next

            If CheckBox_autoFeeCont.Checked Then

                autoFeeChannelsCollection()
                autoFeeUpdate(0)
                updateAllChannels1()

                tmpResult = dt + ": Done auto fee setting!" + vbCrLf
                bgWorker.ReportProgress(progressNum)

            End If

        Next

        If CheckBox_autoRebalance.Checked Then
            GoTo reStartRebalance_query
        End If


    End Sub
    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged

        TextBox_log.Text += tmpResult

    End Sub

    Private Sub BackgroundWorker2_Completed(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted

        If e.Cancelled = True Then
            activeButton()
            TextBox_log.Text += dt + ": Rebalance(query) done." + vbCrLf
        Else
            TextBox_log.Text += dt + ": Rebalance(query) done error." + vbCrLf
            activeButton()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim bgWorker As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim rebalance_amount As String = TextBox_amount_reb.Text
        Dim rebalance_fee_limit As String = TextBox_feelimit_reb.Text
        Dim repeatNum As Integer = CType(TextBox_repeat_reb.Text, Integer)
        Dim repeatRoute As Integer = CType(TextBox_repeatRoute.Text, Integer)
        Dim interval As Integer = CType(TextBox_interval_reb.Text, Integer)

reStartRebalance:
        Dim i As Integer = 0
        Dim res As String = "FAILED"
        Dim tmpres As String = ""
        Dim progressNum As Integer = 0

        OutgoingChannelsCollection()
        LasthopChannelsCollection()

        For lasthop_num = 0 To Lasthop_ChannelsCollection.Count - 1
            For outgoing_num = 0 To Outgoing_ChannelsCollection.Count - 1

                progressNum += 1

                Dim tmpChannel_outgoing As channel = New channel
                Dim tmpChannel_lashop As channel = New channel
                tmpChannel_lashop = Lasthop_ChannelsCollection(lasthop_num)
                tmpChannel_outgoing = Outgoing_ChannelsCollection(outgoing_num)

                If CType(rebalance_fee_limit, Int32) > CType(rebalance_amount, Int32) / 1000000 * CType(tmpChannel_lashop.RemoteFeeRate, Int32) And Not CheckBox_reckless.Checked Then
                    rebalance_fee_limit = (CType(rebalance_amount, Int32) / 1000000 * CType(tmpChannel_lashop.RemoteFeeRate, Int32)).ToString
                End If

                Dim memo As String = "Rebalance " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName
                Dim Payment_req As String = ""
                Dim Payment_hash As String = ""

                addinvoice(rebalance_amount, memo, Payment_req, Payment_hash)

                i = 0
repPayInvoice:
                res = payinvoice(tmpChannel_outgoing.ChanID, tmpChannel_lashop.PubKey, rebalance_fee_limit, Payment_req)

                If res = "SUCCEEDED" And i <= repeatNum Then
                    tmpres = "SUCCEEDED"
                    addinvoice(rebalance_amount, memo, Payment_req, Payment_hash)
                    i += 1
                    GoTo repPayInvoice
                End If

                tmpResult = "*** Rebalancing " + tmpChannel_outgoing.AliasName + " to " + tmpChannel_lashop.AliasName + " " + tmpres + vbCrLf
                bgWorker.ReportProgress(progressNum)

                If bgWorker.CancellationPending = True Then
                    e.Cancel = True
                    Exit Sub
                End If

                tmpres = "FAILED"

            Next

            If CheckBox_autoFeeCont.Checked Then

                autoFeeChannelsCollection()
                autoFeeUpdate(0)
                updateAllChannels1()

                tmpResult = dt + ": Done auto fee setting!" + vbCrLf
                bgWorker.ReportProgress(progressNum)

            End If

        Next

        If CheckBox_autoRebalance.Checked Then
            GoTo reStartRebalance
        End If


    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        TextBox_log.Text += tmpResult

    End Sub

    Private Sub BackgroundWorker1_Completed(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If e.Cancelled = True Then
            activeButton()
            TextBox_log.Text += dt + ": Rebalance canceled." + vbCrLf
        Else
            TextBox_log.Text += dt + ": Rebalance canceled error." + vbCrLf
            activeButton()
        End If

    End Sub
    Private Sub freezeButton()

        Button_updateChannel.Enabled = False
        Button_changePara.Enabled = False
        Button_autoFeeUpdate.Enabled = False
        Button_startRebalance.Enabled = False
        TextBox_amount_reb.ReadOnly = True
        TextBox_feelimit_reb.ReadOnly = True
        TextBox_interval_reb.ReadOnly = True
        TextBox_repeat_reb.ReadOnly = True
        TextBox_timeout_reb.ReadOnly = True
        TextBox_repeatRoute.ReadOnly = True
        CheckBox_autoFeeCont.AutoCheck = False
        CheckBox_autoRebalance.AutoCheck = False
        CheckBox_reckless.AutoCheck = False
        CheckBox_useQuery.AutoCheck = False
        TextBox_uri.ReadOnly = True
        TextBox_macaroon.ReadOnly = True

        Button_setMC.Enabled = False
        Button_mcReset.Enabled = False

    End Sub

    Private Sub activeButton()

        Button_updateChannel.Enabled = True
        Button_changePara.Enabled = True
        Button_autoFeeUpdate.Enabled = True
        Button_startRebalance.Enabled = True
        TextBox_amount_reb.ReadOnly = False
        TextBox_feelimit_reb.ReadOnly = False
        TextBox_interval_reb.ReadOnly = False
        TextBox_repeat_reb.ReadOnly = False
        TextBox_timeout_reb.ReadOnly = False
        TextBox_repeatRoute.ReadOnly = False
        CheckBox_autoFeeCont.AutoCheck = True
        CheckBox_autoRebalance.AutoCheck = True
        CheckBox_reckless.AutoCheck = True
        CheckBox_useQuery.AutoCheck = True
        TextBox_uri.ReadOnly = False
        TextBox_macaroon.ReadOnly = False

        Button_setMC.Enabled = True
        Button_mcReset.Enabled = True

    End Sub


    Private Function IsSamePubkey(ByVal pubkey As String) As Boolean

        For i = 0 To Ignore_ChannelsCollection.Count - 1
            Dim tmpPubkey As String = Ignore_ChannelsCollection(i)

            If tmpPubkey = pubkey Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Sub rebalanceExcute()

    End Sub

    Private Sub addinvoice(ByVal amount As String, ByVal memo As String, ByRef Payment_req As String, ByRef Payment_hash As String)

        'add invoice, expire=3600(1hour)
        Payment_req = lnd_restApi.postInvoice(amount, memo)
        Payment_hash = lnd_restApi.getPaymentHash(Payment_req)

    End Sub

    Private Function payRoute(ByVal route As Object, ByVal feelimit As String, ByVal payhash As String) As String

        Dim response As ArrayList = New ArrayList
        Dim Fw As IO.StreamWriter
        Dim FileName As String = "LNDw(query)_result"
        Dim resString As String = ""
        Dim res As String = ""

        Fw = New IO.StreamWriter((".\" + FileName + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"), False, Encoding.Default)

        resString = lnd_restApi.sendRoute(route, feelimit, payhash)

        Fw.WriteLine(route.ToString)
        Fw.WriteLine(resString)

        Try
            Dim JsonObject As Object = JsonConvert.DeserializeObject(resString)
            res = CType(JsonObject("status"), String)
        Catch ex As Exception
            res = "JsonConvertError"
        End Try

        Fw.Close()

        Return res

    End Function

    Private Function payinvoice(ByVal outgoing As String, ByVal lasthop As String, ByVal feelimit As String, ByVal payreq As String) As String

        Dim response As ArrayList = New ArrayList
        Dim Fw As IO.StreamWriter
        Dim FileName As String = "LNDw_result"
        Dim res As String = ""

        Fw = New IO.StreamWriter((".\" + FileName + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"), False, Encoding.Default)

        response = lnd_restApi.sendPayment(outgoing, lasthop, feelimit, payreq)

        For Each resString As String In response

            Fw.WriteLine(resString)

            Try
                Dim JsonObject As Object = JsonConvert.DeserializeObject(resString)
                res = CType(JsonObject("result")("status"), String)
            Catch ex As Exception
                res = "JsonConvertError"
            End Try

            If res = "SUCCEEDED" Or res = "JsonConvertError" Then
                Exit For
            End If


        Next

        Fw.Close()

        Return res

    End Function

    Private Sub Button_autoFeeUpdate_Click(sender As Object, e As EventArgs) Handles Button_autoFeeUpdate.Click

        Dim resDialog As DialogResult = MessageBox.Show("Just a minutes...", "Set channels fee", MessageBoxButtons.OKCancel)

        If resDialog = DialogResult.Cancel Then
            Exit Sub
        End If

        autoFeeChannelsCollection()
        autoFeeUpdate(1)

        TextBox_log.Text += dt + ": Done auto fee setting!" + vbCrLf

        updateAllChannels()

    End Sub

    Private Sub autoFeeChannelsCollection()

        AutoFeeSet_ChannelsCollection.Clear()

        For i = 0 To AllChannels_cash.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels_cash(i)

            If tmpChannel.AutoFeeCont > 0 Then
                AutoFeeSet_ChannelsCollection.Add(tmpChannel)
            End If
        Next

    End Sub

    Private Sub autoFeeUpdate(ByVal buttonClick As Boolean)

        Dim fee As Single
        Dim HTLC_max As Single
        Dim BaseFee As String = TextBox_basefee.Text
        Dim TimeLock As String = TextBox_timelock.Text
        Dim feeSetting As Single()
        Dim check_localBalance As Boolean = False

        For i = 0 To 9
            FeeSetting1(i) = CType(Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString).Text, Single)
            FeeSetting2(i) = CType(Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString).Text, Single)
        Next

        If buttonClick = False Then
            checkAllChannels.Clear()
            checkAllChannels = lnd_restApi.getAllCannels() 'temporary update channel info
        End If

        For i = 0 To AutoFeeSet_ChannelsCollection.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AutoFeeSet_ChannelsCollection(i)

            If buttonClick = False Then
                check_localBalance = checkLocalBalance(i)

                If check_localBalance = False Then
                    Continue For
                End If
            End If

            If tmpChannel.AutoFeeCont = 1 Then
                feeSetting = FeeSetting1
            Else
                feeSetting = FeeSetting2
            End If

            Select Case tmpChannel.LocalCapRate

                Case Is <= 10
                    fee = tmpChannel.BaseFeeRate / feeSetting(0)
                    HTLC_max = tmpChannel.LocalBalance / 2
                Case 10 To 20
                    fee = tmpChannel.BaseFeeRate / feeSetting(1)
                    HTLC_max = tmpChannel.LocalBalance / 2
                Case 20 To 30
                    fee = tmpChannel.BaseFeeRate / feeSetting(2)
                    HTLC_max = tmpChannel.LocalBalance / 2
                Case 30 To 40
                    fee = tmpChannel.BaseFeeRate / feeSetting(3)
                    HTLC_max = tmpChannel.LocalBalance / 2
                Case 40 To 50
                    fee = tmpChannel.BaseFeeRate / feeSetting(4)
                    HTLC_max = tmpChannel.LocalBalance / 2
                Case 50 To 60
                    fee = tmpChannel.BaseFeeRate / feeSetting(5)
                    HTLC_max = tmpChannel.LocalBalance / 3
                Case 60 To 70
                    fee = tmpChannel.BaseFeeRate / feeSetting(6)
                    HTLC_max = tmpChannel.LocalBalance / 3
                Case 70 To 80
                    fee = tmpChannel.BaseFeeRate / feeSetting(7)
                    HTLC_max = tmpChannel.LocalBalance / 3
                Case 80 To 90
                    fee = tmpChannel.BaseFeeRate / feeSetting(8)
                    HTLC_max = tmpChannel.LocalBalance / 3
                Case Else
                    fee = tmpChannel.BaseFeeRate / feeSetting(9)
                    HTLC_max = tmpChannel.LocalBalance / 3

            End Select

            Dim setFeeRate As String = fee.ToString("0")
            Dim setHTLCs As String = HTLC_max.ToString(0) + "000"

            Dim res As String = lnd_restApi.postChannelPolicy(tmpChannel.ChanPointID, BaseFee, setFeeRate, setHTLCs, TimeLock)

            tmpChannel.LocalFeeRate = setFeeRate
            tmpChannel.LocalCapRate = CType(tmpChannel.LocalBalance, Single) / CType(tmpChannel.Capacity, Single) * 100

        Next

        For i = 0 To AutoFeeSet_ChannelsCollection.Count - 1
            Dim tmpChannel As channel = New channel
            tmpChannel = AutoFeeSet_ChannelsCollection(i)

            For j = 0 To AllChannels_cash.Count - 1
                Dim tmpChannel1 As channel = New channel
                tmpChannel1 = AllChannels_cash(j)

                If tmpChannel1.ChanID = tmpChannel.ChanID Then
                    AllChannels_cash(j) = tmpChannel
                    Exit For
                End If
            Next
        Next

    End Sub

    Private Function checkLocalBalance(ByVal i As Integer) As Boolean

        Dim res As Boolean
        Dim chkChannel As channel = New channel
        chkChannel = AutoFeeSet_ChannelsCollection(i)

        For j = 0 To checkAllChannels.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = checkAllChannels(j)

            If tmpChannel.ChanID = chkChannel.ChanID Then
                If (Not tmpChannel.LocalBalance = chkChannel.LocalBalance) And chkChannel.Active Then

                    tmpChannel.LocalBalance = chkChannel.LocalBalance
                    tmpChannel.RemoteBalance = chkChannel.RemoteBalance
                    AutoFeeSet_ChannelsCollection(i) = tmpChannel
                    res = True
                    GoTo end_checkLocalBalance
                Else
                    res = False
                    GoTo end_checkLocalBalance
                End If

            End If

        Next

end_checkLocalBalance:

        res = False

        Return res

    End Function

    Private Sub RebalanceNodeConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebalanceNodeConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String
        Dim Fs As IO.StreamReader
        Dim tmpData As String
        Dim strData() As String
        Dim strData1() As String

        Ret = OpenFileDialog1.ShowDialog()

        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = IO.Path.GetFullPath(OpenFileDialog1.FileName)

        Fs = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        tmpData = Fs.ReadLine

        Do While tmpData <> Nothing

            strData = tmpData.Split(",")
            Dim tmpChanID As String = strData(1).Replace(" ", "")
            strData1 = strData(4).Split("-")

            For i = 0 To AllChannels_cash.Count - 1

                Dim tmpChannel As channel = New channel
                tmpChannel = AllChannels_cash(i)

                If tmpChannel.ChanID = tmpChanID Then
                    tmpChannel.ChanDirection = CType(strData(3), String)
                    tmpChannel.LocalCapRateTarget(0) = CType(strData1(0), Integer)
                    tmpChannel.LocalCapRateTarget(1) = CType(strData1(1), Integer)
                    AllChannels_cash(i) = tmpChannel

                    Continue For
                End If

            Next

            tmpData = Fs.ReadLine

        Loop

        TextBox_log.Text += dt + ": read rebalance setting file [" + FileName + "]" + vbCrLf

        updateAllChannels()

    End Sub

    Private Sub Button_PayResultRead_Click(sender As Object, e As EventArgs) Handles Button_PayResultRead.Click

        Dim Ret As DialogResult
        Dim FileName As String
        Dim Fs As IO.StreamReader
        Dim tmpData As String
        'Dim strData() As String

        Ret = OpenFileDialog1.ShowDialog()

        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = IO.Path.GetFullPath(OpenFileDialog1.FileName)

        Fs = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        tmpData = Fs.ReadLine

        Do While tmpData <> Nothing

            Dim JsonObject As Object = JsonConvert.DeserializeObject(tmpData)
            'Dim JsonObject_res As Object = JsonObject("")

            tmpData = Fs.ReadLine

        Loop



    End Sub

    Private Sub Button_cancel_Click(sender As Object, e As EventArgs) Handles Button_cancel.Click

        BackgroundWorker1.CancelAsync()
        BackgroundWorker2.CancelAsync()

    End Sub

    Private Sub Button_getMC_Click(sender As Object, e As EventArgs) Handles Button_getMC.Click

        Dim mcCfg As mc_cfg = lnd_restApi.getMcCfg()

        TextBox_mcHLS.Text = mcCfg.HalfLifeSeconds
        TextBox_mcHP.Text = mcCfg.HopProbability.ToString
        TextBox_mcW.Text = mcCfg.Weight.ToString
        TextBox_mcMFR.Text = mcCfg.MinFailRelaxInterval
        TextBox_mcMPR.Text = mcCfg.MaxPaymentResults

    End Sub

    Private Sub Button_setMC_Click(sender As Object, e As EventArgs) Handles Button_setMC.Click

        Dim mcCfg As mc_cfg = New mc_cfg

        mcCfg.HalfLifeSeconds = TextBox_mcHLS.Text
        mcCfg.HopProbability = CType(TextBox_mcHP.Text, Double)
        mcCfg.Weight = CType(TextBox_mcW.Text, Double)
        mcCfg.MinFailRelaxInterval = TextBox_mcMFR.Text
        mcCfg.MaxPaymentResults = CType(TextBox_mcMPR.Text, Int64)

        lnd_restApi.postMcCfg(mcCfg)

    End Sub

    Private Sub SaveNodeConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveNodeConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String = "nodeConf" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        Dim Fw As IO.StreamWriter
        'Dim strData() As String

        SaveFileDialog1.FileName = FileName

        Ret = SaveFileDialog1.ShowDialog()
        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = SaveFileDialog1.FileName
        Fw = New IO.StreamWriter(FileName, False, System.Text.Encoding.Default)

        Fw.WriteLine(TextBox_uri.Text)
        Fw.WriteLine(TextBox_macaroon.Text)

        Dim tmpFeeSet1 As String = "control_fee1"
        Dim tmpFeeSet2 As String = "control_fee2"

        For i = 0 To 9
            tmpFeeSet1 += "," + Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString).Text
            tmpFeeSet2 += "," + Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString).Text
        Next

        Fw.WriteLine(tmpFeeSet1)
        Fw.WriteLine(tmpFeeSet2)

        Fw.Close()

    End Sub

    Private Sub SaveBaseFeeRateConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBaseFeeRateConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String = "FeeRateConf" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        Dim Fw As IO.StreamWriter
        'Dim strData() As String

        SaveFileDialog1.FileName = FileName

        Ret = SaveFileDialog1.ShowDialog()
        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = SaveFileDialog1.FileName
        Fw = New IO.StreamWriter(FileName, False, System.Text.Encoding.Default)

        Fw.WriteLine("remote_pubkey,chan_id,remote_alias,BaseFee,autoFee,active")

        For i = 0 To AllChannels_cash.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels_cash(i)

            Fw.WriteLine(tmpChannel.PubKey + "," + tmpChannel.ChanID + "," + tmpChannel.AliasName _
                         + "," + ListView_cannels.Items(i).SubItems(6).Text + "," + ListView_cannels.Items(i).SubItems(7).Text)

        Next

        Fw.Close()


    End Sub

    Private Sub SaveRebalanceNodeConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveRebalanceNodeConfigFileToolStripMenuItem.Click

        Dim Ret As DialogResult
        Dim FileName As String = "RebalanceConf" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        Dim Fw As IO.StreamWriter
        'Dim strData() As String

        SaveFileDialog1.FileName = FileName

        Ret = SaveFileDialog1.ShowDialog()
        If Ret = DialogResult.Cancel Then
            Exit Sub
        End If

        FileName = SaveFileDialog1.FileName
        Fw = New IO.StreamWriter(FileName, False, System.Text.Encoding.Default)

        Fw.WriteLine("remote_pubkey,chan_id,remote_alias,direction,rebalance")

        For i = 0 To AllChannels_cash.Count - 1

            Dim tmpChannel As channel = New channel
            tmpChannel = AllChannels_cash(i)

            Fw.WriteLine(tmpChannel.PubKey + "," + tmpChannel.ChanID + "," + tmpChannel.AliasName _
                         + "," + ListView_cannels.Items(i).SubItems(4).Text + "," + ListView_cannels.Items(i).SubItems(5).Text)

        Next

        Fw.Close()

    End Sub

End Class
