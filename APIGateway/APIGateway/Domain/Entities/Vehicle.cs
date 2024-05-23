using System.Text.Json.Serialization;

namespace APIGateway.Domain.Entities
{
    public class Vehicle : IEquatable<Vehicle>
    {
        [JsonPropertyName("registration")]
        public string Registration { get; set; }

        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("firstUsedDate")]
        public string FirstUsedDate { get; set; }

        [JsonPropertyName("fuelType")]
        public string FuelType { get; set; }

        [JsonPropertyName("primaryColour")]
        public string PrimaryColour { get; set; }

        [JsonPropertyName("motTests")]
        public List<MotTest> MotTests { get; set; }
        public bool Equals(Vehicle? other)
        {
            if (other == null) return false;
            return Registration == other.Registration &&
                   Make == other.Make &&
                   Model == other.Model &&
                   FirstUsedDate == other.FirstUsedDate &&
                   FuelType == other.FuelType &&
                   PrimaryColour == other.PrimaryColour &&
                   (MotTests == other.MotTests || (MotTests != null && other.MotTests != null && MotTests.SequenceEqual(other.MotTests)));
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Vehicle);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Registration, Make, Model, FirstUsedDate, FuelType, PrimaryColour, MotTests);
        }
    }

    public class MotTest
    {
        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        [JsonPropertyName("testResult")]
        public string TestResult { get; set; }

        [JsonPropertyName("expiryDate")]
        public string ExpiryDate { get; set; }

        [JsonPropertyName("odometerValue")]
        public string OdometerValue { get; set; }

        [JsonPropertyName("odometerUnit")]
        public string OdometerUnit { get; set; }

        [JsonPropertyName("motTestNumber")]
        public string MotTestNumber { get; set; }

        [JsonPropertyName("rfrAndComments")]
        public List<RfrAndComment> RfrAndComments { get; set; }
    }

    public class RfrAndComment
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
    public class VehicleResponse : IEquatable<VehicleResponse>
    {
        public Vehicle Vehicle { get; set; }
        public string ErrorMessage { get; set; }
        public bool Equals(VehicleResponse other)
        {
            if (other == null) return false;
            return ErrorMessage == other.ErrorMessage &&
                   (Vehicle == other.Vehicle || (Vehicle != null && Vehicle.Equals(other.Vehicle)));
        }      
        public override int GetHashCode()
        {
            return HashCode.Combine(Vehicle, ErrorMessage);
        }
    }
}
