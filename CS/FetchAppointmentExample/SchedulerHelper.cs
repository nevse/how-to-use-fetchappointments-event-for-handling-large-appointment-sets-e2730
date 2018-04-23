using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FetchAppointmentExample {
    class SchedulerHelper {
        const int DAY_COUNT = 100;
        static string[] resources = {"Peter Dolan", "Ryan Fischer", "Richard Fisher",
                                 "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain",
                                 "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman",
                                 "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"};

        static string[] subjects = {
            "Meeting",
            "Phone call",
            "Travel",
            "One more meeting",
            "One more phone call",
            "One more travel"
        };

        public static void FillResources(ISchedulerStorage storage, int count) {
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
            try {
                int cnt = Math.Min(count, SchedulerHelper.resources.Length);
                for (int i = 1; i <= cnt; i++) {
                    Resource resource = storage.CreateResource(i);
                    resource.Caption = SchedulerHelper.resources[i - 1];
                    resources.Add(resource);
                }
            }
            finally {
                storage.EndUpdate();
            }
        }

        public static void GenerateAppointments(ISchedulerStorage storage, int aptsPerDay) {
            storage.BeginUpdate();
            Random rnd = new Random();
            DateTime start = DateTime.Today.AddDays(-DAY_COUNT / 2);
            for (int i = 0; i <= DAY_COUNT * aptsPerDay; i++) {
                storage.Appointments.Add(CreateNewAppointment(storage, i, aptsPerDay, rnd, start));
            }
            storage.EndUpdate();
        }

        static double GetRandomDouble(Random rnd, double min, double max) {
            return min + (max - min) * rnd.NextDouble();
        }

        static Appointment CreateNewAppointment(ISchedulerStorage storage, int index, int aptsPerDay, Random rnd, DateTime start) {
            int day = index / aptsPerDay;

            Appointment apt = storage.CreateAppointment(AppointmentType.Normal);
            apt.SetId(index + 1);
            apt.Start = start.AddDays(day).AddHours(GetRandomDouble(rnd, 0, 18));
            apt.End = apt.Start.AddHours(GetRandomDouble(rnd, 0.5, 6.0));
            int subjectIndex = rnd.Next(0, subjects.Length);
            apt.Subject = subjects[subjectIndex];
            apt.LabelKey = rnd.Next(1, 12);
            apt.ResourceId = rnd.Next(0, resources.Length);
            return apt;
        }

    }
}
