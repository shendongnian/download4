    public class TextBoxX : TextBox
    {
        private X _valor;
        public X Field
        {
            get
            {
                if (_valor == null)
                {
                    _valor = new X();
                }
                return _valor;
            }
        }
    }
