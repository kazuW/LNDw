Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports Newtonsoft.Json

Public Class channel

    Implements System.IComparable


    Private _aliasName As String
    Private _pubKey As String
    Private _chanID As String
    Private _chanPointID As String
    Private _capacity As String
    Private _localBalance As String
    Private _remoteBalance As String
    Private _localFeeBase As String
    Private _localFeeRate As String
    Private _remoteFeeBase As String
    Private _remoteFeeRate As String
    Private _localTimelock As String
    Private _remoteTimelock As String
    Private _chanDirection As String
    Private _autoFeeCont As Integer
    Private _localCapRate As Single
    Private _localCapRateTarget(1) As Single
    Private _baseFeeRate As Single
    Private _ambossFeeRate As String
    Private _active As Boolean
    Private _feeNoflowCount As Integer
    Private _feeDuringDec As Integer
    Private _localBalanceDec As Integer

    'AliasName
    Public Property AliasName() As String
        Get
            Return Me._aliasName
        End Get
        Set(ByVal value As String)
            Me._aliasName = value
        End Set
    End Property

    'PubKey
    Public Property PubKey() As String
        Get
            Return Me._pubKey
        End Get
        Set(ByVal value As String)
            Me._pubKey = value
        End Set
    End Property

    'Channel ID 
    Public Property ChanID() As String
        Get
            Return Me._chanID
        End Get
        Set(ByVal value As String)
            Me._chanID = value
        End Set
    End Property

    'Channel Point ID 
    Public Property ChanPointID() As String
        Get
            Return Me._chanPointID
        End Get
        Set(ByVal value As String)
            Me._chanPointID = value
        End Set
    End Property

    'Capacity
    Public Property Capacity() As String
        Get
            Return Me._capacity
        End Get
        Set(ByVal value As String)
            Me._capacity = value
        End Set
    End Property

    'LocalBalance
    Public Property LocalBalance() As String
        Get
            Return Me._localBalance
        End Get
        Set(ByVal value As String)
            Me._localBalance = value
        End Set
    End Property

    'RemoteBalance
    Public Property RemoteBalance() As String
        Get
            Return Me._remoteBalance
        End Get
        Set(ByVal value As String)
            Me._remoteBalance = value
        End Set
    End Property

    'LocalFeeBase
    Public Property LocalFeeBase() As String
        Get
            Return Me._localFeeBase
        End Get
        Set(ByVal value As String)
            Me._localFeeBase = value
        End Set
    End Property

    'LocalFeeRate
    Public Property LocalFeeRate() As String
        Get
            Return Me._localFeeRate
        End Get
        Set(ByVal value As String)
            Me._localFeeRate = value
        End Set
    End Property

    'RemoteFeeBase
    Public Property RemoteFeeBase() As String
        Get
            Return Me._remoteFeeBase
        End Get
        Set(ByVal value As String)
            Me._remoteFeeBase = value
        End Set
    End Property

    'RemoteFeeRate
    Public Property RemoteFeeRate() As String
        Get
            Return Me._remoteFeeRate
        End Get
        Set(ByVal value As String)
            Me._remoteFeeRate = value
        End Set
    End Property

    'LocalTimelock
    Public Property LocalTimelock() As String
        Get
            Return Me._localTimelock
        End Get
        Set(ByVal value As String)
            Me._localTimelock = value
        End Set
    End Property

    'RemoteTimelock
    Public Property RemoteTimelock() As String
        Get
            Return Me._remoteTimelock
        End Get
        Set(ByVal value As String)
            Me._remoteTimelock = value
        End Set
    End Property

    'Channelの特性(in or out)
    Public Property ChanDirection() As String
        Get
            Return Me._chanDirection
        End Get
        Set(ByVal value As String)
            Me._chanDirection = value
        End Set
    End Property

    'LocalCapacity Rate
    Public Property LocalCapRate() As Single
        Get
            Return Me._localCapRate
        End Get
        Set(ByVal value As Single)
            Me._localCapRate = value
        End Set
    End Property

    'LocalCapacity Rate
    Public Property LocalCapRateTarget() As Single()
        Get
            Return Me._localCapRateTarget
        End Get
        Set(ByVal value As Single())
            Me._localCapRateTarget = value
        End Set
    End Property

    'Base Fee Rate
    Public Property BaseFeeRate() As Single
        Get
            Return Me._baseFeeRate
        End Get
        Set(ByVal value As Single)
            Me._baseFeeRate = value
        End Set
    End Property

    'Amboss Fee Rate
    Public Property AmbossFeeRate() As String
        Get
            Return Me._ambossFeeRate
        End Get
        Set(ByVal value As String)
            Me._ambossFeeRate = value
        End Set
    End Property

    'AutoFeeCont
    Public Property AutoFeeCont() As Integer
        Get
            Return Me._autoFeeCont
        End Get
        Set(ByVal value As Integer)
            Me._autoFeeCont = value
        End Set
    End Property

    'Active
    Public Property Active() As Boolean
        Get
            Return Me._active
        End Get
        Set(ByVal value As Boolean)
            Me._active = value
        End Set
    End Property

    'FeeNoflowCount
    Public Property FeeNoflowCount() As Integer
        Get
            Return Me._feeNoflowCount
        End Get
        Set(ByVal value As Integer)
            Me._feeNoflowCount = value
        End Set
    End Property

    'FeeDuringDec
    Public Property FeeDuringDec() As Integer
        Get
            Return Me._feeDuringDec
        End Get
        Set(ByVal value As Integer)
            Me._feeDuringDec = value
        End Set
    End Property

    'FeeDuringDec
    Public Property LocalBalanceDec() As Integer
        Get
            Return Me._localBalanceDec
        End Get
        Set(ByVal value As Integer)
            Me._localBalanceDec = value
        End Set
    End Property

    Public Function CompareTo(other As Object) As Integer Implements IComparable.CompareTo

        If Not (Me.GetType() = other.GetType()) Then
            Throw New ArgumentException()
        End If

        Dim obj As channel = CType(other, channel)
        Return Me._localCapRate.CompareTo(obj._localCapRate)

        'Throw New NotImplementedException()

    End Function

