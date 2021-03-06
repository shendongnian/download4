    var res = (from p in db.ProjectTable
              select new Project
              {
                  Id = p.Id,
                  ProjectName = p.ProjectName,
                  TaskList = (from q in db.TaskTable
                             where q.ProjectId = p.Id
                             select new Task
                             {
                                Id = q.TaskId,
                                ProjectId = q.ProjectId,
                                Name = q.TaskName
                             }).ToList()
              }).ToList();
     return res;  //you will get List<Project> with their List<TaskList>
