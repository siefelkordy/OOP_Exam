using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace OOP_05
{

    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;
        public static int TotalShipmentsCreated = 0;
        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{Street} {BuildingNumber}, {City}";
        }
    }
    public partial class Shipment:ICloneable
    {
        string trackingCode;
        string description;
        decimal weight;
        decimal deliveryFee;
        public DeliveryAddress destination;
        public static int TotalShipmentsCreated;
        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == "")
                {
                    throw new ArgumentException("Tracking code cannot be null or empty.");
                }
                else
                {
                    trackingCode = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == "")
                {
                    throw new ArgumentException("Description cannot be null or empty.");
                }
                else
                {
                    description = value;
                }
            }
        }
        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight must be greater than zero.");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Delivery fee cannot be negative.");
                }
                else
                {
                    deliveryFee = value;
                }
            }
        }
        public DeliveryAddress Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public void UpdateWeight(decimal newWeight)
        {
            this.Weight = newWeight;
        }
        public void UpdateWeight(decimal newWeight, decimal ExtraWeight)
        {
            this.Weight = newWeight + ExtraWeight;
        }
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }
        public Shipment()
        {
            this.trackingCode??= trackingCode!;
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;
            this.Destination = new DeliveryAddress();
        }
        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode;
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;
            this.Destination = new DeliveryAddress();
        }
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = trackingCode;
            this.description = description;
            this.weight = weight;
            this.deliveryFee = deliveryFee;
            this.Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee < 0)
            {
                throw new ArgumentException("Delivery fee cannot be negative.");
            }
            deliveryFee = newFee;
        }
        public Shipment CopyShipment()
        {
            return new Shipment(TrackingCode, Description, Weight, DeliveryFee, Destination);
        }
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Shipment
            {
                TrackingCode = this.TrackingCode,
                Description=this.Description,
                Weight=this.Weight,
                DeliveryFee=this.DeliveryFee,
                Destination = new DeliveryAddress {City = this.Destination.City}
            };
        }
        public partial void OnTrackingStatusChanged(string newStatus);
    }
    public class StandardShipment : Shipment, ITrackable
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }
       
        
        public override string GetTrackingStatus()
        {
            return "Shipment SH001 is Ready.";
        }
        
    }
    public class ExpressShipment : Shipment, ITrackable
    {
        decimal extraFee;
        public decimal ExtraFee
        {
            get
            {
                return extraFee;
            }
            set
            {
                if (value >= 0)
                    extraFee = value;
                else
                    throw new ArgumentException("Extra fee cannot be negative.");
            }
        }
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal ExtraFee) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            this.ExtraFee = ExtraFee;
        }
        public override string GetTrackingStatus()
        {
            return "Shipment SH002 is Out for Delivery.";
        }
    }
    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        string destinationcountry;
        decimal customsfee;
        public string DestinationCountry
        {
            get
            {
                return destinationcountry;
            }
            set
            {


                if (!string.IsNullOrWhiteSpace(value))
                    destinationcountry = value;
                else
                    throw new ArgumentException("Destination country cannot be empty.");

            }
        }
        public decimal CustomsFee
        {
            get
            {
                return customsfee;

            }
            set
            {
                if (value >= 0)
                    customsfee = value;
            }
        }
        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string DestinationCountry, decimal CustomsFee) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            this.DestinationCountry = DestinationCountry;
            this.CustomsFee = CustomsFee;
        }
        
        public override void PrintShipment()
        {
            Console.WriteLine($"International Shipment\n\nTracking Code: {TrackingCode}\nDestination Country: {DestinationCountry}\nEstimated Cost: {EstimatedCost}");
        }
        public virtual void GenerateCustomsReport()
        {
            PrintShipment();
        }
        public override string GetTrackingStatus()
        {
            return "Shipment SH003 has been Delivered.";
        }
        public decimal CalculateInsurance()
        {
            return 0.12m * EstimatedCost;
        }
    }

    public class DeliveryCenter
    {
        public string CenterName;
        public string DriverName;
        private Shipment[] shipments;
        public DeliveryCenter()
        {
            shipments = new Shipment[20];
        }
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }
                return default!;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }

            }

        }
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                    {
                        return shipments[i];
                    }
                }
                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCode == shipment.TrackingCode)
                {
                    shipments[i] = null!;
                    return true;
                }
            }

            return false;
        }
        public void PrintAllShipments()
        {
            foreach (Shipment s in shipments)
            {
                if (s == null)
                {
                    continue;
                }
                else
                {
                    s.PrintShipment();
                    Console.WriteLine("=================================");
                }
            }
        }
        public void PrintShipment(ITrackable shipment)
        {
            shipment.GetTrackingStatus();
        }
        public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine(shipment.CalculateInsurance());
        }
        public void PrintTrackingStatuses()
        {
            foreach (ITrackable s in shipments)
            {
                if (s == null)
                    continue;
                else
                    Console.WriteLine(s.GetTrackingStatus());
            }
        }
        public void PrintInsurances()
        {
            foreach (IInsurable s in shipments)
            {
                if (s == null)
                    continue;
                else
                    Console.WriteLine(s.CalculateInsurance());
            }
        }

    }

    public static class DeliveryUtilities
    {
        public static void PrintSeperator()
        {
           Console.WriteLine(" ");
        }
        public static void PrintSystemTitle()
        {
            Console.WriteLine("Smart Delivery Management System");
        }
    }
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            return ($"{shipment.TrackingCode}|{shipment.GetType}|{shipment.Weight}|{shipment.GetTrackingStatus}");
        }
        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment.GetTrackingStatus != null)
                return true;
            else
                return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shipment shipment1 = new Shipment("abc123");
            Shipment shipment2 = shipment1.CopyShipment();
            shipment1.TrackingCode = "def456";
            Console.WriteLine($"Original shipment Tracking code: {shipment1.TrackingCode},copied shipment Tracking code: {shipment2.TrackingCode}")
            shipment2 = shipment1;
            Console.WriteLine($"Original shipment Tracking code: {shipment1.TrackingCode},Referenced shipment Tracking code: {shipment2.TrackingCode}")

            //DeliveryCenter center = new DeliveryCenter();
            //string trackingcode;
            //string description;
            //decimal weight;
            //decimal deliveryfee;
            //decimal extrafee;
            //string destinationcountry;
            //decimal customsfee;
            //Console.WriteLine("=================================");
            //Console.Write("Delivery Center");
            //Console.WriteLine("=================================");

            //for (int i = 0; i < 3; i++)
            //{
            //    switch (i)
            //    {
            //        case 0:
            //            Console.WriteLine("Standard Shipment");
            //            Console.WriteLine("\nTracking Code:");
            //            trackingcode = Console.ReadLine()!;
            //            Console.WriteLine("Description:");
            //            description = Console.ReadLine()!;
            //            Console.WriteLine("Weight:");
            //            weight = decimal.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Delivery Fee:");
            //            deliveryfee = decimal.Parse(Console.ReadLine()!);
            //            Shipment standardShipment = new StandardShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress());
            //            Console.WriteLine($"Estimated Cost: {standardShipment.EstimatedCost}");
            //            Console.WriteLine("=================================");
            //            center[i] = standardShipment;
            //            break;
            //        case 1:
            //            Console.WriteLine("Express Shipment");
            //            Console.WriteLine("\nTracking Code:");
            //            trackingcode = Console.ReadLine()!;
            //            Console.WriteLine("Description:");
            //            description = Console.ReadLine()!;
            //            Console.WriteLine("Weight:");
            //            weight = decimal.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Delivery Fee:");
            //            deliveryfee = decimal.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Extra Fee:");
            //            extrafee = decimal.Parse(Console.ReadLine()!);
            //            Shipment expressshipment = new ExpressShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress(), extrafee);
            //            Console.WriteLine($"Estimated Cost: {expressshipment.EstimatedCost}");
            //            Console.WriteLine("=================================");
            //            center[i] = expressshipment;
            //            break;
            //        case 2:
            //            Console.WriteLine("International Shipment");
            //            Console.WriteLine("\nTracking Code:");
            //            trackingcode = Console.ReadLine()!;
            //            Console.WriteLine("Description:");
            //            description = Console.ReadLine()!;
            //            Console.WriteLine("Weight:");
            //            weight = decimal.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Delivery Fee:");
            //            deliveryfee = decimal.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Destination Country:");
            //            destinationcountry = Console.ReadLine()!;
            //            Console.WriteLine("Customs Fee:");
            //            customsfee = decimal.Parse(Console.ReadLine()!);
            //            Shipment internationalshipment = new InternationalShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress(), destinationcountry, customsfee);
            //            Console.WriteLine($"Estimated Cost: {internationalshipment.EstimatedCost}");
            //            Console.WriteLine("=================================");
            //            center[i] = internationalshipment;
            //            break;

            //    }

            //}
            //center.PrintAllShipments();
            //center.PrintTrackingStatuses();
            //center.PrintInsurances();
            //ITrackable[] trackableshipments = new ITrackable[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    trackableshipments[i] = (ITrackable)center[i];
            //    Console.WriteLine(trackableshipments[i].GetTrackingStatus());
            //}

            //IInsurable[] insurableshipments = new IInsurable[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    insurableshipments[i] = (IInsurable)center[i];
            //    Console.WriteLine(insurableshipments[i].CalculateInsurance());
            //}


        }
    }


}


