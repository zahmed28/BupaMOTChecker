namespace BupaMOTCheckerUI.Model
{
    public class Vehicle
    {
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FirstUsedDate { get; set; }
        public string FuelType { get; set; }
        public string PrimaryColour { get; set; }
        public List<MotTest> MotTests { get; set; }
    }

    public class MotTest
    {
        public string CompletedDate { get; set; }
        public string TestResult { get; set; }
        public string ExpiryDate { get; set; }
        public string OdometerValue { get; set; }
        public string OdometerUnit { get; set; }
        public string MotTestNumber { get; set; }
        public List<RfrAndComment> RfrAndComments { get; set; }
    }

    public class RfrAndComment
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class VehicleResponse
    {
        public Vehicle Vehicle { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class VehicleRequest
    {
        public string Registration { get; set; }
    }
}
