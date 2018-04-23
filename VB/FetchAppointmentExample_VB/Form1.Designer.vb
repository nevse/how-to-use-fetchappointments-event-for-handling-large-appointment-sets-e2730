Partial Public Class Form1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.appointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.scheduleTestDataSet = New FetchAppointmentExample_VB.ScheduleTestDataSet()
        Me.resourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.appointmentsTableAdapter = New FetchAppointmentExample_VB.ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter()
        Me.resourcesTableAdapter = New FetchAppointmentExample_VB.ScheduleTestDataSetTableAdapters.ResourcesTableAdapter()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cbBoldAppointmentDates = New System.Windows.Forms.CheckBox()
        Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scheduleTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'schedulerControl1
        '
        Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.schedulerControl1.Location = New System.Drawing.Point(0, 42)
        Me.schedulerControl1.Name = "schedulerControl1"
        Me.schedulerControl1.Size = New System.Drawing.Size(646, 521)
        Me.schedulerControl1.Start = New Date(2014, 3, 17, 0, 0, 0, 0)
        Me.schedulerControl1.Storage = Me.schedulerStorage1
        Me.schedulerControl1.TabIndex = 0
        Me.schedulerControl1.Text = "schedulerControl1"
        Me.schedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.schedulerControl1.Views.GanttView.Enabled = False
        Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler2)
        '
        'schedulerStorage1
        '
        Me.schedulerStorage1.Appointments.DataSource = Me.appointmentsBindingSource
        Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
        Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
        Me.schedulerStorage1.Appointments.Mappings.End = "EndDate"
        Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
        Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
        Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
        Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
        Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID"
        Me.schedulerStorage1.Appointments.Mappings.Start = "StartDate"
        Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
        Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
        Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
        Me.schedulerStorage1.Resources.DataSource = Me.resourcesBindingSource
        Me.schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
        Me.schedulerStorage1.Resources.Mappings.Color = "Color"
        Me.schedulerStorage1.Resources.Mappings.Id = "ResourceID"
        Me.schedulerStorage1.Resources.Mappings.Image = "Image"
        Me.schedulerStorage1.Resources.Mappings.ParentId = "UniqueID"
        '
        'appointmentsBindingSource
        '
        Me.appointmentsBindingSource.DataMember = "Appointments"
        Me.appointmentsBindingSource.DataSource = Me.scheduleTestDataSet
        '
        'scheduleTestDataSet
        '
        Me.scheduleTestDataSet.DataSetName = "ScheduleTestDataSet"
        Me.scheduleTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'resourcesBindingSource
        '
        Me.resourcesBindingSource.DataMember = "Resources"
        Me.resourcesBindingSource.DataSource = Me.scheduleTestDataSet
        '
        'appointmentsTableAdapter
        '
        Me.appointmentsTableAdapter.ClearBeforeFill = True
        '
        'resourcesTableAdapter
        '
        Me.resourcesTableAdapter.ClearBeforeFill = True
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.lblInfo)
        Me.panel1.Controls.Add(Me.cbBoldAppointmentDates)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(825, 42)
        Me.panel1.TabIndex = 1
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(306, 13)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(0, 13)
        Me.lblInfo.TabIndex = 1
        '
        'cbBoldAppointmentDates
        '
        Me.cbBoldAppointmentDates.AutoSize = True
        Me.cbBoldAppointmentDates.Location = New System.Drawing.Point(13, 13)
        Me.cbBoldAppointmentDates.Name = "cbBoldAppointmentDates"
        Me.cbBoldAppointmentDates.Size = New System.Drawing.Size(206, 17)
        Me.cbBoldAppointmentDates.TabIndex = 0
        Me.cbBoldAppointmentDates.Text = "DateNavigator.BoldAppointmentDates"
        Me.cbBoldAppointmentDates.UseVisualStyleBackColor = True
        '
        'dateNavigator1
        '
        Me.dateNavigator1.BoldAppointmentDates = False
        Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
        Me.dateNavigator1.HotDate = Nothing
        Me.dateNavigator1.Location = New System.Drawing.Point(646, 42)
        Me.dateNavigator1.Name = "dateNavigator1"
        Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
        Me.dateNavigator1.Size = New System.Drawing.Size(179, 521)
        Me.dateNavigator1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 563)
        Me.Controls.Add(Me.schedulerControl1)
        Me.Controls.Add(Me.dateNavigator1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.scheduleTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
    Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Private scheduleTestDataSet As ScheduleTestDataSet
    Private appointmentsBindingSource As System.Windows.Forms.BindingSource
    Private appointmentsTableAdapter As ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter
    Private resourcesBindingSource As System.Windows.Forms.BindingSource
    Private resourcesTableAdapter As ScheduleTestDataSetTableAdapters.ResourcesTableAdapter
    Private panel1 As System.Windows.Forms.Panel
    Private WithEvents cbBoldAppointmentDates As System.Windows.Forms.CheckBox
    Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Private lblInfo As System.Windows.Forms.Label
End Class