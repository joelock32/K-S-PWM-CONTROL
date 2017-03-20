
Imports System.Text
Imports System
Imports System.IO
Imports PCANBasicExample.Peak.Can.Basic
Imports TPCANHandle = System.Byte
Imports System.Collections.Stack
Imports System.Threading.ThreadState
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office



Public Class Form1

    Public Sub New()
        ' Initializes Form's component
        '
        InitializeComponent()
        ' Initializes specific components
        '
        InitializeBasicComponents()
    End Sub

#Region "Structures"
    ''' <summary>
    ''' Message Status structure used to show CAN Messages
    ''' in a ListView
    ''' </summary>
    Private Class MessageStatus
        Private m_Msg As TPCANMsg
        Private m_TimeStamp As TPCANTimestamp
        Private m_oldTimeStamp As TPCANTimestamp
        Private m_iIndex As Integer
        Private m_Count As Integer
        Private m_bShowPeriod As Boolean
        Private m_bWasChanged As Boolean

        Public Sub New(ByVal canMsg As TPCANMsg, ByVal canTimestamp As TPCANTimestamp, ByVal listIndex As Integer)
            m_Msg = canMsg
            m_TimeStamp = canTimestamp
            m_iIndex = listIndex
            m_Count = 1
            m_bShowPeriod = True
            m_bWasChanged = False
        End Sub

        Public Sub Update(ByVal canMsg As TPCANMsg, ByVal canTimestamp As TPCANTimestamp)
            m_Msg = canMsg
            m_oldTimeStamp = m_TimeStamp
            m_TimeStamp = canTimestamp
            m_bWasChanged = True
            m_Count += 1
        End Sub

        Private Function GetMsgTypeString() As String
            Dim strTemp As String

            If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_EXTENDED) = TPCANMessageType.PCAN_MESSAGE_EXTENDED Then
                strTemp = "EXTENDED"
            Else
                strTemp = "STANDARD"
            End If

            If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_RTR) = TPCANMessageType.PCAN_MESSAGE_RTR Then
                strTemp += "/RTR"
            End If

            Return strTemp
        End Function

        Private Function GetIdString() As String
            If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_EXTENDED) = TPCANMessageType.PCAN_MESSAGE_EXTENDED Then
                Return String.Format("{0:X8}h", m_Msg.ID)
            Else
                Return String.Format("{0:X3}h", m_Msg.ID)
            End If
        End Function

        Private Function GetDataString() As String
            Dim strTemp As String

            strTemp = ""

            If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_RTR) = TPCANMessageType.PCAN_MESSAGE_RTR Then
                strTemp = "Remote Request"
            Else
                For i As Integer = 0 To m_Msg.LEN - 1
                    strTemp += String.Format("{0:X2} ", m_Msg.DATA(i))
                Next
            End If

            Return strTemp
        End Function

        Private Function GetTimeString() As String
            Dim fTime As Double

            fTime = m_TimeStamp.millis + (m_TimeStamp.micros / 1000.0R)
            If m_bShowPeriod Then
                fTime -= (m_oldTimeStamp.millis + (m_oldTimeStamp.micros / 1000.0R))
            End If

            Return fTime.ToString("F1")
        End Function

        Public ReadOnly Property CANMsg() As TPCANMsg
            Get
                Return m_Msg
            End Get
        End Property

        Public ReadOnly Property Timestamp() As TPCANTimestamp
            Get
                Return m_TimeStamp
            End Get
        End Property

        Public ReadOnly Property Position() As Integer
            Get
                Return m_iIndex
            End Get
        End Property

        Public ReadOnly Property TypeString() As String
            Get
                Return GetMsgTypeString()
            End Get
        End Property

        Public ReadOnly Property IdString() As String
            Get
                Return GetIdString()
            End Get
        End Property

        Public ReadOnly Property DataString() As String
            Get
                Return GetDataString()
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return m_Count
            End Get
        End Property

        Public Property ShowingPeriod() As Boolean
            Get
                Return m_bShowPeriod
            End Get
            Set(ByVal value As Boolean)
                If m_bShowPeriod Xor value Then
                    m_bShowPeriod = value
                    m_bWasChanged = True
                End If
            End Set
        End Property

        Public Property MarkedAsUpdated() As Boolean
            Get
                Return m_bWasChanged
            End Get
            Set(ByVal value As Boolean)
                m_bWasChanged = value
            End Set
        End Property

        Public ReadOnly Property TimeString() As String
            Get
                Return GetTimeString()
            End Get
        End Property
    End Class
#End Region

#Region "Delegates"
    ''' <summary>
    ''' Read-Delegate Handler
    ''' </summary>
    Private Delegate Sub ReadDelegateHandler()
#End Region

#Region "Members"
    ''' <summary>
    ''' Saves the handle of a PCAN hardware
    ''' </summary>
    Private m_PcanHandle As TPCANHandle
    ''' <summary>
    ''' Saves the baudrate register for a conenction
    ''' </summary>
    Private m_Baudrate As TPCANBaudrate
    ''' <summary>
    ''' Saves the type of a non-plug-and-play hardware
    ''' </summary>
    Private m_HwType As TPCANType
    ''' <summary>
    ''' Stores the status of received messages for its display
    ''' </summary>
    Private m_LastMsgsList As System.Collections.ArrayList
    ''' <summary>
    ''' Read Delegate for calling the function "ReadMessages"
    ''' </summary>
    Private m_ReadDelegate As ReadDelegateHandler
    ''' <summary>
    ''' Receive-Event
    ''' </summary>
    Private m_ReceiveEvent As System.Threading.AutoResetEvent
    ''' <summary>
    ''' Thread for message reading (using events)
    ''' </summary>
    Private m_ReadThread As System.Threading.Thread
    ''' <summary>
    ''' Handles of the current available PCAN-Hardware
    ''' </summary>
    Private m_HandlesArray As TPCANHandle()
    ''' <summary>
    ''' Array to handel multipule channels
    ''' </summary>
    Public chan_Array() As String
    Public Recipe As Boolean
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#End Region

#Region "Methods"

