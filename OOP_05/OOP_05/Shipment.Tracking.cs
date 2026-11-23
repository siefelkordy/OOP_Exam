using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace OOP_05
{
    public partial class Shipment:ITrackable

    {

        public void IncrementCounter()
        {
            TotalShipmentsCreated++;
        }
        public virtual string GetTrackingStatus()
        {
            return "";
        }
        public partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }


        public string UpdateTrackingStatus()
        {
            OnTrackingStatusChanged(string newStatus);
           return ;
        }
    }
}
