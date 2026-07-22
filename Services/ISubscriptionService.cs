namespace CargaBR.Services
{
    public interface ISubscriptionService
    {
        bool IsPremium { get; }

        bool IsFeatureAccessible(string featureId);
    }
}
