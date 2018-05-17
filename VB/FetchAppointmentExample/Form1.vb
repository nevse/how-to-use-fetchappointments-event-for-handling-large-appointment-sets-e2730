Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports System.Data.SqlClient

Namespace FetchAppointmentExample
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        ' The counter used to display the number of fetches.
        Public Shared queryExecutionCounter As Integer

        #Region "#lastfetchedinterval"
        Private Const PADDING_DAYS As Integer = 7
        #End Region ' #lastfetchedinterval

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Me.resourcesTableAdapter.Fill(scheduleTestDataSet.Resources)
            Me.appointmentsTableAdapter.Fill(scheduleTestDataSet.Appointments)
            If (scheduleTestDataSet.Resources.Rows.Count = 0) OrElse (scheduleTestDataSet.Appointments.Rows.Count = 0) Then
                CreateSampleData()
            End If

            AddHandler schedulerStorage1.AppointmentsChanged, AddressOf OnApptChangedInsertedDeleted
            AddHandler schedulerStorage1.AppointmentsInserted, AddressOf OnApptChangedInsertedDeleted
            AddHandler schedulerStorage1.AppointmentsDeleted, AddressOf OnApptChangedInsertedDeleted

            AddHandler schedulerControl1.VisibleIntervalChanged, AddressOf schedulerControl1_VisibleIntervalChanged
            AddHandler schedulerControl1.VisibleResourcesChanged, AddressOf SchedulerControl1_VisibleResourcesChanged

            schedulerControl1.Start = Date.Today
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.ActiveView.ResourcesPerPage = 1

            UpdateStatisticsInformationDisplayedOnTheForm()
        End Sub

        #Region "#fetchappointments"
        Private Sub schedulerStorage1_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim resourcesVisible As New ResourceBaseCollection() With {.Capacity = schedulerControl1.ActiveView.ResourcesPerPage}
            For i As Integer = 0 To schedulerControl1.ActiveView.ResourcesPerPage - 1
                resourcesVisible.Add(schedulerStorage1.Resources(schedulerControl1.ActiveView.FirstVisibleResourceIndex + i))
            Next i

            QueryAppointmentDataSource(e, resourcesVisible)
        End Sub

        Private Sub QueryAppointmentDataSource(ByVal e As FetchAppointmentsEventArgs, ByVal resources As ResourceBaseCollection)
            Dim resListString As String = String.Join(",", resources.Select(Function(res) res.Id.ToString()))
            ' Modify the FillBy query to fetch appointments only for the specified resources. 
            appointmentsTableAdapter.Commands(1).CommandText = String.Format("SELECT Appointments.* FROM Appointments WHERE (OriginalOccurrenceStart >= @Start) AND(OriginalOccurrenceEnd <= @End) AND (ResourceID IN ({0})) OR (Type != 0)", resListString)
            appointmentsTableAdapter.FillBy(Me.scheduleTestDataSet.Appointments, e.Interval.Start.AddDays(-PADDING_DAYS), e.Interval.End.AddDays(PADDING_DAYS))

            queryExecutionCounter += 1
        End Sub
        #End Region ' #fetchappointments

        Private Sub OnApptChangedInsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            Me.appointmentsTableAdapter.Update(scheduleTestDataSet)
            Me.scheduleTestDataSet.AcceptChanges()
        End Sub

        Private Sub UpdateStatisticsInformationDisplayedOnTheForm()
            lblInfo.Text = String.Format("FetchAppointment query has been executed {0} times," & ControlChars.CrLf & "data set contains {1} appointments.", queryExecutionCounter, Me.scheduleTestDataSet.Appointments.Count)
        End Sub
        Private Sub schedulerControl1_VisibleIntervalChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateStatisticsInformationDisplayedOnTheForm()
        End Sub
        Private Sub SchedulerControl1_VisibleResourcesChanged(ByVal sender As Object, ByVal args As VisibleResourcesChangedEventArgs)
            UpdateStatisticsInformationDisplayedOnTheForm()
        End Sub


        ' Fills the Scheduler with resources and appointments.
        Private Sub CreateSampleData()
            SchedulerHelper.FillResources(Me.schedulerStorage1, 17)
            Me.resourcesTableAdapter.Update(scheduleTestDataSet)
            SchedulerHelper.GenerateAppointments(Me.schedulerStorage1, 150)
            BulkUpdateAppointmentsTable()
            Me.scheduleTestDataSet.AcceptChanges()
            Me.appointmentsTableAdapter.Fill(Me.scheduleTestDataSet.Appointments)
        End Sub

        ' Performs a bulk insert which is much faster than calling the appointmentsTableAdapter.Update. 
        ' The appointmentsTableAdapter.Update method has low performance 
        ' because it updates one row at at time, executes Select query to obtain the identity value for each row 
        ' and writes to the transaction log.
        ' The BulkUpdateAppointmentsTable method does not retrieve ID values, 
        ' so the appointmentsTableAdapter.Fill method should be called subsequently.        
        Private Sub BulkUpdateAppointmentsTable()
            Using connection As New SqlConnection(My.Settings.Default.ScheduleTestConnectionString)
                connection.Open()
                Dim transaction As SqlTransaction = connection.BeginTransaction()

                Using bulkCopy As New SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)
                    bulkCopy.BatchSize = 100
                    bulkCopy.DestinationTableName = "dbo.Appointments"
                    Try
                        bulkCopy.WriteToServer(scheduleTestDataSet.Appointments)
                    Catch e1 As Exception
                        transaction.Rollback()
                    End Try
                End Using
                transaction.Commit()
            End Using
        End Sub

        Private Sub cbFetchAppointments_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbFetchAppointments.CheckedChanged
            If cbFetchAppointments.Checked Then
                schedulerStorage1.EnableSmartFetch = False
                AddHandler schedulerStorage1.FetchAppointments, AddressOf schedulerStorage1_FetchAppointments
            Else
                RemoveHandler schedulerStorage1.FetchAppointments, AddressOf schedulerStorage1_FetchAppointments
                Me.resourcesTableAdapter.Fill(scheduleTestDataSet.Resources)
                Me.appointmentsTableAdapter.Fill(scheduleTestDataSet.Appointments)
                schedulerStorage1.EnableSmartFetch = True
            End If
        End Sub
        Private Sub cbBoldAppointmentDates_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbBoldAppointmentDates.CheckedChanged
            If cbBoldAppointmentDates.Checked Then
                dateNavigator1.BoldAppointmentDates = True
            Else
                dateNavigator1.BoldAppointmentDates = False
            End If
            dateNavigator1.Refresh()
        End Sub
    End Class
End Namespace
