    public abstract class Character
    {
        public abstract void Attack(Character t);
    }
    public class A :Character
    {
            public override void Attack(Character t)
            {
             /*instructions for the attacking of a character of type A*/
            }
            public void Attack(B y)
            {
             /*instructions for the attacking of a type B character*/
            }
            public void Attack(C z)
            {
             /*instructions for the attacking of a type C character*/
            }
    }
