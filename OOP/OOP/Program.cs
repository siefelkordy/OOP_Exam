namespace OOP
{
    struct DeliveryAddress
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
    struct Shipment
    {
        string trackingCode;
        string description;
        decimal weight;
        decimal deliveryFee;
        public DeliveryAddress destination;
        
        public string TrackingCode {
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
        public decimal EstimatedCost()
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
        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {trackingCode}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Weight: {weight} kg");
            Console.WriteLine($"Delivery Fee: ${deliveryFee}");
            Console.WriteLine($"Destination: {destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost()}");
        }
    }
    struct DeliveryCenter
    {
        private Shipment[] shipments;
        public DeliveryCenter()
        { 
            shipments = new Shipment[10];
        }
        public Shipment this[int index]
        {
            get
            {
                if(index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }
                return default;
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
                    if (shipments[i].TrackingCode == trackingCode)
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

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryCenter center = new DeliveryCenter();
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i + 1} Data");
                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine()!;
                Console.Write("Description: ");
                string description = Console.ReadLine()!;
                Console.Write("Weight: ");
                decimal weight = decimal.Parse(Console.ReadLine()!);
                Console.Write("Delivery Fee: ");
                decimal deliveryFee = decimal.Parse(Console.ReadLine()!);
                Console.Write("Destination City: ");
                string city = Console.ReadLine()!;
                Console.Write("Destination Street: ");
                string street = Console.ReadLine()!;
                Console.Write("Destination Building Number: ");
                int buildingNumber = int.Parse(Console.ReadLine()!);
                DeliveryAddress destination = new DeliveryAddress(city, street, buildingNumber);
                Shipment shipment = new Shipment(trackingCode, description, weight, deliveryFee, destination);
                center.AddShipment(shipment);
                Console.WriteLine("Shipment added successfully!");
            }
            Console.WriteLine("--- All Shipments");
            for (int i = 0; i < 3; i++)
            {
                Shipment shipment = center[i];
                Console.WriteLine($"\nShipment {i + 1} Details:");
                shipment.PrintShipment();
            }
            Console.WriteLine("Enter a tracking code to search:");
            string trackingCodeToSearch = Console.ReadLine()!;
            Shipment foundShipment  = center[trackingCodeToSearch];
            if (foundShipment.TrackingCode == null)
            {
                Console.WriteLine("Shipment not found.");

            }
            else
            {
                Console.WriteLine("Shipment found:");
                foundShipment.PrintShipment();
            }
            Console.WriteLine("--- Struct Copy Test ---");
            DeliveryAddress address = new DeliveryAddress("Nasr city", "Abdelkader El Bakkar", 16);
            DeliveryAddress copyOfAddress = address;
            copyOfAddress.BuildingNumber = 20;
            copyOfAddress.City = "Tagamo3";
            copyOfAddress.Street = "El Narges";
            Console.WriteLine("Original Address: " + address.GetFullAddress());
            Console.WriteLine("Copied Address: " + copyOfAddress.GetFullAddress());
        }
    }
}
