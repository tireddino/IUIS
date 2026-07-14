using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IUIS.Models;
using IUIS.Utilities;

namespace IUIS.Forms.Subjects
{
    public partial class SubjectsForm : Form
    {
        private readonly SubjectRepository _subjectRepository;
        private readonly CourseRepository _courseRepository;
        private Subject? _currentSubject;
        private bool _isEditMode;

        public SubjectsForm()
        {
            InitializeComponent();
            _subjectRepository = new SubjectRepository();
            _courseRepository = new CourseRepository();
            InitializeForm();
            LoadSubjects();
            LoadCoursesToComboBox();
            InitializeBatStateUSubjects();
        }

        private void InitializeBatStateUSubjects()
        {
            // Pre-populate with Batangas State University subjects if none exist
            if (_subjectRepository.GetAll().Count == 0)
            {
                var courses = _courseRepository.GetAll().ToList();
                var subjects = new List<Subject>();

                // BSIT - Bachelor of Science in Information Technology
                var bsitId = courses.FirstOrDefault(c => c.CourseCode == "BSIT")?.Id;
                if (bsitId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1 - Semester 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC101", SubjectName = "Introduction to Computing", Description = "Fundamentals of computing and IT profession", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC102", SubjectName = "Computer Programming 1", Description = "Introduction to programming using C++", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC102L", SubjectName = "Computer Programming 1 Laboratory", Description = "Hands-on programming exercises", Units = 1, Prerequisites = new[] { "CC102" }, Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH101", SubjectName = "Discrete Mathematics", Description = "Mathematical foundations for computing", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ENG101", SubjectName = "English for Academic and Professional Purposes", Description = "Communication skills development", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PE101", SubjectName = "Physical Education 1", Description = "Fitness and wellness", Units = 2, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NSTP1", SubjectName = "National Service Training Program 1", Description = "Civic consciousness and service", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        
                        // Year 1 - Semester 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC103", SubjectName = "Computer Programming 2", Description = "Object-oriented programming", Units = 3, Prerequisites = new[] { "CC102" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC103L", SubjectName = "Computer Programming 2 Laboratory", Description = "OOP hands-on exercises", Units = 1, Prerequisites = new[] { "CC102L" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC104", SubjectName = "Information Management", Description = "Database fundamentals", Units = 3, Prerequisites = new[] { "CC102" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC104L", SubjectName = "Information Management Laboratory", Description = "Database design and SQL", Units = 1, Prerequisites = new[] { "CC102L" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH102", SubjectName = "Calculus for Computing", Description = "Applied calculus", Units = 3, Prerequisites = new[] { "MATH101" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PE102", SubjectName = "Physical Education 2", Description = "Individual and dual sports", Units = 2, Prerequisites = new[] { "PE101" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NSTP2", SubjectName = "National Service Training Program 2", Description = "Community service project", Units = 3, Prerequisites = new[] { "NSTP1" }, Semester = 2, YearLevel = 1, CourseId = bsitId, IsActive = true },

                        // Year 2 - Semester 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC201", SubjectName = "Data Structures and Algorithms", Description = "Advanced data organization", Units = 3, Prerequisites = new[] { "CC103", "MATH101" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC201L", SubjectName = "Data Structures and Algorithms Laboratory", Description = "DS implementation", Units = 1, Prerequisites = new[] { "CC103L" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC202", SubjectName = "Object-Oriented Analysis and Design", Description = "Software modeling with UML", Units = 3, Prerequisites = new[] { "CC103" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC203", SubjectName = "Web Systems and Technologies", Description = "Web development fundamentals", Units = 3, Prerequisites = new[] { "CC103" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC203L", SubjectName = "Web Systems and Technologies Laboratory", Description = "HTML, CSS, JavaScript", Units = 1, Prerequisites = new[] { "CC103L" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "STAT101", SubjectName = "Statistics for Computing", Description = "Statistical methods", Units = 3, Prerequisites = new[] { "MATH102" }, Semester = 1, YearLevel = 2, CourseId = bsitId, IsActive = true },

                        // Year 2 - Semester 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC204", SubjectName = "Platform Administration", Description = "Operating system administration", Units = 3, Prerequisites = new[] { "CC201" }, Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC204L", SubjectName = "Platform Administration Laboratory", Description = "Linux/Windows admin", Units = 1, Prerequisites = new[] { "CC201L" }, Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC205", SubjectName = "Application Development and Emerging Technologies", Description = "Mobile and cloud computing", Units = 3, Prerequisites = new[] { "CC203" }, Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC205L", SubjectName = "Application Development Laboratory", Description = "Mobile app development", Units = 1, Prerequisites = new[] { "CC203L" }, Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC206", SubjectName = "Networking 1", Description = "Data communications", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC206L", SubjectName = "Networking 1 Laboratory", Description = "Network configuration", Units = 1, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 2, CourseId = bsitId, IsActive = true },

                        // Year 3 - Semester 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC301", SubjectName = "Software Engineering 1", Description = "Software development lifecycle", Units = 3, Prerequisites = new[] { "CC202" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC302", SubjectName = "Database Systems", Description = "Advanced database concepts", Units = 3, Prerequisites = new[] { "CC104" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC302L", SubjectName = "Database Systems Laboratory", Description = "DBMS implementation", Units = 1, Prerequisites = new[] { "CC104L" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC303", SubjectName = "Networking 2", Description = "Advanced networking", Units = 3, Prerequisites = new[] { "CC206" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC303L", SubjectName = "Networking 2 Laboratory", Description = "Routing and switching", Units = 1, Prerequisites = new[] { "CC206L" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC304", SubjectName = "Human-Computer Interaction", Description = "UI/UX design principles", Units = 3, Prerequisites = new[] { "CC203" }, Semester = 1, YearLevel = 3, CourseId = bsitId, IsActive = true },

                        // Year 3 - Semester 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC305", SubjectName = "Software Engineering 2", Description = "Agile and DevOps", Units = 3, Prerequisites = new[] { "CC301" }, Semester = 2, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC306", SubjectName = "Information Assurance and Security", Description = "Cybersecurity fundamentals", Units = 3, Prerequisites = new[] { "CC204" }, Semester = 2, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC307", SubjectName = "Digital Design", Description = "Multimedia production", Units = 3, Prerequisites = new[] { "CC203" }, Semester = 2, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC307L", SubjectName = "Digital Design Laboratory", Description = "Graphics and animation", Units = 1, Prerequisites = new[] { "CC203L" }, Semester = 2, YearLevel = 3, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "TECH1", SubjectName = "Technopreneurship", Description = "IT business ventures", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 3, CourseId = bsitId, IsActive = true },

                        // Year 4 - Semester 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC401", SubjectName = "Capstone Project 1", Description = "Research and proposal", Units = 3, Prerequisites = new[] { "CC305" }, Semester = 1, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC402", SubjectName = "Practicum 1", Description = "Industry immersion", Units = 6, Prerequisites = new[] { "CC305" }, Semester = 1, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC403", SubjectName = "System Integration and Architecture", Description = "Enterprise systems", Units = 3, Prerequisites = new[] { "CC302", "CC303" }, Semester = 1, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC404", SubjectName = "Management Information Systems", Description = "IT governance", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ELECT1", SubjectName = "Elective 1", Description = "Specialized track subject", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsitId, IsActive = true },

                        // Year 4 - Semester 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC405", SubjectName = "Capstone Project 2", Description = "Project implementation", Units = 3, Prerequisites = new[] { "CC401" }, Semester = 2, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC406", SubjectName = "Practicum 2", Description = "Extended industry immersion", Units = 6, Prerequisites = new[] { "CC402" }, Semester = 2, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CC407", SubjectName = "Ethics and Professional Issues", Description = "IT ethics and laws", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 4, CourseId = bsitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ELECT2", SubjectName = "Elective 2", Description = "Advanced specialized subject", Units = 3, Prerequisites = new[] { "ELECT1" }, Semester = 2, YearLevel = 4, CourseId = bsitId, IsActive = true }
                    });
                }

