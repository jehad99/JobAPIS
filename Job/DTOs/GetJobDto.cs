﻿namespace JobAPIS.DTOs
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frontend Developer";
        public string Description { get; set; } = "UI developer";
        public string JobRequirements { get; set; } = "2years exp, skills:html-css-js";
    }
}
