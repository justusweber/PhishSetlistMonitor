namespace PhishSetlistMonitor.Infrastructure.HttpClients;

public static class HttpClientStringExtensions
{
    public static string BuildStringFromPattern(this string pattern, Dictionary<string, string> replacements)
    {
        pattern = pattern.ToLower();
        if (replacements == null) return pattern;

        foreach (var parameter in replacements)
        {
            var paramValue = Uri.EscapeDataString(parameter.Value);

            // account for required and optional params
            var paramPlaceHolder = $"{{{parameter.Key}}}".ToLower();
            var paramPlaceHolderOptional = $"{{{parameter.Key}?}}".ToLower();

            pattern = pattern.Replace(paramPlaceHolder, paramValue);
            pattern = pattern.Replace(paramPlaceHolderOptional, paramValue);
        }

        // if we have any optional params that did not have values, remove
        // the optional placeholders from the pattern
        var tokenizedPattern = pattern.Split("/").Where(w => w.EndsWith("?}")).ToList();
        tokenizedPattern.ForEach(optionalParam => pattern = pattern.Replace(optionalParam, ""));

        // optional params may have left some blank spaces in the URL, get rid of them
        return pattern.Replace("//", "/");
    }
}
