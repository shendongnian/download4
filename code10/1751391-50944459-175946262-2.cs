    using System.Collections.Generic;
    using System.IO;
	public static IEnumerable<Deity> Parse(string filePath) {
		
		var deities = new List<Deity>();
		var currentDeity = new Deity();
		var currentFieldIndex = 0;
		
		foreach (string line in File.ReadLines(filePath)) {
			 
			// empty line might indicate next deity
			if (string.IsNullOrWhiteSpace(line)) {
                // next deity if all fields have been found
				if (currentFieldIndex > 2) {
					deities.Add(currentDeity);
					currentDeity = new Deity();
					currentFieldIndex = 0;
				}
				continue;
			}
			
			switch(currentFieldIndex) {
			    case 0: currentDeity.Name = line; currentFieldIndex++; break;
				case 1: currentDeity.Origin = line.Replace("Origin: ", string.Empty); currentFieldIndex++; break;
				case 2: currentDeity.Description = line; currentFieldIndex++; break;
				default: break;
			}
			
        }
		return deities;
	}
