<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Alias :"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point))
        Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Active channels :")
        Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Inactive channels :")
        Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Pending channels :")
        Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("On-chain balance :")
        Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Lightning balance :")
        Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Network :")
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaseFeeRateConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebalanceNodeConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveNodeConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveBaseFeeRateConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveRebalanceNodeConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_main = New System.Windows.Forms.TabPage()
        Me.ListView_main = New System.Windows.Forms.ListView()
        Me.ColumnTitle = New System.Windows.Forms.ColumnHeader()
        Me.ColumnData = New System.Windows.Forms.ColumnHeader()
        Me.TabPage_channel = New System.Windows.Forms.TabPage()
        Me.Button_cancel = New System.Windows.Forms.Button()
        Me.ComboBox_feeAC = New System.Windows.Forms.ComboBox()
        Me.Button_autoFeeUpdate = New System.Windows.Forms.Button()
        Me.Button_startRebalance = New System.Windows.Forms.Button()
        Me.Button_changePara = New System.Windows.Forms.Button()
        Me.ComboBox_dir = New System.Windows.Forms.ComboBox()
        Me.TextBox_basefee1 = New System.Windows.Forms.TextBox()
        Me.TextBox_target1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView_cannels = New System.Windows.Forms.ListView()
        Me.AliasName = New System.Windows.Forms.ColumnHeader()
        Me.LocalCapRatio = New System.Windows.Forms.ColumnHeader()
        Me.LocalFee = New System.Windows.Forms.ColumnHeader()
        Me.RemoteFee = New System.Windows.Forms.ColumnHeader()
        Me.Direction = New System.Windows.Forms.ColumnHeader()
        Me.Target = New System.Windows.Forms.ColumnHeader()
        Me.BaseFee = New System.Windows.Forms.ColumnHeader()
        Me.FeeControl = New System.Windows.Forms.ColumnHeader()
        Me.TabPage_rebalance = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_feeCont = New System.Windows.Forms.Button()
        Me.Button_rebDirection = New System.Windows.Forms.Button()
        Me.Button_mcReset = New System.Windows.Forms.Button()
        Me.Button_setMC = New System.Windows.Forms.Button()
        Me.TextBox_mcMFR = New System.Windows.Forms.TextBox()
        Me.TextBox_mcMPR = New System.Windows.Forms.TextBox()
        Me.TextBox_mcW = New System.Windows.Forms.TextBox()
        Me.TextBox_mcHP = New System.Windows.Forms.TextBox()
        Me.TextBox_mcHLS = New System.Windows.Forms.TextBox()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox_repeatRoute = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.CheckBox_useQuery = New System.Windows.Forms.CheckBox()
        Me.CheckBox_autoFeeCont = New System.Windows.Forms.CheckBox()
        Me.CheckBox_autoRebalance = New System.Windows.Forms.CheckBox()
        Me.TextBox_timeout_reb = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox_repeat_reb = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox_interval_reb = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox_feelimit_reb = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox_amount_reb = New System.Windows.Forms.TextBox()
        Me.CheckBox_reckless = New System.Windows.Forms.CheckBox()
        Me.Button_getMC = New System.Windows.Forms.Button()
        Me.TabPage_conf = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox_uri = New System.Windows.Forms.TextBox()
        Me.TextBox_macaroon = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_0 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_1 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_2 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_3 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_4 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_5 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_6 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_7 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_8 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee1_9 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_0 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_1 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_2 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_3 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_4 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_5 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_6 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_7 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_8 = New System.Windows.Forms.TextBox()
        Me.TextBox_Fee2_9 = New System.Windows.Forms.TextBox()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.TextBox_basefee = New System.Windows.Forms.TextBox()
        Me.TextBox_timelock = New System.Windows.Forms.TextBox()
        Me.TabPage_log = New System.Windows.Forms.TabPage()
        Me.Button_PayResultRead = New System.Windows.Forms.Button()
        Me.TextBox_log = New System.Windows.Forms.TextBox()
        Me.Label_version = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_pubkey = New System.Windows.Forms.TextBox()
        Me.Button_updateChannel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_main.SuspendLayout()
        Me.TabPage_channel.SuspendLayout()
        Me.TabPage_rebalance.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage_conf.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage_log.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileFToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(820, 33)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileFToolStripMenuItem
        '
        Me.FileFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NodeConfigFileToolStripMenuItem, Me.BaseFeeRateConfigFileToolStripMenuItem, Me.RebalanceNodeConfigFileToolStripMenuItem, Me.SaveNodeConfigFileToolStripMenuItem, Me.SaveBaseFeeRateConfigFileToolStripMenuItem, Me.SaveRebalanceNodeConfigFileToolStripMenuItem})
        Me.FileFToolStripMenuItem.Name = "FileFToolStripMenuItem"
        Me.FileFToolStripMenuItem.Size = New System.Drawing.Size(73, 29)
        Me.FileFToolStripMenuItem.Text = "File(&F)"
        '
        'NodeConfigFileToolStripMenuItem
        '
        Me.NodeConfigFileToolStripMenuItem.Name = "NodeConfigFileToolStripMenuItem"
        Me.NodeConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.NodeConfigFileToolStripMenuItem.Text = "Open Node config File"
        '
        'BaseFeeRateConfigFileToolStripMenuItem
        '
        Me.BaseFeeRateConfigFileToolStripMenuItem.Name = "BaseFeeRateConfigFileToolStripMenuItem"
        Me.BaseFeeRateConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.BaseFeeRateConfigFileToolStripMenuItem.Text = "Open BaseFeeRate config File"
        '
        'RebalanceNodeConfigFileToolStripMenuItem
        '
        Me.RebalanceNodeConfigFileToolStripMenuItem.Name = "RebalanceNodeConfigFileToolStripMenuItem"
        Me.RebalanceNodeConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.RebalanceNodeConfigFileToolStripMenuItem.Text = "Open RebalanceNode config File"
        '
        'SaveNodeConfigFileToolStripMenuItem
        '
        Me.SaveNodeConfigFileToolStripMenuItem.Name = "SaveNodeConfigFileToolStripMenuItem"
        Me.SaveNodeConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.SaveNodeConfigFileToolStripMenuItem.Text = "Save Node config File"
        '
        'SaveBaseFeeRateConfigFileToolStripMenuItem
        '
        Me.SaveBaseFeeRateConfigFileToolStripMenuItem.Name = "SaveBaseFeeRateConfigFileToolStripMenuItem"
        Me.SaveBaseFeeRateConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.SaveBaseFeeRateConfigFileToolStripMenuItem.Text = "Save BaseFeeRate config File"
        '
        'SaveRebalanceNodeConfigFileToolStripMenuItem
        '
        Me.SaveRebalanceNodeConfigFileToolStripMenuItem.Name = "SaveRebalanceNodeConfigFileToolStripMenuItem"
        Me.SaveRebalanceNodeConfigFileToolStripMenuItem.Size = New System.Drawing.Size(374, 34)
        Me.SaveRebalanceNodeConfigFileToolStripMenuItem.Text = "Save RebalanceNode config File"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_main)
        Me.TabControl1.Controls.Add(Me.TabPage_channel)
        Me.TabControl1.Controls.Add(Me.TabPage_rebalance)
        Me.TabControl1.Controls.Add(Me.TabPage_conf)
        Me.TabControl1.Controls.Add(Me.TabPage_log)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(820, 544)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage_main
        '
        Me.TabPage_main.Controls.Add(Me.ListView_main)
        Me.TabPage_main.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_main.Name = "TabPage_main"
        Me.TabPage_main.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_main.Size = New System.Drawing.Size(812, 506)
        Me.TabPage_main.TabIndex = 2
        Me.TabPage_main.Text = "Main"
        Me.TabPage_main.UseVisualStyleBackColor = True
        '
        'ListView_main
        '
        Me.ListView_main.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnTitle, Me.ColumnData})
        Me.ListView_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_main.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ListView_main.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30})
        Me.ListView_main.Location = New System.Drawing.Point(3, 3)
        Me.ListView_main.Name = "ListView_main"
        Me.ListView_main.Size = New System.Drawing.Size(806, 500)
        Me.ListView_main.TabIndex = 0
        Me.ListView_main.UseCompatibleStateImageBehavior = False
        Me.ListView_main.View = System.Windows.Forms.View.Details
        '
        'ColumnTitle
        '
        Me.ColumnTitle.Text = "Item"
        Me.ColumnTitle.Width = 200
        '
        'ColumnData
        '
        Me.ColumnData.Text = "Data"
        Me.ColumnData.Width = 300
        '
        'TabPage_channel
        '
        Me.TabPage_channel.Controls.Add(Me.Button_cancel)
        Me.TabPage_channel.Controls.Add(Me.ComboBox_feeAC)
        Me.TabPage_channel.Controls.Add(Me.Button_autoFeeUpdate)
        Me.TabPage_channel.Controls.Add(Me.Button_startRebalance)
        Me.TabPage_channel.Controls.Add(Me.Button_changePara)
        Me.TabPage_channel.Controls.Add(Me.ComboBox_dir)
        Me.TabPage_channel.Controls.Add(Me.TextBox_basefee1)
        Me.TabPage_channel.Controls.Add(Me.TextBox_target1)
        Me.TabPage_channel.Controls.Add(Me.Label5)
        Me.TabPage_channel.Controls.Add(Me.Label4)
        Me.TabPage_channel.Controls.Add(Me.Label3)
        Me.TabPage_channel.Controls.Add(Me.Label2)
        Me.TabPage_channel.Controls.Add(Me.ListView_cannels)
        Me.TabPage_channel.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_channel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage_channel.Name = "TabPage_channel"
        Me.TabPage_channel.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage_channel.Size = New System.Drawing.Size(812, 506)
        Me.TabPage_channel.TabIndex = 3
        Me.TabPage_channel.Text = "Channels"
        Me.TabPage_channel.UseVisualStyleBackColor = True
        '
        'Button_cancel
        '
        Me.Button_cancel.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Button_cancel.Location = New System.Drawing.Point(407, 424)
        Me.Button_cancel.Name = "Button_cancel"
        Me.Button_cancel.Size = New System.Drawing.Size(168, 34)
        Me.Button_cancel.TabIndex = 13
        Me.Button_cancel.Text = "cancel"
        Me.Button_cancel.UseVisualStyleBackColor = True
        '
        'ComboBox_feeAC
        '
        Me.ComboBox_feeAC.FormattingEnabled = True
        Me.ComboBox_feeAC.Location = New System.Drawing.Point(304, 465)
        Me.ComboBox_feeAC.Name = "ComboBox_feeAC"
        Me.ComboBox_feeAC.Size = New System.Drawing.Size(97, 33)
        Me.ComboBox_feeAC.TabIndex = 12
        '
        'Button_autoFeeUpdate
        '
        Me.Button_autoFeeUpdate.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Button_autoFeeUpdate.Location = New System.Drawing.Point(594, 424)
        Me.Button_autoFeeUpdate.Name = "Button_autoFeeUpdate"
        Me.Button_autoFeeUpdate.Size = New System.Drawing.Size(210, 34)
        Me.Button_autoFeeUpdate.TabIndex = 11
        Me.Button_autoFeeUpdate.Text = "Auto Fee update"
        Me.Button_autoFeeUpdate.UseVisualStyleBackColor = True
        '
        'Button_startRebalance
        '
        Me.Button_startRebalance.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Button_startRebalance.Location = New System.Drawing.Point(594, 464)
        Me.Button_startRebalance.Name = "Button_startRebalance"
        Me.Button_startRebalance.Size = New System.Drawing.Size(210, 34)
        Me.Button_startRebalance.TabIndex = 10
        Me.Button_startRebalance.Text = "Start rebalance"
        Me.Button_startRebalance.UseVisualStyleBackColor = True
        '
        'Button_changePara
        '
        Me.Button_changePara.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Button_changePara.Location = New System.Drawing.Point(407, 463)
        Me.Button_changePara.Name = "Button_changePara"
        Me.Button_changePara.Size = New System.Drawing.Size(168, 34)
        Me.Button_changePara.TabIndex = 9
        Me.Button_changePara.Text = "change param"
        Me.Button_changePara.UseVisualStyleBackColor = True
        '
        'ComboBox_dir
        '
        Me.ComboBox_dir.FormattingEnabled = True
        Me.ComboBox_dir.Location = New System.Drawing.Point(8, 465)
        Me.ComboBox_dir.Name = "ComboBox_dir"
        Me.ComboBox_dir.Size = New System.Drawing.Size(118, 33)
        Me.ComboBox_dir.TabIndex = 8
        '
        'TextBox_basefee1
        '
        Me.TextBox_basefee1.Location = New System.Drawing.Point(218, 465)
        Me.TextBox_basefee1.Name = "TextBox_basefee1"
        Me.TextBox_basefee1.Size = New System.Drawing.Size(80, 31)
        Me.TextBox_basefee1.TabIndex = 6
        '
        'TextBox_target1
        '
        Me.TextBox_target1.Location = New System.Drawing.Point(132, 465)
        Me.TextBox_target1.Name = "TextBox_target1"
        Me.TextBox_target1.Size = New System.Drawing.Size(80, 31)
        Me.TextBox_target1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(315, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 28)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "FeeAC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(215, 437)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Base fee"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(135, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Target"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(23, 437)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Direction"
        '
        'ListView_cannels
        '
        Me.ListView_cannels.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView_cannels.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.ListView_cannels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AliasName, Me.LocalCapRatio, Me.LocalFee, Me.RemoteFee, Me.Direction, Me.Target, Me.BaseFee, Me.FeeControl})
        Me.ListView_cannels.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView_cannels.Font = New System.Drawing.Font("Yu Gothic UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ListView_cannels.GridLines = True
        Me.ListView_cannels.HoverSelection = True
        Me.ListView_cannels.Location = New System.Drawing.Point(4, 5)
        Me.ListView_cannels.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListView_cannels.MultiSelect = False
        Me.ListView_cannels.Name = "ListView_cannels"
        Me.ListView_cannels.Size = New System.Drawing.Size(804, 411)
        Me.ListView_cannels.TabIndex = 0
        Me.ListView_cannels.UseCompatibleStateImageBehavior = False
        Me.ListView_cannels.View = System.Windows.Forms.View.Details
        '
        'AliasName
        '
        Me.AliasName.Text = "AliasName"
        Me.AliasName.Width = 300
        '
        'LocalCapRatio
        '
        Me.LocalCapRatio.Text = "ratio"
        Me.LocalCapRatio.Width = 65
        '
        'LocalFee
        '
        Me.LocalFee.Text = "Fee-L"
        Me.LocalFee.Width = 65
        '
        'RemoteFee
        '
        Me.RemoteFee.Text = "Fee-R"
        Me.RemoteFee.Width = 65
        '
        'Direction
        '
        Me.Direction.Text = "Direction"
        Me.Direction.Width = 100
        '
        'Target
        '
        Me.Target.Text = "Target"
        Me.Target.Width = 80
        '
        'BaseFee
        '
        Me.BaseFee.Text = "B-Fee"
        Me.BaseFee.Width = 65
        '
        'FeeControl
        '
        Me.FeeControl.Text = "FeeAC"
        Me.FeeControl.Width = 70
        '
        'TabPage_rebalance
        '
        Me.TabPage_rebalance.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage_rebalance.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_rebalance.Name = "TabPage_rebalance"
        Me.TabPage_rebalance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_rebalance.Size = New System.Drawing.Size(812, 506)
        Me.TabPage_rebalance.TabIndex = 4
        Me.TabPage_rebalance.Text = "Rebalance setting"
        Me.TabPage_rebalance.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button_feeCont, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_rebDirection, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_mcReset, 3, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_setMC, 3, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_mcMFR, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_mcMPR, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_mcW, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_mcHP, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_mcHLS, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox32, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox31, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox30, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox28, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox26, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox24, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_repeatRoute, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox22, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox_useQuery, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox_autoFeeCont, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox_autoRebalance, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_timeout_reb, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox29, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_repeat_reb, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox27, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_interval_reb, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox25, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_feelimit_reb, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox23, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox21, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_amount_reb, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox_reckless, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_getMC, 3, 7)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(806, 500)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Button_feeCont
        '
        Me.Button_feeCont.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_feeCont.Location = New System.Drawing.Point(453, 203)
        Me.Button_feeCont.Name = "Button_feeCont"
        Me.Button_feeCont.Size = New System.Drawing.Size(350, 34)
        Me.Button_feeCont.TabIndex = 31
        Me.Button_feeCont.Text = "fee control reset"
        Me.Button_feeCont.UseVisualStyleBackColor = True
        '
        'Button_rebDirection
        '
        Me.Button_rebDirection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_rebDirection.Location = New System.Drawing.Point(453, 163)
        Me.Button_rebDirection.Name = "Button_rebDirection"
        Me.Button_rebDirection.Size = New System.Drawing.Size(350, 34)
        Me.Button_rebDirection.TabIndex = 30
        Me.Button_rebDirection.Text = "rebalace direction reset"
        Me.Button_rebDirection.UseVisualStyleBackColor = True
        '
        'Button_mcReset
        '
        Me.Button_mcReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_mcReset.Location = New System.Drawing.Point(453, 363)
        Me.Button_mcReset.Name = "Button_mcReset"
        Me.Button_mcReset.Size = New System.Drawing.Size(350, 34)
        Me.Button_mcReset.TabIndex = 29
        Me.Button_mcReset.Text = "Reset Mission Control"
        Me.Button_mcReset.UseVisualStyleBackColor = True
        '
        'Button_setMC
        '
        Me.Button_setMC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_setMC.Location = New System.Drawing.Point(453, 323)
        Me.Button_setMC.Name = "Button_setMC"
        Me.Button_setMC.Size = New System.Drawing.Size(350, 34)
        Me.Button_setMC.TabIndex = 28
        Me.Button_setMC.Text = "Set Mission Control"
        Me.Button_setMC.UseVisualStyleBackColor = True
        '
        'TextBox_mcMFR
        '
        Me.TextBox_mcMFR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_mcMFR.Location = New System.Drawing.Point(203, 443)
        Me.TextBox_mcMFR.Name = "TextBox_mcMFR"
        Me.TextBox_mcMFR.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_mcMFR.TabIndex = 26
        '
        'TextBox_mcMPR
        '
        Me.TextBox_mcMPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_mcMPR.Location = New System.Drawing.Point(203, 403)
        Me.TextBox_mcMPR.Name = "TextBox_mcMPR"
        Me.TextBox_mcMPR.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_mcMPR.TabIndex = 25
        '
        'TextBox_mcW
        '
        Me.TextBox_mcW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_mcW.Location = New System.Drawing.Point(203, 363)
        Me.TextBox_mcW.Name = "TextBox_mcW"
        Me.TextBox_mcW.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_mcW.TabIndex = 24
        '
        'TextBox_mcHP
        '
        Me.TextBox_mcHP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_mcHP.Location = New System.Drawing.Point(203, 323)
        Me.TextBox_mcHP.Name = "TextBox_mcHP"
        Me.TextBox_mcHP.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_mcHP.TabIndex = 23
        '
        'TextBox_mcHLS
        '
        Me.TextBox_mcHLS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_mcHLS.Location = New System.Drawing.Point(203, 283)
        Me.TextBox_mcHLS.Name = "TextBox_mcHLS"
        Me.TextBox_mcHLS.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_mcHLS.TabIndex = 22
        '
        'TextBox32
        '
        Me.TextBox32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox32.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox32.Location = New System.Drawing.Point(3, 443)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.ReadOnly = True
        Me.TextBox32.Size = New System.Drawing.Size(194, 31)
        Me.TextBox32.TabIndex = 21
        Me.TextBox32.Text = "MinFailRelaxInterval :"
        '
        'TextBox31
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBox31, 4)
        Me.TextBox31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox31.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox31.Location = New System.Drawing.Point(3, 243)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.ReadOnly = True
        Me.TextBox31.Size = New System.Drawing.Size(800, 34)
        Me.TextBox31.TabIndex = 20
        Me.TextBox31.Text = "Mission control"
        Me.TextBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox30
        '
        Me.TextBox30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox30.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox30.Location = New System.Drawing.Point(3, 403)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.ReadOnly = True
        Me.TextBox30.Size = New System.Drawing.Size(194, 31)
        Me.TextBox30.TabIndex = 19
        Me.TextBox30.Text = "MaxPaymentResults :"
        '
        'TextBox28
        '
        Me.TextBox28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox28.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox28.Location = New System.Drawing.Point(3, 363)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.ReadOnly = True
        Me.TextBox28.Size = New System.Drawing.Size(194, 34)
        Me.TextBox28.TabIndex = 18
        Me.TextBox28.Text = "Weight (s) :"
        '
        'TextBox26
        '
        Me.TextBox26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox26.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox26.Location = New System.Drawing.Point(3, 323)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.ReadOnly = True
        Me.TextBox26.Size = New System.Drawing.Size(194, 34)
        Me.TextBox26.TabIndex = 17
        Me.TextBox26.Text = "Hop probability :"
        '
        'TextBox24
        '
        Me.TextBox24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox24.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox24.Location = New System.Drawing.Point(3, 283)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.ReadOnly = True
        Me.TextBox24.Size = New System.Drawing.Size(194, 34)
        Me.TextBox24.TabIndex = 16
        Me.TextBox24.Text = "Half life seconds :"
        '
        'TextBox_repeatRoute
        '
        Me.TextBox_repeatRoute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_repeatRoute.Location = New System.Drawing.Point(203, 163)
        Me.TextBox_repeatRoute.Name = "TextBox_repeatRoute"
        Me.TextBox_repeatRoute.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_repeatRoute.TabIndex = 15
        '
        'TextBox22
        '
        Me.TextBox22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox22.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox22.Location = New System.Drawing.Point(3, 163)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.Size = New System.Drawing.Size(194, 34)
        Me.TextBox22.TabIndex = 14
        Me.TextBox22.Text = "Repeat route(n) :"
        '
        'CheckBox_useQuery
        '
        Me.CheckBox_useQuery.AutoSize = True
        Me.CheckBox_useQuery.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.CheckBox_useQuery.Location = New System.Drawing.Point(453, 123)
        Me.CheckBox_useQuery.Name = "CheckBox_useQuery"
        Me.CheckBox_useQuery.Size = New System.Drawing.Size(130, 32)
        Me.CheckBox_useQuery.TabIndex = 13
        Me.CheckBox_useQuery.Text = "Use query"
        Me.CheckBox_useQuery.UseVisualStyleBackColor = True
        '
        'CheckBox_autoFeeCont
        '
        Me.CheckBox_autoFeeCont.AutoSize = True
        Me.CheckBox_autoFeeCont.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.CheckBox_autoFeeCont.Location = New System.Drawing.Point(453, 83)
        Me.CheckBox_autoFeeCont.Name = "CheckBox_autoFeeCont"
        Me.CheckBox_autoFeeCont.Size = New System.Drawing.Size(187, 32)
        Me.CheckBox_autoFeeCont.TabIndex = 12
        Me.CheckBox_autoFeeCont.Text = "Auto fee control"
        Me.CheckBox_autoFeeCont.UseVisualStyleBackColor = True
        '
        'CheckBox_autoRebalance
        '
        Me.CheckBox_autoRebalance.AutoSize = True
        Me.CheckBox_autoRebalance.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.CheckBox_autoRebalance.Location = New System.Drawing.Point(453, 3)
        Me.CheckBox_autoRebalance.Name = "CheckBox_autoRebalance"
        Me.CheckBox_autoRebalance.Size = New System.Drawing.Size(175, 32)
        Me.CheckBox_autoRebalance.TabIndex = 11
        Me.CheckBox_autoRebalance.Text = "Auto rebalance"
        Me.CheckBox_autoRebalance.UseVisualStyleBackColor = True
        '
        'TextBox_timeout_reb
        '
        Me.TextBox_timeout_reb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_timeout_reb.Location = New System.Drawing.Point(203, 203)
        Me.TextBox_timeout_reb.Name = "TextBox_timeout_reb"
        Me.TextBox_timeout_reb.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_timeout_reb.TabIndex = 10
        '
        'TextBox29
        '
        Me.TextBox29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox29.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox29.Location = New System.Drawing.Point(3, 203)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.ReadOnly = True
        Me.TextBox29.Size = New System.Drawing.Size(194, 34)
        Me.TextBox29.TabIndex = 9
        Me.TextBox29.Text = "Timeout (s) :"
        '
        'TextBox_repeat_reb
        '
        Me.TextBox_repeat_reb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_repeat_reb.Location = New System.Drawing.Point(203, 123)
        Me.TextBox_repeat_reb.Name = "TextBox_repeat_reb"
        Me.TextBox_repeat_reb.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_repeat_reb.TabIndex = 8
        '
        'TextBox27
        '
        Me.TextBox27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox27.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox27.Location = New System.Drawing.Point(3, 123)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.ReadOnly = True
        Me.TextBox27.Size = New System.Drawing.Size(194, 34)
        Me.TextBox27.TabIndex = 7
        Me.TextBox27.Text = "Repeat (n) :"
        '
        'TextBox_interval_reb
        '
        Me.TextBox_interval_reb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_interval_reb.Location = New System.Drawing.Point(203, 83)
        Me.TextBox_interval_reb.Name = "TextBox_interval_reb"
        Me.TextBox_interval_reb.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_interval_reb.TabIndex = 6
        '
        'TextBox25
        '
        Me.TextBox25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox25.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox25.Location = New System.Drawing.Point(3, 83)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(194, 34)
        Me.TextBox25.TabIndex = 5
        Me.TextBox25.Text = "Interval (s) :"
        '
        'TextBox_feelimit_reb
        '
        Me.TextBox_feelimit_reb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_feelimit_reb.Location = New System.Drawing.Point(203, 43)
        Me.TextBox_feelimit_reb.Name = "TextBox_feelimit_reb"
        Me.TextBox_feelimit_reb.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_feelimit_reb.TabIndex = 3
        '
        'TextBox23
        '
        Me.TextBox23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox23.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox23.Location = New System.Drawing.Point(3, 43)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.ReadOnly = True
        Me.TextBox23.Size = New System.Drawing.Size(194, 34)
        Me.TextBox23.TabIndex = 2
        Me.TextBox23.Text = "Fee limit (sat) :"
        '
        'TextBox21
        '
        Me.TextBox21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox21.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBox21.Location = New System.Drawing.Point(3, 3)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.Size = New System.Drawing.Size(194, 34)
        Me.TextBox21.TabIndex = 0
        Me.TextBox21.Text = "Amount/unit (sat) :"
        '
        'TextBox_amount_reb
        '
        Me.TextBox_amount_reb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_amount_reb.Location = New System.Drawing.Point(203, 3)
        Me.TextBox_amount_reb.Name = "TextBox_amount_reb"
        Me.TextBox_amount_reb.Size = New System.Drawing.Size(194, 31)
        Me.TextBox_amount_reb.TabIndex = 1
        '
        'CheckBox_reckless
        '
        Me.CheckBox_reckless.AutoSize = True
        Me.CheckBox_reckless.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.CheckBox_reckless.Location = New System.Drawing.Point(453, 43)
        Me.CheckBox_reckless.Name = "CheckBox_reckless"
        Me.CheckBox_reckless.Size = New System.Drawing.Size(110, 32)
        Me.CheckBox_reckless.TabIndex = 4
        Me.CheckBox_reckless.Text = "reckless"
        Me.CheckBox_reckless.UseVisualStyleBackColor = True
        '
        'Button_getMC
        '
        Me.Button_getMC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_getMC.Location = New System.Drawing.Point(453, 283)
        Me.Button_getMC.Name = "Button_getMC"
        Me.Button_getMC.Size = New System.Drawing.Size(350, 34)
        Me.Button_getMC.TabIndex = 27
        Me.Button_getMC.Text = "Get Mission Control"
        Me.Button_getMC.UseVisualStyleBackColor = True
        '
        'TabPage_conf
        '
        Me.TabPage_conf.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage_conf.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_conf.Name = "TabPage_conf"
        Me.TabPage_conf.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_conf.Size = New System.Drawing.Size(812, 506)
        Me.TabPage_conf.TabIndex = 1
        Me.TabPage_conf.Text = "Config setting"
        Me.TabPage_conf.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox20, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox16, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox19, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox18, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox17, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox15, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox14, 10, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox13, 9, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox12, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox11, 7, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox9, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox8, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox7, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox6, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_uri, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_macaroon, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_0, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_1, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_2, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_3, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_4, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_5, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_6, 7, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_7, 8, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_8, 9, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee1_9, 10, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_0, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_1, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_2, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_3, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_4, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_5, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_6, 7, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_7, 8, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_8, 9, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_Fee2_9, 10, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox39, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_basefee, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox_timelock, 1, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(806, 500)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TextBox20
        '
        Me.TextBox20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox20.Location = New System.Drawing.Point(3, 363)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(194, 31)
        Me.TextBox20.TabIndex = 42
        Me.TextBox20.Text = "Time Lock :"
        '
        'TextBox16
        '
        Me.TextBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox16.Location = New System.Drawing.Point(3, 323)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(194, 31)
        Me.TextBox16.TabIndex = 41
        Me.TextBox16.Text = "Base fee (msat):"
        '
        'TextBox19
        '
        Me.TextBox19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox19.Location = New System.Drawing.Point(3, 283)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.Size = New System.Drawing.Size(194, 31)
        Me.TextBox19.TabIndex = 20
        Me.TextBox19.Text = "0.Fixed defaultFee :"
        '
        'TextBox18
        '
        Me.TextBox18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox18.Location = New System.Drawing.Point(3, 243)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(194, 31)
        Me.TextBox18.TabIndex = 19
        Me.TextBox18.Text = "2.BaseFee divided by X :"
        '
        'TextBox17
        '
        Me.TextBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox17.Location = New System.Drawing.Point(3, 203)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(194, 31)
        Me.TextBox17.TabIndex = 18
        Me.TextBox17.Text = "1.BaseFee divided by X :"
        '
        'TextBox15
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox15, 11)
        Me.TextBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox15.Location = New System.Drawing.Point(3, 3)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(800, 31)
        Me.TextBox15.TabIndex = 16
        Me.TextBox15.Text = "Path setting"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox14.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox14.Location = New System.Drawing.Point(743, 163)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(60, 29)
        Me.TextBox14.TabIndex = 15
        Me.TextBox14.Text = "<100%"
        '
        'TextBox13
        '
        Me.TextBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox13.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox13.Location = New System.Drawing.Point(683, 163)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(54, 29)
        Me.TextBox13.TabIndex = 14
        Me.TextBox13.Text = "<90%"
        '
        'TextBox12
        '
        Me.TextBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox12.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox12.Location = New System.Drawing.Point(623, 163)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(54, 29)
        Me.TextBox12.TabIndex = 13
        Me.TextBox12.Text = "<80%"
        '
        'TextBox11
        '
        Me.TextBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox11.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox11.Location = New System.Drawing.Point(563, 163)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(54, 29)
        Me.TextBox11.TabIndex = 12
        Me.TextBox11.Text = "<70%"
        '
        'TextBox10
        '
        Me.TextBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox10.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox10.Location = New System.Drawing.Point(383, 163)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(54, 29)
        Me.TextBox10.TabIndex = 11
        Me.TextBox10.Text = "<40%"
        '
        'TextBox9
        '
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox9.Location = New System.Drawing.Point(443, 163)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(54, 29)
        Me.TextBox9.TabIndex = 10
        Me.TextBox9.Text = "<50%"
        '
        'TextBox8
        '
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox8.Location = New System.Drawing.Point(503, 163)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(54, 29)
        Me.TextBox8.TabIndex = 9
        Me.TextBox8.Text = "<60%"
        '
        'TextBox7
        '
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox7.Location = New System.Drawing.Point(263, 163)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(54, 29)
        Me.TextBox7.TabIndex = 8
        Me.TextBox7.Text = "<20%"
        '
        'TextBox6
        '
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox6.Location = New System.Drawing.Point(323, 163)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(54, 29)
        Me.TextBox6.TabIndex = 7
        Me.TextBox6.Text = "<30%"
        '
        'TextBox5
        '
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(3, 163)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(194, 31)
        Me.TextBox5.TabIndex = 6
        Me.TextBox5.Text = "Local cap. ratio : "
        '
        'TextBox4
        '
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBox4.Location = New System.Drawing.Point(203, 163)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(54, 29)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = "<10%"
        '
        'TextBox3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox3, 11)
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(3, 123)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(800, 31)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = "Auto fee control setting"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(194, 31)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "URI :"
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(3, 83)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(194, 31)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "Mmacaroon path :"
        '
        'TextBox_uri
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox_uri, 10)
        Me.TextBox_uri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_uri.Location = New System.Drawing.Point(203, 43)
        Me.TextBox_uri.Name = "TextBox_uri"
        Me.TextBox_uri.Size = New System.Drawing.Size(600, 31)
        Me.TextBox_uri.TabIndex = 2
        '
        'TextBox_macaroon
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox_macaroon, 10)
        Me.TextBox_macaroon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_macaroon.Location = New System.Drawing.Point(203, 83)
        Me.TextBox_macaroon.Name = "TextBox_macaroon"
        Me.TextBox_macaroon.Size = New System.Drawing.Size(600, 31)
        Me.TextBox_macaroon.TabIndex = 3
        '
        'TextBox_Fee1_0
        '
        Me.TextBox_Fee1_0.Location = New System.Drawing.Point(203, 203)
        Me.TextBox_Fee1_0.Name = "TextBox_Fee1_0"
        Me.TextBox_Fee1_0.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_0.TabIndex = 17
        '
        'TextBox_Fee1_1
        '
        Me.TextBox_Fee1_1.Location = New System.Drawing.Point(263, 203)
        Me.TextBox_Fee1_1.Name = "TextBox_Fee1_1"
        Me.TextBox_Fee1_1.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_1.TabIndex = 21
        '
        'TextBox_Fee1_2
        '
        Me.TextBox_Fee1_2.Location = New System.Drawing.Point(323, 203)
        Me.TextBox_Fee1_2.Name = "TextBox_Fee1_2"
        Me.TextBox_Fee1_2.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_2.TabIndex = 22
        '
        'TextBox_Fee1_3
        '
        Me.TextBox_Fee1_3.Location = New System.Drawing.Point(383, 203)
        Me.TextBox_Fee1_3.Name = "TextBox_Fee1_3"
        Me.TextBox_Fee1_3.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_3.TabIndex = 23
        '
        'TextBox_Fee1_4
        '
        Me.TextBox_Fee1_4.Location = New System.Drawing.Point(443, 203)
        Me.TextBox_Fee1_4.Name = "TextBox_Fee1_4"
        Me.TextBox_Fee1_4.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_4.TabIndex = 24
        '
        'TextBox_Fee1_5
        '
        Me.TextBox_Fee1_5.Location = New System.Drawing.Point(503, 203)
        Me.TextBox_Fee1_5.Name = "TextBox_Fee1_5"
        Me.TextBox_Fee1_5.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_5.TabIndex = 25
        '
        'TextBox_Fee1_6
        '
        Me.TextBox_Fee1_6.Location = New System.Drawing.Point(563, 203)
        Me.TextBox_Fee1_6.Name = "TextBox_Fee1_6"
        Me.TextBox_Fee1_6.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_6.TabIndex = 26
        '
        'TextBox_Fee1_7
        '
        Me.TextBox_Fee1_7.Location = New System.Drawing.Point(623, 203)
        Me.TextBox_Fee1_7.Name = "TextBox_Fee1_7"
        Me.TextBox_Fee1_7.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_7.TabIndex = 27
        '
        'TextBox_Fee1_8
        '
        Me.TextBox_Fee1_8.Location = New System.Drawing.Point(683, 203)
        Me.TextBox_Fee1_8.Name = "TextBox_Fee1_8"
        Me.TextBox_Fee1_8.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee1_8.TabIndex = 28
        '
        'TextBox_Fee1_9
        '
        Me.TextBox_Fee1_9.Location = New System.Drawing.Point(743, 203)
        Me.TextBox_Fee1_9.Name = "TextBox_Fee1_9"
        Me.TextBox_Fee1_9.Size = New System.Drawing.Size(55, 31)
        Me.TextBox_Fee1_9.TabIndex = 29
        '
        'TextBox_Fee2_0
        '
        Me.TextBox_Fee2_0.Location = New System.Drawing.Point(203, 243)
        Me.TextBox_Fee2_0.Name = "TextBox_Fee2_0"
        Me.TextBox_Fee2_0.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_0.TabIndex = 30
        '
        'TextBox_Fee2_1
        '
        Me.TextBox_Fee2_1.Location = New System.Drawing.Point(263, 243)
        Me.TextBox_Fee2_1.Name = "TextBox_Fee2_1"
        Me.TextBox_Fee2_1.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_1.TabIndex = 31
        '
        'TextBox_Fee2_2
        '
        Me.TextBox_Fee2_2.Location = New System.Drawing.Point(323, 243)
        Me.TextBox_Fee2_2.Name = "TextBox_Fee2_2"
        Me.TextBox_Fee2_2.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_2.TabIndex = 32
        '
        'TextBox_Fee2_3
        '
        Me.TextBox_Fee2_3.Location = New System.Drawing.Point(383, 243)
        Me.TextBox_Fee2_3.Name = "TextBox_Fee2_3"
        Me.TextBox_Fee2_3.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_3.TabIndex = 33
        '
        'TextBox_Fee2_4
        '
        Me.TextBox_Fee2_4.Location = New System.Drawing.Point(443, 243)
        Me.TextBox_Fee2_4.Name = "TextBox_Fee2_4"
        Me.TextBox_Fee2_4.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_4.TabIndex = 34
        '
        'TextBox_Fee2_5
        '
        Me.TextBox_Fee2_5.Location = New System.Drawing.Point(503, 243)
        Me.TextBox_Fee2_5.Name = "TextBox_Fee2_5"
        Me.TextBox_Fee2_5.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_5.TabIndex = 35
        '
        'TextBox_Fee2_6
        '
        Me.TextBox_Fee2_6.Location = New System.Drawing.Point(563, 243)
        Me.TextBox_Fee2_6.Name = "TextBox_Fee2_6"
        Me.TextBox_Fee2_6.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_6.TabIndex = 36
        '
        'TextBox_Fee2_7
        '
        Me.TextBox_Fee2_7.Location = New System.Drawing.Point(623, 243)
        Me.TextBox_Fee2_7.Name = "TextBox_Fee2_7"
        Me.TextBox_Fee2_7.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_7.TabIndex = 37
        '
        'TextBox_Fee2_8
        '
        Me.TextBox_Fee2_8.Location = New System.Drawing.Point(683, 243)
        Me.TextBox_Fee2_8.Name = "TextBox_Fee2_8"
        Me.TextBox_Fee2_8.Size = New System.Drawing.Size(53, 31)
        Me.TextBox_Fee2_8.TabIndex = 38
        '
        'TextBox_Fee2_9
        '
        Me.TextBox_Fee2_9.Location = New System.Drawing.Point(743, 243)
        Me.TextBox_Fee2_9.Name = "TextBox_Fee2_9"
        Me.TextBox_Fee2_9.Size = New System.Drawing.Size(55, 31)
        Me.TextBox_Fee2_9.TabIndex = 39
        '
        'TextBox39
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox39, 10)
        Me.TextBox39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox39.Location = New System.Drawing.Point(203, 283)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.ReadOnly = True
        Me.TextBox39.Size = New System.Drawing.Size(600, 31)
        Me.TextBox39.TabIndex = 40
        Me.TextBox39.Text = "Default fee"
        Me.TextBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_basefee
        '
        Me.TextBox_basefee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox_basefee, 10)
        Me.TextBox_basefee.Location = New System.Drawing.Point(203, 323)
        Me.TextBox_basefee.Name = "TextBox_basefee"
        Me.TextBox_basefee.Size = New System.Drawing.Size(600, 31)
        Me.TextBox_basefee.TabIndex = 43
        '
        'TextBox_timelock
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBox_timelock, 10)
        Me.TextBox_timelock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_timelock.Location = New System.Drawing.Point(203, 363)
        Me.TextBox_timelock.Name = "TextBox_timelock"
        Me.TextBox_timelock.Size = New System.Drawing.Size(600, 31)
        Me.TextBox_timelock.TabIndex = 44
        '
        'TabPage_log
        '
        Me.TabPage_log.Controls.Add(Me.Button_PayResultRead)
        Me.TabPage_log.Controls.Add(Me.TextBox_log)
        Me.TabPage_log.Location = New System.Drawing.Point(4, 34)
        Me.TabPage_log.Name = "TabPage_log"
        Me.TabPage_log.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_log.Size = New System.Drawing.Size(812, 506)
        Me.TabPage_log.TabIndex = 0
        Me.TabPage_log.Text = "Log"
        Me.TabPage_log.UseVisualStyleBackColor = True
        '
        'Button_PayResultRead
        '
        Me.Button_PayResultRead.Location = New System.Drawing.Point(596, 466)
        Me.Button_PayResultRead.Name = "Button_PayResultRead"
        Me.Button_PayResultRead.Size = New System.Drawing.Size(210, 34)
        Me.Button_PayResultRead.TabIndex = 1
        Me.Button_PayResultRead.Text = "payment result read"
        Me.Button_PayResultRead.UseVisualStyleBackColor = True
        '
        'TextBox_log
        '
        Me.TextBox_log.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox_log.Location = New System.Drawing.Point(3, 3)
        Me.TextBox_log.Multiline = True
        Me.TextBox_log.Name = "TextBox_log"
        Me.TextBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_log.Size = New System.Drawing.Size(806, 412)
        Me.TextBox_log.TabIndex = 0
        '
        'Label_version
        '
        Me.Label_version.AutoSize = True
        Me.Label_version.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label_version.Location = New System.Drawing.Point(12, 592)
        Me.Label_version.Name = "Label_version"
        Me.Label_version.Size = New System.Drawing.Size(89, 25)
        Me.Label_version.TabIndex = 1
        Me.Label_version.Text = "Version : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(9, 627)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pubkey : "
        '
        'TextBox_pubkey
        '
        Me.TextBox_pubkey.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TextBox_pubkey.Location = New System.Drawing.Point(122, 631)
        Me.TextBox_pubkey.Name = "TextBox_pubkey"
        Me.TextBox_pubkey.ReadOnly = True
        Me.TextBox_pubkey.Size = New System.Drawing.Size(690, 31)
        Me.TextBox_pubkey.TabIndex = 3
        '
        'Button_updateChannel
        '
        Me.Button_updateChannel.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Button_updateChannel.Location = New System.Drawing.Point(618, 585)
        Me.Button_updateChannel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_updateChannel.Name = "Button_updateChannel"
        Me.Button_updateChannel.Size = New System.Drawing.Size(194, 38)
        Me.Button_updateChannel.TabIndex = 4
        Me.Button_updateChannel.Text = "update channel"
        Me.Button_updateChannel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 674)
        Me.Controls.Add(Me.Button_updateChannel)
        Me.Controls.Add(Me.TextBox_pubkey)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label_version)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "LNDw"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_main.ResumeLayout(False)
        Me.TabPage_channel.ResumeLayout(False)
        Me.TabPage_channel.PerformLayout()
        Me.TabPage_rebalance.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage_conf.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPage_log.ResumeLayout(False)
        Me.TabPage_log.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NodeConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseFeeRateConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RebalanceNodeConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_main As TabPage
    Friend WithEvents ListView_main As ListView
    Friend WithEvents ColumnTitle As ColumnHeader
    Friend WithEvents ColumnData As ColumnHeader
    Friend WithEvents TabPage_conf As TabPage
    Friend WithEvents TabPage_log As TabPage
    Friend WithEvents Label_version As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox_uri As TextBox
    Friend WithEvents TextBox_macaroon As TextBox
    Friend WithEvents TextBox_log As TextBox
    Friend WithEvents TextBox_pubkey As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox_Fee1_0 As TextBox
    Friend WithEvents TextBox_Fee1_1 As TextBox
    Friend WithEvents TextBox_Fee1_2 As TextBox
    Friend WithEvents TextBox_Fee1_3 As TextBox
    Friend WithEvents TextBox_Fee1_4 As TextBox
    Friend WithEvents TextBox_Fee1_5 As TextBox
    Friend WithEvents TextBox_Fee1_6 As TextBox
    Friend WithEvents TextBox_Fee1_7 As TextBox
    Friend WithEvents TextBox_Fee1_8 As TextBox
    Friend WithEvents TextBox_Fee1_9 As TextBox
    Friend WithEvents TextBox_Fee2_0 As TextBox
    Friend WithEvents TextBox_Fee2_1 As TextBox
    Friend WithEvents TextBox_Fee2_2 As TextBox
    Friend WithEvents TextBox_Fee2_3 As TextBox
    Friend WithEvents TextBox_Fee2_4 As TextBox
    Friend WithEvents TextBox_Fee2_5 As TextBox
    Friend WithEvents TextBox_Fee2_6 As TextBox
    Friend WithEvents TextBox_Fee2_7 As TextBox
    Friend WithEvents TextBox_Fee2_8 As TextBox
    Friend WithEvents TextBox_Fee2_9 As TextBox
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents TabPage_channel As TabPage
    Friend WithEvents ListView_cannels As ListView
    Friend WithEvents AliasName As ColumnHeader
    Friend WithEvents LocalCapRatio As ColumnHeader
    Friend WithEvents LocalFee As ColumnHeader
    Friend WithEvents RemoteFee As ColumnHeader
    Friend WithEvents Direction As ColumnHeader
    Friend WithEvents Target As ColumnHeader
    Friend WithEvents BaseFee As ColumnHeader
    Friend WithEvents FeeControl As ColumnHeader
    Friend WithEvents Button_updateChannel As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button_changePara As Button
    Friend WithEvents ComboBox_dir As ComboBox
    Friend WithEvents TextBox_basefee1 As TextBox
    Friend WithEvents TextBox_target1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox_basefee As TextBox
    Friend WithEvents TextBox_timelock As TextBox
    Friend WithEvents TabPage_rebalance As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents CheckBox_autoFeeCont As CheckBox
    Friend WithEvents CheckBox_autoRebalance As CheckBox
    Friend WithEvents TextBox_timeout_reb As TextBox
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents TextBox_repeat_reb As TextBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents TextBox_interval_reb As TextBox
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents TextBox_feelimit_reb As TextBox
    Friend WithEvents TextBox23 As TextBox
    Friend WithEvents TextBox_amount_reb As TextBox
    Friend WithEvents CheckBox_reckless As CheckBox
    Friend WithEvents Button_autoFeeUpdate As Button
    Friend WithEvents Button_startRebalance As Button
    Friend WithEvents Button_PayResultRead As Button
    Friend WithEvents CheckBox_useQuery As CheckBox
    Friend WithEvents ComboBox_feeAC As ComboBox
    Friend WithEvents TextBox_repeatRoute As TextBox
    Friend WithEvents TextBox22 As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button_cancel As Button
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button_setMC As Button
    Friend WithEvents TextBox_mcMFR As TextBox
    Friend WithEvents TextBox_mcMPR As TextBox
    Friend WithEvents TextBox_mcW As TextBox
    Friend WithEvents TextBox_mcHP As TextBox
    Friend WithEvents TextBox_mcHLS As TextBox
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents Button_getMC As Button
    Friend WithEvents Button_mcReset As Button
    Friend WithEvents SaveNodeConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveBaseFeeRateConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveRebalanceNodeConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button_feeCont As Button
    Friend WithEvents Button_rebDirection As Button
End Class