                // BSCS - Bachelor of Science in Computer Science
                var bscsId = courses.FirstOrDefault(c => c.CourseCode == "BSCS")?.Id;
                if (bscsId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS101", SubjectName = "Introduction to Computer Science", Description = "CS fundamentals and problem solving", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS102", SubjectName = "Programming Fundamentals", Description = "Structured programming in C", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS102L", SubjectName = "Programming Fundamentals Laboratory", Description = "C programming labs", Units = 1, Prerequisites = new[] { "CS102" }, Semester = 1, YearLevel = 1, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS103", SubjectName = "Object-Oriented Programming", Description = "OOP with Java", Units = 3, Prerequisites = new[] { "CS102" }, Semester = 2, YearLevel = 1, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS103L", SubjectName = "Object-Oriented Programming Laboratory", Description = "Java programming labs", Units = 1, Prerequisites = new[] { "CS102L" }, Semester = 2, YearLevel = 1, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS201", SubjectName = "Algorithms and Complexity", Description = "Algorithm analysis", Units = 3, Prerequisites = new[] { "CS103", "MATH101" }, Semester = 1, YearLevel = 2, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS202", SubjectName = "Theory of Computation", Description = "Automata and formal languages", Units = 3, Prerequisites = new[] { "CS103", "MATH101" }, Semester = 1, YearLevel = 2, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS203", SubjectName = "Computer Organization", Description = "Computer architecture", Units = 3, Prerequisites = new[] { "CS103" }, Semester = 2, YearLevel = 2, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS301", SubjectName = "Operating Systems", Description = "OS concepts and implementation", Units = 3, Prerequisites = new[] { "CS203" }, Semester = 1, YearLevel = 3, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS302", SubjectName = "Programming Languages", Description = "Language paradigms", Units = 3, Prerequisites = new[] { "CS201" }, Semester = 1, YearLevel = 3, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS303", SubjectName = "Artificial Intelligence", Description = "AI fundamentals", Units = 3, Prerequisites = new[] { "CS201", "STAT101" }, Semester = 2, YearLevel = 3, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS401", SubjectName = "Capstone Project", Description = "CS research project", Units = 6, Prerequisites = new[] { "CS301", "CS302" }, Semester = 1, YearLevel = 4, CourseId = bscsId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CS402", SubjectName = "Software Testing and Quality Assurance", Description = "QA methodologies", Units = 3, Prerequisites = new[] { "CS302" }, Semester = 2, YearLevel = 4, CourseId = bscsId, IsActive = true }
                    });
                }

                // BSCE - Bachelor of Science in Civil Engineering
                var bsceId = courses.FirstOrDefault(c => c.CourseCode == "BSCE")?.Id;
                if (bsceId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE101", SubjectName = "Engineering Drawing and CAD", Description = "Technical drawing and AutoCAD", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE102", SubjectName = "Statics of Rigid Bodies", Description = "Force analysis", Units = 3, Prerequisites = new[] { "MATH101" }, Semester = 1, YearLevel = 1, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE201", SubjectName = "Strength of Materials", Description = "Stress and strain analysis", Units = 3, Prerequisites = new[] { "CE102" }, Semester = 1, YearLevel = 2, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE202", SubjectName = "Structural Analysis", Description = "Beam and frame analysis", Units = 3, Prerequisites = new[] { "CE201" }, Semester = 2, YearLevel = 2, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE301", SubjectName = "Reinforced Concrete Design", Description = "RC structural design", Units = 3, Prerequisites = new[] { "CE202" }, Semester = 1, YearLevel = 3, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE302", SubjectName = "Geotechnical Engineering", Description = "Soil mechanics", Units = 3, Prerequisites = new[] { "CE201" }, Semester = 1, YearLevel = 3, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE303", SubjectName = "Hydraulics", Description = "Fluid mechanics for CE", Units = 3, Prerequisites = new[] { "CE102" }, Semester = 2, YearLevel = 3, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE401", SubjectName = "Steel Design", Description = "Steel structural design", Units = 3, Prerequisites = new[] { "CE202" }, Semester = 1, YearLevel = 4, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE402", SubjectName = "Construction Management", Description = "Project management for CE", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsceId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CE403", SubjectName = "Capstone Project", Description = "CE design project", Units = 6, Prerequisites = new[] { "CE301", "CE302" }, Semester = 2, YearLevel = 4, CourseId = bsceId, IsActive = true }
                    });
                }

                // BSA - Bachelor of Science in Accountancy
                var bsaId = courses.FirstOrDefault(c => c.CourseCode == "BSA")?.Id;
                if (bsaId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG101", SubjectName = "Fundamentals of Accounting", Description = "Basic accounting principles", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG102", SubjectName = "Intermediate Accounting 1", Description = "Financial accounting concepts", Units = 3, Prerequisites = new[] { "ACCTG101" }, Semester = 1, YearLevel = 2, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG103", SubjectName = "Intermediate Accounting 2", Description = "Advanced financial accounting", Units = 3, Prerequisites = new[] { "ACCTG102" }, Semester = 2, YearLevel = 2, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG201", SubjectName = "Advanced Accounting 1", Description = "Partnership and corporation", Units = 3, Prerequisites = new[] { "ACCTG103" }, Semester = 1, YearLevel = 3, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG202", SubjectName = "Advanced Accounting 2", Description = "Consolidated statements", Units = 3, Prerequisites = new[] { "ACCTG201" }, Semester = 2, YearLevel = 3, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG301", SubjectName = "Auditing Theory", Description = "Audit fundamentals", Units = 3, Prerequisites = new[] { "ACCTG202" }, Semester = 1, YearLevel = 4, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ACCTG302", SubjectName = "Auditing Problems", Description = "Practical audit applications", Units = 3, Prerequisites = new[] { "ACCTG301" }, Semester = 2, YearLevel = 4, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "TAX101", SubjectName = "Income Taxation", Description = "Philippine tax system", Units = 3, Prerequisites = new[] { "ACCTG102" }, Semester = 1, YearLevel = 3, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "TAX102", SubjectName = "Transfer and Business Taxation", Description = "Estate, donor's, and VAT", Units = 3, Prerequisites = new[] { "TAX101" }, Semester = 2, YearLevel = 3, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MAS101", SubjectName = "Management Advisory Services", Description = "Business consulting", Units = 3, Prerequisites = new[] { "ACCTG202" }, Semester = 1, YearLevel = 4, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "AFAR1", SubjectName = "Advanced Financial Accounting and Reporting", Description = "Complex financial reporting", Units = 3, Prerequisites = new[] { "ACCTG202" }, Semester = 1, YearLevel = 4, CourseId = bsaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "AFAR2", SubjectName = "Advanced Financial Accounting and Reporting 2", Description = "Government accounting", Units = 3, Prerequisites = new[] { "AFAR1" }, Semester = 2, YearLevel = 4, CourseId = bsaId, IsActive = true }
                    });
                }

                // BSN - Bachelor of Science in Nursing
                var bsnId = courses.FirstOrDefault(c => c.CourseCode == "BSN")?.Id;
                if (bsnId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR101", SubjectName = "Fundamentals of Nursing", Description = "Basic nursing concepts", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR101L", SubjectName = "Fundamentals of Nursing Laboratory", Description = "Nursing skills lab", Units = 2, Prerequisites = new[] { "NUR101" }, Semester = 1, YearLevel = 1, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR102", SubjectName = "Health Assessment", Description = "Patient assessment techniques", Units = 3, Prerequisites = new[] { "NUR101" }, Semester = 2, YearLevel = 1, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR201", SubjectName = "Medical-Surgical Nursing 1", Description = "Adult health nursing", Units = 3, Prerequisites = new[] { "NUR102" }, Semester = 1, YearLevel = 2, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR201L", SubjectName = "Medical-Surgical Nursing 1 Laboratory", Description = "Med-surg clinical lab", Units = 3, Prerequisites = new[] { "NUR101L" }, Semester = 1, YearLevel = 2, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR202", SubjectName = "Medical-Surgical Nursing 2", Description = "Complex adult conditions", Units = 3, Prerequisites = new[] { "NUR201" }, Semester = 2, YearLevel = 2, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR301", SubjectName = "Maternal and Child Nursing", Description = "Obstetric and pediatric care", Units = 3, Prerequisites = new[] { "NUR202" }, Semester = 1, YearLevel = 3, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR301L", SubjectName = "Maternal and Child Nursing Laboratory", Description = "MCN clinical rotation", Units = 3, Prerequisites = new[] { "NUR201L" }, Semester = 1, YearLevel = 3, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR302", SubjectName = "Community Health Nursing", Description = "Public health nursing", Units = 3, Prerequisites = new[] { "NUR202" }, Semester = 2, YearLevel = 3, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR302L", SubjectName = "Community Health Nursing Laboratory", Description = "Community immersion", Units = 3, Prerequisites = new[] { "NUR301L" }, Semester = 2, YearLevel = 3, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR401", SubjectName = "Nursing Leadership and Management", Description = "Nurse administration", Units = 3, Prerequisites = new[] { "NUR302" }, Semester = 1, YearLevel = 4, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR402", SubjectName = "Comprehensive Nursing Practicum", Description = "Full clinical rotation", Units = 9, Prerequisites = new[] { "NUR302L" }, Semester = 2, YearLevel = 4, CourseId = bsnId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "NUR403", SubjectName = "Nursing Jurisprudence and Ethics", Description = "Nursing laws and ethics", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 4, CourseId = bsnId, IsActive = true }
                    });
                }

                // BSCRIM - Bachelor of Science in Criminology
                var bscrimId = courses.FirstOrDefault(c => c.CourseCode == "BSCRIM")?.Id;
                if (bscrimId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM101", SubjectName = "Introduction to Criminology", Description = "Crime and criminal behavior", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM102", SubjectName = "Introduction to Criminal Justice", Description = "CJ system overview", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM201", SubjectName = "Criminal Law 1", Description = "Book 1 of RPC", Units = 3, Prerequisites = new[] { "CRIM102" }, Semester = 1, YearLevel = 2, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM202", SubjectName = "Criminal Law 2", Description = "Book 2 of RPC", Units = 3, Prerequisites = new[] { "CRIM201" }, Semester = 2, YearLevel = 2, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM301", SubjectName = "Criminal Investigation", Description = "Investigation techniques", Units = 3, Prerequisites = new[] { "CRIM202" }, Semester = 1, YearLevel = 3, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM302", SubjectName = "Forensic Photography", Description = "Crime scene photography", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM303", SubjectName = "Police Patrol Operations", Description = "Patrol procedures", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 3, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM401", SubjectName = "Criminalistics", Description = "Forensic science", Units = 3, Prerequisites = new[] { "CRIM301" }, Semester = 1, YearLevel = 4, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM402", SubjectName = "Correctional Administration", Description = "Penology and corrections", Units = 3, Prerequisites = new[] { "CRIM102" }, Semester = 1, YearLevel = 4, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM403", SubjectName = "Criminological Research", Description = "Research methods", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 4, CourseId = bscrimId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CRIM404", SubjectName = "Internship", Description = "Field training", Units = 9, Prerequisites = new[] { "CRIM401" }, Semester = 2, YearLevel = 4, CourseId = bscrimId, IsActive = true }
                    });
                }

                // BSEd - Bachelor of Secondary Education (General subjects for all majors)
                var bsedEngId = courses.FirstOrDefault(c => c.CourseCode == "BSED-ENG")?.Id;
                if (bsedEngId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED101", SubjectName = "The Child and Adolescent Development", Description = "Developmental psychology", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED102", SubjectName = "Principles and Strategies of Teaching", Description = "Teaching methodologies", Units = 3, Prerequisites = new[] { "PROFED101" }, Semester = 2, YearLevel = 1, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ENG101", SubjectName = "Study and Thinking Skills", Description = "Academic English", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ENG201", SubjectName = "Writing in the Discipline", Description = "Academic writing", Units = 3, Prerequisites = new[] { "ENG101" }, Semester = 1, YearLevel = 2, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ENG301", SubjectName = "Teaching English Grammar", Description = "English grammar pedagogy", Units = 3, Prerequisites = new[] { "ENG201" }, Semester = 1, YearLevel = 3, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ENG302", SubjectName = "Teaching Literature", Description = "Literature pedagogy", Units = 3, Prerequisites = new[] { "ENG201" }, Semester = 2, YearLevel = 3, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED301", SubjectName = "Assessment of Learning", Description = "Educational assessment", Units = 3, Prerequisites = new[] { "PROFED102" }, Semester = 1, YearLevel = 3, CourseId = bsedEngId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED401", SubjectName = "Professional Education Internship", Description = "Teaching practicum", Units = 9, Prerequisites = new[] { "PROFED301" }, Semester = 2, YearLevel = 4, CourseId = bsedEngId, IsActive = true }
                    });
                }

                // BSHM - Bachelor of Science in Hospitality Management
                var bshmId = courses.FirstOrDefault(c => c.CourseCode == "BSHM")?.Id;
                if (bshmId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM101", SubjectName = "Introduction to Hospitality Industry", Description = "Hospitality overview", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM102", SubjectName = "Food and Beverage Service", Description = "F&B operations", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM102L", SubjectName = "Food and Beverage Service Laboratory", Description = "F&B practical training", Units = 2, Prerequisites = new[] { "HM102" }, Semester = 1, YearLevel = 1, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM201", SubjectName = "Front Office Operations", Description = "Hotel front desk", Units = 3, Prerequisites = new[] { "HM101" }, Semester = 1, YearLevel = 2, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM201L", SubjectName = "Front Office Operations Laboratory", Description = "FO practical training", Units = 2, Prerequisites = new[] { "HM102L" }, Semester = 1, YearLevel = 2, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM202", SubjectName = "Housekeeping Operations", Description = "Room management", Units = 3, Prerequisites = new[] { "HM101" }, Semester = 2, YearLevel = 2, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM202L", SubjectName = "Housekeeping Operations Laboratory", Description = "HK practical training", Units = 2, Prerequisites = new[] { "HM102L" }, Semester = 2, YearLevel = 2, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM301", SubjectName = "Tourism Planning and Development", Description = "Tourism management", Units = 3, Prerequisites = new[] { "HM201" }, Semester = 1, YearLevel = 3, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM302", SubjectName = "Events Management", Description = "MICE industry", Units = 3, Prerequisites = new[] { "HM201" }, Semester = 2, YearLevel = 3, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM401", SubjectName = "Hospitality Strategic Management", Description = "Strategic planning", Units = 3, Prerequisites = new[] { "HM301" }, Semester = 1, YearLevel = 4, CourseId = bshmId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "HM402", SubjectName = "Practicum", Description = "Industry immersion", Units = 12, Prerequisites = new[] { "HM302" }, Semester = 2, YearLevel = 4, CourseId = bshmId, IsActive = true }
                    });
                }

                // BSMarE - Bachelor of Science in Marine Engineering
                var bsmareId = courses.FirstOrDefault(c => c.CourseCode == "BSMarE")?.Id;
                if (bsmareId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME101", SubjectName = "Introduction to Marine Engineering", Description = "Marine engineering overview", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME102", SubjectName = "Naval Architecture", Description = "Ship design fundamentals", Units = 3, Prerequisites = new[] { "ME101" }, Semester = 1, YearLevel = 1, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME201", SubjectName = "Marine Power Plant 1", Description = "Ship propulsion systems", Units = 3, Prerequisites = new[] { "ME102" }, Semester = 1, YearLevel = 2, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME202", SubjectName = "Marine Power Plant 2", Description = "Auxiliary systems", Units = 3, Prerequisites = new[] { "ME201" }, Semester = 2, YearLevel = 2, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME301", SubjectName = "Marine Electricity", Description = "Ship electrical systems", Units = 3, Prerequisites = new[] { "ME202" }, Semester = 1, YearLevel = 3, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME302", SubjectName = "Marine Control Systems", Description = "Automation on ships", Units = 3, Prerequisites = new[] { "ME301" }, Semester = 2, YearLevel = 3, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME401", SubjectName = "Marine Safety and Environmental Protection", Description = "MARPOL and SOLAS", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME402", SubjectName = "Shipboard Operation and Management", Description = "Engine room management", Units = 3, Prerequisites = new[] { "ME302" }, Semester = 1, YearLevel = 4, CourseId = bsmareId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ME403", SubjectName = "Sea Internship", Description = "Shipboard training", Units = 12, Prerequisites = new[] { "ME402" }, Semester = 2, YearLevel = 4, CourseId = bsmareId, IsActive = true }
                    });
                }

                // BSME - Bachelor of Science in Mechanical Engineering
                var bsmeId = courses.FirstOrDefault(c => c.CourseCode == "BSME")?.Id;
                if (bsmeId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1 - Semester 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH101", SubjectName = "Engineering Drawing and CAD", Description = "Technical drawing and AutoCAD", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH102", SubjectName = "Statics of Rigid Bodies", Description = "Force analysis", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH103", SubjectName = "Manufacturing Processes", Description = "Basic manufacturing techniques", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmeId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH201", SubjectName = "Strength of Materials", Description = "Stress and strain analysis", Units = 3, Prerequisites = new[] { "MECH102" }, Semester = 1, YearLevel = 2, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH202", SubjectName = "Dynamics of Rigid Bodies", Description = "Kinematics and kinetics", Units = 3, Prerequisites = new[] { "MECH102" }, Semester = 2, YearLevel = 2, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH203", SubjectName = "Thermodynamics 1", Description = "Laws of thermodynamics", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 2, CourseId = bsmeId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH301", SubjectName = "Fluid Mechanics", Description = "Fluid behavior and analysis", Units = 3, Prerequisites = new[] { "MECH201" }, Semester = 1, YearLevel = 3, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH302", SubjectName = "Heat Transfer", Description = "Conduction, convection, radiation", Units = 3, Prerequisites = new[] { "MECH203" }, Semester = 1, YearLevel = 3, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH303", SubjectName = "Machine Design 1", Description = "Mechanical element design", Units = 3, Prerequisites = new[] { "MECH201" }, Semester = 2, YearLevel = 3, CourseId = bsmeId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH401", SubjectName = "HVAC Systems", Description = "Heating, ventilation, air conditioning", Units = 3, Prerequisites = new[] { "MECH302" }, Semester = 1, YearLevel = 4, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH402", SubjectName = "Industrial Plant Engineering", Description = "Plant layout and optimization", Units = 3, Prerequisites = new[] { "MECH301" }, Semester = 1, YearLevel = 4, CourseId = bsmeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MECH403", SubjectName = "Capstone Project", Description = "ME design project", Units = 6, Prerequisites = new[] { "MECH303" }, Semester = 2, YearLevel = 4, CourseId = bsmeId, IsActive = true }
                    });
                }

                // BSEE - Bachelor of Science in Electrical Engineering
                var bseeId = courses.FirstOrDefault(c => c.CourseCode == "BSEE")?.Id;
                if (bseeId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE101", SubjectName = "Electrical Circuits 1", Description = "DC circuit analysis", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE101L", SubjectName = "Electrical Circuits 1 Laboratory", Description = "DC circuit experiments", Units = 1, Prerequisites = new[] { "EE101" }, Semester = 1, YearLevel = 1, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE102", SubjectName = "Electrical Circuits 2", Description = "AC circuit analysis", Units = 3, Prerequisites = new[] { "EE101" }, Semester = 2, YearLevel = 1, CourseId = bseeId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE201", SubjectName = "Electromagnetics", Description = "Electric and magnetic fields", Units = 3, Prerequisites = new[] { "EE102" }, Semester = 1, YearLevel = 2, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE202", SubjectName = "Electronics 1", Description = "Diode and transistor circuits", Units = 3, Prerequisites = new[] { "EE102" }, Semester = 1, YearLevel = 2, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE202L", SubjectName = "Electronics 1 Laboratory", Description = "Electronic circuit labs", Units = 1, Prerequisites = new[] { "EE101L" }, Semester = 1, YearLevel = 2, CourseId = bseeId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE301", SubjectName = "Electrical Machines 1", Description = "Transformers and DC machines", Units = 3, Prerequisites = new[] { "EE201" }, Semester = 1, YearLevel = 3, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE301L", SubjectName = "Electrical Machines 1 Laboratory", Description = "Machine testing", Units = 1, Prerequisites = new[] { "EE202L" }, Semester = 1, YearLevel = 3, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE302", SubjectName = "Power Systems Analysis 1", Description = "Transmission line analysis", Units = 3, Prerequisites = new[] { "EE201" }, Semester = 2, YearLevel = 3, CourseId = bseeId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE401", SubjectName = "Power Systems Analysis 2", Description = "Fault analysis and protection", Units = 3, Prerequisites = new[] { "EE302" }, Semester = 1, YearLevel = 4, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE402", SubjectName = "Electrical System Design", Description = "Wiring and distribution design", Units = 3, Prerequisites = new[] { "EE302" }, Semester = 1, YearLevel = 4, CourseId = bseeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "EE403", SubjectName = "Capstone Project", Description = "EE design project", Units = 6, Prerequisites = new[] { "EE301" }, Semester = 2, YearLevel = 4, CourseId = bseeId, IsActive = true }
                    });
                }

                // BSCpE - Bachelor of Science in Computer Engineering
                var bscpeId = courses.FirstOrDefault(c => c.CourseCode == "BSCpE")?.Id;
                if (bscpeId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE101", SubjectName = "Computer Programming 1", Description = "Structured programming in C", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE101L", SubjectName = "Computer Programming 1 Laboratory", Description = "C programming labs", Units = 1, Prerequisites = new[] { "CPE101" }, Semester = 1, YearLevel = 1, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE102", SubjectName = "Digital Logic Design", Description = "Boolean algebra and logic gates", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 1, CourseId = bscpeId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE201", SubjectName = "Data Structures and Algorithms", Description = "Algorithm design and analysis", Units = 3, Prerequisites = new[] { "CPE101" }, Semester = 1, YearLevel = 2, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE202", SubjectName = "Computer Organization and Architecture", Description = "CPU and memory organization", Units = 3, Prerequisites = new[] { "CPE102" }, Semester = 1, YearLevel = 2, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE203", SubjectName = "Object-Oriented Programming", Description = "OOP with C++", Units = 3, Prerequisites = new[] { "CPE101" }, Semester = 2, YearLevel = 2, CourseId = bscpeId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE301", SubjectName = "Microprocessors", Description = "Microprocessor architecture and programming", Units = 3, Prerequisites = new[] { "CPE202" }, Semester = 1, YearLevel = 3, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE301L", SubjectName = "Microprocessors Laboratory", Description = "Assembly programming", Units = 1, Prerequisites = new[] { "CPE202" }, Semester = 1, YearLevel = 3, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE302", SubjectName = "Embedded Systems", Description = "Microcontroller applications", Units = 3, Prerequisites = new[] { "CPE301" }, Semester = 2, YearLevel = 3, CourseId = bscpeId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE401", SubjectName = "VLSI Design", Description = "Very Large Scale Integration", Units = 3, Prerequisites = new[] { "CPE202" }, Semester = 1, YearLevel = 4, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE402", SubjectName = "Computer Networks", Description = "Network protocols and architecture", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bscpeId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "CPE403", SubjectName = "Capstone Project", Description = "CpE design project", Units = 6, Prerequisites = new[] { "CPE302" }, Semester = 2, YearLevel = 4, CourseId = bscpeId, IsActive = true }
                    });
                }

                // BSChE - Bachelor of Science in Chemical Engineering
                var bscheId = courses.FirstOrDefault(c => c.CourseCode == "BSChE")?.Id;
                if (bscheId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE101", SubjectName = "Chemical Engineering Calculations", Description = "Material and energy balances", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE102", SubjectName = "Inorganic Chemistry", Description = "Descriptive inorganic chemistry", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bscheId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE201", SubjectName = "Fluid Mechanics", Description = "Fluid flow principles", Units = 3, Prerequisites = new[] { "ChE101" }, Semester = 1, YearLevel = 2, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE202", SubjectName = "Thermodynamics 1", Description = "First and second laws", Units = 3, Prerequisites = new[] { "ChE101" }, Semester = 1, YearLevel = 2, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE203", SubjectName = "Organic Chemistry", Description = "Organic compounds and reactions", Units = 3, Prerequisites = new[] { "ChE102" }, Semester = 2, YearLevel = 2, CourseId = bscheId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE301", SubjectName = "Heat Transfer", Description = "Conduction, convection, radiation", Units = 3, Prerequisites = new[] { "ChE201" }, Semester = 1, YearLevel = 3, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE302", SubjectName = "Mass Transfer", Description = "Diffusion and separation processes", Units = 3, Prerequisites = new[] { "ChE201" }, Semester = 1, YearLevel = 3, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE303", SubjectName = "Chemical Reaction Engineering", Description = "Reactor design and kinetics", Units = 3, Prerequisites = new[] { "ChE202" }, Semester = 2, YearLevel = 3, CourseId = bscheId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE401", SubjectName = "Chemical Engineering Plant Design", Description = "Process design and economics", Units = 3, Prerequisites = new[] { "ChE303" }, Semester = 1, YearLevel = 4, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE402", SubjectName = "Process Control", Description = "Dynamic systems and control", Units = 3, Prerequisites = new[] { "ChE301" }, Semester = 1, YearLevel = 4, CourseId = bscheId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "ChE403", SubjectName = "Capstone Project", Description = "ChE design project", Units = 6, Prerequisites = new[] { "ChE303" }, Semester = 2, YearLevel = 4, CourseId = bscheId, IsActive = true }
                    });
                }

                // BSIS - Bachelor of Science in Information Systems
                var bsisId = courses.FirstOrDefault(c => c.CourseCode == "BSIS")?.Id;
                if (bsisId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS101", SubjectName = "Introduction to Information Systems", Description = "IS fundamentals", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS102", SubjectName = "Business Process Analysis", Description = "Process modeling", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS103", SubjectName = "Programming Fundamentals", Description = "Introduction to programming", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 1, CourseId = bsisId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS201", SubjectName = "Database Management Systems", Description = "Database design and SQL", Units = 3, Prerequisites = new[] { "IS103" }, Semester = 1, YearLevel = 2, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS202", SubjectName = "Systems Analysis and Design", Description = "SDLC methodologies", Units = 3, Prerequisites = new[] { "IS102" }, Semester = 1, YearLevel = 2, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS203", SubjectName = "Web Development", Description = "Web technologies", Units = 3, Prerequisites = new[] { "IS103" }, Semester = 2, YearLevel = 2, CourseId = bsisId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS301", SubjectName = "Enterprise Architecture", Description = "IT infrastructure planning", Units = 3, Prerequisites = new[] { "IS202" }, Semester = 1, YearLevel = 3, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS302", SubjectName = "Business Intelligence", Description = "Data analytics and reporting", Units = 3, Prerequisites = new[] { "IS201" }, Semester = 1, YearLevel = 3, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS303", SubjectName = "IT Project Management", Description = "Project planning and execution", Units = 3, Prerequisites = new[] { "IS202" }, Semester = 2, YearLevel = 3, CourseId = bsisId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS401", SubjectName = "Information Security", Description = "Security policies and practices", Units = 3, Prerequisites = new[] { "IS301" }, Semester = 1, YearLevel = 4, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS402", SubjectName = "ERP Systems", Description = "Enterprise resource planning", Units = 3, Prerequisites = new[] { "IS301" }, Semester = 1, YearLevel = 4, CourseId = bsisId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IS403", SubjectName = "Capstone Project", Description = "IS integration project", Units = 6, Prerequisites = new[] { "IS303" }, Semester = 2, YearLevel = 4, CourseId = bsisId, IsActive = true }
                    });
                }

                // BSBA - Bachelor of Science in Business Administration
                var bsbaId = courses.FirstOrDefault(c => c.CourseCode == "BSBA")?.Id;
                if (bsbaId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA101", SubjectName = "Introduction to Business", Description = "Business fundamentals", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA102", SubjectName = "Principles of Management", Description = "Management theories", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA103", SubjectName = "Business Mathematics", Description = "Math for business", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 1, CourseId = bsbaId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA201", SubjectName = "Marketing Management", Description = "Marketing strategies", Units = 3, Prerequisites = new[] { "BA101" }, Semester = 1, YearLevel = 2, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA202", SubjectName = "Financial Management", Description = "Corporate finance", Units = 3, Prerequisites = new[] { "BA103" }, Semester = 1, YearLevel = 2, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA203", SubjectName = "Human Resource Management", Description = "HR practices", Units = 3, Prerequisites = new[] { "BA102" }, Semester = 2, YearLevel = 2, CourseId = bsbaId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA301", SubjectName = "Operations Management", Description = "Production and operations", Units = 3, Prerequisites = new[] { "BA201" }, Semester = 1, YearLevel = 3, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA302", SubjectName = "Business Law", Description = "Commercial law", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA303", SubjectName = "Strategic Management", Description = "Business strategy", Units = 3, Prerequisites = new[] { "BA202" }, Semester = 2, YearLevel = 3, CourseId = bsbaId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA401", SubjectName = "Entrepreneurship", Description = "Starting a business", Units = 3, Prerequisites = new[] { "BA303" }, Semester = 1, YearLevel = 4, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA402", SubjectName = "Business Ethics", Description = "Ethical decision making", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsbaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BA403", SubjectName = "Business Practicum", Description = "Industry immersion", Units = 6, Prerequisites = new[] { "BA303" }, Semester = 2, YearLevel = 4, CourseId = bsbaId, IsActive = true }
                    });
                }

                // BSMA - Bachelor of Science in Management Accounting
                var bsmaId = courses.FirstOrDefault(c => c.CourseCode == "BSMA")?.Id;
                if (bsmaId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA101", SubjectName = "Fundamentals of Accounting", Description = "Basic accounting principles", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA102", SubjectName = "Business Economics", Description = "Micro and macroeconomics", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmaId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA201", SubjectName = "Intermediate Accounting", Description = "Financial accounting", Units = 3, Prerequisites = new[] { "MA101" }, Semester = 1, YearLevel = 2, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA202", SubjectName = "Cost Accounting", Description = "Cost analysis and control", Units = 3, Prerequisites = new[] { "MA101" }, Semester = 1, YearLevel = 2, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA203", SubjectName = "Management Accounting", Description = "Decision-making tools", Units = 3, Prerequisites = new[] { "MA202" }, Semester = 2, YearLevel = 2, CourseId = bsmaId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA301", SubjectName = "Advanced Management Accounting", Description = "Strategic cost management", Units = 3, Prerequisites = new[] { "MA203" }, Semester = 1, YearLevel = 3, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA302", SubjectName = "Performance Management", Description = "KPIs and balanced scorecard", Units = 3, Prerequisites = new[] { "MA203" }, Semester = 1, YearLevel = 3, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA303", SubjectName = "Taxation for Management", Description = "Tax planning", Units = 3, Prerequisites = new[] { "MA201" }, Semester = 2, YearLevel = 3, CourseId = bsmaId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA401", SubjectName = "Risk Management", Description = "Enterprise risk assessment", Units = 3, Prerequisites = new[] { "MA301" }, Semester = 1, YearLevel = 4, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA402", SubjectName = "Financial Statement Analysis", Description = "Ratio and trend analysis", Units = 3, Prerequisites = new[] { "MA201" }, Semester = 1, YearLevel = 4, CourseId = bsmaId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MA403", SubjectName = "Management Accounting Practicum", Description = "Industry immersion", Units = 6, Prerequisites = new[] { "MA301" }, Semester = 2, YearLevel = 4, CourseId = bsmaId, IsActive = true }
                    });
                }

                // BEED - Bachelor of Elementary Education
                var beedId = courses.FirstOrDefault(c => c.CourseCode == "BEED")?.Id;
                if (beedId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED101", SubjectName = "The Child and Adolescent Development", Description = "Developmental psychology", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED102", SubjectName = "Principles and Strategies of Teaching", Description = "Teaching methodologies", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED103", SubjectName = "Facilitating Human Learning", Description = "Learning theories", Units = 3, Prerequisites = new[] { "BEED101" }, Semester = 2, YearLevel = 1, CourseId = beedId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED201", SubjectName = "Curriculum Development", Description = "Curriculum design", Units = 3, Prerequisites = new[] { "BEED102" }, Semester = 1, YearLevel = 2, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED202", SubjectName = "Assessment of Learning", Description = "Educational assessment", Units = 3, Prerequisites = new[] { "BEED103" }, Semester = 1, YearLevel = 2, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED203", SubjectName = "Teaching Mathematics in Elementary Grades", Description = "Math pedagogy", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 2, CourseId = beedId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED301", SubjectName = "Teaching Science in Elementary Grades", Description = "Science pedagogy", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED302", SubjectName = "Teaching English in Elementary Grades", Description = "English pedagogy", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED303", SubjectName = "Classroom Management", Description = "Discipline and organization", Units = 3, Prerequisites = new[] { "BEED201" }, Semester = 2, YearLevel = 3, CourseId = beedId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED401", SubjectName = "Special Education", Description = "Inclusive education", Units = 3, Prerequisites = new[] { "BEED101" }, Semester = 1, YearLevel = 4, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED402", SubjectName = "Action Research in Education", Description = "Educational research", Units = 3, Prerequisites = new[] { "BEED202" }, Semester = 1, YearLevel = 4, CourseId = beedId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "BEED403", SubjectName = "Practice Teaching", Description = "Teaching internship", Units = 9, Prerequisites = new[] { "BEED303" }, Semester = 2, YearLevel = 4, CourseId = beedId, IsActive = true }
                    });
                }

                // BSED-MATH - Bachelor of Secondary Education - Mathematics
                var bsedMathId = courses.FirstOrDefault(c => c.CourseCode == "BSED-MATH")?.Id;
                if (bsedMathId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH101", SubjectName = "College Algebra", Description = "Algebraic concepts", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED101", SubjectName = "The Child and Adolescent Development", Description = "Developmental psychology", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedMathId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH201", SubjectName = "Trigonometry", Description = "Trigonometric functions", Units = 3, Prerequisites = new[] { "MATH101" }, Semester = 1, YearLevel = 2, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH202", SubjectName = "Plane and Solid Geometry", Description = "Euclidean geometry", Units = 3, Prerequisites = new[] { "MATH101" }, Semester = 1, YearLevel = 2, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED201", SubjectName = "Principles and Strategies of Teaching", Description = "Teaching methodologies", Units = 3, Prerequisites = new[] { "PROFED101" }, Semester = 2, YearLevel = 2, CourseId = bsedMathId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH301", SubjectName = "Calculus 1", Description = "Differential calculus", Units = 3, Prerequisites = new[] { "MATH201" }, Semester = 1, YearLevel = 3, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH302", SubjectName = "Linear Algebra", Description = "Matrices and vectors", Units = 3, Prerequisites = new[] { "MATH101" }, Semester = 1, YearLevel = 3, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH303", SubjectName = "Teaching Mathematics in Secondary School", Description = "Math pedagogy", Units = 3, Prerequisites = new[] { "PROFED201" }, Semester = 2, YearLevel = 3, CourseId = bsedMathId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH401", SubjectName = "Statistics and Probability", Description = "Statistical methods", Units = 3, Prerequisites = new[] { "MATH301" }, Semester = 1, YearLevel = 4, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MATH402", SubjectName = "Modern Geometry", Description = "Non-Euclidean geometry", Units = 3, Prerequisites = new[] { "MATH202" }, Semester = 1, YearLevel = 4, CourseId = bsedMathId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED401", SubjectName = "Professional Education Internship", Description = "Teaching practicum", Units = 9, Prerequisites = new[] { "MATH303" }, Semester = 2, YearLevel = 4, CourseId = bsedMathId, IsActive = true }
                    });
                }

                // BSED-SCI - Bachelor of Secondary Education - Science
                var bsedSciId = courses.FirstOrDefault(c => c.CourseCode == "BSED-SCI")?.Id;
                if (bsedSciId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI101", SubjectName = "General Biology", Description = "Biological sciences", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI101L", SubjectName = "General Biology Laboratory", Description = "Biology labs", Units = 1, Prerequisites = new[] { "SCI101" }, Semester = 1, YearLevel = 1, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED101", SubjectName = "The Child and Adolescent Development", Description = "Developmental psychology", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsedSciId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI201", SubjectName = "General Chemistry", Description = "Chemical principles", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 2, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI201L", SubjectName = "General Chemistry Laboratory", Description = "Chemistry labs", Units = 1, Prerequisites = new[] { "SCI201" }, Semester = 1, YearLevel = 2, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED201", SubjectName = "Principles and Strategies of Teaching", Description = "Teaching methodologies", Units = 3, Prerequisites = new[] { "PROFED101" }, Semester = 2, YearLevel = 2, CourseId = bsedSciId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI301", SubjectName = "Physics for Teachers", Description = "Physical sciences", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI301L", SubjectName = "Physics Laboratory", Description = "Physics experiments", Units = 1, Prerequisites = new[] { "SCI301" }, Semester = 1, YearLevel = 3, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI302", SubjectName = "Teaching Science in Secondary School", Description = "Science pedagogy", Units = 3, Prerequisites = new[] { "PROFED201" }, Semester = 2, YearLevel = 3, CourseId = bsedSciId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI401", SubjectName = "Environmental Science", Description = "Ecology and conservation", Units = 3, Prerequisites = new[] { "SCI101" }, Semester = 1, YearLevel = 4, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "SCI402", SubjectName = "Earth Science", Description = "Geology and meteorology", Units = 3, Prerequisites = new[] { "SCI301" }, Semester = 1, YearLevel = 4, CourseId = bsedSciId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "PROFED401", SubjectName = "Professional Education Internship", Description = "Teaching practicum", Units = 9, Prerequisites = new[] { "SCI302" }, Semester = 2, YearLevel = 4, CourseId = bsedSciId, IsActive = true }
                    });
                }

                // BSMT - Bachelor of Science in Marine Transportation
                var bsmtId = courses.FirstOrDefault(c => c.CourseCode == "BSMT")?.Id;
                if (bsmtId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT101", SubjectName = "Introduction to Maritime Industry", Description = "Maritime overview", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT102", SubjectName = "Navigation 1", Description = "Basic navigation", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bsmtId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT201", SubjectName = "Navigation 2", Description = "Coastal navigation", Units = 3, Prerequisites = new[] { "MT102" }, Semester = 1, YearLevel = 2, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT202", SubjectName = "Meteorology", Description = "Weather and climate", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 2, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT203", SubjectName = "Ship Stability", Description = "Stability calculations", Units = 3, Prerequisites = new[] { "MT101" }, Semester = 2, YearLevel = 2, CourseId = bsmtId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT301", SubjectName = "Cargo Handling and Stowage", Description = "Cargo operations", Units = 3, Prerequisites = new[] { "MT203" }, Semester = 1, YearLevel = 3, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT302", SubjectName = "Maritime Law", Description = "Admiralty law", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT303", SubjectName = "Celestial Navigation", Description = "Astronomical navigation", Units = 3, Prerequisites = new[] { "MT201" }, Semester = 2, YearLevel = 3, CourseId = bsmtId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT401", SubjectName = "Bridge Resource Management", Description = "Bridge team management", Units = 3, Prerequisites = new[] { "MT303" }, Semester = 1, YearLevel = 4, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT402", SubjectName = "Marine Pollution Prevention", Description = "MARPOL regulations", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bsmtId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "MT403", SubjectName = "Sea Internship", Description = "Shipboard training", Units = 12, Prerequisites = new[] { "MT401" }, Semester = 2, YearLevel = 4, CourseId = bsmtId, IsActive = true }
                    });
                }

                // BIT - Bachelor in Industrial Technology
                var bitId = courses.FirstOrDefault(c => c.CourseCode == "BIT")?.Id;
                if (bitId != null)
                {
                    subjects.AddRange(new List<Subject>
                    {
                        // Year 1
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT101", SubjectName = "Introduction to Industrial Technology", Description = "IT overview", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT102", SubjectName = "Technical Drawing", Description = "Engineering graphics", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 1, CourseId = bitId, IsActive = true },
                        
                        // Year 2
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT201", SubjectName = "Industrial Materials", Description = "Material properties", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 2, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT202", SubjectName = "Manufacturing Processes", Description = "Production techniques", Units = 3, Prerequisites = new[] { "IT101" }, Semester = 1, YearLevel = 2, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT203", SubjectName = "Quality Control", Description = "QA/QC methods", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 2, CourseId = bitId, IsActive = true },
                        
                        // Year 3
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT301", SubjectName = "Industrial Safety", Description = "Occupational safety", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 3, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT302", SubjectName = "Production Planning", Description = "Scheduling and control", Units = 3, Prerequisites = new[] { "IT202" }, Semester = 1, YearLevel = 3, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT303", SubjectName = "Instrumentation and Control", Description = "Industrial automation", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 2, YearLevel = 3, CourseId = bitId, IsActive = true },
                        
                        // Year 4
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT401", SubjectName = "Plant Layout and Design", Description = "Facility planning", Units = 3, Prerequisites = new[] { "IT302" }, Semester = 1, YearLevel = 4, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT402", SubjectName = "Industrial Management", Description = "Factory management", Units = 3, Prerequisites = Array.Empty<string>(), Semester = 1, YearLevel = 4, CourseId = bitId, IsActive = true },
                        new Subject { Id = Guid.NewGuid().ToString(), SubjectCode = "IT403", SubjectName = "Industry Practicum", Description = "Industry immersion", Units = 9, Prerequisites = new[] { "IT303" }, Semester = 2, YearLevel = 4, CourseId = bitId, IsActive = true }
                    });
                }

                // Save all subjects
                foreach (var subject in subjects)
                {
                    _subjectRepository.Add(subject);
                }
            }
        }

        private void InitializeForm()
        {
            this.Text = "Subjects Management";
            this.Dock = DockStyle.Fill;
            
            ApplyModernStyle();
            SetupDataGridView();
            ClearFields();
        }

        private void ApplyModernStyle()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            
            // Panel styling
            pnlForm.BackColor = Color.White;
            pnlForm.Location = new Point(20, 20);
            pnlForm.Size = new Size(350, 580);
            
            // Labels
            foreach (Control ctrl in pnlForm.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 9F);
                    lbl.ForeColor = Color.FromArgb(51, 51, 51);
                }
                else if (ctrl is TextBox txtBox)
                {
                    txtBox.Font = new Font("Segoe UI", 9F);
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cb)
                {
                    cb.Font = new Font("Segoe UI", 9F);
                }
                else if (ctrl is NumericUpDown num)
                {
                    num.Font = new Font("Segoe UI", 9F);
                }
            }
            
            // Buttons
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.FromArgb(51, 51, 51);
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Cursor = Cursors.Hand;
            
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
            
            // Search box
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetupDataGridView()
        {
            dgvSubjects.AutoGenerateColumns = false;
            dgvSubjects.Columns.Clear();
            
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectCode",
                HeaderText = "Code",
                Width = 100
            });
            
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectName",
                HeaderText = "Subject Name",
                Width = 250
            });
            
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Units",
                HeaderText = "Units",
                Width = 60
            });
            
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "YearLevel",
                HeaderText = "Year",
                Width = 50
            });
            
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Semester",
                HeaderText = "Sem",
                Width = 50
            });
            
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.ReadOnly = true;
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.BackgroundColor = Color.White;
            dgvSubjects.GridColor = Color.FromArgb(230, 230, 230);
            dgvSubjects.RowHeadersVisible = false;
            dgvSubjects.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSubjects.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvSubjects.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSubjects.EnableHeadersVisualStyles = false;
            dgvSubjects.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _subjectRepository.GetAll().Where(s => s.IsActive).ToList();
                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = subjects;
                lblRecordCount.Text = $"Total Records: {subjects.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCoursesToComboBox()
        {
            try
            {
                var courses = _courseRepository.GetAll().Where(c => c.IsActive).ToList();
                cmbCourse.DataSource = courses;
                cmbCourse.DisplayMember = "CourseName";
                cmbCourse.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            _currentSubject = null;
            _isEditMode = false;
            
            txtSubjectCode.Clear();
            txtSubjectName.Clear();
            txtDescription.Clear();
            numUnits.Value = 3;
            numSemester.Value = 1;
            numYearLevel.Value = 1;
            txtPrerequisites.Clear();
            
            if (cmbCourse.Items.Count > 0)
                cmbCourse.SelectedIndex = 0;
            
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void PopulateFields(Subject subject)
        {
            _currentSubject = subject;
            _isEditMode = true;
            
            txtSubjectCode.Text = subject.SubjectCode;
            txtSubjectName.Text = subject.SubjectName;
            txtDescription.Text = subject.Description;
            numUnits.Value = subject.Units;
            numSemester.Value = subject.Semester;
            numYearLevel.Value = subject.YearLevel;
            txtPrerequisites.Text = string.Join(", ", subject.Prerequisites);
            
            if (cmbCourse.Items.Count > 0)
            {
                for (int i = 0; i < cmbCourse.Items.Count; i++)
                {
                    var course = (Course)cmbCourse.Items[i];
                    if (course.Id == subject.CourseId)
                    {
                        cmbCourse.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        private Subject GetSubjectFromFields()
        {
            var subject = _currentSubject ?? new Subject();
            
            subject.SubjectCode = txtSubjectCode.Text.Trim().ToUpper();
            subject.SubjectName = txtSubjectName.Text.Trim();
            subject.Description = txtDescription.Text.Trim();
            subject.Units = (int)numUnits.Value;
            subject.Semester = (int)numSemester.Value;
            subject.YearLevel = (int)numYearLevel.Value;
            subject.CourseId = cmbCourse.SelectedValue?.ToString() ?? string.Empty;
            
            var prereqs = txtPrerequisites.Text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim().ToUpper()).ToArray();
            subject.Prerequisites = prereqs;
            
            return subject;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtSubjectCode.Text))
            {
                MessageBox.Show("Subject Code is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectCode.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Subject Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectName.Focus();
                return false;
            }
            
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCourse.Focus();
                return false;
            }
            
            return true;
        }

        private void SaveSubject()
        {
            if (!ValidateFields()) return;
            
            try
            {
                var subject = GetSubjectFromFields();
                
                if (_isEditMode)
                {
                    _subjectRepository.Update(subject);
                    MessageBox.Show("Subject record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _subjectRepository.Add(subject);
                    MessageBox.Show("Subject record saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                LoadSubjects();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving subject: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveSubject();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_currentSubject == null)
            {
                MessageBox.Show("Please select a subject to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show($"Are you sure you want to delete subject '{_currentSubject.SubjectName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    _subjectRepository.Delete(_currentSubject.Id);
                    MessageBox.Show("Subject deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSubjects();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting subject: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvSubjects_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count > 0)
            {
                var selectedSubject = (Subject?)dgvSubjects.SelectedRows[0].DataBoundItem;
                if (selectedSubject != null)
                {
                    PopulateFields(selectedSubject);
                }
            }
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                var searchTerm = txtSearch.Text.Trim();
                var subjects = _subjectRepository.GetAll().Where(s => s.IsActive).ToList();
                
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    subjects = subjects.Where(s => 
                        s.SubjectCode.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        s.SubjectName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        s.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();
                }
                
                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = subjects;
                lblRecordCount.Text = $"Total Records: {subjects.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching subjects: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
