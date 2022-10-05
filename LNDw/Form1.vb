

Public Class Form1

    Public Shared uri_path As String
    Public Shared macaroon_path As String = ""
    Public Shared dt As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm")

    Public Shared FeeSetting1(9) As Integer
    Public Shared FeeSetting2(9) As Integer

    Public Shared AllChannels As ArrayList = New ArrayList
    Public Shared AllChannels_cash As ArrayList = New ArrayList
    Private lnd_restApi As New lnd_restApi

    Public Shared tmpResult As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox_dir.Items.Clear()
        ComboBox_dir.Items.Add("ongoing")
        ComboBox_dir.Items.Add("lasthop")
        ComboBox_dir.Items.Add("both")
        ComboBox_dir.Items.Add("none")

        'List_view Main setting

        'setting
        TextBox_uri.Text = "https://localhost:8080"
        TextBox_macaroon.Text = "C:\Users\quick\AppData\Local\Lnd\data\chain\bitcoin\mainnet\"

        uri_path = TextBox_uri.Text
        macaroon_path = TextBox_macaroon.Text

        For i = 0 To 9
            FeeSetting1(i) = 1
            FeeSetting2(i) = 1
            CType(Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString), TextBox).Text = "1"
            CType(Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString), TextBox).Text = "1"
        Next

        TextBox_log.Text += dt + ": Start LNDw" + vbCrLf


        Console.ReadLine()

    End Sub

    Private Sub UpdateNodeInfo()

        Dim MyNode As node_info = lnd_restApi.getInfo()

        ListView_main.Items(0).SubItems.Add(MyNode.AliasName)

        ListView_main.Items(2).SubItems.Add(MyNode.NumActiveChannel.ToString)
        ListView_main.Items(3).SubItems.Add(MyNode.NumInactiveChannel.ToString)
        ListView_main.Items(4).SubItems.Add(MyNode.NumPendingChannel.ToString)

        ListView_main.Items(9).SubItems.Add(MyNode.Chain + "-" + MyNode.Network)

        Label_version.Text = "version ; " + MyNode.LndVersion
        TextBox1.Text = MyNode.PubKey

        Dim wallet_balance As UInt64 = lnd_restApi.walletBalance()
        Dim lightning_balance As UInt64 = lnd_restApi.lightningBalance()

        ListView_main.Items(6).SubItems.Add(wallet_balance.ToString)
        ListView_main.Items(7).SubItems.Add(lightning_balance.ToString)


        TextBox_log.Text += dt + ": Done nodeinfo updeate!" + vbCrLf

    End Sub

    Private Sub Button_updateChannel_Click(sender As Object, e As EventArgs) Handles Button_updateChannel.Click

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


    End Sub

    Private Sub Listview_channels_ItemActivation(ByVal sender As Object, ByVal e As EventArgs) Handles ListView_cannels.ItemActivate

        Dim tmpItem As ListViewItem = ListView_cannels.SelectedItems(0)

        If tmpItem.SubItems(4).Text = "ongoing" Then
            ComboBox_dir.SelectedIndex = 0
        ElseIf tmpItem.SubItems(4).Text = "lasthop" Then
            ComboBox_dir.SelectedIndex = 1
        ElseIf tmpItem.SubItems(4).Text = "both" Then
            ComboBox_dir.SelectedIndex = 2
        Else
            ComboBox_dir.SelectedIndex = 3
        End If

        TextBox_target1.Text = tmpItem.SubItems(5).Text
        TextBox_basefee1.Text = tmpItem.SubItems(6).Text
        TextBox_feeac1.Text = tmpItem.SubItems(7).Text


    End Sub

    Private Sub Button_changePara_Click(sender As Object, e As EventArgs) Handles Button_changePara.Click

        Dim numIndex As Integer = ListView_cannels.SelectedItems(0).Index

        ListView_cannels.Items(numIndex).SubItems(4).Text = ComboBox_dir.SelectedItem.ToString
        ListView_cannels.Items(numIndex).SubItems(5).Text = TextBox_target1.Text
        ListView_cannels.Items(numIndex).SubItems(6).Text = TextBox_basefee1.Text
        ListView_cannels.Items(numIndex).SubItems(7).Text = TextBox_feeac1.Text


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
                        CType(Me.TableLayoutPanel1.Controls("TextBox_Fee1_" + i.ToString), TextBox).Text = strData(i + 1)
                    Next
                Case "control_fee2"
                    For i = 0 To 9
                        CType(Me.TableLayoutPanel1.Controls("TextBox_Fee2_" + i.ToString), TextBox).Text = strData(i + 1)
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



End Class
