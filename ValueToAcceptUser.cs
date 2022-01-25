using Microsoft.AspNetCore.Authorization;

namespace Meta.IntroApp
{
    public class ValueToAcceptUser:IAuthorizationRequirement
    {
        public ValueToAcceptUser(int valueAccept)
        {
            Value = valueAccept;
        }

        public int Value { get; }
    }
}