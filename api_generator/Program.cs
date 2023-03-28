// See https://aka.ms/new-console-template for more information
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.TypeScript;


if (args.Length != 3) throw new ArgumentException("Expecting 4 arguments: URL, generatePath, language");

var url = args[0];
var generatePath = args[1];
var language = args[2];

if (language != "TypeScript" && language != "CSharp") throw new AbandonedMutexException("Invalid language parameter; valid values are TypeScript and CSharp");

var document = await OpenApiDocument.FromUrlAsync(url);
Console.WriteLine($"Generating {generatePath}...");

await System.IO.File.WriteAllTextAsync(generatePath, language switch
{
    "TypeScript" => GenerateTypeScriptClient(document),
    "CSharp" => GenerateCSharpClient(document),
    _ => throw new AbandonedMutexException("Invalid language parameter; valid values are TypeScript and CSharp")

});

static string GenerateTypeScriptClient(OpenApiDocument document)
{
    var settings = new TypeScriptClientGeneratorSettings
    {
        Template = TypeScriptTemplate.Axios,
        TypeScriptGeneratorSettings =
        {
            // TypeStyle = TypeScriptTypeStyle.Interface,
            TypeScriptVersion = 3.5M,
            DateTimeType = TypeScriptDateTimeType.String
        }
    };
    var generator = new TypeScriptClientGenerator(document, settings);
    return generator.GenerateFile();
}
static string GenerateCSharpClient(OpenApiDocument document)
{
    var settings = new CSharpClientGeneratorSettings
    {
        UseBaseUrl = false,
        CSharpGeneratorSettings =
        {
            Namespace = "DemoAPI",
        }
    };
    var generator = new CSharpClientGenerator(document, settings);
    return generator.GenerateFile();
}