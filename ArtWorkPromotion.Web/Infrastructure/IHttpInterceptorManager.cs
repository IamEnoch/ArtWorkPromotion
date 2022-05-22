using ArtWorkPromotion.Managers;
using Toolbelt.Blazor;

public interface IHttpInterceptorManager: IManager {
        void RegisterEvent();

        Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

        void DisposeEvent();

}