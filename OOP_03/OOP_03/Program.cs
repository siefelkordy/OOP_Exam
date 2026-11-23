using System.Diagnostics.Metrics;

namespace OOP_03
{

    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;
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
    public class Shipment
    {
        string trackingCode;
        string description;
        decimal weight;
        decimal deliveryFee;
        public DeliveryAddress destination;

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
        public void UpdateWeight(decimal newWeight,decimal ExtraWeight)
        {
            this.Weight = newWeight + ExtraWeight;
        }
        public virtual decimal EstimatedCost()
        {
            return deliveryFee + (weight * 5);
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
        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {trackingCode}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Weight: {weight} kg");
            Console.WriteLine($"Delivery Fee: ${deliveryFee}");
        }
    }
    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
        public override decimal EstimatedCost()
        {
            return base.EstimatedCost();
        }
        public override void PrintShipment()
        {
            
            Console.WriteLine("Standard Shipment Printed Successfully.");
        }
    }
    public class ExpressShipment : Shipment
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
        public override decimal EstimatedCost()
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment Printed Successfully.");
        }
    }
    public class InternationalShipment : Shipment
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
        public override decimal EstimatedCost()
        {
            return base.EstimatedCost() + (Weight * 5) + CustomsFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment Printed Successfully.");
        }
        public virtual void GenerateCustomsReport()
        {
            PrintShipment();
        }
    }

    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(
            string trackingcode,
            string description,
            decimal weight,
            decimal deliveryfee,
            DeliveryAddress destination,
            string destinationcountry,
            decimal customsfee)
            : base(
                trackingcode,
                description,
                weight,
                deliveryfee,
                destination,
                destinationcountry,
                customsfee)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("Printing Using Sealed overridden method...");
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

    }

    public static class DeliveryHelper
    { 
    public static void PrintShipmentDetails(Shipment shipment)
        {
            Console.WriteLine("Printing Using DeliveryHelper...");
            shipment.PrintShipment();
        }
    }
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
        public void SealedCheck()
        {
            Console.WriteLine("Sealed Class Reached");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            DeliveryCenter center = new DeliveryCenter();
            string trackingcode;
            string description;
            decimal weight;
            decimal deliveryfee;
            decimal extrafee;
            string destinationcountry;
            decimal customsfee;
            Console.WriteLine("=================================");
            Console.Write("Delivery Center");
            Console.WriteLine("=================================");
            Console.Write("\n\nDriver: ");
            center.DriverName = Console.ReadLine()!;

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Standard Shipment");
                        Console.WriteLine("\nTracking Code:");
                        trackingcode = Console.ReadLine()!;
                        Console.WriteLine("Description:");
                        description = Console.ReadLine()!;
                        Console.WriteLine("Weight:");
                        weight = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine("Delivery Fee:");
                        deliveryfee = decimal.Parse(Console.ReadLine()!);
                        Shipment standardShipment = new StandardShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress());
                        Console.WriteLine($"Estimated Cost: {standardShipment.EstimatedCost()}");
                        Console.WriteLine("=================================");
                        center[i] = standardShipment;
                        break;
                    case 1:
                        Console.WriteLine("Express Shipment");
                        Console.WriteLine("\nTracking Code:");
                        trackingcode = Console.ReadLine()!;
                        Console.WriteLine("Description:");
                        description = Console.ReadLine()!;
                        Console.WriteLine("Weight:");
                        weight = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine("Delivery Fee:");
                        deliveryfee = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine("Extra Fee:");
                        extrafee = decimal.Parse(Console.ReadLine()!);
                        Shipment expressshipment = new ExpressShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress(), extrafee);
                        Console.WriteLine($"Estimated Cost: {expressshipment.EstimatedCost()}");
                        Console.WriteLine("=================================");
                        center[i] = expressshipment;
                        break;
                    case 2:
                        Console.WriteLine("International Shipment");
                        Console.WriteLine("\nTracking Code:");
                        trackingcode = Console.ReadLine()!;
                        Console.WriteLine("Description:");
                        description = Console.ReadLine()!;
                        Console.WriteLine("Weight:");
                        weight = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine("Delivery Fee:");
                        deliveryfee = decimal.Parse(Console.ReadLine()!);
                        Console.WriteLine("Destination Country:");
                        destinationcountry = Console.ReadLine()!;
                        Console.WriteLine("Customs Fee:");
                        customsfee = decimal.Parse(Console.ReadLine()!);
                        Shipment internationalshipment = new InternationalShipment(trackingcode, description, weight, deliveryfee, new DeliveryAddress(), destinationcountry, customsfee);
                        Console.WriteLine($"Estimated Cost: {internationalshipment.EstimatedCost()}");
                        Console.WriteLine("=================================");
                        center[i] = internationalshipment;
                        break;

                }

            }
            center.PrintAllShipments();
            for (int i = 0; i < 3; i++)
            {
                DeliveryHelper.PrintShipmentDetails(center[i]);
                Console.WriteLine("=================================");

            }
            Console.WriteLine("Updating Weight...");
            Console.WriteLine($"Original Weight : {center[0].Weight}");
            center[0].UpdateWeight(5);
            Console.WriteLine($"Updated Weight : {center[0].Weight}");
            center[0].UpdateWeight(5, 0.5m);
            Console.WriteLine($"Updated Weight After Packing :{center[0].Weight}");
            Console.WriteLine("=================================");
            Shipment[] MixedShipments = new Shipment[3];
            for (int i = 0; i < 3; i++)
            {
                MixedShipments[i] = center[i];
                MixedShipments[i].PrintShipment();
            }
            CompletedShipment completedShipment = new CompletedShipment(center[0].TrackingCode, center[0].Description, center[0].Weight, center[0].DeliveryFee, center[0].Destination);
            completedShipment.SealedCheck();
            if (center[2] is InternationalShipment internationalShipment)
            {
                PriorityInternationalShipment priorityInternationalShipment =
                    new PriorityInternationalShipment(
                        internationalShipment.TrackingCode,
                        internationalShipment.Description,
                        internationalShipment.Weight,
                        internationalShipment.DeliveryFee,
                        internationalShipment.Destination,
                        internationalShipment.DestinationCountry,
                        internationalShipment.CustomsFee
                    );
                priorityInternationalShipment.GenerateCustomsReport();

            }
            else
            {
                Console.WriteLine("This shipment is not an InternationalShipment.");
            }
        }
    }


}


