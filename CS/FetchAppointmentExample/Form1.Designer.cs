namespace FetchAppointmentExample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbFetchAppointments = new DevExpress.XtraEditors.CheckEdit();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.cbBoldAppointmentDates = new DevExpress.XtraEditors.CheckEdit();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scheduleTestDataSet = new FetchAppointmentExample.ScheduleTestDataSet();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.appointmentsTableAdapter = new FetchAppointmentExample.ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter();
            this.resourcesTableAdapter = new FetchAppointmentExample.ScheduleTestDataSetTableAdapters.ResourcesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFetchAppointments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoldAppointmentDates.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbFetchAppointments);
            this.panelControl1.Controls.Add(this.lblInfo);
            this.panelControl1.Controls.Add(this.cbBoldAppointmentDates);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(848, 53);
            this.panelControl1.TabIndex = 0;
            // 
            // cbFetchAppointments
            // 
            this.cbFetchAppointments.Location = new System.Drawing.Point(12, 16);
            this.cbFetchAppointments.Name = "cbFetchAppointments";
            this.cbFetchAppointments.Properties.Caption = "FetchAppointments Event";
            this.cbFetchAppointments.Size = new System.Drawing.Size(153, 19);
            this.cbFetchAppointments.TabIndex = 2;
            this.cbFetchAppointments.CheckedChanged += new System.EventHandler(this.cbFetchAppointments_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblInfo.Location = new System.Drawing.Point(466, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(370, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "lblInfo";
            this.lblInfo.UseMnemonic = false;
            // 
            // cbBoldAppointmentDates
            // 
            this.cbBoldAppointmentDates.AutoSizeInLayoutControl = true;
            this.cbBoldAppointmentDates.Location = new System.Drawing.Point(202, 16);
            this.cbBoldAppointmentDates.Name = "cbBoldAppointmentDates";
            this.cbBoldAppointmentDates.Properties.AutoWidth = true;
            this.cbBoldAppointmentDates.Properties.Caption = "DateNavigator.BoldAppointmentDates";
            this.cbBoldAppointmentDates.Size = new System.Drawing.Size(205, 19);
            this.cbBoldAppointmentDates.TabIndex = 0;
            this.cbBoldAppointmentDates.CheckedChanged += new System.EventHandler(this.cbBoldAppointmentDates_CheckedChanged);
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.DataStorage = this.schedulerStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 53);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(628, 515);
            this.schedulerControl1.Start = new System.DateTime(2017, 3, 21, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 1;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.MonthView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.DataSource = this.appointmentsBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueID";
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceEnd = "OriginalOccurrenceEnd";
            this.schedulerStorage1.Appointments.Mappings.OriginalOccurrenceStart = "OriginalOccurrenceStart";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            this.schedulerStorage1.Resources.DataSource = this.resourcesBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.scheduleTestDataSet;
            // 
            // scheduleTestDataSet
            // 
            this.scheduleTestDataSet.DataSetName = "ScheduleTestDataSet";
            this.scheduleTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.scheduleTestDataSet;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.AllowAnimatedContentChange = true;
            this.dateNavigator1.BoldAppointmentDates = false;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.Location = new System.Drawing.Point(628, 53);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(220, 515);
            this.dateNavigator1.TabIndex = 2;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 568);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "FetchAppointment Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFetchAppointments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoldAppointmentDates.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit cbBoldAppointmentDates;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private ScheduleTestDataSet scheduleTestDataSet;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private ScheduleTestDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private ScheduleTestDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private DevExpress.XtraEditors.CheckEdit cbFetchAppointments;
    }
}

