using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
#region #usings
using DevExpress.XtraScheduler;
#endregion #usings

namespace FetchAppointmentsExample
{
    public partial class Form1 : Form
    {
        TimeInterval lastFetchedInterval = new TimeInterval();

        public Form1()
        {
            InitializeComponent();
            carSchedulingTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler
    (carSchedulingTableAdapter_RowUpdated);

            schedulerStorage1.FetchAppointments += new FetchAppointmentsEventHandler(schedulerStorage1_FetchAppointments);

        }
        #region #fetchappointments
        void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e)
        {
            DateTime start = e.Interval.Start;
            DateTime end = e.Interval.End;
            // Specify the time range to pad the queried time interval
            TimeSpan padding =  TimeSpan.FromDays(7);

            // Check if the requested interval is outside the lastFetchedInterval
            if (start <= lastFetchedInterval.Start || end >= lastFetchedInterval.End)
            {
                lastFetchedInterval = new TimeInterval(start - padding, end + padding);
                carSchedulingTableAdapter.FillBy(this.carsDBDataSet.CarScheduling, lastFetchedInterval.Start, lastFetchedInterval.End);
                // Watch the queried time range and the number of rows in a resulting table
                Console.WriteLine(start + " / " + end);
                Console.WriteLine(this.carsDBDataSet.CarScheduling.Count.ToString());
            }
        }
        #endregion #fetchappointments

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDBDataSet.Cars);
            // TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            this.carSchedulingTableAdapter.Fill(this.carsDBDataSet.CarScheduling);

        }

        private void OnApptChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            carSchedulingTableAdapter.Update(carsDBDataSet);
            carsDBDataSet.AcceptChanges();
        }
        
        private void carSchedulingTableAdapter_RowUpdated(object sender,
    OleDbRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
            {
                int id = 0;
                using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY",
                    carSchedulingTableAdapter.Connection))
                {
                    id = (int)cmd.ExecuteScalar();
                }
                e.Row["ID"] = id;
            }
        }

    }
}