    private static string IsValidRtf(string text) {
        try {
            new RichTextBox().Rtf = text;
        }
        catch (ArgumentException) {
            return false;
        }
            
        return true;
    }
