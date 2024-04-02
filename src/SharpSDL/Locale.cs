namespace SharpSDL;
public readonly record struct Locale(string Language, string? Country)
{
    public override string ToString() => Country is not null ? $"{Language}-{Country}" : Language;

    public static List<Locale> GetPreferredLocales()
    {
        var locales = new List<Locale>();
        unsafe
        {
            for (var locale = SDL.GetPreferredLocales(); locale->language is not null; ++locale)
                locales.Add(FromNative(locale));
        }
        return locales;
    }

    internal static unsafe Locale FromNative(SDL_Locale* locale) =>
        new(StringHelper.ToUtf16(locale->language), locale->country is not null ? StringHelper.ToUtf16(locale->country) : null);
}
