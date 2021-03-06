    public static bool IsWhiteSpace(char c) { // char.IsWhiteSpace
              
        if (IsLatin1(c)) {
            return (IsWhiteSpaceLatin1(c));
        }
        return CharUnicodeInfo.IsWhiteSpace(c);
    }
    private static bool IsWhiteSpaceLatin1(char c) {
 
        // There are characters which belong to UnicodeCategory.Control but are considered as white spaces.
        // We use code point comparisons for these characters here as a temporary fix.
        
        // U+0009 = <control> HORIZONTAL TAB
        // U+000a = <control> LINE FEED
        // U+000b = <control> VERTICAL TAB
        // U+000c = <contorl> FORM FEED
        // U+000d = <control> CARRIAGE RETURN
        // U+0085 = <control> NEXT LINE
        // U+00a0 = NO-BREAK SPACE
        if ((c == ' ') || (c >= '\x0009' && c <= '\x000d') || c == '\x00a0' || c == '\x0085') {
            return (true);
        }
        return (false);
    }
    internal static bool IsWhiteSpace(char c) // CharUnicodeInfo.IsWhiteSpace
    {
        UnicodeCategory uc = GetUnicodeCategory(c);
        // In Unicode 3.0, U+2028 is the only character which is under the category "LineSeparator".
        // And U+2029 is th eonly character which is under the category "ParagraphSeparator".
        switch (uc) {
            case (UnicodeCategory.SpaceSeparator):
            case (UnicodeCategory.LineSeparator):
            case (UnicodeCategory.ParagraphSeparator):
                return (true);
        }
 
        return (false);
    }
