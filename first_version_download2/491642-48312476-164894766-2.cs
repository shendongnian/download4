    import "Windows.Foundation.idl";
    namespace Component
    {
      runtimeclass Button;
      [version(1.0), uuid(461c8806-8bc2-4622-8eac-b547c39f867e), exclusiveto(Button)]
      interface IButton : IInspectable
      {
        [propget] HRESULT Text([out,retval] HSTRING* value);
      };
      [version(2.0), uuid(d3235252-4081-4cc8-b0e0-8c7691813845), exclusiveto(Button)]
      interface IButton2 : IInspectable
      {
          HRESULT Show();
      };
      [version(1.0), activatable(1.0)]
      runtimeclass Button
      {
          [default] interface IButton;
          interface IButton2;
          interface Windows.Foundation.IStringable;
      }
    }
