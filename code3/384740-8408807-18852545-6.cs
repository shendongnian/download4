    foreach(var name in dirs
          .Select(d => MyMethod(d))) {
       if (name != null) {
         myList.Items.Add(name);
       } else {
         SingSong(); // or ... whatever
       }
    }
