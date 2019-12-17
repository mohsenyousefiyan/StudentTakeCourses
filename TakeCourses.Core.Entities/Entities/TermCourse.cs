using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    /// <summary>
    /// درس هایی که در یک ترم درسی قرار است ارائه شوند
    /// </summary>
    public class TermCourse:BaseEntity<int>
    {
        public int TermId { get; set; }
        public Term Term { get; set; }       
        public Int16 CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public byte Capacity { get; set; }
        public List<PresentationDay> PresentationDays { get; private set; }
        public TestDate TestDate { get; set; }

    }

    public class PresentationDay
    {
        public Days Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string PlaceName { get; set; }
    }

    public class TestDate
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string PlaceName { get; set; }
    }
}
