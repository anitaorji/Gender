using System;
using System.Collections.Generic;
using System.Text;

namespace Gender.Application.DTOs
{
    public class GenderResponseDto
    {
        public string Gender { get; set; }
        public double Probability { get; set; }
        public int SampleSize { get; set; }
        public bool IsConfident { get; set; }
        public string ProcessedAt { get; set; }
    }
}
