namespace CargaBR.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        // TODO: ligar a User.IsPremium retornado pelo IAuthService/API quando a autenticação real estiver implementada.
        public bool IsPremium { get; private set; } = true;

        public bool IsFeatureAccessible(string featureId)
        {
            return featureId switch
            {
                "HomePage" or "SettingPage" => true,
                _ => IsPremium
            };
        }
    }
}
