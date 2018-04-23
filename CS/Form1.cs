using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerAppointmentPropertyChanged {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            SchedulerStorage schedulerStorage = schedulerControl1.Storage;
            Appointment apt = schedulerStorage.CreateAppointment(AppointmentType.Normal);
            DateTime baseTime = DateTime.Today;

            apt.Start = baseTime.AddHours(1);
            apt.End = baseTime.AddHours(2);
            apt.Subject = "Test";
            apt.Location = "Office";
            apt.Description = "Test procedure";

            schedulerStorage.Appointments.Add(apt);

            schedulerControl1.Start = baseTime;
        }

        private void schedulerStorage1_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e) {
            int oldLabel = Convert.ToInt32(((DataRowView)((Appointment)e.Object).GetSourceObject((SchedulerStorageBase)sender)).Row["Label"]);
            int newLabel = ((Appointment)e.Object).LabelId;

            if (!newLabel.Equals(oldLabel))
                MessageBox.Show("Label was changed!");
        }
    }
}