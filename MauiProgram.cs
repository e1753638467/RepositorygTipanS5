﻿using gTipanS5.Utils;
using Microsoft.Extensions.Logging;

namespace gTipanS5
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            string dbPath = FileAccessHelper.GetlocalfilePath("persona.db3");
            builder.Services.AddSingleton<PersonRepository>(s =>
            ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#endif

            return builder.Build();
        }
    }
}