#Region "UI Handler"

    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
        Dim stsResult As TPCANStatus

        ' Connects a selected PCAN-Basic channel
        '
        stsResult = PCANBasic.Initialize(m_PcanHandle, m_Baudrate, m_HwType, Convert.ToUInt32(cbbIO.Text, 16), Convert.ToUInt16(cbbInterrupt.Text))

        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
        Else
            ' Prepares the PCAN-Basic's PCAN-Trace file
            '
            ConfigureTraceFile()
        End If

        ' Sets the connection status of the main-form
        '
        SetConnectionStatus(stsResult = TPCANStatus.PCAN_ERROR_OK)
    End Sub

    Private Sub cbbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbChannel.SelectedIndexChanged
        Dim bNonPnP As Boolean
        Dim strTemp As String

        ' Get the handle fromt he text being shown
        strTemp = cbbChannel.Text
        strTemp = strTemp.Substring(strTemp.IndexOf("("c) + 1, 2)

        ' Determines if the handle belong to a No Plug&Play hardware 
        '
        m_PcanHandle = Convert.ToByte(strTemp, 16)
        bNonPnP = m_PcanHandle <= PCANBasic.PCAN_DNGBUS1

        ' Activates/deactivates configuration controls according with the 
        ' kind of hardware
        '
        cbbHwType.Enabled = bNonPnP
        cbbIO.Enabled = bNonPnP
        cbbInterrupt.Enabled = bNonPnP

    End Sub

    Private Sub btnHwRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHwRefresh.Click
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        ' Clears the Channel combioBox and fill it againa with 
        ' the PCAN-Basic handles for no-Plug&Play hardware and
        ' the detected Plug&Play hardware
        '
        cbbChannel.Items.Clear()
        Try
            For i As Integer = 0 To m_HandlesArray.Length - 1
                ' Includes all no-Plug&Play Handles
                If m_HandlesArray(i) <= PCANBasic.PCAN_DNGBUS1 Then
                    cbbChannel.Items.Add(FormatChannelName(m_HandlesArray(i)))
                Else
                    ' Checks for a Plug&Play Handle and, according with the return value, includes it
                    ' into the list of available hardware channels.
                    '
                    stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_CONDITION, iBuffer, System.Runtime.InteropServices.Marshal.SizeOf(iBuffer))
                    If (stsResult = TPCANStatus.PCAN_ERROR_OK) AndAlso (iBuffer = PCANBasic.PCAN_CHANNEL_AVAILABLE) Then
                        cbbChannel.Items.Add(FormatChannelName(m_HandlesArray(i)))
                    End If
                End If
            Next
            cbbChannel.SelectedIndex = cbbChannel.Items.Count - 1
        Catch ex As DllNotFoundException
            MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End Try

    End Sub

    Private Sub cbbBaudrates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbBaudrates.SelectedIndexChanged
        ' Saves the current selected baudrate register code
        '
        Select Case cbbBaudrates.SelectedIndex
            Case 0
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M
                Exit Select
            Case 1
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_800K
                Exit Select
            Case 2
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K
                Exit Select
            Case 3
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K
                Exit Select
            Case 4
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_125K
                Exit Select
            Case 5
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_100K
                Exit Select
            Case 6
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_95K
                Exit Select
            Case 7
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_83K
                Exit Select
            Case 8
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_50K
                Exit Select
            Case 9
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_47K
                Exit Select
            Case 10
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_33K
                Exit Select
            Case 11
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_20K
                Exit Select
            Case 12
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_10K
                Exit Select
            Case 13
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_5K
                Exit Select
        End Select
    End Sub

    Private Sub cbbHwType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbHwType.SelectedIndexChanged
        ' Saves the current type for a no-Plug&Play hardware
        '
        Select Case cbbHwType.SelectedIndex
            Case 0
                m_HwType = TPCANType.PCAN_TYPE_ISA
                Exit Select
            Case 1
                m_HwType = TPCANType.PCAN_TYPE_ISA_SJA
                Exit Select
            Case 2
                m_HwType = TPCANType.PCAN_TYPE_ISA_PHYTEC
                Exit Select
            Case 3
                m_HwType = TPCANType.PCAN_TYPE_DNG
                Exit Select
            Case 4
                m_HwType = TPCANType.PCAN_TYPE_DNG_EPP
                Exit Select
            Case 5
                m_HwType = TPCANType.PCAN_TYPE_DNG_SJA
                Exit Select
            Case 6
                m_HwType = TPCANType.PCAN_TYPE_DNG_SJA_EPP
                Exit Select
        End Select
    End Sub

    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        ' Releases a current connected PCAN-Basic channel
        '
        PCANBasic.Uninitialize(m_PcanHandle)
        tmrRead.Enabled = False
        If m_ReadThread IsNot Nothing Then
            m_ReadThread.Abort()
            m_ReadThread.Join()
            m_ReadThread = Nothing
        End If

        ' Sets the connection status of the main-form
        '
        SetConnectionStatus(False)

    End Sub

    Private Sub chbFilterExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFilterExt.CheckedChanged
        Dim iMaxValue As Integer

        iMaxValue = IIf((chbFilterExt.Checked), &H1FFFFFFF, &H7FF)

        ' We check that the maximum value for a selected filter 
        ' mode is used
        '
        If nudIdTo.Value > iMaxValue Then
            nudIdTo.Value = iMaxValue
        End If

        nudIdTo.Maximum = iMaxValue
    End Sub

    Private Sub btnFilterApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterApply.Click
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        ' Gets the current status of the message filter
        '
        If Not GetFilterStatus(iBuffer) Then
            Return
        End If

        ' Configures the message filter for a custom range of messages
        '
        If rdbFilterCustom.Checked Then
            ' Sets the custom filter
            '
            stsResult = PCANBasic.FilterMessages(m_PcanHandle, Convert.ToUInt32(nudIdFrom.Value), Convert.ToUInt32(nudIdTo.Value), IIf(chbFilterExt.Checked, TPCANMode.PCAN_MODE_EXTENDED, TPCANMode.PCAN_MODE_STANDARD))
            ' If success, an information message is written, if it is not, an error message is shown
            '
            If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                IncludeTextMessage(String.Format("The filter was customized. IDs from {0:X} to {1:X} will be received", nudIdFrom.Text, nudIdTo.Text))
            Else
                MessageBox.Show(GetFormatedError(stsResult))
            End If

            Return
        End If

        ' The filter will be full opened or complete closed
        '
        If rdbFilterClose.Checked Then
            iBuffer = PCANBasic.PCAN_FILTER_CLOSE
        Else
            iBuffer = PCANBasic.PCAN_FILTER_OPEN
        End If

        ' The filter is configured
        '
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))

        ' If success, an information message is written, if it is not, an error message is shown
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(String.Format("The filter was successfully {0}", IIf(rdbFilterClose.Checked, "closed.", "opened.")))
        Else
            MessageBox.Show(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub btnFilterQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterQuery.Click
        Dim iBuffer As UInt32

        ' Queries the current status of the message filter
        '
        If GetFilterStatus(iBuffer) Then
            Select Case iBuffer
                ' The filter is closed
                '
                Case PCANBasic.PCAN_FILTER_CLOSE
                    IncludeTextMessage("The Status of the filter is: closed.")
                    Exit Select
                    ' The filter is fully opened
                    '
                Case PCANBasic.PCAN_FILTER_OPEN
                    IncludeTextMessage("The Status of the filter is: full opened.")
                    Exit Select
                    ' The filter is customized
                    '
                Case PCANBasic.PCAN_FILTER_CUSTOM
                    IncludeTextMessage("The Status of the filter is: customized.")
                    Exit Select
                Case Else
                    ' The status of the filter is undefined. (Should never happen)
                    '
                    IncludeTextMessage("The Status of the filter is: Invalid.")
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub cbbParameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbParameter.SelectedIndexChanged
        ' Activates/deactivates controls according with the selected 
        ' PCAN-Basic parameter 
        '
        rdbParamActive.Enabled = TryCast(sender, ComboBox).SelectedIndex <> 0
        rdbParamInactive.Enabled = rdbParamActive.Enabled
        nudDeviceId.Enabled = Not rdbParamActive.Enabled
    End Sub

    Private Sub btnParameterSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParameterSet.Click
        Dim stsResult As TPCANStatus
        Dim iBuffer As UInt32
        Dim bActivate As Boolean

        bActivate = rdbParamActive.Checked

        ' Sets a PCAN-Basic parameter value
        '
        Select Case cbbParameter.SelectedIndex
            ' The Device-Number of an USB channel will be set
            '
            Case 0
                iBuffer = Convert.ToUInt32(nudDeviceId.Value)
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_DEVICE_NUMBER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage("The desired Device-Number was successfully configured")
                End If
                Exit Select
                ' The 5 Volt Power feature of a PC-card or USB will be set
                '
            Case 1
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_5VOLTS_POWER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The USB/PC-Card 5 power was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
                ' The feature for automatic reset on BUS-OFF will be set
                '
            Case 2
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_BUSOFF_AUTORESET, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The automatic-reset on BUS-OFF was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
                ' The CAN option "Listen Only" will be set
                '
            Case 3
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_LISTEN_ONLY, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The CAN option ""Listen Only"" was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
                ' The feature for logging debug-information will be set
                '
            Case 4
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The feature for logging debug information was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
                ' The channel option "Receive Status" will be set
                '
            Case 5
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The channel option ""Receive Status"" was set to {0}", IIf(bActivate, "ON", "OFF")))
                End If
                Exit Select
                ' The feature for tracing will be set
                '
            Case 7
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The feature for tracing data was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
                ' The feature for identifying an USB Channel will be set
                '
            Case 8
                iBuffer = CUInt((IIf(bActivate, PCANBasic.PCAN_PARAMETER_ON, PCANBasic.PCAN_PARAMETER_OFF)))
                stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The procedure for channel identification was successfully {0}", IIf(bActivate, "activated", "deactivated")))
                End If
                Exit Select
            Case Else
                ' The current parameter is invalid
                '
                stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN
                MessageBox.Show("Wrong parameter code.")
                Return
        End Select

        ' If the function fail, an error message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
        End If

    End Sub

    Private Sub btnParameterGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParameterGet.Click
        Dim stsResult As TPCANStatus
        Dim iBuffer As UInt32

        ' Gets a PCAN-Basic parameter value
        '
        Select Case cbbParameter.SelectedIndex
            ' The Device-Number of an USB channel will be retrieved
            '
            Case 0
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_DEVICE_NUMBER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The configured Device-Number is {0:X}", iBuffer))
                End If
                Exit Select
                ' The activation status of the 5 Volt Power feature of a PC-card or USB will be retrieved
                '
            Case 1
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_5VOLTS_POWER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The 5-Volt Power of the USB/PC-Card is {0:X}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The activation status of the feature for automatic reset on BUS-OFF will be retrieved
                '
            Case 2
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_BUSOFF_AUTORESET, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The automatic-reset on BUS-OFF is {0:X}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The activation status of the CAN option "Listen Only" will be retrieved
                '
            Case 3
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_LISTEN_ONLY, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The CAN option ""Listen Only"" is {0:X}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The activation status for the feature for logging debug-information will be retrieved
            Case 4
                stsResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The feature for logging debug information is {0:X}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The activation status of the channel option "Receive Status"  will be retrieved
                '
            Case 5
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The channel option ""Receive Status"" is {0}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The Number of the CAN-Controller used by a PCAN-Channel
                '
            Case 6
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_CONTROLLER_NUMBER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The CAN Controller number is {0}", iBuffer))
                End If
                Exit Select
                ' The activation status for the feature for tracing data will be retrieved
                '
            Case 7
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_STATUS, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The feature for tracing data is {0}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
                ' The activation status of the Channel Identifying procedure will be retrieved
                '
            Case 8
                stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                    IncludeTextMessage(String.Format("The identification procedure of the selected channel is {0}", IIf((iBuffer = PCANBasic.PCAN_PARAMETER_ON), "ON", "OFF")))
                End If
                Exit Select
            Case Else
                ' The current parameter is invalid
                '
                stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN
                MessageBox.Show("Wrong parameter code.")
                Return
        End Select

        ' If the function fail, an error message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub rdbTimer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTimer.CheckedChanged, rdbManual.CheckedChanged, rdbEvent.CheckedChanged
        ''Checks Form Initialization is complete 
        '      If Not isFormInitCompleted Then
        '           Return
        '        End If

        If Not btnRelease.Enabled Then
            Return
        End If

        ' According with the kind of reading, a timer, a thread or a button will be enabled
        '
        If rdbTimer.Checked Then
            ' Abort Read Thread if it exists
            '
            If m_ReadThread IsNot Nothing Then
                m_ReadThread.Abort()
                m_ReadThread.Join()
                m_ReadThread = Nothing
            End If

            ' Enable Timer
            '
            tmrRead.Enabled = btnRelease.Enabled
        End If
        If rdbEvent.Checked Then
            ' Disable Timer
            '
            tmrRead.Enabled = False
            ' Create and start the tread to read CAN Message using SetRcvEvent()
            '
            Dim threadDelegate As New System.Threading.ThreadStart(AddressOf Me.CANReadThreadFunc)
            m_ReadThread = New System.Threading.Thread(threadDelegate)
            m_ReadThread.IsBackground = True
            m_ReadThread.Start()
        End If
        If rdbManual.Checked Then
            ' Abort Read Thread if it exists
            '
            If m_ReadThread IsNot Nothing Then
                m_ReadThread.Abort()
                m_ReadThread.Join()
                m_ReadThread = Nothing
            End If
            ' Disable Timer
            '
            tmrRead.Enabled = False
            btnRead.Enabled = btnRelease.Enabled AndAlso rdbManual.Checked
        End If
    End Sub

    Private Sub chbShowPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowPeriod.CheckedChanged
        ' According with the check-value of this checkbox,
        ' the recieved time of a messages will be interpreted as 
        ' period (time between the two last messages) or as time-stamp
        ' (the elapsed time since windows was started)
        '
        SyncLock m_LastMsgsList.SyncRoot
            For Each msg As MessageStatus In m_LastMsgsList
                msg.ShowingPeriod = chbShowPeriod.Checked
            Next
        End SyncLock
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        Dim CANMsg As TPCANMsg = Nothing
        Dim CANTimeStamp As TPCANTimestamp
        Dim stsResult As TPCANStatus

        ' We execute the "Read" function of the PCANBasic                
        '
        stsResult = PCANBasic.Read(m_PcanHandle, CANMsg, CANTimeStamp)
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            ' We show the received message
            '
            ProcessMessage(CANMsg, CANTimeStamp)
        Else
            ' If an error occurred, an information message is included
            '
            IncludeTextMessage(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub btnMsgClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMsgClear.Click
        ' The information contained in the messages List-View
        ' is cleared
        '
        SyncLock m_LastMsgsList.SyncRoot
            lstMessages.Items.Clear()
            m_LastMsgsList.Clear()
        End SyncLock
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress, txtData7.KeyPress, txtData6.KeyPress, txtData5.KeyPress, txtData4.KeyPress, txtData3.KeyPress, txtData2.KeyPress, txtData1.KeyPress, txtData0.KeyPress
        Dim chCheck As Int16

        ' We convert the Character to its Upper case equivalent
        '
        chCheck = Microsoft.VisualBasic.Asc(e.KeyChar.ToString().ToUpper())

        ' The Key is the Delete (Backspace) Key
        '
        If chCheck = 8 Then
            Return
        End If
        ' The Key is a number between 0-9
        '
        If (chCheck > 47) AndAlso (chCheck < 58) Then
            Return
        End If
        ' The Key is a character between A-F
        '
        If (chCheck > 64) AndAlso (chCheck < 71) Then
            Return
        End If

        ' Is neither a number nor a character between A(a) and F(f)
        '
        e.Handled = True

    End Sub

    Private Sub txtID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.Leave
        Dim iTextLength As Integer
        Dim uiMaxValue As UInteger

        ' Calculates the text length and Maximum ID value according
        ' with the Message Type
        '
        iTextLength = IIf((chbExtended.Checked), 8, 3)
        uiMaxValue = IIf((chbExtended.Checked), CUInt(&H1FFFFFFF), CUInt(&H7FF))

        ' The Textbox for the ID is represented with 3 characters for 
        ' Standard and 8 characters for extended messages.
        ' Therefore if the Length of the text is smaller than TextLength,  
        ' we add "0"
        '
        While txtID.Text.Length <> iTextLength
            txtID.Text = ("0" & txtID.Text)
        End While

        ' We check that the ID is not bigger than current maximum value
        '
        If Convert.ToUInt32(txtID.Text, 16) > uiMaxValue Then
            txtID.Text = String.Format("{0:X" & iTextLength.ToString() & "}", uiMaxValue)
        End If
    End Sub

    Private Sub chbExtended_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbExtended.CheckedChanged
        Dim uiTemp As UInteger

        txtID.MaxLength = IIf((chbExtended.Checked), 8, 3)

        ' the only way that the text length can be bigger als MaxLength
        ' is when the change is from Extended to Standard message Type.
        ' We have to handle this and set an ID not bigger than the Maximum
        ' ID value for a Standard Message (0x7FF)
        '
        If txtID.Text.Length > txtID.MaxLength Then
            uiTemp = Convert.ToUInt32(txtID.Text, 16)
            txtID.Text = IIf((uiTemp < &H7FF), String.Format("{0:X3}", uiTemp), "7FF")
        End If

        txtID_Leave(Me, New EventArgs())
    End Sub

    Private Sub chbRemote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRemote.CheckedChanged
        Dim txtbCurrentTextBox As TextBox

        txtbCurrentTextBox = txtData0

        ' If the message is a RTR, no data is sent. The textbox for data 
        ' will be turned invisible
        ' 
        For i As Integer = 0 To 7
            txtbCurrentTextBox.Visible = Not chbRemote.Checked
            If i < 7 Then
                txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
            End If
        Next
    End Sub

    Private Sub txtData0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtData7.Leave, txtData6.Leave, txtData5.Leave, txtData4.Leave, txtData3.Leave, txtData2.Leave, txtData1.Leave, txtData0.Leave
        Dim txtbCurrentTextbox As TextBox

        ' all the Textbox Data fields are represented with 2 characters.
        ' Therefore if the Length of the text is smaller than 2, we add
        ' a "0"
        '
        If sender.[GetType]().Name = "TextBox" Then
            txtbCurrentTextbox = DirectCast(sender, TextBox)
            While txtbCurrentTextbox.Text.Length <> 2
                txtbCurrentTextbox.Text = ("0" & txtbCurrentTextbox.Text)
            End While
        End If
    End Sub

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT")
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        ''Check for faults 
        txtID.Text = "10051112"
        autoSend()
    End Sub

    Private Sub btnGetVersions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetVersions.Click
        Dim stsResult As TPCANStatus
        Dim strTemp As StringBuilder
        Dim strArrayVersion As String()

        strTemp = New StringBuilder(256)

        ' We get the vesion of the PCAN-Basic API
        '
        stsResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_API_VERSION, strTemp, 256)
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("API Version: " & strTemp.ToString())
            ' We get the driver version of the channel being used
            '
            stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_CHANNEL_VERSION, strTemp, 256)
            If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                ' Because this information contains line control characters (several lines)
                ' we split this also in several entries in the Information List-Box
                '
                strArrayVersion = strTemp.ToString().Split(New Char() {ControlChars.Lf})
                IncludeTextMessage("Channel/Driver Version: ")
                For i As Integer = 0 To strArrayVersion.Length - 1
                    IncludeTextMessage("     * " & strArrayVersion(i))
                Next
            End If
        End If

        ' If an error ccurred, a message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        IncludeTextMessage("K & S Home Grown Controllor Version: 1")
        IncludeTextMessage("AstrodynTDI SW#: T100106228-LF")
        IncludeTextMessage("Based on PCANBasic Example, Peak Systems")
        IncludeTextMessage("Released By: Joe Lockhart 4/09/2015")
    End Sub

    Private Sub btnInfoClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoClear.Click
        ' The information contained in the Information List-Box 
        ' is cleared
        lbxInfo.Items.Clear()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Releases the used PCAN-Basic channel
        '
        PCANBasic.Uninitialize(m_PcanHandle)
    End Sub

    Private Sub tmrRead_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRead.Tick
        '' Checks if in the receive-queue are currently messages for read
        ReadMessages()


    End Sub

    Private Sub tmrDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDisplay.Tick
        DisplayMessages()

    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbShowPeriod.Checked = True
        rdbParamActive.Checked = True
        rdbTimer.Checked = True
        rdbFilterOpen.Checked = True
        'Setup page Auto
        btnInit_Click(sender, e)
        btnFilterApply_Click(sender, e)
        chbExtended.CheckState = CheckState.Checked
    End Sub

    Private Sub lstMessages_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMessages.DoubleClick
        ' Clears the content of the Message List-View
        '
        btnMsgClear_Click(Me, New EventArgs())
    End Sub

    Private Sub lbxInfo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxInfo.DoubleClick
        ' Clears the content of the Information List-Box
        '
        btnInfoClear_Click(Me, New EventArgs())
    End Sub
