using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using IUIS.Models;

namespace IUIS.Utilities
{
    /// <summary>
    /// Generic repository for JSON file operations
    /// Implements OOP principles: Encapsulation, Abstraction
    /// </summary>
    public class JsonRepository<T> where T : BaseEntity
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonRepository(string fileName)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            
            // Ensure Data directory exists
            var dataDir = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir!);
            }

            // Configure JSON serialization options
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // Initialize file if it doesn't exist
            if (!File.Exists(_filePath))
            {
                SaveAll(new List<T>());
            }
        }

        /// <summary>
        /// Get all records from JSON file
        /// </summary>
        public List<T> GetAll()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<T>();

                var json = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(json))
                    return new List<T>();

                var records = JsonSerializer.Deserialize<List<T>>(json, _jsonOptions);
                return records ?? new List<T>();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error deserializing JSON file {_filePath}: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error reading file {_filePath}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get a single record by ID
        /// </summary>
        public T? GetById(string id)
        {
            var records = GetAll();
            return records.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Add a new record
        /// </summary>
        public T Add(T entity)
        {
            try
            {
                var records = GetAll();
                entity.Id = Guid.NewGuid().ToString();
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                records.Add(entity);
                SaveAll(records);
                return entity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing record
        /// </summary>
        public bool Update(T entity)
        {
            try
            {
                var records = GetAll();
                var existingRecord = records.FirstOrDefault(r => r.Id == entity.Id);

                if (existingRecord == null)
                    return false;

                entity.ModifiedDate = DateTime.Now;
                var index = records.IndexOf(existingRecord);
                records[index] = entity;
                SaveAll(records);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Delete a record by ID (soft delete by setting IsActive to false)
        /// </summary>
        public bool Delete(string id)
        {
            try
            {
                var records = GetAll();
                var record = records.FirstOrDefault(r => r.Id == id);

                if (record == null)
                    return false;

                // Soft delete
                record.IsActive = false;
                record.ModifiedDate = DateTime.Now;
                
                var index = records.IndexOf(record);
                records[index] = record;
                SaveAll(records);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error deleting record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Hard delete - permanently remove from file
        /// </summary>
        public bool HardDelete(string id)
        {
            try
            {
                var records = GetAll();
                var record = records.FirstOrDefault(r => r.Id == id);

                if (record == null)
                    return false;

                records.Remove(record);
                SaveAll(records);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error hard deleting record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Search records by predicate
        /// </summary>
        public List<T> Search(Func<T, bool> predicate)
        {
            var records = GetAll();
            return records.Where(predicate).ToList();
        }

        /// <summary>
        /// Save all records to JSON file
        /// </summary>
        private void SaveAll(List<T> records)
        {
            try
            {
                var json = JsonSerializer.Serialize(records, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error writing file {_filePath}: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error serializing to JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Check if file exists
        /// </summary>
        public bool FileExists()
        {
            return File.Exists(_filePath);
        }

        /// <summary>
        /// Get the file path
        /// </summary>
        public string GetFilePath()
        {
            return _filePath;
        }
    }

    /// <summary>
    /// Specific repositories for each entity type
    /// </summary>
    public class StudentRepository : JsonRepository<Student>
    {
        public StudentRepository() : base("students.json") { }

        public Student? GetByStudentId(string studentId)
        {
            var students = GetAll();
            return students.FirstOrDefault(s => s.StudentId == studentId && s.IsActive);
        }

        public List<Student> GetByCourse(string courseId)
        {
            var students = GetAll();
            return students.Where(s => s.CourseId == courseId && s.IsActive).ToList();
        }

        public List<Student> SearchByName(string searchTerm)
        {
            var students = GetAll();
            return students.Where(s => 
                (s.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                 s.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) && 
                s.IsActive).ToList();
        }
    }

    public class CourseRepository : JsonRepository<Course>
    {
        public CourseRepository() : base("courses.json") { }

        public Course? GetByCourseCode(string courseCode)
        {
            var courses = GetAll();
            return courses.FirstOrDefault(c => c.CourseCode == courseCode && c.IsActive);
        }
    }

    public class SubjectRepository : JsonRepository<Subject>
    {
        public SubjectRepository() : base("subjects.json") { }

        public List<Subject> GetByCourse(string courseId)
        {
            var subjects = GetAll();
            return subjects.Where(s => s.CourseId == courseId && s.IsActive).ToList();
        }

        public List<Subject> GetByYearLevel(int yearLevel)
        {
            var subjects = GetAll();
            return subjects.Where(s => s.YearLevel == yearLevel && s.IsActive).ToList();
        }
    }

    public class EnrollmentRepository : JsonRepository<Enrollment>
    {
        public EnrollmentRepository() : base("enrollments.json") { }

        public List<Enrollment> GetByStudent(string studentId)
        {
            var enrollments = GetAll();
            return enrollments.Where(e => e.StudentId == studentId && e.IsActive).ToList();
        }

        public Enrollment? GetCurrentEnrollment(string studentId, string academicYear, int semester)
        {
            var enrollments = GetAll();
            return enrollments.FirstOrDefault(e => 
                e.StudentId == studentId && 
                e.AcademicYear == academicYear && 
                e.Semester == semester && 
                e.IsActive);
        }
    }

    public class PaymentRepository : JsonRepository<Payment>
    {
        public PaymentRepository() : base("payments.json") { }

        public List<Payment> GetByStudent(string studentId)
        {
            var payments = GetAll();
            return payments.Where(p => p.StudentId == studentId && p.IsActive).ToList();
        }

        public decimal GetTotalPaid(string studentId)
        {
            var payments = GetAll();
            return payments.Where(p => p.StudentId == studentId && p.IsActive).Sum(p => p.AmountPaid);
        }
    }

    public class EmployeeRepository : JsonRepository<Employee>
    {
        public EmployeeRepository() : base("employees.json") { }

        public Employee? GetByEmployeeId(string employeeId)
        {
            var employees = GetAll();
            return employees.FirstOrDefault(e => e.EmployeeId == employeeId && e.IsActive);
        }

        public List<Employee> GetByDepartment(string department)
        {
            var employees = GetAll();
            return employees.Where(e => e.Department == department && e.IsActive).ToList();
        }

        public List<Employee> GetFaculty()
        {
            var employees = GetAll();
            return employees.Where(e => e.Position.Contains("Faculty", StringComparison.OrdinalIgnoreCase) || 
                                        e.Position.Contains("Instructor", StringComparison.OrdinalIgnoreCase) ||
                                        e.Position.Contains("Professor", StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    public class BookRepository : JsonRepository<Book>
    {
        public BookRepository() : base("books.json") { }

        public Book? GetByISBN(string isbn)
        {
            var books = GetAll();
            return books.FirstOrDefault(b => b.ISBN == isbn && b.IsActive);
        }

        public List<Book> SearchByTitle(string searchTerm)
        {
            var books = GetAll();
            return books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) && b.IsActive).ToList();
        }

        public List<Book> SearchByAuthor(string searchTerm)
        {
            var books = GetAll();
            return books.Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) && b.IsActive).ToList();
        }
    }

    public class BorrowingRepository : JsonRepository<Borrowing>
    {
        public BorrowingRepository() : base("borrowings.json") { }

        public List<Borrowing> GetByStudent(string studentId)
        {
            var borrowings = GetAll();
            return borrowings.Where(b => b.StudentId == studentId && b.IsActive).ToList();
        }

        public List<Borrowing> GetActiveBorrowings()
        {
            var borrowings = GetAll();
            return borrowings.Where(b => b.Status == "Borrowed" && b.IsActive).ToList();
        }
    }

    public class CounselingRepository : JsonRepository<CounselingSession>
    {
        public CounselingRepository() : base("counseling.json") { }

        public List<CounselingSession> GetByStudent(string studentId)
        {
            var sessions = GetAll();
            return sessions.Where(s => s.StudentId == studentId && s.IsActive).ToList();
        }
    }

    public class ViolationRepository : JsonRepository<Violation>
    {
        public ViolationRepository() : base("violations.json") { }

        public List<Violation> GetByStudent(string studentId)
        {
            var violations = GetAll();
            return violations.Where(v => v.StudentId == studentId && v.IsActive).ToList();
        }
    }

    public class MedicalRecordRepository : JsonRepository<MedicalRecord>
    {
        public MedicalRecordRepository() : base("medical_records.json") { }

        public List<MedicalRecord> GetByStudent(string studentId)
        {
            var records = GetAll();
            return records.Where(r => r.StudentId == studentId && r.IsActive).ToList();
        }
    }

    public class AttendanceRepository : JsonRepository<AttendanceRecord>
    {
        public AttendanceRepository() : base("attendance.json") { }

        public List<AttendanceRecord> GetByEmployee(string employeeId)
        {
            var records = GetAll();
            return records.Where(r => r.EmployeeId == employeeId && r.IsActive).ToList();
        }

        public List<AttendanceRecord> GetByDate(DateTime date)
        {
            var records = GetAll();
            return records.Where(r => r.Date.Date == date.Date && r.IsActive).ToList();
        }
    }

    public class ClearanceRepository : JsonRepository<Clearance>
    {
        public ClearanceRepository() : base("clearances.json") { }

        public List<Clearance> GetByStudent(string studentId)
        {
            var clearances = GetAll();
            return clearances.Where(c => c.StudentId == studentId && c.IsActive).ToList();
        }
    }

    public class UserRepository : JsonRepository<User>
    {
        public UserRepository() : base("users.json") { }

        public User? Authenticate(string username, string password)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsActive);
        }

        public User? GetByUsername(string username)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Username == username && u.IsActive);
        }
    }
}
