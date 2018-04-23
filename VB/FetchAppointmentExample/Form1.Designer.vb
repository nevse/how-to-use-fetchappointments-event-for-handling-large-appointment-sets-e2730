Namespace FetchAppointmentExample
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
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler3 As New DevExpress.XtraScheduler.TimeRuler()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.cbFetchAppointments = New DevExpress.XtraEditors.CheckEdit()
            Me.lblInfo = New DevExpress.XtraEditors.LabelControl()
            Me.cbBoldAppointmentDates = New DevExpress.XtraEditors.CheckEdit()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.appointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.scheduleTestDataSet = New FetchAppointmentExample.ScheduleTestDataSet()
            Me.resourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.appointmentsTableAdapter = New FetchAppointmentExample.ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter()
            Me.resourcesTableAdapter = New FetchAppointmentExample.ScheduleTestDataSetTableAdapters.ResourcesTableAdapter()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            DirectCast(Me.cbFetchAppointments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.cbBoldAppointmentDates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.scheduleTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.cbFetchAppointments)
            Me.panelControl1.Controls.Add(Me.lblInfo)
            Me.panelControl1.Controls.Add(Me.cbBoldAppointmentDates)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(848, 53)
            Me.panelControl1.TabIndex = 0
            ' 
            ' cbFetchAppointments
            ' 
            Me.cbFetchAppointments.Location = New System.Drawing.Point(12, 16)
            Me.cbFetchAppointments.Name = "cbFetchAppointments"
            Me.cbFetchAppointments.Properties.Caption = "FetchAppointments Event"
            Me.cbFetchAppointments.Size = New System.Drawing.Size(153, 19)
            Me.cbFetchAppointments.TabIndex = 2
            ' 
            ' lblInfo
            ' 
            Me.lblInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
            Me.lblInfo.Location = New System.Drawing.Point(466, 12)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(370, 13)
            Me.lblInfo.TabIndex = 1
            Me.lblInfo.Text = "lblInfo"
            Me.lblInfo.UseMnemonic = False
            ' 
            ' cbBoldAppointmentDates
            ' 
            Me.cbBoldAppointmentDates.AutoSizeInLayoutControl = True
            Me.cbBoldAppointmentDates.Location = New System.Drawing.Point(202, 16)
            Me.cbBoldAppointmentDates.Name = "cbBoldAppointmentDates"
            Me.cbBoldAppointmentDates.Properties.AutoWidth = True
            Me.cbBoldAppointmentDates.Properties.Caption = "DateNavigator.BoldAppointmentDates"
            Me.cbBoldAppointmentDates.Size = New System.Drawing.Size(205, 19)
            Me.cbBoldAppointmentDates.TabIndex = 0
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.DataStorage = Me.schedulerStorage1
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 53)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(628, 515)
            Me.schedulerControl1.Start = New Date(2017, 3, 21, 0, 0, 0, 0)
            Me.schedulerControl1.TabIndex = 1
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.FullWeekView.Enabled = True
            Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2)
            Me.schedulerControl1.Views.MonthView.Enabled = False
            Me.schedulerControl1.Views.WeekView.Enabled = False
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Appointments.DataSource = Me.appointmentsBindingSource
            Me.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueID"
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.End = "EndDate"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceEnd = "OriginalOccurrenceEnd"
            Me.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceStart = "OriginalOccurrenceStart"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartDate"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId"
            Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
            Me.schedulerStorage1.Resources.DataSource = Me.resourcesBindingSource
            Me.schedulerStorage1.Resources.Mappings.Caption = "ResourceName"
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "ResourceID"
            Me.schedulerStorage1.Resources.Mappings.Image = "Image"
            ' 
            ' appointmentsBindingSource
            ' 
            Me.appointmentsBindingSource.DataMember = "Appointments"
            Me.appointmentsBindingSource.DataSource = Me.scheduleTestDataSet
            ' 
            ' scheduleTestDataSet
            ' 
            Me.scheduleTestDataSet.DataSetName = "ScheduleTestDataSet"
            Me.scheduleTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' resourcesBindingSource
            ' 
            Me.resourcesBindingSource.DataMember = "Resources"
            Me.resourcesBindingSource.DataSource = Me.scheduleTestDataSet
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.AllowAnimatedContentChange = True
            Me.dateNavigator1.BoldAppointmentDates = False
            Me.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold
            Me.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = True
            Me.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dateNavigator1.Cursor = System.Windows.Forms.Cursors.Default
            Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
            Me.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday
            Me.dateNavigator1.Location = New System.Drawing.Point(628, 53)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(220, 515)
            Me.dateNavigator1.TabIndex = 2
            ' 
            ' defaultLookAndFeel1
            ' 
            Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful"
            ' 
            ' appointmentsTableAdapter
            ' 
            Me.appointmentsTableAdapter.ClearBeforeFill = True
            ' 
            ' resourcesTableAdapter
            ' 
            Me.resourcesTableAdapter.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(848, 568)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "FetchAppointment Example"
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            DirectCast(Me.cbFetchAppointments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.cbBoldAppointmentDates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.appointmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.scheduleTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.resourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private panelControl1 As DevExpress.XtraEditors.PanelControl
        Private WithEvents cbBoldAppointmentDates As DevExpress.XtraEditors.CheckEdit
        Private lblInfo As DevExpress.XtraEditors.LabelControl
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private scheduleTestDataSet As ScheduleTestDataSet
        Private appointmentsBindingSource As System.Windows.Forms.BindingSource
        Private appointmentsTableAdapter As ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter
        Private resourcesBindingSource As System.Windows.Forms.BindingSource
        Private resourcesTableAdapter As ScheduleTestDataSetTableAdapters.ResourcesTableAdapter
        Private WithEvents cbFetchAppointments As DevExpress.XtraEditors.CheckEdit
    End Class
End Namespace