#End Region

#Region "Help functions"
    ''' <summary>
    ''' Initialization of PCAN-Basic components
    ''' </summary>
    Private Sub InitializeBasicComponents()
        ' Creates the list for received messages
        '
        m_LastMsgsList = New System.Collections.ArrayList()
        ' Creates the delegate used for message reading
        '
        m_ReadDelegate = New ReadDelegateHandler(AddressOf ReadMessages)
        ' Creates the event used for signalize incomming messages 
        '
        m_ReceiveEvent = New System.Threading.AutoResetEvent(False)
        ' Creates an array with all possible PCAN-Channels
        '
        m_HandlesArray = New TPCANHandle() {PCANBasic.PCAN_ISABUS1, PCANBasic.PCAN_ISABUS2, PCANBasic.PCAN_ISABUS3, PCANBasic.PCAN_ISABUS4, PCANBasic.PCAN_ISABUS5, PCANBasic.PCAN_ISABUS6, _
         PCANBasic.PCAN_ISABUS7, PCANBasic.PCAN_ISABUS8, PCANBasic.PCAN_DNGBUS1, PCANBasic.PCAN_PCIBUS1, PCANBasic.PCAN_PCIBUS2, PCANBasic.PCAN_PCIBUS3, _
         PCANBasic.PCAN_PCIBUS4, PCANBasic.PCAN_PCIBUS5, PCANBasic.PCAN_PCIBUS6, PCANBasic.PCAN_PCIBUS7, PCANBasic.PCAN_PCIBUS8, PCANBasic.PCAN_USBBUS1, _
         PCANBasic.PCAN_USBBUS2, PCANBasic.PCAN_USBBUS3, PCANBasic.PCAN_USBBUS4, PCANBasic.PCAN_USBBUS5, PCANBasic.PCAN_USBBUS6, PCANBasic.PCAN_USBBUS7, _
         PCANBasic.PCAN_USBBUS8, PCANBasic.PCAN_PCCBUS1, PCANBasic.PCAN_PCCBUS2}

        ' Fills and configures the Data of several comboBox components
        '
        FillComboBoxData()

        ' Prepares the PCAN-Basic's debug-Log file
        '
        ConfigureLogFile()
    End Sub

    ''' <summary>
    ''' Configures the Debug-Log file of PCAN-Basic
    ''' </summary>
    Private Sub ConfigureLogFile()
        Dim iBuffer As UInt32

        ' Sets the mask to catch all events
        '
        iBuffer = PCANBasic.LOG_FUNCTION_ALL

        ' Configures the log file. 
        ' NOTE: The Log capability is to be used with the NONEBUS Handle. Other handle than this will 
        ' cause the function fail.
        '
        PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_CONFIGURE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
    End Sub

    ''' <summary>
    ''' Configures the Debug-Log file of PCAN-Basic
    ''' </summary>
    Private Sub ConfigureTraceFile()
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        ' Configure the maximum size of a trace file to 5 megabytes
        '
        iBuffer = 5
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(GetFormatedError(stsResult))
        End If

        ' Configure the way how trace files are created: 
        ' * Standard name is used
        ' * Existing file is ovewritten,
        ' * Only one file is created.
        ' * Recording stopts when the file size reaches 5 megabytes.
        '
        iBuffer = PCANBasic.TRACE_FILE_SINGLE Or PCANBasic.TRACE_FILE_OVERWRITE
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(GetFormatedError(stsResult))
        End If
    End Sub

    ''' <summary>
    ''' Help Function used to get an error as text
    ''' </summary>
    ''' <param name="error">Error code to be translated</param>
    ''' <returns>A text with the translated error</returns>
    Private Function GetFormatedError(ByVal [error] As TPCANStatus) As String
        Dim strTemp As StringBuilder

        ' Creates a buffer big enough for a error-text
        '
        strTemp = New StringBuilder(256)
        ' Gets the text using the GetErrorText API function
        ' If the function success, the translated error is returned. If it fails,
        ' a text describing the current error is returned.
        '
        If PCANBasic.GetErrorText([error], 0, strTemp) <> TPCANStatus.PCAN_ERROR_OK Then
            Return String.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", [error])
        Else
            Return strTemp.ToString()
        End If
    End Function

    ''' <summary>
    ''' Includes a new line of text into the information Listview
    ''' </summary>
    ''' <param name="strMsg">Text to be included</param>
    Private Sub IncludeTextMessage(ByVal strMsg As String)
        lbxInfo.Items.Add(strMsg)
        lbxInfo.SelectedIndex = lbxInfo.Items.Count - 1
    End Sub

    ''' <summary>
    ''' Gets the current status of the PCAN-Basic message filter
    ''' </summary>
    ''' <param name="status">Buffer to retrieve the filter status</param>
    ''' <returns>If calling the function was successfull or not</returns>
    Private Function GetFilterStatus(ByRef status As UInteger) As Boolean
        Dim stsResult As TPCANStatus

        ' Tries to get the sttaus of the filter for the current connected hardware
        '
        stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, status, CType(System.Runtime.InteropServices.Marshal.SizeOf(status), UInteger))

        ' If it fails, a error message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Configures the data of all ComboBox components of the main-form
    ''' </summary>
    Private Sub FillComboBoxData()
        ' Channels will be check
        '
        btnHwRefresh_Click(Me, New EventArgs())

        ' Baudrates 
        '
        cbbBaudrates.SelectedIndex = 2 ' 500 K
        ' Hardware Type for no plugAndplay hardware
        '
        cbbHwType.SelectedIndex = 0

        ' Interrupt for no plugAndplay hardware
        '
        cbbInterrupt.SelectedIndex = 0

        ' IO Port for no plugAndplay hardware
        '
        cbbIO.SelectedIndex = 0

        ' Parameters for GetValue and SetValue function calls
        '
        cbbParameter.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Activates/deaactivates the different controls of the main-form according
    ''' with the current connection status
    ''' </summary>
    ''' <param name="bConnected">Current status. True if connected, false otherwise</param>
    Private Sub SetConnectionStatus(ByVal bConnected As Boolean)
        ' Buttons
        '
        btnInit.Enabled = Not bConnected
        btnRead.Enabled = bConnected AndAlso rdbManual.Checked
        btnWrite.Enabled = bConnected
        btnRelease.Enabled = bConnected
        btnFilterApply.Enabled = bConnected
        btnFilterQuery.Enabled = bConnected
        btnParameterSet.Enabled = bConnected
        btnParameterGet.Enabled = bConnected
        btnGetVersions.Enabled = bConnected
        btnHwRefresh.Enabled = Not bConnected
        btnStatus.Enabled = bConnected
        btnReset.Enabled = bConnected

        ' ComboBoxs
        '
        cbbBaudrates.Enabled = Not bConnected
        cbbChannel.Enabled = Not bConnected
        cbbHwType.Enabled = Not bConnected
        cbbIO.Enabled = Not bConnected
        cbbInterrupt.Enabled = Not bConnected

        ' Hardware configuration and read mode
        '
        If Not bConnected Then
            cbbChannel_SelectedIndexChanged(Me, New EventArgs())
        Else
            rdbTimer_CheckedChanged(Me, New EventArgs())
        End If

        ' Display messages in grid
        '
        tmrDisplay.Enabled = bConnected
    End Sub

    ''' <summary>
    ''' Gets the formated text for a CPAN-Basic channel handle
    ''' </summary>
    ''' <param name="handle">PCAN-Basic Handle to format</param>
    ''' <returns>The formatted text for a channel</returns>
    Private Function FormatChannelName(ByVal handle As TPCANHandle) As String
        Dim devDevice As TPCANDevice
        Dim byChannel As Byte

        ' Gets the owner device and channel for a 
        ' PCAN-Basic handle
        '
        devDevice = DirectCast((handle >> 4), TPCANDevice)
        byChannel = CByte((handle And &HF))

        ' Constructs the PCAN-Basic Channel name and return it
        '
        Return String.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle)
    End Function
