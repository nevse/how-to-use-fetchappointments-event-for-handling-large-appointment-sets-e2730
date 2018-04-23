#region #usings
using DevExpress.XtraScheduler;
using System;
using System.Windows.Forms;
#endregion #usings

namespace FetchAppointmentExample
{
    public partial class Form1 : Form
    {
        public static Random RandomInstance = new Random();

        #region #lastfetchedinterval
        TimeInterval lastFetchedInterval = new TimeInterval();
        #endregion #lastfetchedinterval

        public Form1()
        {
            InitializeComponent();

            schedulerControl1.GroupType = SchedulerGroupType.Resource;

            schedulerControl1.VisibleIntervalChanged += schedulerControl1_VisibleIntervalChanged;

            schedulerStorage1.AppointmentsChanged += OnApptChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnApptChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnApptChangedInsertedDeleted;

            schedulerStorage1.FetchAppointments += schedulerStorage1_FetchAppointments;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scheduleTestDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.scheduleTestDataSet.Resources);
            //GenerateEvents(schedulerStorage1);
            // TODO: This line of code loads data into the 'scheduleTestDataSet.Appointments' table. You can move, or remove it, as needed.
            //this.appointmentsTableAdapter.Fill(this.scheduleTestDataSet.Appointments);

            schedulerControl1.Start = new DateTime(2014, 03, 18);
            UpdateLblInfo();
        }

        private void OnApptChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            this.appointmentsTableAdapter.Update(scheduleTestDataSet);
            this.scheduleTestDataSet.AcceptChanges();
        }

        #region #fetchappointments
        void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e)
        {
            DateTime start = e.Interval.Start;
            DateTime end = e.Interval.End;
            // Specify the time range to pad the queried time interval. 
            // You can vary it find the balance between performance and detalization. 
            TimeSpan padding = TimeSpan.FromDays(7);

            // Check if the requested interval is outside the lastFetchedInterval.
            if (start <= lastFetchedInterval.Start || end >= lastFetchedInterval.End)
            {
                lastFetchedInterval = new TimeInterval(start - padding, end + padding);
                appointmentsTableAdapter.FillBy(this.scheduleTestDataSet.Appointments, lastFetchedInterval.Start, lastFetchedInterval.End);
            }
        }
        #endregion #fetchappointments

        private void cbBoldAppointmentDates_CheckedChanged(object sender, EventArgs e)
        {
            dateNavigator1.BoldAppointmentDates = cbBoldAppointmentDates.Checked;
            UpdateLblInfo();
        }

        void schedulerControl1_VisibleIntervalChanged(object sender, EventArgs e)
        {
            UpdateLblInfo();
        }

        private void UpdateLblInfo()
        {
            lblInfo.Text = string.Format("Interval: {0}, Appointments: {1}", lastFetchedInterval, this.scheduleTestDataSet.Appointments.Count);
        }
    }
}
