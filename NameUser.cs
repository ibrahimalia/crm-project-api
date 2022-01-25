namespace Meta.IntroApp
{
    public class NameUser:INameUser
    {
        public int Get(string name)
        {
            if (name == "ibrahim")
            {
                return 1;
            }

            return 0;
        }
    }
}