End Class


Public Class node_info

    Private _aliasName As String
    Private _pubKey As String
    Private _lndVersion As String
    Private _chain As String
    Private _network As String
    Private _numPendingChannel As Integer
    Private _numActiveChannel As Integer
    Private _numInactiveChannel As Integer


    'AliasName
    Public Property AliasName() As String
        Get
            Return Me._aliasName
        End Get
        Set(ByVal value As String)
            Me._aliasName = value
        End Set
    End Property

    'PubKey
    Public Property PubKey() As String
        Get
            Return Me._pubKey
        End Get
        Set(ByVal value As String)
            Me._pubKey = value
        End Set
    End Property

    'Network 
    Public Property Chain() As String
        Get
            Return Me._chain
        End Get
        Set(ByVal value As String)
            Me._chain = value
        End Set
    End Property

    'Network 
    Public Property Network() As String
        Get
            Return Me._network
        End Get
        Set(ByVal value As String)
            Me._network = value
        End Set
    End Property

    'LndVersion
    Public Property LndVersion() As String
        Get
            Return Me._lndVersion
        End Get
        Set(ByVal value As String)
            Me._lndVersion = value
        End Set
    End Property

    'NumPendingChannel
    Public Property NumPendingChannel() As Integer
        Get
            Return Me._numPendingChannel
        End Get
        Set(ByVal value As Integer)
            Me._numPendingChannel = value
        End Set
    End Property

    'NumActiveChannel
    Public Property NumActiveChannel() As Integer
        Get
            Return Me._numActiveChannel
        End Get
        Set(ByVal value As Integer)
            Me._numActiveChannel = value
        End Set
    End Property

    'NumPendingChannel
    Public Property NumInactiveChannel() As Integer
        Get
            Return Me._numInactiveChannel
        End Get
        Set(ByVal value As Integer)
            Me._numInactiveChannel = value
        End Set
    End Property


End Class

Public Class mc_cfg

    Private _halfLifeSeconds As String
    Private _hopProbability As Double
    Private _weight As Double
    Private _maxPaymentResults As Int64
    Private _minFailRelaxInterval As String


    'HalfLifeSeconds
    Public Property HalfLifeSeconds() As String
        Get
            Return Me._halfLifeSeconds
        End Get
        Set(ByVal value As String)
            Me._halfLifeSeconds = value
        End Set
    End Property

    'HopProbability
    Public Property HopProbability() As Double
        Get
            Return Me._hopProbability
        End Get
        Set(ByVal value As Double)
            Me._hopProbability = value
        End Set
    End Property

    'Weight 
    Public Property Weight() As Double
        Get
            Return Me._weight
        End Get
        Set(ByVal value As Double)
            Me._weight = value
        End Set
    End Property

    'MaxPaymentResults 
    Public Property MaxPaymentResults() As Int64
        Get
            Return Me._maxPaymentResults
        End Get
        Set(ByVal value As Int64)
            Me._maxPaymentResults = value
        End Set
    End Property

    'MinFailRelaxInterval
    Public Property MinFailRelaxInterval() As String
        Get
            Return Me._minFailRelaxInterval
        End Get
        Set(ByVal value As String)
            Me._minFailRelaxInterval = value
        End Set
    End Property


End Class

