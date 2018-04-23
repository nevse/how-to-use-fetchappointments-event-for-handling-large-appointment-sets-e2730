Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace FetchAppointmentExample
    Friend Class SchedulerHelper
        Private Const DAY_COUNT As Integer = 100
        Private Shared resources() As String = {"Peter Dolan", "Ryan Fischer", "Richard Fisher", "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"}

        Private Shared subjects() As String = { "Meeting", "Phone call", "Travel", "One more meeting", "One more phone call", "One more travel" }

        Public Shared Sub FillResources(ByVal storage As ISchedulerStorage, ByVal count As Integer)
            Dim resources As ResourceCollection = storage.Resources.Items
            storage.BeginUpdate()
            Try
                Dim cnt As Integer = Math.Min(count, SchedulerHelper.resources.Length)
                For i As Integer = 1 To cnt
                    Dim resource As Resource = storage.CreateResource(i)
                    resource.Caption = SchedulerHelper.resources(i - 1)
                    resources.Add(resource)
                Next i
            Finally
                storage.EndUpdate()
            End Try
        End Sub

        Public Shared Sub GenerateAppointments(ByVal storage As ISchedulerStorage, ByVal aptsPerDay As Integer)
            storage.BeginUpdate()
            Dim rnd As New Random()
            Dim start As Date = Date.Today.AddDays(-DAY_COUNT \ 2)
            For i As Integer = 0 To DAY_COUNT * aptsPerDay
                storage.Appointments.Add(CreateNewAppointment(storage, i, aptsPerDay, rnd, start))
            Next i
            storage.EndUpdate()
        End Sub

        Private Shared Function GetRandomDouble(ByVal rnd As Random, ByVal min As Double, ByVal max As Double) As Double
            Return min + (max - min) * rnd.NextDouble()
        End Function

        Private Shared Function CreateNewAppointment(ByVal storage As ISchedulerStorage, ByVal index As Integer, ByVal aptsPerDay As Integer, ByVal rnd As Random, ByVal start As Date) As Appointment
            Dim day As Integer = index \ aptsPerDay

            Dim apt As Appointment = storage.CreateAppointment(AppointmentType.Normal)
            apt.SetId(index + 1)
            apt.Start = start.AddDays(day).AddHours(GetRandomDouble(rnd, 0, 18))
            apt.End = apt.Start.AddHours(GetRandomDouble(rnd, 0.5, 6.0))
            Dim subjectIndex As Integer = rnd.Next(0, subjects.Length)
            apt.Subject = subjects(subjectIndex)
            apt.LabelKey = rnd.Next(1, 12)
            apt.ResourceId = rnd.Next(0, resources.Length)
            Return apt
        End Function

    End Class
End Namespace
