                string source = @"
    1096:001:161208:092218:1935:001:H:101:0006:                :00+00000+000000001
    1096:001:161208:092218:1935:002:w:100:0006:                :00:00000:00000000R
    1096:001:161208:092218:1935:003:S:101:0508:   2416100000006+00010010*000000140
    1096:001:161208:092221:1935:004:S:101:0501:   8691397181056+00010010*000000250
    1096:001:161208:092228:1935:005:l:100:0000:LCS SUCCESS     :00000000+000000000
    1096:001:161208:092231:1935:006:T:110:0006:                :01+00001+000002000
    1096:001:161208:092231:1935:007:T:114:0006:                :01+00000-000001610
    1096:001:161208:092231:1935:008:V:111:0006:          %1    :00+00001+000000248
    1096:001:161208:092231:1935:009:V:110:0006:          %1    :00+00001+000000002
    1096:001:161208:092231:1935:010:V:121:0006:          %8    :00+00001+000000130
    1096:001:161208:092231:1935:011:V:120:0006:          %8    :00+00001+000000010
    1096:001:161208:092231:1935:012:w:100:0006:                :00:00000:00000000R
    1096:001:161208:092231:1935:013:q:100:0000:                :000000000000000000
    1096:001:161208:092231:1935:014:F:100:0006:                :00+00002+000000390
    FIS :001:161208:092231:1935:015: :100:0006:TN 13091080     :00+01178+000000390            
                ";
                string[] lines = source.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
                foreach(string line in lines) {
                    string[] values = line.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                    int counter = 1;
                    foreach(string value in values) {
                        Console.Write("Label" + counter + ": " + value + "   ");
                        counter++;
                    }
                    Console.WriteLine("-");
                }
    
                Console.ReadLine();
