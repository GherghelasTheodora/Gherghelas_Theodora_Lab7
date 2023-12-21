namespace Gherghelas_Theodora_Lab7;

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
			})
            .ConfigureEssentials(essentials =>
            {
                essentials.UseMapServiceToken("mJnfgrSAUNpiIwvT9PBn~2SyxAA2iHOPqSDz3iACKKA~AgS7v19L4uCxt_m2f6pfRodXbbKosDsRRFOnpkcpBZRzykodU_ePz2Oxtc3TBDAO");
            });

		return builder.Build();
	}

}