using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable enable

namespace IUIS.Models
{
    /// <summary>
    /// Base class for all entities with common properties
    /// </summary>
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("modifiedDate")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Student entity representing student records
    /// </summary>
    public class Student : BaseEntity
    {
        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("courseId")]
        public string CourseId { get; set; } = string.Empty;

        [JsonPropertyName("course")]
        public string Course { get; set; } = string.Empty;

        [JsonPropertyName("yearLevel")]
        public int YearLevel { get; set; }

        [JsonPropertyName("enrollmentStatus")]
        public string EnrollmentStatus { get; set; } = "Active";

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Active";

        [JsonPropertyName("guardianName")]
        public string GuardianName { get; set; } = string.Empty;

        [JsonPropertyName("guardianContact")]
        public string GuardianContact { get; set; } = string.Empty;

        [JsonIgnore]
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    }

    /// <summary>
    /// Course/Academic Program entity
    /// </summary>
    public class Course : BaseEntity
    {
        [JsonPropertyName("courseCode")]
        public string CourseCode { get; set; } = string.Empty;

        [JsonPropertyName("courseName")]
        public string CourseName { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("degree")]
        public string Degree { get; set; } = string.Empty;

        [JsonPropertyName("totalUnits")]
        public int TotalUnits { get; set; }

        [JsonPropertyName("durationYears")]
        public int DurationYears { get; set; }
    }

    /// <summary>
    /// Subject entity
    /// </summary>
    public class Subject : BaseEntity
    {
        [JsonPropertyName("subjectCode")]
        public string SubjectCode { get; set; } = string.Empty;

        [JsonPropertyName("subjectName")]
        public string SubjectName { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("units")]
        public int Units { get; set; }

        [JsonPropertyName("prerequisites")]
        public string[] Prerequisites { get; set; } = Array.Empty<string>();

        [JsonPropertyName("semester")]
        public int Semester { get; set; }

        [JsonPropertyName("yearLevel")]
        public int YearLevel { get; set; }

        [JsonPropertyName("courseCode")]
        public string CourseCode { get; set; } = string.Empty;

        [JsonIgnore]
        public string DisplayName => $"{SubjectCode} - {SubjectName}";
    }

    /// <summary>
    /// Enrollment entity
    /// </summary>
    public class Enrollment : BaseEntity
    {
        [JsonPropertyName("enrollmentId")]
        public string EnrollmentId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("academicYear")]
        public string AcademicYear { get; set; } = string.Empty;

        [JsonPropertyName("semester")]
        public string Semester { get; set; } = "1";

        [JsonPropertyName("term")]
        public string Term { get; set; } = string.Empty;

        [JsonPropertyName("enrollmentDate")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [JsonPropertyName("dateEnrolled")]
        public DateTime DateEnrolled { get; set; } = DateTime.Now;

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Enrolled";

        [JsonPropertyName("subjectIds")]
        public string[] SubjectIds { get; set; } = Array.Empty<string>();

        [JsonPropertyName("subjects")]
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        [JsonPropertyName("totalUnits")]
        public int TotalUnits { get; set; }

        [JsonPropertyName("tuitionFee")]
        public decimal TuitionFee { get; set; }

        [JsonPropertyName("miscellaneousFee")]
        public decimal MiscellaneousFee { get; set; }

        [JsonPropertyName("totalAssessment")]
        public decimal TotalAssessment { get; set; }

        [JsonPropertyName("amountPaid")]
        public decimal AmountPaid { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Payment/Tuition Assessment entity
    /// </summary>
    public class Payment : BaseEntity
    {
        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("enrollmentId")]
        public string EnrollmentId { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("amountPaid")]
        public decimal AmountPaid { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("paymentDate")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; } = string.Empty;

        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Pending";

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }

    /// <summary>
    /// Employee/Faculty entity
    /// </summary>
    public class Employee : BaseEntity
    {
        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; } = string.Empty;

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("position")]
        public string Position { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string Department { get; set; } = string.Empty;

        [JsonPropertyName("hireDate")]
        public DateTime HireDate { get; set; }

        [JsonPropertyName("salary")]
        public decimal Salary { get; set; }

        [JsonPropertyName("employmentType")]
        public string EmploymentType { get; set; } = "Full-time";

        [JsonPropertyName("specialization")]
        public string Specialization { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    }

    /// <summary>
    /// Book entity for library
    /// </summary>
    public class Book : BaseEntity
    {
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("author")]
        public string Author { get; set; } = string.Empty;

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; } = string.Empty;

        [JsonPropertyName("publishYear")]
        public int PublishYear { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("totalCopies")]
        public int TotalCopies { get; set; }

        [JsonPropertyName("availableCopies")]
        public int AvailableCopies { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
    }

    /// <summary>
    /// Borrowing transaction entity
    /// </summary>
    public class Borrowing : BaseEntity
    {
        [JsonPropertyName("borrowingId")]
        public string BorrowingId { get; set; } = string.Empty;

        [JsonPropertyName("bookId")]
        public string BookId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("borrowDate")]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        [JsonPropertyName("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("returnDate")]
        public DateTime? ReturnDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Borrowed";

        [JsonPropertyName("fine")]
        public decimal Fine { get; set; }
    }

    /// <summary>
    /// Counseling session entity
    /// </summary>
    public class CounselingSession : BaseEntity
    {
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("counselorId")]
        public string CounselorId { get; set; } = string.Empty;

        [JsonPropertyName("sessionDate")]
        public DateTime SessionDate { get; set; }

        [JsonPropertyName("sessionType")]
        public string SessionType { get; set; } = string.Empty;

        [JsonPropertyName("concerns")]
        public string Concerns { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("recommendations")]
        public string Recommendations { get; set; } = string.Empty;

        [JsonPropertyName("followUpRequired")]
        public bool FollowUpRequired { get; set; }

        [JsonPropertyName("followUpDate")]
        public DateTime? FollowUpDate { get; set; }
    }

    /// <summary>
    /// Student violation entity
    /// </summary>
    public class Violation : BaseEntity
    {
        [JsonPropertyName("violationId")]
        public string ViolationId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("violationType")]
        public string ViolationType { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("incidentDate")]
        public DateTime IncidentDate { get; set; }

        [JsonPropertyName("reportedBy")]
        public string ReportedBy { get; set; } = string.Empty;

        [JsonPropertyName("sanction")]
        public string Sanction { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Pending";

        [JsonPropertyName("resolvedDate")]
        public DateTime? ResolvedDate { get; set; }
    }

    /// <summary>
    /// Medical record entity
    /// </summary>
    public class MedicalRecord : BaseEntity
    {
        [JsonPropertyName("recordId")]
        public string RecordId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("consultationDate")]
        public DateTime ConsultationDate { get; set; }

        [JsonPropertyName("chiefComplaint")]
        public string ChiefComplaint { get; set; } = string.Empty;

        [JsonPropertyName("diagnosis")]
        public string Diagnosis { get; set; } = string.Empty;

        [JsonPropertyName("treatment")]
        public string Treatment { get; set; } = string.Empty;

        [JsonPropertyName("medications")]
        public string Medications { get; set; } = string.Empty;

        [JsonPropertyName("physicianName")]
        public string PhysicianName { get; set; } = string.Empty;

        [JsonPropertyName("followUpRequired")]
        public bool FollowUpRequired { get; set; }

        [JsonPropertyName("followUpDate")]
        public DateTime? FollowUpDate { get; set; }

        [JsonPropertyName("isCleared")]
        public bool IsCleared { get; set; }

        [JsonPropertyName("clearanceNotes")]
        public string ClearanceNotes { get; set; } = string.Empty;
    }

    /// <summary>
    /// Attendance record entity
    /// </summary>
    public class AttendanceRecord : BaseEntity
    {
        [JsonPropertyName("attendanceId")]
        public string AttendanceId { get; set; } = string.Empty;

        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonPropertyName("timeIn")]
        public TimeSpan? TimeIn { get; set; }

        [JsonPropertyName("timeOut")]
        public TimeSpan? TimeOut { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Present";

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = string.Empty;
    }

    /// <summary>
    /// Clearance entity
    /// </summary>
    public class Clearance : BaseEntity
    {
        [JsonPropertyName("clearanceId")]
        public string ClearanceId { get; set; } = string.Empty;

        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("clearanceType")]
        public string ClearanceType { get; set; } = string.Empty;

        [JsonPropertyName("issuedDate")]
        public DateTime IssuedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "Active";

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = string.Empty;
    }

    /// <summary>
    /// User account entity for authentication
    /// </summary>
    public class User : BaseEntity
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public string Role { get; set; } = "User";

        [JsonPropertyName("employeeId")]
        public string? EmployeeId { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("lastLogin")]
        public DateTime? LastLogin { get; set; }
    }
}
