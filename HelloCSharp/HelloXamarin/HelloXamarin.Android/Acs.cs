namespace HelloXamarin.Droid
{
    public class Acs : IAcs
    {
        public int doIt()
        {
            Com.Ocuvera.Hellojava.Acs acs = new Com.Ocuvera.Hellojava.Acs();
            return acs.DoIt();
        }
    }
}