    class Student
    {
        public bool Equals(object other)
        {
            var student = other as Student;
            if(student == null) return false;
            return this.Name == student.Name;
        }
    }