#End Region

#Region "Message-proccessing functions"
    ''' <summary>
    ''' Display CAN messages in the Message-ListView
    ''' </summary>
    Private Sub DisplayMessages()
        Dim lviCurrentItem As ListViewItem

        SyncLock m_LastMsgsList.SyncRoot
            For Each msgStatus As MessageStatus In m_LastMsgsList
                ' Get the data to actualize
                '
                If msgStatus.MarkedAsUpdated Then
                    msgStatus.MarkedAsUpdated = False
                    lviCurrentItem = lstMessages.Items(msgStatus.Position)

                    lviCurrentItem.SubItems(2).Text = msgStatus.CANMsg.LEN.ToString()
                    lviCurrentItem.SubItems(3).Text = msgStatus.DataString
                    lviCurrentItem.SubItems(4).Text = msgStatus.Count.ToString()
                    lviCurrentItem.SubItems(5).Text = msgStatus.TimeString
                    'Check for faults
                    If msgStatus.CANMsg.DATA(0) = CByte(3) Then
                        rdIHFLTCON.Checked = True
                        rdBBHCON.Checked = True
                        rdIHFLTCON.ForeColor = Color.DarkRed
                        rdBBHCON.ForeColor = Color.DarkRed
                        IncludeTextMessage("Bond Heater and Index Heater NOT CONNECTED!")
                    ElseIf msgStatus.CANMsg.DATA(0) = CByte(1) Then
                        rdIHFLTCON.Checked = False
                        rdBBHCON.Checked = True
                        rdIHFLTCON.ForeColor = Color.MediumSeaGreen
                        rdBBHCON.ForeColor = Color.DarkRed
                        IncludeTextMessage("Bond Head Heater in Fault Condition!")
                    ElseIf msgStatus.CANMsg.DATA(0) = CByte(2) Then
                        rdIHFLTCON.Checked = True
                        rdBBHCON.Checked = False
                        rdIHFLTCON.ForeColor = Color.DarkRed
                        rdBBHCON.ForeColor = Color.MediumSeaGreen
                        IncludeTextMessage("Index Heater in Fault Condition!")
                    ElseIf msgStatus.CANMsg.DATA(0) = CByte(0) Then
                        rdIHFLTCON.Checked = False
                        rdBBHCON.Checked = False
                        rdIHFLTCON.ForeColor = Color.MediumSeaGreen
                        rdBBHCON.ForeColor = Color.MediumSeaGreen
                    End If
                End If
            Next
        End SyncLock
    End Sub

    ''' <summary>
    ''' Inserts a new entry for a new message in the Message-ListView
    ''' </summary>
    ''' <param name="newMsg">The messasge to be inserted</param>
    ''' <param name="timeStamp">The Timesamp of the new message</param>
    Private Sub InsertMsgEntry(ByVal newMsg As TPCANMsg, ByVal timeStamp As TPCANTimestamp)
        Dim lviCurrentItem As ListViewItem
        Dim msgStsCurrentMsg As MessageStatus

        SyncLock m_LastMsgsList.SyncRoot
            ' We add this status in the last message list
            '
            msgStsCurrentMsg = New MessageStatus(newMsg, timeStamp, lstMessages.Items.Count)
            m_LastMsgsList.Add(msgStsCurrentMsg)

            ' Add the new ListView Item with the Type of the message
            '	
            lviCurrentItem = lstMessages.Items.Add(msgStsCurrentMsg.TypeString)
            ' We set the ID of the message
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.IdString)
            ' We set the length of the Message
            '
            lviCurrentItem.SubItems.Add(newMsg.LEN.ToString())
            ' We set the data of the message. 	
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.DataString)
            ' we set the message count message (this is the First, so count is 1)            
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.Count.ToString())
            ' Add time stamp information if needed
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.TimeString)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Processes a received message, in order to show it in the Message-ListView
    ''' </summary>
    ''' <param name="theMsg">The received PCAN-Basic message</param>
    ''' <param name="itsTimeStamp">The Timestamp of the received message</param>
    Private Sub ProcessMessage(ByVal theMsg As TPCANMsg, ByVal itsTimeStamp As TPCANTimestamp)
        ' We search if a message (Same ID and Type) is 
        ' already received or if this is a new message
        '
        SyncLock m_LastMsgsList.SyncRoot
            For Each msg As MessageStatus In m_LastMsgsList
                If (msg.CANMsg.ID = theMsg.ID) And (msg.CANMsg.MSGTYPE = theMsg.MSGTYPE) Then
                    ' Messages of this kind are already received; we do an update
                    '
                    msg.Update(theMsg, itsTimeStamp)
                    Exit Sub
                End If
            Next

            ' Message not found. It will created
            '
            InsertMsgEntry(theMsg, itsTimeStamp)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Thread-Function used for reading PCAN-Basic messages
    ''' </summary>
    Private Sub CANReadThreadFunc()
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32())
        ' Sets the handle of the Receive-Event.
        '
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))

        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' While this mode is selected
        While rdbEvent.Checked
            ' Waiting for Receive-Event
            ' 
            If m_ReceiveEvent.WaitOne(50) Then
                ' Process Receive-Event using .NET Invoke function
                ' in order to interact with Winforms UI (calling the 
                ' function ReadMessages)
                ' 
                Me.Invoke(m_ReadDelegate)
            End If
        End While
    End Sub

    ''' <summary>
    ''' Function for reading PCAN-Basic messages
    ''' </summary>
    Private Sub ReadMessages()
        Dim CANMsg As TPCANMsg = Nothing
        Dim CANTimeStamp As TPCANTimestamp
        Dim stsResult As TPCANStatus

        ' We read at least one time the queue looking for messages.
        ' If a message is found, we look again trying to find more.
        ' If the queue is empty or an error occurr, we get out from
        ' the dowhile statement.
        '			
        Do
            ' We execute the "Read" function of the PCANBasic                
            '
            stsResult = PCANBasic.Read(m_PcanHandle, CANMsg, CANTimeStamp)

            ' A message was received
            ' We process the message(s)
            '
            If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                ProcessMessage(CANMsg, CANTimeStamp)
            End If
        Loop While btnRelease.Enabled AndAlso (Not Convert.ToBoolean(stsResult And TPCANStatus.PCAN_ERROR_QRCVEMPTY))
    End Sub
#End Region

#End Region

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim stsResult As TPCANStatus

        ' Resets the receive and transmit queues of a PCAN Channel.
        '
        stsResult = PCANBasic.Reset(m_PcanHandle)

        ' If it fails, a error message is shown
        '
        If (stsResult <> TPCANStatus.PCAN_ERROR_OK) Then
            MessageBox.Show(GetFormatedError(stsResult))
        Else
            IncludeTextMessage("Receive and transmit queues successfully reset")
        End If

    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim stsResult As TPCANStatus
        Dim errorName As String

        ' Gets the current BUS status of a PCAN Channel.
        '
        stsResult = PCANBasic.GetStatus(m_PcanHandle)

        ' Switch On Error Name
        '
        Select Case stsResult
            Case TPCANStatus.PCAN_ERROR_INITIALIZE
                errorName = "PCAN_ERROR_INITIALIZE"
                Exit Select
            Case TPCANStatus.PCAN_ERROR_BUSLIGHT
                errorName = "PCAN_ERROR_BUSLIGHT"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSHEAVY
                errorName = "PCAN_ERROR_BUSHEAVY"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSOFF
                errorName = "PCAN_ERROR_BUSOFF"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_OK
                errorName = "PCAN_ERROR_OK"
                Exit Select
            Case Else
                errorName = "See Documentation"
                Exit Select
        End Select

        ' Display Message
        '
        IncludeTextMessage(String.Format("Status: {0} ({1:X}h)", errorName, stsResult))
    End Sub

    Private Sub CmBBond_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmBBond.SelectedIndexChanged
        If CmBBond.Text = "Duty Cycle Adjust" Then
            chbExtended.CheckState = CheckState.Checked
            txtID.Text = "10011112"
        End If

        If CmBBond.Text = "CAN Reset" Then
            chbExtended.CheckState = CheckState.Checked
            txtID.Text = "10021112"
        End If

        'If CmBBond.Text = "ALL Digital I/O Pins ON (PWM)" Then txtID.Text = "10031112"
        'If CmBBond.Text = "ALL Digital I/O Pins OFF (PWM)" Then txtID.Text = "10031112"
        'If CmBBond.Text = "Duty Cycle Adjust" Then txtID.Text = "10011112"

    End Sub

    Private Sub CmbBHHCHN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbBHHCHN.SelectedIndexChanged
        If CmbBHHCHN.Text = "Channel 1=Output 1A" Then txtData0.Text = Hex(16)
        If CmbBHHCHN.Text = "Channel 2=Output 1B" Then txtData0.Text = Hex(17)
        If CmbBHHCHN.Text = "Channel 3=Output 2A" Then txtData0.Text = Hex(18)
        If CmbBHHCHN.Text = "Channel 4=Output 2B" Then txtData0.Text = Hex(19)
    End Sub

    Private Sub txtBHHDC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBHHDC.TextChanged

        If txtBHHDC.Text = "" Then Exit Sub
        txtData1.Text = Hex(txtBHHDC.Text)
        'End If
    End Sub

    Private Sub CmBIond_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmBIond.SelectedIndexChanged
        If CmBIond.Text = "Duty Cycle Adjust" Then
            chbExtended.CheckState = CheckState.Checked
            txtID.Text = "10011112"
        End If

        If CmBIond.Text = "CAN Reset" Then
            chbExtended.CheckState = CheckState.Checked
            txtID.Text = "10021112"
        End If
    End Sub

    Private Sub CmbIHCHN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbIHCHN.SelectedIndexChanged
        If CmbIHCHN.Text = "Channel 1" Then txtData0.Text = Hex(0)
        If CmbIHCHN.Text = "Channel 2" Then txtData0.Text = Hex(1)
        If CmbIHCHN.Text = "Channel 3" Then txtData0.Text = Hex(2)
        If CmbIHCHN.Text = "Channel 4" Then txtData0.Text = Hex(3)
        If CmbIHCHN.Text = "Channel 5" Then txtData0.Text = Hex(4)
        If CmbIHCHN.Text = "Channel 6" Then txtData0.Text = Hex(5)
        If CmbIHCHN.Text = "Channel 7" Then txtData0.Text = Hex(6)
        If CmbIHCHN.Text = "Channel 8" Then txtData0.Text = Hex(7)
        If CmbIHCHN.Text = "Channel 9" Then txtData0.Text = Hex(8)
        If CmbIHCHN.Text = "Channel 10" Then txtData0.Text = Hex(9)
        If CmbIHCHN.Text = "Channel 11" Then txtData0.Text = Hex(10)
        If CmbIHCHN.Text = "Channel 12" Then txtData0.Text = Hex(11)
        If CmbIHCHN.Text = "Channel 13" Then txtData0.Text = Hex(12)
        If CmbIHCHN.Text = "Channel 14" Then txtData0.Text = Hex(13)
        If CmbIHCHN.Text = "Channel 15" Then txtData0.Text = Hex(14)
        If CmbIHCHN.Text = "Channel 16" Then txtData0.Text = Hex(15)
    End Sub

    Private Sub txtIHDC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIHDC.TextChanged
        If txtIHDC.Text = "" Or txtIHDC.Text = "False" Then Exit Sub
        txtData1.Text = Hex(txtIHDC.Text)
        ' End If

    End Sub

    Private Sub cmdSendBHH_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendBHH.Click
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT " & "Duty Cycle: " & CStr(txtData1.Text) & "HEX  " & CInt("&H" & txtData1.Text) & "INT")
            IncludeTextMessage("TO Bond Head Heater " & "Channel#: " & CInt("&H" & txtData0.Text))
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        ''Check for faults 
        txtID.Text = "10051112"
        autoSend()
        DisplayMessages()
        'txtData0.Text = "00"
        'txtData1.Text = "00"
        txtBHHDC.Text = ""
        txtIHDC.Text = ""
        If CmBIond.Text = "Duty Cycle Adjust" Or CmBBond.Text = "Duty Cycle Adjust" Then txtID.Text = "10011112"

    End Sub

    Private Sub cmdSendIH_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendIH.Click
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT " & "Duty Cycle: " & CStr(txtData1.Text) & "HEX  " & CInt("&H" & txtData1.Text) & "INT")
            IncludeTextMessage("TO Index Heater " & "Channel#: " & CInt("&H" & txtData0.Text))
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        ''Check for faults 
        txtID.Text = "10051112"
        autoSend()
        'txtData0.Text = "00"
        txtData1.Text = "00"
        txtBHHDC.Text = ""
        txtIHDC.Text = ""
        If CmBIond.Text = "Duty Cycle Adjust" Or CmBBond.Text = "Duty Cycle Adjust" Then txtID.Text = "10011112"

    End Sub

    Private Sub cmdPWMDIO_Click(sender As System.Object, e As System.EventArgs) Handles cmdPWMDIO.Click
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        chbExtended.CheckState = CheckState.Checked
        txtID.Text = "10031112"
        txtData0.Text = Hex(0)
        txtData1.Text = Hex(0)

        If cmdPWMDIO.Text = "PWM DIGITAL I/O" Then
            cmdPWMDIO.Text = "PWM DIGITAL I/O ON"
            txtData0.Text = Hex(255)
        ElseIf cmdPWMDIO.Text = "PWM DIGITAL I/O ON" Then
            cmdPWMDIO.Text = "PWM DIGITAL I/O OFF"
            txtData0.Text = Hex(0)
        ElseIf cmdPWMDIO.Text = "PWM DIGITAL I/O OFF" Then
            cmdPWMDIO.Text = "PWM DIGITAL I/O ON"
            txtData0.Text = Hex(255)
        End If

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT")
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        ''Check for faults from unit fault pins 
        txtID.Text = "10051112"
        autoSend()

    End Sub

    Private Sub cmdDIO_Click(sender As System.Object, e As System.EventArgs) Handles cmdDIO.Click
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        chbExtended.CheckState = CheckState.Checked
        txtID.Text = "10041112"
        'txtData0.Text = Hex(0)
        txtData1.Text = Hex(0)

        If cmdDIO.Text = "DIGITAL I/O" Then
            cmdDIO.Text = "DIGITAL I/O ON"
            txtData1.Text = Hex(255)
        ElseIf cmdDIO.Text = "DIGITAL I/O ON" Then
            cmdDIO.Text = "DIGITAL I/O OFF"
            txtData1.Text = Hex(0)
        ElseIf cmdDIO.Text = "DIGITAL I/O OFF" Then
            cmdDIO.Text = "DIGITAL I/O ON"
            txtData1.Text = Hex(255)
        End If

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT")
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
        ''Check for faults 
        txtID.Text = "10051112"
        autoSend()
    End Sub

    Public Sub autoSend()
        Dim CANMsg As TPCANMsg
        Dim txtbCurrentTextBox As TextBox
        Dim stsResult As TPCANStatus

        ' We create a TCLightMsg message structure 
        '
        CANMsg = New TPCANMsg()
        CANMsg.DATA = New Byte(7) {}

        ' We configurate the Message.  The ID (max 0x1FF),
        ' Length of the Data, Message Type (Standard in 
        ' this example) and die data
        '
        CANMsg.ID = Convert.ToUInt32(txtID.Text, 16)
        CANMsg.LEN = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = IIf((chbExtended.Checked), TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
        ' If a remote frame will be sent, the data bytes are not important.
        '
        If chbRemote.Checked Then
            CANMsg.MSGTYPE = CANMsg.MSGTYPE Or TPCANMessageType.PCAN_MESSAGE_RTR
        Else
            ' We get so much data as the Len of the message
            '
            txtbCurrentTextBox = txtData0
            For i As Integer = 0 To CANMsg.LEN - 1
                CANMsg.DATA(i) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
                If i < 7 Then
                    txtbCurrentTextBox = DirectCast(Me.GetNextControl(txtbCurrentTextBox, True), TextBox)
                End If
            Next
        End If

        ' The message is sent to the configured hardware
        '
        stsResult = PCANBasic.Write(m_PcanHandle, CANMsg)

        ' The Hardware was successfully sent
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("Message was successfully SENT" & "Error ?: " & CStr(txtData0.Text))
            If CInt("&H" & txtData0.Text) > 0 Then IncludeTextMessage("There is a Fault Condition: " & txtData0.Text)
            If CInt("&H" & txtData0.Text) = 1 Then IncludeTextMessage("INDEX HEATER ONLY")
            If CInt("&H" & txtData0.Text) = 2 Then IncludeTextMessage("BOND HEAD HEATER ONLY")
            If CInt("&H" & txtData0.Text) = 3 Then IncludeTextMessage("INDEX HEATER And BOND HEAD HEATER. Check connections")
        Else
            ' An error occurred.  We show the error.
            '			
            MessageBox.Show(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub CmbENABLE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbENABLE.SelectedIndexChanged
        'Dim IH As Integer, BBH1 As Integer, BBH2 As Integer, FH1 As Integer, FH2 As Integer
        cmdDIO.ResetText()
        cmdDIO.Text = "DIGITAL I/O"
        If CmbENABLE.Text = "Enable Index Heater" Then txtData0.Text = Hex(0)
        If CmbENABLE.Text = "Enable BBH 1" Then txtData0.Text = Hex(1)
        If CmbENABLE.Text = "Enable BBH 2" Then txtData0.Text = Hex(2)
        If CmbENABLE.Text = "Enable Heater Fault 1" Then txtData0.Text = Hex(3)
        If CmbENABLE.Text = "Enable Heater Fault 2" Then txtData0.Text = Hex(4)
        If CmbENABLE.Text = "Channel 6" Then txtData0.Text = Hex(5)
        If CmbENABLE.Text = "Channel 7" Then txtData0.Text = Hex(6)

    End Sub


    Private Sub txtID_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtID.TextChanged
        chbExtended.CheckState = CheckState.Checked
    End Sub
    Public Sub FileToArray(ByVal FileName As String, _
    ByRef TheArray As Object)

    End Sub

    Private Sub btnSA_Click(sender As System.Object, e As System.EventArgs) Handles btnSA.Click
        Dim SArray() As String
        Dim f As Integer

        txtID.Text = "10011112"
        ReDim SArray(UBound(txtALLC.Lines))

        For f = 0 To UBound(txtALLC.Lines)
            SArray(f) = txtALLC.Lines(f)
            'txtData0.Text = Hex(SArray(f))
            'txtData1.Text = Hex(txtALLDuty.Text)
            'Call autoSend()
            Debug.Print(SArray(f))
        Next


        For Each inp As String In SArray
            txtData0.Text = Hex(inp)
            txtID.Text = "10011112"
            txtData1.Text = Hex(txtALLDuty.Text)
            Call autoSend()
        Next

        'txtALLC.Text = ""
        txtData0.Text = "00"
        txtData1.Text = "00"
    End Sub
    Private Sub MenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
    Private Sub runRecipe()
        Dim arrName() As String
        Dim arrValue() As String
        Dim DCValue() As String
        Dim tmr As Integer
        Static Dim howlong As New Stopwatch


        Using ioReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\tdi\KandS_Recipe.csv")

            ioReader.TextFieldType = FileIO.FieldType.Delimited
            ioReader.SetDelimiters(",")

            While Not ioReader.EndOfData And Recipe = True

                Dim arrCurrentRow As String() = ioReader.ReadFields()

                If arrName Is Nothing Then

                    ReDim Preserve arrName(0)
                    ReDim Preserve arrValue(0)
                    ReDim Preserve DCValue(0)

                    arrName(0) = arrCurrentRow(0)
                    arrValue(0) = arrCurrentRow(1)
                    DCValue(0) = arrCurrentRow(2)

                Else

                    ReDim Preserve arrName(arrName.Length)
                    ReDim Preserve arrValue(arrValue.Length)
                    ReDim Preserve DCValue(DCValue.Length)

                    tmr = CInt(arrName((arrName.Length - 1)) = arrCurrentRow(0))
                    tmr = CInt(arrCurrentRow(0))
                    arrValue((arrValue.Length - 1)) = arrCurrentRow(1)
                    txtData0.Text = Hex(arrCurrentRow(1))
                    txtIHDC.Text = DCValue((DCValue.Length - 1)) = arrCurrentRow(2)
                    txtData1.Text = Hex(arrCurrentRow(2))
                    'Load Duty Cycle send variables
                    txtID.Text = "10011112" 'send duty cycle cmd
                    autoSend()
                    howlong.Start()
                    Console.WriteLine(howlong.ElapsedMilliseconds)
                    Console.WriteLine(DateTime.Now.ToLongTimeString)
                    Do While howlong.Elapsed.TotalMinutes < tmr And Recipe = True
                        IncludeTextMessage("Recipe Running: " & howlong.Elapsed.ToString())
                        'autoSend()
                    Loop
                    howlong.Stop()
                End If

            End While
        End Using
    End Sub

    Private Sub CustomizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomizeToolStripMenuItem.Click
        Static Dim howlong As New Stopwatch
        Dim Task1 As New System.Threading.Thread(AddressOf runRecipe)

        MsgBox("Other Controls may not function during Recipe run")
        Recipe = True
        'Task1.Start(Sub()
        runRecipe()
        'End Sub)
        Console.WriteLine("Recipe Completed Sucssesfully!")

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim Task2 As New System.Threading.Thread(AddressOf runRecipe)


        Recipe = False
        'Task2.Start(Sub()
        runRecipe()
        'End Sub)
        Console.WriteLine("Recipe Stopped!")

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("K & S Home Grown Controllor Version: 1" & vbCrLf _
        & "AstrodynTDI SW#: T100106228-LF" & vbCrLf _
        & "Based on PCANBasic Example, Peak Systems" & vbCrLf _
        & "Released By: Joe Lockhart 4/09/2015")
    End Sub

    'Public Shared Function Run(action As Action) As Task

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        ' Specify the directories you want to manipulate.
        Dim di As DirectoryInfo = New DirectoryInfo("c:\TDI\KandS_Recipe.csv")
        Try
            ' Determine whether the directory exists.
            If di.Exists Then
                ' Indicate that it already exists.
                Console.WriteLine("That path exists already.")
                FileOpen(1, "KandS_Recipe.csv", OpenMode.Output, OpenAccess.Default, OpenShare.Default, 1)
                Return
            End If

            ' Try to create the directory.
            di.Create()
            Console.WriteLine("The directory was created successfully.")
            FileOpen(1, "KandS_Recipe.csv", OpenMode.Output, OpenAccess.Default, OpenShare.Default, 1)
            ' Delete the directory.
            di.Delete()
            Console.WriteLine("The directory was deleted successfully.")

        Catch x As Exception
            Console.WriteLine("The process failed: {0}", x.ToString())
            Exit Sub
        End Try

        'User can now view and edit file.
        FileOpen(1, "KandS_Recipe.csv", OpenMode.Output, OpenAccess.Default, OpenShare.Default, 1)
        Dim Recipe As New ProcessStartInfo("c:\TDI\KandS_Recipe.csv")
        With Recipe
            .FileName = "c:\TDI\KandS_Recipe.csv"
            .UseShellExecute = True
            Recipe.WindowStyle = ProcessWindowStyle.Normal
            'StartInfo = Recipe
        End With
        Process.Start("c:\TDI\KandS_Recipe.csv")




    End Sub

    Private Sub BenchVueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BenchVueToolStripMenuItem.Click
        If System.IO.File.Exists("C:\Program Files (x86)\Keysight\BenchVue\Applications\BenchVue\Keysight BenchVue.exe") = True Then
            Process.Start("C:\Program Files (x86)\Keysight\BenchVue\Applications\BenchVue\Keysight BenchVue.exe")
        Else
            MsgBox("Please Install Keysight BenchVue Software")
        End If


    End Sub
End Class