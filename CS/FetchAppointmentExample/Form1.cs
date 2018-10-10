using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Data.SqlClient;

namespace FetchAppointmentExample {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        // The counter used to display the number of fetches.
        public static int queryExecutionCounter;

        #region #lastfetchedinterval
        const int PADDING_DAYS = 7;
        #endregion #lastfetchedinterval

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.resourcesTableAdapter.Fill(scheduleTestDataSet.Resources);
            this.appointmentsTableAdapter.Fill(scheduleTestDataSet.Appointments);
            if ((scheduleTestDataSet.Resources.Rows.Count == 0) || (scheduleTestDataSet.Appointments.Rows.Count == 0))
                CreateSampleData();

            schedulerStorage1.AppointmentsChanged += OnApptChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnApptChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnApptChangedInsertedDeleted;

            schedulerControl1.VisibleIntervalChanged += schedulerControl1_VisibleIntervalChanged;
            schedulerControl1.VisibleResourcesChanged += SchedulerControl1_VisibleResourcesChanged;

            schedulerControl1.Start = DateTime.Today;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.ActiveView.ResourcesPerPage = 1;

            schedulerControl1.DayView.ResourcesPerPage = 1;
            schedulerControl1.WorkWeekView.ResourcesPerPage = 1;
            schedulerControl1.FullWeekView.ResourcesPerPage = 1;
            schedulerControl1.MonthView.ResourcesPerPage = 1;
            schedulerControl1.TimelineView.ResourcesPerPage = 1;

            UpdateStatisticsInformationDisplayedOnTheForm();
        }

        #region #fetchappointments
        void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e) {
            ResourceBaseCollection resourcesVisible = new ResourceBaseCollection() { Capacity = schedulerControl1.ActiveView.ResourcesPerPage };
            int resourceCount = schedulerControl1.ActiveView.ResourcesPerPage;
            int firstVisibleResourceIndex = schedulerControl1.ActiveView.FirstVisibleResourceIndex;
            if (resourceCount == 0) {
                firstVisibleResourceIndex = 0;
                resourceCount = schedulerControl1.DataStorage.Resources.Count;
            }
            for (int i = 0; i < resourceCount; i++) {
                resourcesVisible.Add(this.schedulerStorage1.Resources[firstVisibleResourceIndex + i]);
            }

            QueryAppointmentDataSource(e, resourcesVisible);
        }

        private void QueryAppointmentDataSource(FetchAppointmentsEventArgs e, ResourceBaseCollection resources) {
            string resListString = String.Join(",", resources.Select(res => res.Id.ToString()));
            // Modify the FillBy query to fetch appointments only for the specified resources. 
            appointmentsTableAdapter.Commands[1].CommandText =
                String.Format("SELECT Appointments.* FROM Appointments WHERE (OriginalOccurrenceStart >= @Start) AND(OriginalOccurrenceEnd <= @End) AND (ResourceID IN ({0})) OR (Type != 0)", resListString);
            appointmentsTableAdapter.FillBy(this.scheduleTestDataSet.Appointments, e.Interval.Start.AddDays(-PADDING_DAYS), e.Interval.End.AddDays(PADDING_DAYS));

            queryExecutionCounter++;
        }
        #endregion #fetchappointments

        private void OnApptChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e) {
            this.appointmentsTableAdapter.Update(scheduleTestDataSet);
            this.scheduleTestDataSet.AcceptChanges();
        }

        private void UpdateStatisticsInformationDisplayedOnTheForm() {
            lblInfo.Text = String.Format("FetchAppointment query has been executed {0} times,\r\ndata set contains {1} appointments.", queryExecutionCounter, this.scheduleTestDataSet.Appointments.Count);
        }
        void schedulerControl1_VisibleIntervalChanged(object sender, EventArgs e) {
            UpdateStatisticsInformationDisplayedOnTheForm();
        }
        private void SchedulerControl1_VisibleResourcesChanged(object sender, VisibleResourcesChangedEventArgs args) {
            UpdateStatisticsInformationDisplayedOnTheForm();
        }


        // Fills the Scheduler with resources and appointments.
        private void CreateSampleData() {
            SchedulerHelper.FillResources(this.schedulerStorage1, 17);
            this.resourcesTableAdapter.Update(scheduleTestDataSet);
            SchedulerHelper.GenerateAppointments(this.schedulerStorage1, 150);
            BulkUpdateAppointmentsTable();
            this.scheduleTestDataSet.AcceptChanges();
            this.appointmentsTableAdapter.Fill(this.scheduleTestDataSet.Appointments);
        }

        // Performs a bulk insert which is much faster than calling the appointmentsTableAdapter.Update. 
        // The appointmentsTableAdapter.Update method has low performance 
        // because it updates one row at at time, executes Select query to obtain the identity value for each row 
        // and writes to the transaction log.
        // The BulkUpdateAppointmentsTable method does not retrieve ID values, 
        // so the appointmentsTableAdapter.Fill method should be called subsequently.        
        private void BulkUpdateAppointmentsTable() {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ScheduleTestConnectionString)) {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)) {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = "dbo.Appointments";
                    try {
                        bulkCopy.WriteToServer(scheduleTestDataSet.Appointments);
                    }
                    catch (Exception) {
                        transaction.Rollback();
                    }
                }
                transaction.Commit();
            }
        }

        private void cbFetchAppointments_CheckedChanged(object sender, EventArgs e) {
            if (cbFetchAppointments.Checked) {
                schedulerStorage1.EnableSmartFetch = true;
                schedulerStorage1.FetchAppointments += schedulerStorage1_FetchAppointments;
            }
            else {
                schedulerStorage1.FetchAppointments -= schedulerStorage1_FetchAppointments;
                this.resourcesTableAdapter.Fill(scheduleTestDataSet.Resources);
                this.appointmentsTableAdapter.Fill(scheduleTestDataSet.Appointments);
                schedulerStorage1.EnableSmartFetch = false;
            }
        }
        private void cbBoldAppointmentDates_CheckedChanged(object sender, EventArgs e) {
            if (cbBoldAppointmentDates.Checked)
                dateNavigator1.BoldAppointmentDates = true;
            else
                dateNavigator1.BoldAppointmentDates = false;
            dateNavigator1.Refresh();
        }
    }
}
