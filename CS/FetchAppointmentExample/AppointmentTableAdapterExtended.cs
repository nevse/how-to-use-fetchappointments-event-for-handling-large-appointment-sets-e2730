using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FetchAppointmentExample.ScheduleTestDataSetTableAdapters {
    #region #AppointmentsTableAdapterEx
    public partial class AppointmentsTableAdapter {
        public System.Data.SqlClient.SqlCommand[] Commands
        {
            get
            {
                return this._commandCollection;
            }
        }
    }
    #endregion #AppointmentsTableAdapterEx
}
