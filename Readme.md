# How to determine whether or not a specific appointment property value is changed


<p>This example illustrates how to determine whether or not the specific appointment property (the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerAppointment_LabelIdtopic"><u>Appointment.LabelId</u></a> in this example) value is changed without creating a <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument2288"><u>Custom Appointment Form</u></a>. We handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_AppointmentChangingtopic"><u>SchedulerStorageBase.AppointmentChanging Event</u></a> for this purpose and examine the <strong>e.Object</strong>'s parameter value and the value returned by the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerPersistentObject_GetSourceObjecttopic"><u>PersistentObject.GetSourceObject Method</u></a>. The first one represents a new value whereas the second one represents the previous value. Note that the <strong>GetSourceObject</strong><strong>()</strong> method works even in unbound mode because in this mode a hidden data layer still exist in the Scheduler context (see <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument3875"><u>Logical Layers</u></a>). Here is a corresponding code snippet:</p>

```cs
        private void schedulerStorage1_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e) {
            int oldLabel = Convert.ToInt32(((DataRowView)((Appointment)e.Object).GetSourceObject((SchedulerStorageBase)sender)).Row["Label"]);
            int newLabel = ((Appointment)e.Object).LabelId;

            if (!newLabel.Equals(oldLabel))
                MessageBox.Show("Label was changed!");
        }
```

<p> </p><p>Note that a similar technique is used in the <a href="https://www.devexpress.com/Support/Center/p/E3792">How to split appointments into groups</a> example.</p>

<br/>


