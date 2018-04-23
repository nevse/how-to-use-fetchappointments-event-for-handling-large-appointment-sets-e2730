#Region "#usings"
Imports DevExpress.XtraScheduler
Imports System
Imports System.Windows.Forms
#End Region ' #usings

Namespace FetchAppointmentExample
    Partial Public Class Form1
        Inherits Form

        Public Shared RandomInstance As New Random()

        #Region "#lastfetchedinterval"
        Private lastFetchedInterval As New TimeInterval()
        #End Region ' #lastfetchedinterval

        Public Sub New()
            InitializeComponent()

            schedulerControl1.GroupType = SchedulerGroupType.Resource

            AddHandler schedulerControl1.VisibleIntervalChanged, AddressOf schedulerControl1_VisibleIntervalChanged

            AddHandler schedulerStorage1.AppointmentsChanged, AddressOf OnApptChangedInsertedDeleted
            AddHandler schedulerStorage1.AppointmentsInserted, AddressOf OnApptChangedInsertedDeleted
            AddHandler schedulerStorage1.AppointmentsDeleted, AddressOf OnApptChangedInsertedDeleted

            AddHandler schedulerStorage1.FetchAppointments, AddressOf schedulerStorage1_FetchAppointments
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' TODO: This line of code loads data into the 'scheduleTestDataSet.Resources' table. You can move, or remove it, as needed.
            Me.resourcesTableAdapter.Fill(Me.scheduleTestDataSet.Resources)
            'GenerateEvents(schedulerStorage1);
            ' TODO: This line of code loads data into the 'scheduleTestDataSet.Appointments' table. You can move, or remove it, as needed.
            'this.appointmentsTableAdapter.Fill(this.scheduleTestDataSet.Appointments);

            schedulerControl1.Start = New Date(2014, 03, 18)
            UpdateLblInfo()

        End Sub

        Private Sub OnApptChangedInsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            Me.appointmentsTableAdapter.Update(scheduleTestDataSet)
            Me.scheduleTestDataSet.AcceptChanges()
        End Sub

        #Region "#fetchappointments"
        Private Sub schedulerStorage1_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim start As Date = e.Interval.Start
            Dim [end] As Date = e.Interval.End
            ' Specify the time range to pad the queried time interval. 
            ' You can vary it find the balance between performance and detalization. 

            Dim padding_Renamed As TimeSpan = TimeSpan.FromDays(7)

            ' Check if the requested interval is outside the lastFetchedInterval.
            If start <= lastFetchedInterval.Start OrElse [end] >= lastFetchedInterval.End Then
                lastFetchedInterval = New TimeInterval(start.Subtract(padding_Renamed), [end].Add(padding_Renamed))
                appointmentsTableAdapter.FillBy(Me.scheduleTestDataSet.Appointments, lastFetchedInterval.Start, lastFetchedInterval.End)
            End If
        End Sub
        #End Region ' #fetchappointments

        Private Sub cbBoldAppointmentDates_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbBoldAppointmentDates.CheckedChanged
            dateNavigator1.BoldAppointmentDates = cbBoldAppointmentDates.Checked
            UpdateLblInfo()
        End Sub

        Private Sub schedulerControl1_VisibleIntervalChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateLblInfo()
        End Sub

        Private Sub UpdateLblInfo()
            lblInfo.Text = String.Format("Interval: {0}, Appointments: {1}", lastFetchedInterval, Me.scheduleTestDataSet.Appointments.Count)
        End Sub
    End Class
End Namespace
