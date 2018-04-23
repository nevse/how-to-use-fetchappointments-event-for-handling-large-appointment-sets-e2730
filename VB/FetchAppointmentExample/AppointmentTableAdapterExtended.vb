Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace FetchAppointmentExample.ScheduleTestDataSetTableAdapters
    #Region "#AppointmentsTableAdapterEx"
    Partial Public Class AppointmentsTableAdapter
        Public ReadOnly Property Commands() As System.Data.SqlClient.SqlCommand()
            Get
                Return Me._commandCollection
            End Get
        End Property
    End Class
    #End Region ' #AppointmentsTableAdapterEx
End Namespace
