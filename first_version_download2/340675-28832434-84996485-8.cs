    _courses = new List<Course>();
    _courses.Add(new Course("BSc(Hons) Applied Computing"));
    _courses.Add(new Course("Higher National Diploma (HND) Applied Computing"));
    _courses.Add(new Course("Computer Science Part Time (MSc)"));
    _students = new List<Student>();
    _students.Add(new Student("Andy", "Watt"));
    _students.Add(new Student("Dave", "Newbold"));
    _students.Add(new Student("Daniel", "Brown"));
    lbCourses.ItemsSource = _courses;
    cbStudents.ItemsSource = _students;
