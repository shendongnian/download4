    interface ITextReaderOrModifier
    {
      // only a marker
    }
    
    interface IParallelTextReaderOrModifier
    {
      // only a marker
    }
    
    interface ITextReader : ITextReaderOrModifier
    {
      void useText(string text);
    }
    
    interface ITextModifier : ITextReaderOrModifier
    {
      string modifyText(string text);
    }
    
    public class ConcreteImplementationOfTextModifier : ITextReader
    {
      ...
    }
    
    public class ConcreteImplementationOfParallelTextModifier : ITextReader, IParallelTextReaderOrModifier
    {
      ...
    }
