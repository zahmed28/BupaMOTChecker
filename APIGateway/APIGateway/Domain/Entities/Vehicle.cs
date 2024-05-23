﻿using System.Text.Json.Serialization;

namespace APIGateway.Domain.Entities
{
    public class Vehicle
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
    public class VehicleResponse
    {
        public Vehicle Vehicle { get; set; }
        public string ErrorMessage { get; set; }
    }
}
