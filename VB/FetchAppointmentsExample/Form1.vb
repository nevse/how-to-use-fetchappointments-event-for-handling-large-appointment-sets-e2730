Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.OleDb
#Region "#usings"
Imports DevExpress.XtraScheduler
#End Region ' #usings

Namespace FetchAppointmentsExample
	Partial Public Class Form1
		Inherits Form
		Private lastFetchedInterval As New TimeInterval()

		Public Sub New()
			InitializeComponent()
			AddHandler carSchedulingTableAdapter.Adapter.RowUpdated, AddressOf carSchedulingTableAdapter_RowUpdated

			AddHandler schedulerStorage1.FetchAppointments, AddressOf schedulerStorage1_FetchAppointments

		End Sub
		#Region "#fetchappointments"
		Private Sub schedulerStorage1_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
			Dim start As DateTime = e.Interval.Start
			Dim [end] As DateTime = e.Interval.End
			' Specify the time range to pad the queried time interval
			Dim padding As TimeSpan = TimeSpan.FromDays(7)

			' Check if the requested interval is outside the lastFetchedInterval
			If start <= lastFetchedInterval.Start OrElse [end] >= lastFetchedInterval.End Then
				lastFetchedInterval = New TimeInterval(start.Subtract(padding), [end].Add(padding))
				carSchedulingTableAdapter.FillBy(Me.carsDBDataSet.CarScheduling, lastFetchedInterval.Start, lastFetchedInterval.End)
				' Watch the queried time range and the number of rows in a resulting table
				Console.WriteLine(start & " / " & [end])
				Console.WriteLine(Me.carsDBDataSet.CarScheduling.Count.ToString())
			End If
		End Sub
		#End Region ' #fetchappointments

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
			Me.carsTableAdapter.Fill(Me.carsDBDataSet.Cars)
			' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
			Me.carSchedulingTableAdapter.Fill(Me.carsDBDataSet.CarScheduling)

		End Sub

		Private Sub OnApptChangedInsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			carSchedulingTableAdapter.Update(carsDBDataSet)
			carsDBDataSet.AcceptChanges()
		End Sub

		Private Sub carSchedulingTableAdapter_RowUpdated(ByVal sender As Object, ByVal e As OleDbRowUpdatedEventArgs)
			If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
				Dim id As Integer = 0
				Using cmd As New OleDbCommand("SELECT @@IDENTITY", carSchedulingTableAdapter.Connection)
					id = CInt(Fix(cmd.ExecuteScalar()))
				End Using
				e.Row("ID") = id
			End If
		End Sub

	End Class
End Namespace