        Generatorlist.CallDataGeneratorsNotDone
                     .AddRange(Generatorlist.CallDataGeneratorsDone
                          .Except(Generatorlist.CallDataGeneratorsDone
                              .Where(item => item.SkillNumber && item.CallServer))
                              .ToList())
