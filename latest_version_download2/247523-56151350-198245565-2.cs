    int i = 1;
    foreach(item in listNeedInsert)
    {
          await RequestInsertToCosmosDB(item);
          if (i % 100 == 0)
          {
              i = 0;
              await Task.Delay(100); // Miliseconds
          }
          i++;
    }
