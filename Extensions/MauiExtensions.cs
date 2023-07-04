using Words.ViewModels;
using Words.Views;

namespace Words.Extensions
{
    public static class MauiExtensions
    {
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<WordsBoardView>();
            mauiAppBuilder.Services.AddSingleton<WordsBoardViewModel>();

            return mauiAppBuilder;
        }
    }
}