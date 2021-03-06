            public static bool IsComplete(this MyClass obj)
            {
                  if (obj.Steps == null) return false;
                    var stepCount = obj.Steps.Count;
                    var completedCount = obj.Steps.Count(s => s.IsComplete = true);
                    return stepCount == completedCount;
            }
